using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;
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
            cbHandleForm.SelectedIndex = 0;
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
                tbVar1.Text = null;
                tbVar1.BackColor = Color.White;
                tbVar2.Text = null;
                tbVar2.BackColor = Color.White;
                tbVar3.Text = null;
                tbVar3.BackColor = Color.White;

                UpdateErrorList();
            }


            if (rbBottomDiameter.Checked)
            {
                var1Label.Text = "Объём чайника";
                limit1Label.Text = "от 0,63 до 56,55";
                hint1Label.Text = "л";

                var2Label.Text = "Высота чайника";
                limit2Label.Text = "от 80 до 450";
                hint2Label.Text = "мм";

                var3_Label.Text = "Диаметр дна";
                limit3Label.Text = "от 100 до 400";
                hint3Label.Text = "мм";
                tbVar1.Tag = "LidDiameter";
            }
            else if (rbHeightBase.Checked)
            {
                var1Label.Text = "Диаметр дна";
                limit1Label.Text = "от 100 до 400";
                hint1Label.Text = "мм";

                var2Label.Text = "Объём чайника";
                limit2Label.Text = "от 0,63 до 56,55";
                hint2Label.Text = "л";

                var3_Label.Text = "Высота чайника";
                limit3Label.Text = "от 80 до 450";
                hint3Label.Text = "мм";
            }
            else if (rbVolume.Checked)
            {
                var1Label.Text = "Диаметр дна";
                limit1Label.Text = "от 100 до 400";
                hint1Label.Text = "мм";

                var2Label.Text = "Высота чайника";
                limit2Label.Text = "от 80 до 450";
                hint2Label.Text = "мм";

                var3_Label.Text = "Объём чайника";
                limit3Label.Text = "от 0,63 до 56,55";
                hint3Label.Text = "л";
            }
        }

        /// <summary>
        /// Рассчитывает значение для Var3 на основе Var1 и Var2.
        /// </summary>
        private void CalculateVar3()
        {
            if (tbVar1.Text != null && tbVar2.Text != null)
            {
                double var1, var2, var3 = 0;
                if (double.TryParse(tbVar1.Text, out var1) && double.TryParse(tbVar2.Text, out var2))
                {

                    if (rbBottomDiameter.Checked) var3 = _parameters.Calculations(1, var1, var2);
                    if (rbHeightBase.Checked) var3 = _parameters.Calculations(2, var1, var2);
                    if (rbVolume.Checked) var3 = _parameters.Calculations(3, var1, var2);

                    // Записываем рассчитанное значение в текстбокс
                    tbVar3.Text = var3.ToString();
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
                    tbDiameterLid.BackColor = Color.FromArgb(217, 84, 77);
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
                    tbHandleHeight.BackColor = Color.FromArgb(217, 84, 77);
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
            // Допустимый ввод: цифры '0123456789' и одна запятая ','
            if (sender is TextBox textBox &&
                (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back ||
                (e.KeyChar == ',' && textBox.Text.Contains(","))))
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
                        case "tbVar1":
                            if (rbBottomDiameter.Checked)
                            {
                                ColorChanges(ParameterType.Volume, textBox, limit1Label);
                            }
                            else if (rbHeightBase.Checked || rbVolume.Checked)
                            {
                                ColorChanges(ParameterType.DiameterBottom, textBox, limit1Label);
                            }
                            CalculateVar3();
                            break;

                        case "tbVar2":
                            if (rbBottomDiameter.Checked)
                            {
                                ColorChanges(ParameterType.HeightBase, textBox, limit2Label);
                            }
                            else if (rbHeightBase.Checked)
                            {
                                ColorChanges(ParameterType.Volume, textBox, limit2Label);
                            }
                            else if (rbVolume.Checked)
                            {
                                ColorChanges(ParameterType.HeightBase, textBox, limit2Label);
                            }
                            CalculateVar3();
                            break;

                        case "tbVar3":
                            if (rbBottomDiameter.Checked)
                            {
                                ColorChanges(ParameterType.DiameterBottom, textBox, limit3Label);
                            }
                            else if (rbHeightBase.Checked)
                            {
                                ColorChanges(ParameterType.HeightBase, textBox, limit3Label);
                            }
                            else if (rbVolume.Checked)
                            {
                                ColorChanges(ParameterType.Volume, textBox, limit3Label);
                            }
                            ColorChanges(ParameterType.DiameterLid, tbDiameterLid, limit4_Label);
                            ColorChanges(ParameterType.HeightHandle, tbHandleHeight, limit5_Label);
                            break;

                        case "tbDiameterLid":
                            ColorChanges(ParameterType.DiameterLid, textBox, limit4_Label);
                            break;

                        case "tbHandleHeight":
                            ColorChanges(ParameterType.HeightHandle, textBox, limit5_Label);
                            break;
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
            if (this.tbVar1.BackColor == Color.FromArgb(217, 84, 77) ||
                this.tbVar2.BackColor == Color.FromArgb(217, 84, 77) ||
                this.tbVar3.BackColor == Color.FromArgb(217, 84, 77) ||
                this.tbDiameterLid.BackColor == Color.FromArgb(217, 84, 77) ||
                this.tbHandleHeight.BackColor == Color.FromArgb(217, 84, 77) ||
                this.tbVar1.BackColor == SystemColors.Window ||
                this.tbVar2.BackColor == SystemColors.Window ||
                this.tbVar3.BackColor == SystemColors.Window ||
                this.tbDiameterLid.BackColor == SystemColors.Window ||
                this.tbHandleHeight.BackColor == SystemColors.Window)
            {
                MessageBox.Show("Невозможно построить модель. " +
                    "Проверьте параметры на ошибки и заполните все поля.", "Ошибка построения",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int color = pbChoiceColor.BackColor.ToArgb();
                this._builder.Build(this._parameters, color, cbHandleForm.SelectedIndex);
            }
        }
    }
}