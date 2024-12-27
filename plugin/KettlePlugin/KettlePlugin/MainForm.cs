using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KettlePlugin
{
    public partial class MainForm : Form
    {
        private Builder _builder = new Builder();
        private Parameters _parameters = new Parameters();
        private Color _color;

        /// <summary>
        /// Словарь, содержащий строки ошибок валидации.
        /// </summary>
        private Dictionary<ParameterType, string> _errors = new Dictionary<ParameterType, string>();

        public MainForm()
        {
            InitializeComponent();

            CheckChange(true);

            this._parameters.AllParameters = new Dictionary<ParameterType, Parameter>
            {
                { ParameterType.DiameterBottom, new Parameter { MinValue = 100, MaxValue = 400 } },
                { ParameterType.DiameterLid, new Parameter { MinValue = 75, MaxValue = 300 } },
                { ParameterType.HeightBase, new Parameter { MinValue = 80, MaxValue = 450 } },
                { ParameterType.HeightHandle, new Parameter { MinValue = 70, MaxValue = 150 } },
                { ParameterType.Volume, new Parameter { MinValue = 0.63, MaxValue = 56.55 } }
            };

        }

        /// <summary>
        /// Функция для изменения полей при выборе другой формулы.
        /// </summary>
        /// <param name="isNeedClear"></param>
        private void CheckChange(bool isNeedClear)
        {
            if (isNeedClear)
            {
                tb_var1.Text = null;
                tb_var2.Text = null;
                tb_var3.Text = null;
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

        private void UpdateErrorList()
        {
            lbErrors.Items.Clear();
            foreach (var error in _errors.Values)
            {
                lbErrors.Items.Add(error);
            }
        }

        #region TEXTBOX_KEYPRESS
        private void TBVar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка на цифры и запятую
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TBVar2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка на цифры и запятую
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TBDiameterLid_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка на цифры и запятую
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TBHandleHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка на цифры и запятую
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        #endregion

        private void PBChoiceColor_Click(object sender, EventArgs e)
        {
            colorDialog1 = new ColorDialog();
            colorDialog1.ShowDialog();
            DialogResult = DialogResult.OK;
            pbChoiceColor.BackColor = colorDialog1.Color;
        }

        private void BottomDiameter_CheckedChanged(object sender, EventArgs e)
        {
            CheckChange(true);
        }

        private void HeightBase_CheckedChanged(object sender, EventArgs e)
        {
            CheckChange(true);
        }

        private void Volume_CheckedChanged(object sender, EventArgs e)
        {
            CheckChange(true);
        }

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


        private void ValidateDependentParameters(ParameterType parameterType)
        {
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


        private void TBVar1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (rbBottomDiameter.Checked)
                {
                    ColorChanges(ParameterType.Volume, tb_var1, limit1_Label);
                }
                else if (rbHeightBase.Checked)
                {
                    ColorChanges(ParameterType.DiameterBottom, tb_var1, limit1_Label);
                }
                else if (rbVolume.Checked)
                {
                    ColorChanges(ParameterType.DiameterBottom, tb_var1, limit1_Label);
                }
                CalculateVar3();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBVar2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (rbBottomDiameter.Checked)
                {
                    ColorChanges(ParameterType.HeightBase, tb_var2, limit2_Label);
                }
                else if (rbHeightBase.Checked)
                {
                    ColorChanges(ParameterType.Volume, tb_var2, limit2_Label);
                }
                else if (rbVolume.Checked)
                {
                    ColorChanges(ParameterType.HeightBase, tb_var2, limit2_Label);
                }
                CalculateVar3();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBVar3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbBottomDiameter.Checked)
                {
                    ColorChanges(ParameterType.DiameterBottom, tb_var3, limit3_Label);
                }
                else if (rbHeightBase.Checked)
                {
                    ColorChanges(ParameterType.HeightBase, tb_var3, limit3_Label);
                }
                else if (rbVolume.Checked)
                {
                    ColorChanges(ParameterType.Volume, tb_var3, limit3_Label);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void TBDiameterLid_Leave(object sender, EventArgs e)
        {
            try
            {
                ColorChanges(ParameterType.DiameterLid, tb_diameterLid, limit4_Label);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBHandleHeight_Leave(object sender, EventArgs e)
        {
            try
            {
                ColorChanges(ParameterType.HeightHandle, tb_handleHeight, limit5_Label);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                this._builder.Build(this._parameters, color);
            }
        }
    }
}
