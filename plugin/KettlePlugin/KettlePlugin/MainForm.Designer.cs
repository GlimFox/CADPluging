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
            this.limit3_Label = new System.Windows.Forms.Label();
            this.rbVolume = new System.Windows.Forms.RadioButton();
            this.limit2_Label = new System.Windows.Forms.Label();
            this.rbHeightBase = new System.Windows.Forms.RadioButton();
            this.limit1_Label = new System.Windows.Forms.Label();
            this.hint3_Label = new System.Windows.Forms.Label();
            this.rbBottomDiameter = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.equalLabel = new System.Windows.Forms.Label();
            this.tb_var1 = new System.Windows.Forms.TextBox();
            this.var3_Label = new System.Windows.Forms.Label();
            this.var1_Label = new System.Windows.Forms.Label();
            this.hint1_Label = new System.Windows.Forms.Label();
            this.tb_var3 = new System.Windows.Forms.TextBox();
            this.var2_Label = new System.Windows.Forms.Label();
            this.hint2_Label = new System.Windows.Forms.Label();
            this.tb_var2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.limit5_Label = new System.Windows.Forms.Label();
            this.limit4_Label = new System.Windows.Forms.Label();
            this.lid_Label = new System.Windows.Forms.Label();
            this.color_Label = new System.Windows.Forms.Label();
            this.tb_diameterLid = new System.Windows.Forms.TextBox();
            this.handle_Label = new System.Windows.Forms.Label();
            this.hint4_Label = new System.Windows.Forms.Label();
            this.tb_handleHeight = new System.Windows.Forms.TextBox();
            this.hint5_Label = new System.Windows.Forms.Label();
            this.pbChoiceColor = new System.Windows.Forms.PictureBox();
            this.button_Build = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lbErrors = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChoiceColor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.limit3_Label);
            this.groupBox1.Controls.Add(this.rbVolume);
            this.groupBox1.Controls.Add(this.limit2_Label);
            this.groupBox1.Controls.Add(this.rbHeightBase);
            this.groupBox1.Controls.Add(this.limit1_Label);
            this.groupBox1.Controls.Add(this.hint3_Label);
            this.groupBox1.Controls.Add(this.rbBottomDiameter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.equalLabel);
            this.groupBox1.Controls.Add(this.tb_var1);
            this.groupBox1.Controls.Add(this.var3_Label);
            this.groupBox1.Controls.Add(this.var1_Label);
            this.groupBox1.Controls.Add(this.hint1_Label);
            this.groupBox1.Controls.Add(this.tb_var3);
            this.groupBox1.Controls.Add(this.var2_Label);
            this.groupBox1.Controls.Add(this.hint2_Label);
            this.groupBox1.Controls.Add(this.tb_var2);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(513, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры основания";
            // 
            // limit3_Label
            // 
            this.limit3_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.limit3_Label.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.limit3_Label.Location = new System.Drawing.Point(342, 117);
            this.limit3_Label.Margin = new System.Windows.Forms.Padding(0);
            this.limit3_Label.Name = "limit3_Label";
            this.limit3_Label.Size = new System.Drawing.Size(125, 14);
            this.limit3_Label.TabIndex = 30;
            this.limit3_Label.Text = "от х до у";
            this.limit3_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.rbVolume.CheckedChanged += new System.EventHandler(this.Volume_CheckedChanged);
            // 
            // limit2_Label
            // 
            this.limit2_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.limit2_Label.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.limit2_Label.Location = new System.Drawing.Point(149, 138);
            this.limit2_Label.Margin = new System.Windows.Forms.Padding(0);
            this.limit2_Label.Name = "limit2_Label";
            this.limit2_Label.Size = new System.Drawing.Size(125, 14);
            this.limit2_Label.TabIndex = 29;
            this.limit2_Label.Text = "от х до у";
            this.limit2_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.rbHeightBase.CheckedChanged += new System.EventHandler(this.HeightBase_CheckedChanged);
            // 
            // limit1_Label
            // 
            this.limit1_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.limit1_Label.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.limit1_Label.Location = new System.Drawing.Point(149, 100);
            this.limit1_Label.Margin = new System.Windows.Forms.Padding(0);
            this.limit1_Label.Name = "limit1_Label";
            this.limit1_Label.Size = new System.Drawing.Size(125, 14);
            this.limit1_Label.TabIndex = 28;
            this.limit1_Label.Text = "от х до у";
            this.limit1_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hint3_Label
            // 
            this.hint3_Label.AutoSize = true;
            this.hint3_Label.Location = new System.Drawing.Point(473, 98);
            this.hint3_Label.Name = "hint3_Label";
            this.hint3_Label.Size = new System.Drawing.Size(25, 16);
            this.hint3_Label.TabIndex = 39;
            this.hint3_Label.Text = "мм";
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
            this.rbBottomDiameter.CheckedChanged += new System.EventHandler(this.BottomDiameter_CheckedChanged);
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
            // tb_var1
            // 
            this.tb_var1.Location = new System.Drawing.Point(149, 78);
            this.tb_var1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_var1.Name = "tb_var1";
            this.tb_var1.Size = new System.Drawing.Size(125, 22);
            this.tb_var1.TabIndex = 29;
            this.tb_var1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBVar1_KeyPress);
            this.tb_var1.Leave += new System.EventHandler(this.TBVar1_Leave);
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
            // var1_Label
            // 
            this.var1_Label.AutoSize = true;
            this.var1_Label.Location = new System.Drawing.Point(10, 84);
            this.var1_Label.Name = "var1_Label";
            this.var1_Label.Size = new System.Drawing.Size(33, 16);
            this.var1_Label.TabIndex = 28;
            this.var1_Label.Text = "var1";
            // 
            // hint1_Label
            // 
            this.hint1_Label.AutoSize = true;
            this.hint1_Label.Location = new System.Drawing.Point(280, 81);
            this.hint1_Label.Name = "hint1_Label";
            this.hint1_Label.Size = new System.Drawing.Size(25, 16);
            this.hint1_Label.TabIndex = 31;
            this.hint1_Label.Text = "мм";
            // 
            // tb_var3
            // 
            this.tb_var3.Enabled = false;
            this.tb_var3.Location = new System.Drawing.Point(342, 95);
            this.tb_var3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_var3.Name = "tb_var3";
            this.tb_var3.Size = new System.Drawing.Size(125, 22);
            this.tb_var3.TabIndex = 35;
            this.tb_var3.TextChanged += new System.EventHandler(this.TBVar3_TextChanged);
            // 
            // var2_Label
            // 
            this.var2_Label.AutoSize = true;
            this.var2_Label.Location = new System.Drawing.Point(10, 119);
            this.var2_Label.Name = "var2_Label";
            this.var2_Label.Size = new System.Drawing.Size(33, 16);
            this.var2_Label.TabIndex = 32;
            this.var2_Label.Text = "var2";
            // 
            // hint2_Label
            // 
            this.hint2_Label.AutoSize = true;
            this.hint2_Label.Location = new System.Drawing.Point(280, 116);
            this.hint2_Label.Name = "hint2_Label";
            this.hint2_Label.Size = new System.Drawing.Size(25, 16);
            this.hint2_Label.TabIndex = 34;
            this.hint2_Label.Text = "мм";
            // 
            // tb_var2
            // 
            this.tb_var2.Location = new System.Drawing.Point(149, 114);
            this.tb_var2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_var2.Name = "tb_var2";
            this.tb_var2.Size = new System.Drawing.Size(125, 22);
            this.tb_var2.TabIndex = 33;
            this.tb_var2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBVar2_KeyPress);
            this.tb_var2.Leave += new System.EventHandler(this.TBVar2_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.limit5_Label);
            this.groupBox2.Controls.Add(this.limit4_Label);
            this.groupBox2.Controls.Add(this.lid_Label);
            this.groupBox2.Controls.Add(this.color_Label);
            this.groupBox2.Controls.Add(this.tb_diameterLid);
            this.groupBox2.Controls.Add(this.handle_Label);
            this.groupBox2.Controls.Add(this.hint4_Label);
            this.groupBox2.Controls.Add(this.tb_handleHeight);
            this.groupBox2.Controls.Add(this.hint5_Label);
            this.groupBox2.Controls.Add(this.pbChoiceColor);
            this.groupBox2.Location = new System.Drawing.Point(12, 178);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(513, 130);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Другие параметры";
            // 
            // limit5_Label
            // 
            this.limit5_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.limit5_Label.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.limit5_Label.Location = new System.Drawing.Point(138, 82);
            this.limit5_Label.Margin = new System.Windows.Forms.Padding(0);
            this.limit5_Label.Name = "limit5_Label";
            this.limit5_Label.Size = new System.Drawing.Size(139, 14);
            this.limit5_Label.TabIndex = 22;
            this.limit5_Label.Text = "от 70 до 150, <= высоты";
            this.limit5_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // limit4_Label
            // 
            this.limit4_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.limit4_Label.BackColor = System.Drawing.Color.Transparent;
            this.limit4_Label.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.limit4_Label.Location = new System.Drawing.Point(143, 47);
            this.limit4_Label.Margin = new System.Windows.Forms.Padding(0);
            this.limit4_Label.Name = "limit4_Label";
            this.limit4_Label.Size = new System.Drawing.Size(129, 12);
            this.limit4_Label.TabIndex = 18;
            this.limit4_Label.Text = "от 75 до 300, <= дна";
            this.limit4_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lid_Label
            // 
            this.lid_Label.AutoSize = true;
            this.lid_Label.Location = new System.Drawing.Point(6, 27);
            this.lid_Label.Name = "lid_Label";
            this.lid_Label.Size = new System.Drawing.Size(115, 16);
            this.lid_Label.TabIndex = 25;
            this.lid_Label.Text = "Диаметр крышки";
            // 
            // color_Label
            // 
            this.color_Label.AutoSize = true;
            this.color_Label.Location = new System.Drawing.Point(6, 103);
            this.color_Label.Name = "color_Label";
            this.color_Label.Size = new System.Drawing.Size(97, 16);
            this.color_Label.TabIndex = 31;
            this.color_Label.Text = "Цвет чайника";
            // 
            // tb_diameterLid
            // 
            this.tb_diameterLid.Location = new System.Drawing.Point(145, 25);
            this.tb_diameterLid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_diameterLid.Name = "tb_diameterLid";
            this.tb_diameterLid.Size = new System.Drawing.Size(125, 22);
            this.tb_diameterLid.TabIndex = 26;
            this.tb_diameterLid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBDiameterLid_KeyPress);
            this.tb_diameterLid.Leave += new System.EventHandler(this.TBDiameterLid_Leave);
            // 
            // handle_Label
            // 
            this.handle_Label.AutoSize = true;
            this.handle_Label.Location = new System.Drawing.Point(6, 64);
            this.handle_Label.Name = "handle_Label";
            this.handle_Label.Size = new System.Drawing.Size(97, 16);
            this.handle_Label.TabIndex = 28;
            this.handle_Label.Text = "Высота ручки";
            // 
            // hint4_Label
            // 
            this.hint4_Label.AutoSize = true;
            this.hint4_Label.Location = new System.Drawing.Point(276, 28);
            this.hint4_Label.Name = "hint4_Label";
            this.hint4_Label.Size = new System.Drawing.Size(25, 16);
            this.hint4_Label.TabIndex = 27;
            this.hint4_Label.Text = "мм";
            // 
            // tb_handleHeight
            // 
            this.tb_handleHeight.Location = new System.Drawing.Point(145, 60);
            this.tb_handleHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_handleHeight.Name = "tb_handleHeight";
            this.tb_handleHeight.Size = new System.Drawing.Size(125, 22);
            this.tb_handleHeight.TabIndex = 29;
            this.tb_handleHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBHandleHeight_KeyPress);
            this.tb_handleHeight.Leave += new System.EventHandler(this.TBHandleHeight_Leave);
            // 
            // hint5_Label
            // 
            this.hint5_Label.AutoSize = true;
            this.hint5_Label.Location = new System.Drawing.Point(276, 62);
            this.hint5_Label.Name = "hint5_Label";
            this.hint5_Label.Size = new System.Drawing.Size(25, 16);
            this.hint5_Label.TabIndex = 30;
            this.hint5_Label.Text = "мм";
            // 
            // pbChoiceColor
            // 
            this.pbChoiceColor.BackColor = System.Drawing.Color.Gray;
            this.pbChoiceColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbChoiceColor.Location = new System.Drawing.Point(145, 98);
            this.pbChoiceColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbChoiceColor.Name = "pbChoiceColor";
            this.pbChoiceColor.Size = new System.Drawing.Size(27, 22);
            this.pbChoiceColor.TabIndex = 32;
            this.pbChoiceColor.TabStop = false;
            this.pbChoiceColor.Click += new System.EventHandler(this.PBChoiceColor_Click);
            // 
            // button_Build
            // 
            this.button_Build.Location = new System.Drawing.Point(400, 314);
            this.button_Build.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Build.Name = "button_Build";
            this.button_Build.Size = new System.Drawing.Size(125, 23);
            this.button_Build.TabIndex = 26;
            this.button_Build.Text = "Построить";
            this.button_Build.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Build.UseVisualStyleBackColor = true;
            this.button_Build.Click += new System.EventHandler(this.Build_Click);
            // 
            // lbErrors
            // 
            this.lbErrors.BackColor = System.Drawing.SystemColors.Window;
            this.lbErrors.ForeColor = System.Drawing.Color.Red;
            this.lbErrors.FormattingEnabled = true;
            this.lbErrors.ItemHeight = 16;
            this.lbErrors.Location = new System.Drawing.Point(12, 314);
            this.lbErrors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbErrors.Name = "lbErrors";
            this.lbErrors.Size = new System.Drawing.Size(382, 84);
            this.lbErrors.TabIndex = 27;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 413);
            this.Controls.Add(this.lbErrors);
            this.Controls.Add(this.button_Build);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
