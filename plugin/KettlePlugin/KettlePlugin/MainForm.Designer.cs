namespace KettlePlugin
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            groupBox1 = new GroupBox();
            limit3_Label = new Label();
            rbVolume = new RadioButton();
            limit2_Label = new Label();
            rbHeightBase = new RadioButton();
            limit1_Label = new Label();
            hint3_Label = new Label();
            rbBottomDiameter = new RadioButton();
            label1 = new Label();
            equalLabel = new Label();
            tb_var1 = new TextBox();
            var3_Label = new Label();
            var1_Label = new Label();
            hint1_Label = new Label();
            tb_var3 = new TextBox();
            var2_Label = new Label();
            hint2_Label = new Label();
            tb_var2 = new TextBox();
            groupBox2 = new GroupBox();
            limit5_Label = new Label();
            limit4_Label = new Label();
            lid_Label = new Label();
            color_Label = new Label();
            tb_diameterLid = new TextBox();
            handle_Label = new Label();
            hint4_Label = new Label();
            tb_handleHeight = new TextBox();
            hint5_Label = new Label();
            pbChoiceColor = new PictureBox();
            button_Build = new Button();
            colorDialog1 = new ColorDialog();
            lbErrors = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbChoiceColor).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(limit3_Label);
            groupBox1.Controls.Add(rbVolume);
            groupBox1.Controls.Add(limit2_Label);
            groupBox1.Controls.Add(rbHeightBase);
            groupBox1.Controls.Add(limit1_Label);
            groupBox1.Controls.Add(hint3_Label);
            groupBox1.Controls.Add(rbBottomDiameter);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(equalLabel);
            groupBox1.Controls.Add(tb_var1);
            groupBox1.Controls.Add(var3_Label);
            groupBox1.Controls.Add(var1_Label);
            groupBox1.Controls.Add(hint1_Label);
            groupBox1.Controls.Add(tb_var3);
            groupBox1.Controls.Add(var2_Label);
            groupBox1.Controls.Add(hint2_Label);
            groupBox1.Controls.Add(tb_var2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(513, 205);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Параметры основания";
            // 
            // limit3_Label
            // 
            limit3_Label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            limit3_Label.Font = new Font("Segoe UI", 7F);
            limit3_Label.Location = new Point(342, 146);
            limit3_Label.Margin = new Padding(0);
            limit3_Label.Name = "limit3_Label";
            limit3_Label.Size = new Size(125, 18);
            limit3_Label.TabIndex = 30;
            limit3_Label.Text = "от х до у";
            limit3_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rbVolume
            // 
            rbVolume.AutoSize = true;
            rbVolume.Location = new Point(280, 55);
            rbVolume.Name = "rbVolume";
            rbVolume.Size = new Size(140, 24);
            rbVolume.TabIndex = 3;
            rbVolume.Text = "Объем чайника";
            rbVolume.UseVisualStyleBackColor = true;
            rbVolume.CheckedChanged += Volume_CheckedChanged;
            // 
            // limit2_Label
            // 
            limit2_Label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            limit2_Label.Font = new Font("Segoe UI", 7F);
            limit2_Label.Location = new Point(149, 172);
            limit2_Label.Margin = new Padding(0);
            limit2_Label.Name = "limit2_Label";
            limit2_Label.Size = new Size(125, 15);
            limit2_Label.TabIndex = 29;
            limit2_Label.Text = "от х до у";
            limit2_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rbHeightBase
            // 
            rbHeightBase.AutoSize = true;
            rbHeightBase.Location = new Point(132, 55);
            rbHeightBase.Name = "rbHeightBase";
            rbHeightBase.Size = new Size(142, 24);
            rbHeightBase.TabIndex = 2;
            rbHeightBase.Text = "Высота чайника";
            rbHeightBase.UseVisualStyleBackColor = true;
            rbHeightBase.CheckedChanged += HeightBase_CheckedChanged;
            // 
            // limit1_Label
            // 
            limit1_Label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            limit1_Label.Font = new Font("Segoe UI", 7F);
            limit1_Label.Location = new Point(149, 125);
            limit1_Label.Margin = new Padding(0);
            limit1_Label.Name = "limit1_Label";
            limit1_Label.Size = new Size(125, 17);
            limit1_Label.TabIndex = 28;
            limit1_Label.Text = "от х до у";
            limit1_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hint3_Label
            // 
            hint3_Label.AutoSize = true;
            hint3_Label.Location = new Point(473, 122);
            hint3_Label.Name = "hint3_Label";
            hint3_Label.Size = new Size(31, 20);
            hint3_Label.TabIndex = 39;
            hint3_Label.Text = "мм";
            // 
            // rbBottomDiameter
            // 
            rbBottomDiameter.AutoSize = true;
            rbBottomDiameter.Checked = true;
            rbBottomDiameter.Location = new Point(6, 55);
            rbBottomDiameter.Name = "rbBottomDiameter";
            rbBottomDiameter.Size = new Size(120, 24);
            rbBottomDiameter.TabIndex = 1;
            rbBottomDiameter.TabStop = true;
            rbBottomDiameter.Text = "Диаметр дна";
            rbBottomDiameter.UseVisualStyleBackColor = true;
            rbBottomDiameter.CheckedChanged += BottomDiameter_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 32);
            label1.Name = "label1";
            label1.Size = new Size(236, 20);
            label1.TabIndex = 0;
            label1.Text = "Выберите рассчетный параметр";
            // 
            // equalLabel
            // 
            equalLabel.AutoSize = true;
            equalLabel.Location = new Point(317, 122);
            equalLabel.Name = "equalLabel";
            equalLabel.Size = new Size(19, 20);
            equalLabel.TabIndex = 37;
            equalLabel.Text = "=";
            // 
            // tb_var1
            // 
            tb_var1.Location = new Point(149, 98);
            tb_var1.Name = "tb_var1";
            tb_var1.Size = new Size(125, 27);
            tb_var1.TabIndex = 29;
            tb_var1.KeyPress += TBVar1_KeyPress;
            tb_var1.Leave += TBVar1_Leave;
            // 
            // var3_Label
            // 
            var3_Label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            var3_Label.Location = new Point(342, 96);
            var3_Label.Name = "var3_Label";
            var3_Label.Size = new Size(0, 0);
            var3_Label.TabIndex = 36;
            var3_Label.Text = "var3";
            var3_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // var1_Label
            // 
            var1_Label.AutoSize = true;
            var1_Label.Location = new Point(10, 105);
            var1_Label.Name = "var1_Label";
            var1_Label.Size = new Size(37, 20);
            var1_Label.TabIndex = 28;
            var1_Label.Text = "var1";
            // 
            // hint1_Label
            // 
            hint1_Label.AutoSize = true;
            hint1_Label.Location = new Point(280, 101);
            hint1_Label.Name = "hint1_Label";
            hint1_Label.Size = new Size(31, 20);
            hint1_Label.TabIndex = 31;
            hint1_Label.Text = "мм";
            // 
            // tb_var3
            // 
            tb_var3.Enabled = false;
            tb_var3.Location = new Point(342, 119);
            tb_var3.Name = "tb_var3";
            tb_var3.Size = new Size(125, 27);
            tb_var3.TabIndex = 35;
            tb_var3.TextChanged += TBVar3_TextChanged;
            // 
            // var2_Label
            // 
            var2_Label.AutoSize = true;
            var2_Label.Location = new Point(10, 149);
            var2_Label.Name = "var2_Label";
            var2_Label.Size = new Size(37, 20);
            var2_Label.TabIndex = 32;
            var2_Label.Text = "var2";
            // 
            // hint2_Label
            // 
            hint2_Label.AutoSize = true;
            hint2_Label.Location = new Point(280, 145);
            hint2_Label.Name = "hint2_Label";
            hint2_Label.Size = new Size(31, 20);
            hint2_Label.TabIndex = 34;
            hint2_Label.Text = "мм";
            // 
            // tb_var2
            // 
            tb_var2.Location = new Point(149, 142);
            tb_var2.Name = "tb_var2";
            tb_var2.Size = new Size(125, 27);
            tb_var2.TabIndex = 33;
            tb_var2.KeyPress += TBVar2_KeyPress;
            tb_var2.Leave += TBVar2_Leave;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(limit5_Label);
            groupBox2.Controls.Add(limit4_Label);
            groupBox2.Controls.Add(lid_Label);
            groupBox2.Controls.Add(color_Label);
            groupBox2.Controls.Add(tb_diameterLid);
            groupBox2.Controls.Add(handle_Label);
            groupBox2.Controls.Add(hint4_Label);
            groupBox2.Controls.Add(tb_handleHeight);
            groupBox2.Controls.Add(hint5_Label);
            groupBox2.Controls.Add(pbChoiceColor);
            groupBox2.Location = new Point(12, 223);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(513, 163);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Другие параметры";
            // 
            // limit5_Label
            // 
            limit5_Label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            limit5_Label.Font = new Font("Segoe UI", 7F);
            limit5_Label.Location = new Point(138, 102);
            limit5_Label.Margin = new Padding(0);
            limit5_Label.Name = "limit5_Label";
            limit5_Label.Size = new Size(139, 17);
            limit5_Label.TabIndex = 22;
            limit5_Label.Text = "от 70 до 150, <= высоты";
            limit5_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // limit4_Label
            // 
            limit4_Label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            limit4_Label.Font = new Font("Segoe UI", 7F);
            limit4_Label.Location = new Point(145, 59);
            limit4_Label.Margin = new Padding(0);
            limit4_Label.Name = "limit4_Label";
            limit4_Label.Size = new Size(125, 16);
            limit4_Label.TabIndex = 18;
            limit4_Label.Text = "от 75 до 300, <= дна";
            limit4_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lid_Label
            // 
            lid_Label.AutoSize = true;
            lid_Label.Location = new Point(6, 35);
            lid_Label.Name = "lid_Label";
            lid_Label.Size = new Size(129, 20);
            lid_Label.TabIndex = 25;
            lid_Label.Text = "Диаметр крышки";
            // 
            // color_Label
            // 
            color_Label.AutoSize = true;
            color_Label.Location = new Point(6, 129);
            color_Label.Name = "color_Label";
            color_Label.Size = new Size(104, 20);
            color_Label.TabIndex = 31;
            color_Label.Text = "Цвет чайника";
            // 
            // tb_diameterLid
            // 
            tb_diameterLid.Location = new Point(145, 32);
            tb_diameterLid.Name = "tb_diameterLid";
            tb_diameterLid.Size = new Size(125, 27);
            tb_diameterLid.TabIndex = 26;
            tb_diameterLid.KeyPress += TBDiameterLid_KeyPress;
            tb_diameterLid.Leave += TBDiameterLid_Leave;
            // 
            // handle_Label
            // 
            handle_Label.AutoSize = true;
            handle_Label.Location = new Point(6, 80);
            handle_Label.Name = "handle_Label";
            handle_Label.Size = new Size(103, 20);
            handle_Label.TabIndex = 28;
            handle_Label.Text = "Высота ручки";
            // 
            // hint4_Label
            // 
            hint4_Label.AutoSize = true;
            hint4_Label.Location = new Point(276, 35);
            hint4_Label.Name = "hint4_Label";
            hint4_Label.Size = new Size(31, 20);
            hint4_Label.TabIndex = 27;
            hint4_Label.Text = "мм";
            // 
            // tb_handleHeight
            // 
            tb_handleHeight.Location = new Point(145, 75);
            tb_handleHeight.Name = "tb_handleHeight";
            tb_handleHeight.Size = new Size(125, 27);
            tb_handleHeight.TabIndex = 29;
            tb_handleHeight.KeyPress += TBHandleHeight_KeyPress;
            tb_handleHeight.Leave += TBHandleHeight_Leave;
            // 
            // hint5_Label
            // 
            hint5_Label.AutoSize = true;
            hint5_Label.Location = new Point(276, 78);
            hint5_Label.Name = "hint5_Label";
            hint5_Label.Size = new Size(31, 20);
            hint5_Label.TabIndex = 30;
            hint5_Label.Text = "мм";
            // 
            // pbChoiceColor
            // 
            pbChoiceColor.BackColor = Color.Gray;
            pbChoiceColor.BorderStyle = BorderStyle.FixedSingle;
            pbChoiceColor.Location = new Point(145, 122);
            pbChoiceColor.Name = "pbChoiceColor";
            pbChoiceColor.Size = new Size(27, 27);
            pbChoiceColor.TabIndex = 32;
            pbChoiceColor.TabStop = false;
            pbChoiceColor.Click += pbChoiceColor_Click;
            // 
            // button_Build
            // 
            button_Build.Location = new Point(400, 392);
            button_Build.Name = "button_Build";
            button_Build.Size = new Size(125, 29);
            button_Build.TabIndex = 26;
            button_Build.Text = "Построить";
            button_Build.TextAlign = ContentAlignment.TopCenter;
            button_Build.UseVisualStyleBackColor = true;
            button_Build.Click += Build_Click;
            // 
            // lbErrors
            // 
            lbErrors.BackColor = SystemColors.Window;
            lbErrors.ForeColor = Color.Red;
            lbErrors.FormattingEnabled = true;
            lbErrors.Location = new Point(12, 392);
            lbErrors.Name = "lbErrors";
            lbErrors.Size = new Size(382, 104);
            lbErrors.TabIndex = 27;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 516);
            Controls.Add(lbErrors);
            Controls.Add(button_Build);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Чайник";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbChoiceColor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rbBottomDiameter;
        private Label label1;
        private RadioButton rbVolume;
        private RadioButton rbHeightBase;
        private Label hint3_Label;
        private Label equalLabel;
        private TextBox tb_var1;
        private Label var3_Label;
        private Label var1_Label;
        private Label hint1_Label;
        private TextBox tb_var3;
        private Label var2_Label;
        private Label hint2_Label;
        private TextBox tb_var2;
        private Label limit3_Label;
        private Label limit2_Label;
        private Label limit1_Label;
        private GroupBox groupBox2;
        private Label limit5_Label;
        private Label limit4_Label;
        private Label lid_Label;
        private Label color_Label;
        private TextBox tb_diameterLid;
        private Label handle_Label;
        private Label hint4_Label;
        private TextBox tb_handleHeight;
        private Label hint5_Label;
        private PictureBox pbChoiceColor;
        private Button button_Build;
        private ColorDialog colorDialog1;
        private ListBox lbErrors;
    }
}
