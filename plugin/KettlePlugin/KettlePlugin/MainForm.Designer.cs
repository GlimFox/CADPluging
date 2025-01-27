using System.Drawing;
using System.Windows.Forms;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.limit3Label = new System.Windows.Forms.Label();
            this.rbVolume = new System.Windows.Forms.RadioButton();
            this.limit2Label = new System.Windows.Forms.Label();
            this.rbHeightBase = new System.Windows.Forms.RadioButton();
            this.limit1Label = new System.Windows.Forms.Label();
            this.hint3Label = new System.Windows.Forms.Label();
            this.rbBottomDiameter = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.equalLabel = new System.Windows.Forms.Label();
            this.tbVar1 = new System.Windows.Forms.TextBox();
            this.var3_Label = new System.Windows.Forms.Label();
            this.var1Label = new System.Windows.Forms.Label();
            this.hint1Label = new System.Windows.Forms.Label();
            this.tbVar3 = new System.Windows.Forms.TextBox();
            this.var2Label = new System.Windows.Forms.Label();
            this.hint2Label = new System.Windows.Forms.Label();
            this.tbVar2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.handleFormLabel = new System.Windows.Forms.Label();
            this.cbHandleForm = new System.Windows.Forms.ComboBox();
            this.limit5_Label = new System.Windows.Forms.Label();
            this.limit4_Label = new System.Windows.Forms.Label();
            this.lidLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.tbDiameterLid = new System.Windows.Forms.TextBox();
            this.handleLabel = new System.Windows.Forms.Label();
            this.hint4Label = new System.Windows.Forms.Label();
            this.tbHandleHeight = new System.Windows.Forms.TextBox();
            this.hint5Label = new System.Windows.Forms.Label();
            this.pbChoiceColor = new System.Windows.Forms.PictureBox();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lbErrors = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChoiceColor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.limit3Label);
            this.groupBox1.Controls.Add(this.rbVolume);
            this.groupBox1.Controls.Add(this.limit2Label);
            this.groupBox1.Controls.Add(this.rbHeightBase);
            this.groupBox1.Controls.Add(this.limit1Label);
            this.groupBox1.Controls.Add(this.hint3Label);
            this.groupBox1.Controls.Add(this.rbBottomDiameter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.equalLabel);
            this.groupBox1.Controls.Add(this.tbVar1);
            this.groupBox1.Controls.Add(this.var3_Label);
            this.groupBox1.Controls.Add(this.var1Label);
            this.groupBox1.Controls.Add(this.hint1Label);
            this.groupBox1.Controls.Add(this.tbVar3);
            this.groupBox1.Controls.Add(this.var2Label);
            this.groupBox1.Controls.Add(this.hint2Label);
            this.groupBox1.Controls.Add(this.tbVar2);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(513, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры основания";
            // 
            // limit3Label
            // 
            this.limit3Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.limit3Label.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.limit3Label.Location = new System.Drawing.Point(342, 117);
            this.limit3Label.Margin = new System.Windows.Forms.Padding(0);
            this.limit3Label.Name = "limit3Label";
            this.limit3Label.Size = new System.Drawing.Size(125, 14);
            this.limit3Label.TabIndex = 30;
            this.limit3Label.Text = "от х до у";
            this.limit3Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbVolume
            // 
            this.rbVolume.AutoSize = true;
            this.rbVolume.Location = new System.Drawing.Point(280, 44);
            this.rbVolume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbVolume.Name = "rbVolume";
            this.rbVolume.Size = new System.Drawing.Size(130, 20);
            this.rbVolume.TabIndex = 3;
            this.rbVolume.Text = "Объем чайника";
            this.rbVolume.UseVisualStyleBackColor = true;
            this.rbVolume.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChangedHandler);
            // 
            // limit2Label
            // 
            this.limit2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.limit2Label.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.limit2Label.Location = new System.Drawing.Point(149, 143);
            this.limit2Label.Margin = new System.Windows.Forms.Padding(0);
            this.limit2Label.Name = "limit2Label";
            this.limit2Label.Size = new System.Drawing.Size(125, 14);
            this.limit2Label.TabIndex = 29;
            this.limit2Label.Text = "от х до у";
            this.limit2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbHeightBase
            // 
            this.rbHeightBase.AutoSize = true;
            this.rbHeightBase.Location = new System.Drawing.Point(132, 44);
            this.rbHeightBase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbHeightBase.Name = "rbHeightBase";
            this.rbHeightBase.Size = new System.Drawing.Size(134, 20);
            this.rbHeightBase.TabIndex = 2;
            this.rbHeightBase.Text = "Высота чайника";
            this.rbHeightBase.UseVisualStyleBackColor = true;
            this.rbHeightBase.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChangedHandler);
            // 
            // limit1Label
            // 
            this.limit1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.limit1Label.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.limit1Label.Location = new System.Drawing.Point(149, 100);
            this.limit1Label.Margin = new System.Windows.Forms.Padding(0);
            this.limit1Label.Name = "limit1Label";
            this.limit1Label.Size = new System.Drawing.Size(125, 14);
            this.limit1Label.TabIndex = 28;
            this.limit1Label.Text = "от х до у";
            this.limit1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hint3Label
            // 
            this.hint3Label.AutoSize = true;
            this.hint3Label.Location = new System.Drawing.Point(473, 98);
            this.hint3Label.Name = "hint3Label";
            this.hint3Label.Size = new System.Drawing.Size(25, 16);
            this.hint3Label.TabIndex = 39;
            this.hint3Label.Text = "мм";
            // 
            // rbBottomDiameter
            // 
            this.rbBottomDiameter.AutoSize = true;
            this.rbBottomDiameter.Checked = true;
            this.rbBottomDiameter.Location = new System.Drawing.Point(6, 44);
            this.rbBottomDiameter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbBottomDiameter.Name = "rbBottomDiameter";
            this.rbBottomDiameter.Size = new System.Drawing.Size(112, 20);
            this.rbBottomDiameter.TabIndex = 1;
            this.rbBottomDiameter.TabStop = true;
            this.rbBottomDiameter.Text = "Диаметр дна";
            this.rbBottomDiameter.UseVisualStyleBackColor = true;
            this.rbBottomDiameter.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChangedHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите рассчетный параметр";
            // 
            // equalLabel
            // 
            this.equalLabel.AutoSize = true;
            this.equalLabel.Location = new System.Drawing.Point(317, 98);
            this.equalLabel.Name = "equalLabel";
            this.equalLabel.Size = new System.Drawing.Size(14, 16);
            this.equalLabel.TabIndex = 37;
            this.equalLabel.Text = "=";
            // 
            // tbVar1
            // 
            this.tbVar1.Location = new System.Drawing.Point(145, 78);
            this.tbVar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbVar1.Name = "tbVar1";
            this.tbVar1.Size = new System.Drawing.Size(125, 22);
            this.tbVar1.TabIndex = 29;
            this.tbVar1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPressHandler);
            this.tbVar1.Leave += new System.EventHandler(this.TextBoxLeaveHandler);
            // 
            // var3_Label
            // 
            this.var3_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.var3_Label.Location = new System.Drawing.Point(342, 77);
            this.var3_Label.Name = "var3_Label";
            this.var3_Label.Size = new System.Drawing.Size(0, 0);
            this.var3_Label.TabIndex = 36;
            this.var3_Label.Text = "var3";
            this.var3_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // var1Label
            // 
            this.var1Label.AutoSize = true;
            this.var1Label.Location = new System.Drawing.Point(6, 81);
            this.var1Label.Name = "var1Label";
            this.var1Label.Size = new System.Drawing.Size(33, 16);
            this.var1Label.TabIndex = 28;
            this.var1Label.Text = "var1";
            // 
            // hint1Label
            // 
            this.hint1Label.AutoSize = true;
            this.hint1Label.Location = new System.Drawing.Point(276, 81);
            this.hint1Label.Name = "hint1Label";
            this.hint1Label.Size = new System.Drawing.Size(25, 16);
            this.hint1Label.TabIndex = 31;
            this.hint1Label.Text = "мм";
            // 
            // tbVar3
            // 
            this.tbVar3.Enabled = false;
            this.tbVar3.Location = new System.Drawing.Point(342, 95);
            this.tbVar3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbVar3.Name = "tbVar3";
            this.tbVar3.Size = new System.Drawing.Size(125, 22);
            this.tbVar3.TabIndex = 35;
            this.tbVar3.TextChanged += new System.EventHandler(this.TextBoxLeaveHandler);
            // 
            // var2Label
            // 
            this.var2Label.AutoSize = true;
            this.var2Label.Location = new System.Drawing.Point(6, 123);
            this.var2Label.Name = "var2Label";
            this.var2Label.Size = new System.Drawing.Size(33, 16);
            this.var2Label.TabIndex = 32;
            this.var2Label.Text = "var2";
            // 
            // hint2Label
            // 
            this.hint2Label.AutoSize = true;
            this.hint2Label.Location = new System.Drawing.Point(276, 123);
            this.hint2Label.Name = "hint2Label";
            this.hint2Label.Size = new System.Drawing.Size(25, 16);
            this.hint2Label.TabIndex = 34;
            this.hint2Label.Text = "мм";
            // 
            // tbVar2
            // 
            this.tbVar2.Location = new System.Drawing.Point(145, 121);
            this.tbVar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbVar2.Name = "tbVar2";
            this.tbVar2.Size = new System.Drawing.Size(125, 22);
            this.tbVar2.TabIndex = 33;
            this.tbVar2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPressHandler);
            this.tbVar2.Leave += new System.EventHandler(this.TextBoxLeaveHandler);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.handleFormLabel);
            this.groupBox2.Controls.Add(this.cbHandleForm);
            this.groupBox2.Controls.Add(this.limit5_Label);
            this.groupBox2.Controls.Add(this.limit4_Label);
            this.groupBox2.Controls.Add(this.lidLabel);
            this.groupBox2.Controls.Add(this.colorLabel);
            this.groupBox2.Controls.Add(this.tbDiameterLid);
            this.groupBox2.Controls.Add(this.handleLabel);
            this.groupBox2.Controls.Add(this.hint4Label);
            this.groupBox2.Controls.Add(this.tbHandleHeight);
            this.groupBox2.Controls.Add(this.hint5Label);
            this.groupBox2.Controls.Add(this.pbChoiceColor);
            this.groupBox2.Location = new System.Drawing.Point(12, 178);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(513, 182);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Другие параметры";
            // 
            // handleFormLabel
            // 
            this.handleFormLabel.AutoSize = true;
            this.handleFormLabel.Location = new System.Drawing.Point(6, 112);
            this.handleFormLabel.Name = "handleFormLabel";
            this.handleFormLabel.Size = new System.Drawing.Size(93, 16);
            this.handleFormLabel.TabIndex = 34;
            this.handleFormLabel.Text = "Форма ручки";
            // 
            // cbHandleForm
            // 
            this.cbHandleForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHandleForm.FormattingEnabled = true;
            this.cbHandleForm.Items.AddRange(new object[] {
            "Прямая ручка",
            "Изогнутая ручка (вниз)",
            "Изогнутая ручка (вверх)"});
            this.cbHandleForm.Location = new System.Drawing.Point(145, 109);
            this.cbHandleForm.Name = "cbHandleForm";
            this.cbHandleForm.Size = new System.Drawing.Size(156, 24);
            this.cbHandleForm.TabIndex = 33;
            // 
            // limit5_Label
            // 
            this.limit5_Label.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.limit5_Label.Location = new System.Drawing.Point(137, 88);
            this.limit5_Label.Margin = new System.Windows.Forms.Padding(0);
            this.limit5_Label.Name = "limit5_Label";
            this.limit5_Label.Size = new System.Drawing.Size(139, 19);
            this.limit5_Label.TabIndex = 22;
            this.limit5_Label.Text = "от 70 до 150, <= высоты";
            this.limit5_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // limit4_Label
            // 
            this.limit4_Label.BackColor = System.Drawing.Color.Transparent;
            this.limit4_Label.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.limit4_Label.Location = new System.Drawing.Point(143, 47);
            this.limit4_Label.Margin = new System.Windows.Forms.Padding(0);
            this.limit4_Label.Name = "limit4_Label";
            this.limit4_Label.Size = new System.Drawing.Size(129, 17);
            this.limit4_Label.TabIndex = 18;
            this.limit4_Label.Text = "от 75 до 300, <= дна";
            this.limit4_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lidLabel
            // 
            this.lidLabel.AutoSize = true;
            this.lidLabel.Location = new System.Drawing.Point(6, 27);
            this.lidLabel.Name = "lidLabel";
            this.lidLabel.Size = new System.Drawing.Size(115, 16);
            this.lidLabel.TabIndex = 25;
            this.lidLabel.Text = "Диаметр крышки";
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(6, 143);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(97, 16);
            this.colorLabel.TabIndex = 31;
            this.colorLabel.Text = "Цвет чайника";
            // 
            // tbDiameterLid
            // 
            this.tbDiameterLid.Location = new System.Drawing.Point(145, 25);
            this.tbDiameterLid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDiameterLid.Name = "tbDiameterLid";
            this.tbDiameterLid.Size = new System.Drawing.Size(125, 22);
            this.tbDiameterLid.TabIndex = 26;
            this.tbDiameterLid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPressHandler);
            this.tbDiameterLid.Leave += new System.EventHandler(this.TextBoxLeaveHandler);
            // 
            // handleLabel
            // 
            this.handleLabel.AutoSize = true;
            this.handleLabel.Location = new System.Drawing.Point(6, 70);
            this.handleLabel.Name = "handleLabel";
            this.handleLabel.Size = new System.Drawing.Size(97, 16);
            this.handleLabel.TabIndex = 28;
            this.handleLabel.Text = "Высота ручки";
            // 
            // hint4Label
            // 
            this.hint4Label.AutoSize = true;
            this.hint4Label.Location = new System.Drawing.Point(276, 27);
            this.hint4Label.Name = "hint4Label";
            this.hint4Label.Size = new System.Drawing.Size(25, 16);
            this.hint4Label.TabIndex = 27;
            this.hint4Label.Text = "мм";
            // 
            // tbHandleHeight
            // 
            this.tbHandleHeight.Location = new System.Drawing.Point(145, 66);
            this.tbHandleHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbHandleHeight.Name = "tbHandleHeight";
            this.tbHandleHeight.Size = new System.Drawing.Size(125, 22);
            this.tbHandleHeight.TabIndex = 29;
            this.tbHandleHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPressHandler);
            this.tbHandleHeight.Leave += new System.EventHandler(this.TextBoxLeaveHandler);
            // 
            // hint5Label
            // 
            this.hint5Label.AutoSize = true;
            this.hint5Label.Location = new System.Drawing.Point(276, 69);
            this.hint5Label.Name = "hint5Label";
            this.hint5Label.Size = new System.Drawing.Size(25, 16);
            this.hint5Label.TabIndex = 30;
            this.hint5Label.Text = "мм";
            // 
            // pbChoiceColor
            // 
            this.pbChoiceColor.BackColor = System.Drawing.Color.Gray;
            this.pbChoiceColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbChoiceColor.Location = new System.Drawing.Point(145, 140);
            this.pbChoiceColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbChoiceColor.Name = "pbChoiceColor";
            this.pbChoiceColor.Size = new System.Drawing.Size(22, 22);
            this.pbChoiceColor.TabIndex = 32;
            this.pbChoiceColor.TabStop = false;
            this.pbChoiceColor.Click += new System.EventHandler(this.PBChoiceColor_Click);
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(402, 364);
            this.buttonBuild.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(125, 23);
            this.buttonBuild.TabIndex = 26;
            this.buttonBuild.Text = "Построить";
            this.buttonBuild.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.Build_Click);
            // 
            // lbErrors
            // 
            this.lbErrors.BackColor = System.Drawing.SystemColors.Window;
            this.lbErrors.ForeColor = System.Drawing.Color.Red;
            this.lbErrors.FormattingEnabled = true;
            this.lbErrors.ItemHeight = 16;
            this.lbErrors.Location = new System.Drawing.Point(14, 364);
            this.lbErrors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbErrors.Name = "lbErrors";
            this.lbErrors.Size = new System.Drawing.Size(382, 84);
            this.lbErrors.TabIndex = 27;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(539, 457);
            this.Controls.Add(this.lbErrors);
            this.Controls.Add(this.buttonBuild);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Чайник";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChoiceColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rbBottomDiameter;
        private Label label1;
        private RadioButton rbVolume;
        private RadioButton rbHeightBase;
        private Label hint3Label;
        private Label equalLabel;
        private TextBox tbVar1;
        private Label var3_Label;
        private Label var1Label;
        private Label hint1Label;
        private TextBox tbVar3;
        private Label var2Label;
        private Label hint2Label;
        private TextBox tbVar2;
        private Label limit3Label;
        private Label limit2Label;
        private Label limit1Label;
        private GroupBox groupBox2;
        private Label limit5_Label;
        private Label limit4_Label;
        private Label lidLabel;
        private Label colorLabel;
        private TextBox tbDiameterLid;
        private Label handleLabel;
        private Label hint4Label;
        private TextBox tbHandleHeight;
        private Label hint5Label;
        private PictureBox pbChoiceColor;
        private Button buttonBuild;
        private ColorDialog colorDialog1;
        private ListBox lbErrors;
        private ComboBox cbHandleForm;
        private Label handleFormLabel;
    }
}
