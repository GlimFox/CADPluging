using System.Drawing;

namespace KettlePlugin
{
    public partial class MainForm : Form
    {
        private Builder _builder = new Builder();
        private Parameters _parameters = new Parameters();
        private Color _color;

        /// <summary>
        /// �������, ���������� ������ ������ ���������.
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
        /// ������� ��� ��������� ����� ��� ������ ������ �������.
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
                var1_Label.Text = "����� �������";
                limit1_Label.Text = "�� 0,63 �� 56,55";
                hint1_Label.Text = "�";

                var2_Label.Text = "������ �������";
                limit2_Label.Text = "�� 80 �� 450";
                hint2_Label.Text = "��";

                var3_Label.Text = "������� ���";
                limit3_Label.Text = "�� 100 �� 400";
                hint3_Label.Text = "��";
                tb_var1.Tag = "LidDiameter";
            }
            else if (rbHeightBase.Checked)
            {
                var1_Label.Text = "������� ���";
                limit1_Label.Text = "�� 100 �� 400";
                hint1_Label.Text = "��";

                var2_Label.Text = "����� �������";
                limit2_Label.Text = "�� 0,63 �� 56,55";
                hint2_Label.Text = "�";

                var3_Label.Text = "������ �������";
                limit3_Label.Text = "�� 80 �� 450";
                hint3_Label.Text = "��";
            }
            else if (rbVolume.Checked)
            {
                var1_Label.Text = "������� ���";
                limit1_Label.Text = "�� 100 �� 400";
                hint1_Label.Text = "��";

                var2_Label.Text = "������ �������";
                limit2_Label.Text = "�� 80 �� 450";
                hint2_Label.Text = "��";

                var3_Label.Text = "����� �������";
                limit3_Label.Text = "�� 0,63 �� 56,55";
                hint3_Label.Text = "�";
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
            // �������� �� ����� � �������
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TBVar2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // �������� �� ����� � �������
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TBDiameterLid_KeyPress(object sender, KeyPressEventArgs e)
        {
            // �������� �� ����� � �������
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TBHandleHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            // �������� �� ����� � �������
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        #endregion

        private void pbChoiceColor_Click(object sender, EventArgs e)
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
                // ������� ���������� �������� ���������
                double value = double.Parse(textBox.Text);
                _parameters.AllParameters[parameterType].Value = value;

                // ������� ������, ���� �������� ���������
                if (_errors.ContainsKey(parameterType))
                    _errors.Remove(parameterType);

                // ���������� ���� ��� ��������� ����������
                textBox.BackColor = Color.LightGreen;
                limitLabel.ForeColor = Color.Black;

                // �������� ������������
                ValidateDependentParameters(parameterType);
            }
            catch (ArgumentException ex)
            {
                // ��������� ������ � ������������ ����
                _errors[parameterType] = ex.Message;
                textBox.BackColor = Color.FromArgb(217, 84, 77);
                limitLabel.ForeColor = Color.FromArgb(217, 84, 77);
            }
            catch (FormatException)
            {
                // ��������� ������ �������
                string errorMessage = "������� ���������� �������� ��������.";
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
                    string errorMessage = "������� ������ �� ����� ��������� ������� ���.";
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
                    string errorMessage = "������ ����� �� ����� ��������� ������ �������.";
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
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    // ���������� ������������ �������� � ���������
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
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("���������� ��������� ������. ��������� ��������� �� ������ � ��������� ��� ����.",
                        "������ ����������",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else
            {
                int color = _color.ToArgb();
                this._builder.Build(this._parameters, color);
            }
        }

    }
}
