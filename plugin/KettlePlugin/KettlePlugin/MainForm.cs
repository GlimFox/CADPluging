using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using StressTests;

namespace KettlePlugin
{
    public partial class MainForm : Form
    {
        #region Features (Свойства)

        /// <summary>
        /// Построитель для создания модели.
        /// </summary>
        private Builder _builder = new Builder();

        /// <summary>
        /// Параметры модели.
        /// </summary>
        private Parameters _parameters = new Parameters();

        /// <summary>
        /// Словарь, содержащий строки ошибок валидации.
        /// </summary>
        private Dictionary<ParameterType, string> _errors = new Dictionary<ParameterType, string>();

        #endregion

        /// <summary>
        /// Конструктор главной формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Выполняем проверку выбранной формулы
            CheckChange(true);

            // Настройки для выполнения стресс-тестирования
            //StressTester stress = new StressTester();
            //stress.StressTesting();

            // Начальное значение формы ручки - прямая ручка
            cb_handleForm.SelectedIndex = 0;
        }

        #region SupportFunctions (Вспомогательные функции)

        /// <summary>
        /// Функция для изменения полей при выборе другой формулы.
        /// </summary>
        /// <param name="isNeedClear"></param>
        private void CheckChange(bool isNeedClear)
        {
            if (isNeedClear)
            {
                tb_var1.Text = null;
                tb_var1.BackColor = Color.White;
                tb_var2.Text = null;
                tb_var2.BackColor = Color.White;
                tb_var3.Text = null;
                tb_var3.BackColor = Color.White;

                UpdateErrorList();
            }


            if (rbBottomDiameter.Checked)
            {
                var1_Label.Text = "Объём чайника";
                limit1_Label.Text = "от 0,63 до 56,55";
                hint1_Label.Text = "л";

                var2_Label.Text = "Высота чайника";
                limit2_Label.Text = "от 80 до 450";
                hint2_Label.Text = "мм";

                var3_Label.Text = "Диаметр дна";
                limit3_Label.Text = "от 100 до 400";
                hint3_Label.Text = "мм";
                tb_var1.Tag = "LidDiameter";
            }
            else if (rbHeightBase.Checked)
            {
                var1_Label.Text = "Диаметр дна";
                limit1_Label.Text = "от 100 до 400";
                hint1_Label.Text = "мм";

                var2_Label.Text = "Объём чайника";
                limit2_Label.Text = "от 0,63 до 56,55";
                hint2_Label.Text = "л";

                var3_Label.Text = "Высота чайника";
                limit3_Label.Text = "от 80 до 450";
                hint3_Label.Text = "мм";
            }
            else if (rbVolume.Checked)
            {
                var1_Label.Text = "Диаметр дна";
                limit1_Label.Text = "от 100 до 400";
                hint1_Label.Text = "мм";

                var2_Label.Text = "Высота чайника";
                limit2_Label.Text = "от 80 до 450";
                hint2_Label.Text = "мм";

                var3_Label.Text = "Объём чайника";
                limit3_Label.Text = "от 0,63 до 56,55";
                hint3_Label.Text = "л";
            }
        }

        /// <summary>
        /// Рассчитывает значение для Var3 на основе Var1 и Var2.
        /// </summary>
        private void CalculateVar3()
        {
            if (tb_var1.Text != null && tb_var2.Text != null)
            {
                double var1, var2, var3 = 0;
                if (double.TryParse(tb_var1.Text, out var1) && double.TryParse(tb_var2.Text, out var2))
                {

                    if (rbBottomDiameter.Checked) var3 = _parameters.Calculations(1, var1, var2);
                    if (rbHeightBase.Checked) var3 = _parameters.Calculations(2, var1, var2);
                    if (rbVolume.Checked) var3 = _parameters.Calculations(3, var1, var2);

                    // Записываем рассчитанное значение в текстбокс
                    tb_var3.Text = var3.ToString();
                }
            }
        }

        /// <summary>
        /// Обновляет список ошибок на форме.
        /// </summary>
        private void UpdateErrorList()
        {
            lbErrors.Items.Clear();
            foreach (var error in _errors.Values)
            {
                lbErrors.Items.Add(error);
            }
        }

        /// <summary>
        /// Обработчик выбора цвета чайника.
        /// </summary>
        private void PBChoiceColor_Click(object sender, EventArgs e)
        {
            colorDialog1 = new ColorDialog();
            colorDialog1.ShowDialog();
            DialogResult = DialogResult.OK;
            pbChoiceColor.BackColor = colorDialog1.Color;
        }

        #endregion

        #region ValidationFunctions (Функции валидации)

        /// <summary>
        /// Изменяет цвет текста и подсказок в зависимости от валидации параметров.
        /// </summary>
        /// <param name="parameterType">Тип параметра.</param>
        /// <param name="textBox">Текстовое поле.</param>
        /// <param name="limitLabel">Метка ограничения.</param>
        private void ColorChanges(ParameterType parameterType, TextBox textBox, Label limitLabel)
        {
            try
            {
                // Пробуем установить значение параметра
                double value = double.Parse(textBox.Text);
                _parameters.AllParameters[parameterType].Value = value;

                // Удаляем ошибку, если значение корректно
                if (_errors.ContainsKey(parameterType))
                    _errors.Remove(parameterType);

                // Сбрасываем цвет для успешного результата
                textBox.BackColor = Color.LightGreen;
                limitLabel.ForeColor = Color.Black;

                // Проверка зависимостей
                ValidateDependentParameters(parameterType);
            }
            catch (ArgumentException ex)
            {
                // Сохраняем ошибку и подсвечиваем поле
                _errors[parameterType] = ex.Message;
                textBox.BackColor = Color.FromArgb(217, 84, 77);
                limitLabel.ForeColor = Color.FromArgb(217, 84, 77);
            }
            catch (FormatException)
            {
                // Обработка ошибок формата
                string errorMessage = "Введите корректное числовое значение.";
                _errors[parameterType] = errorMessage;
                textBox.BackColor = Color.FromArgb(217, 84, 77);
                limitLabel.ForeColor = Color.FromArgb(217, 84, 77);
            }

            UpdateErrorList();
        }

        /// <summary>
        /// Валидирует параметры, зависящие друг от друга.
        /// </summary>
        /// <param name="parameterType">Тип параметра.</param>
        private void ValidateDependentParameters(ParameterType parameterType)
        {
            // Проверка, что диаметр дна > диаметра крышки
            if (parameterType == ParameterType.DiameterLid &&
                _parameters.AllParameters.TryGetValue(ParameterType.DiameterBottom, out var bottomDiameter))
            {
                if (_parameters.AllParameters[ParameterType.DiameterLid].Value > bottomDiameter.Value)
                {
                    string errorMessage = "Диаметр крышки не может превышать диаметр дна.";
                    _errors[ParameterType.DiameterLid] = errorMessage;
                    tb_diameterLid.BackColor = Color.FromArgb(217, 84, 77);
                    limit4_Label.ForeColor = Color.FromArgb(217, 84, 77);
                }
                else
                {
                    _errors.Remove(ParameterType.DiameterLid);
                }
            }

            // Проверка, что высота чанйика > высоты ручки
            if (parameterType == ParameterType.HeightHandle &&
                _parameters.AllParameters.TryGetValue(ParameterType.HeightBase, out var heightBase))
            {
                if (_parameters.AllParameters[ParameterType.HeightHandle].Value > heightBase.Value)
                {
                    string errorMessage = "Высота ручки не может превышать высоту чайника.";
                    _errors[ParameterType.HeightHandle] = errorMessage;
                    tb_handleHeight.BackColor = Color.FromArgb(217, 84, 77);
                    limit5_Label.ForeColor = Color.FromArgb(217, 84, 77);
                }
                else
                {
                    _errors.Remove(ParameterType.HeightHandle);
                }
            }

            UpdateErrorList();
        }

        #endregion

        #region Handlers (Обработчики событий)

        /// <summary>
        /// Единый обработчик ввода в текстовое поле.
        /// </summary>
        /// <param name="sender">Источник события (текстовое поле).</param>
        /// <param name="e">Аргументы события нажатия клавиши.</param>
        private void TextBoxKeyPressHandler(object sender, KeyPressEventArgs e)
        {
            // Проверка на цифры и запятую
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Единый обработчик изменения выбора радиокнопки.
        /// </summary>
        /// <param name="sender">Источник события (радиокнопка).</param>
        /// <param name="e">Аргументы события изменения выбора.</param>
        private void RadioButtonCheckedChangedHandler(object sender, EventArgs e)
        {
            CheckChange(true);
        }

        /// <summary>
        /// Единный обработчик выхода из текстового поля.
        /// </summary>
        /// <param name="sender">Источник события (текстовое поле).</param>
        /// <param name="e">Аргументы события выхода из текстового поля.</param>
        private void TextBoxLeaveHandler(object sender, EventArgs e)
        {
            try
            {
                if (sender is TextBox textBox)
                {
                    switch (textBox.Name)
                    {
                        case "tb_var1":
                            if (rbBottomDiameter.Checked)
                            {
                                ColorChanges(ParameterType.Volume, textBox, limit1_Label);
                            }
                            else if (rbHeightBase.Checked || rbVolume.Checked)
                            {
                                ColorChanges(ParameterType.DiameterBottom, textBox, limit1_Label);
                            }
                            break;

                        case "tb_var2":
                            if (rbBottomDiameter.Checked)
                            {
                                ColorChanges(ParameterType.HeightBase, textBox, limit2_Label);
                            }
                            else if (rbHeightBase.Checked)
                            {
                                ColorChanges(ParameterType.Volume, textBox, limit2_Label);
                            }
                            else if (rbVolume.Checked)
                            {
                                ColorChanges(ParameterType.HeightBase, textBox, limit2_Label);
                            }
                            break;

                        case "tb_var3":
                            if (rbBottomDiameter.Checked)
                            {
                                ColorChanges(ParameterType.DiameterBottom, textBox, limit3_Label);
                            }
                            else if (rbHeightBase.Checked)
                            {
                                ColorChanges(ParameterType.HeightBase, textBox, limit3_Label);
                            }
                            else if (rbVolume.Checked)
                            {
                                ColorChanges(ParameterType.Volume, textBox, limit3_Label);
                            }
                            break;

                        case "tb_diameterLid":
                            ColorChanges(ParameterType.DiameterLid, textBox, limit4_Label);
                            break;

                        case "tb_handleHeight":
                            ColorChanges(ParameterType.HeightHandle, textBox, limit5_Label);
                            break;
                    }

                    // Пересчет Var3, если это поле нужное для расчета
                    if (textBox.Name == "tb_var1" || textBox.Name == "tb_var2")
                    {
                        CalculateVar3();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion

        /// <summary>
        /// Обработчик события нажатия кнопки построения модели.
        /// </summary>
        /// <param name="sender">Источник события (кнопка).</param>
        /// <param name="e">Аргументы события нажатия на кнопку.</param>
        private void Build_Click(object sender, EventArgs e)
        {
            if (this.tb_var1.BackColor == Color.FromArgb(217, 84, 77) ||
                this.tb_var2.BackColor == Color.FromArgb(217, 84, 77) ||
                this.tb_var3.BackColor == Color.FromArgb(217, 84, 77) ||
                this.tb_diameterLid.BackColor == Color.FromArgb(217, 84, 77) ||
                this.tb_handleHeight.BackColor == Color.FromArgb(217, 84, 77) ||
                this.tb_var1.BackColor == SystemColors.Window ||
                this.tb_var2.BackColor == SystemColors.Window ||
                this.tb_var3.BackColor == SystemColors.Window ||
                this.tb_diameterLid.BackColor == SystemColors.Window ||
                this.tb_handleHeight.BackColor == SystemColors.Window)
            {
                MessageBox.Show("Невозможно построить модель. Проверьте параметры на ошибки и заполните все поля.",
                        "Ошибка построения",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else
            {
                int color = pbChoiceColor.BackColor.ToArgb();
                this._builder.Build(this._parameters, color, cb_handleForm.SelectedIndex);
            }
        }
    }
}