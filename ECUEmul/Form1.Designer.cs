namespace ECUEmulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxCommands = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDisc = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBaud = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxEcu = new System.Windows.Forms.ComboBox();
            this.buttonConnecting = new System.Windows.Forms.Button();
            this.comboBoxCom = new System.Windows.Forms.ComboBox();
            this.listBoxMessages = new System.Windows.Forms.ListBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxQ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxModes = new System.Windows.Forms.GroupBox();
            this.rbListening = new System.Windows.Forms.RadioButton();
            this.rbTeaching = new System.Windows.Forms.RadioButton();
            this.rbEmulation = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBoxModes.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxCommands
            // 
            this.listBoxCommands.FormattingEnabled = true;
            this.listBoxCommands.Location = new System.Drawing.Point(200, 9);
            this.listBoxCommands.Name = "listBoxCommands";
            this.listBoxCommands.Size = new System.Drawing.Size(120, 264);
            this.listBoxCommands.TabIndex = 2;
            this.listBoxCommands.SelectedIndexChanged += new System.EventHandler(this.listBoxCommands_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDisc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxBaud);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxEcu);
            this.groupBox1.Controls.Add(this.buttonConnecting);
            this.groupBox1.Controls.Add(this.comboBoxCom);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 264);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // buttonDisc
            // 
            this.buttonDisc.Enabled = false;
            this.buttonDisc.Location = new System.Drawing.Point(101, 74);
            this.buttonDisc.Name = "buttonDisc";
            this.buttonDisc.Size = new System.Drawing.Size(75, 23);
            this.buttonDisc.TabIndex = 7;
            this.buttonDisc.Text = "Disconnect";
            this.buttonDisc.UseVisualStyleBackColor = true;
            this.buttonDisc.Click += new System.EventHandler(this.buttonDisc_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Speed";
            // 
            // textBoxBaud
            // 
            this.textBoxBaud.Location = new System.Drawing.Point(6, 48);
            this.textBoxBaud.Name = "textBoxBaud";
            this.textBoxBaud.Size = new System.Drawing.Size(89, 20);
            this.textBoxBaud.TabIndex = 4;
            this.textBoxBaud.Text = "10400";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "ECU";
            // 
            // comboBoxEcu
            // 
            this.comboBoxEcu.FormattingEnabled = true;
            this.comboBoxEcu.Location = new System.Drawing.Point(6, 211);
            this.comboBoxEcu.Name = "comboBoxEcu";
            this.comboBoxEcu.Size = new System.Drawing.Size(136, 21);
            this.comboBoxEcu.TabIndex = 2;
            this.comboBoxEcu.SelectedIndexChanged += new System.EventHandler(this.comboBoxEcu_SelectedIndexChanged);
            // 
            // buttonConnecting
            // 
            this.buttonConnecting.Location = new System.Drawing.Point(6, 74);
            this.buttonConnecting.Name = "buttonConnecting";
            this.buttonConnecting.Size = new System.Drawing.Size(75, 23);
            this.buttonConnecting.TabIndex = 1;
            this.buttonConnecting.Text = "Connect";
            this.buttonConnecting.UseVisualStyleBackColor = true;
            this.buttonConnecting.Click += new System.EventHandler(this.buttonConnecting_Click);
            // 
            // comboBoxCom
            // 
            this.comboBoxCom.FormattingEnabled = true;
            this.comboBoxCom.Location = new System.Drawing.Point(6, 19);
            this.comboBoxCom.Name = "comboBoxCom";
            this.comboBoxCom.Size = new System.Drawing.Size(89, 21);
            this.comboBoxCom.TabIndex = 0;
            // 
            // listBoxMessages
            // 
            this.listBoxMessages.FormattingEnabled = true;
            this.listBoxMessages.HorizontalScrollbar = true;
            this.listBoxMessages.Location = new System.Drawing.Point(326, 61);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.Size = new System.Drawing.Size(483, 212);
            this.listBoxMessages.TabIndex = 4;
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(62, 304);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(747, 20);
            this.textBoxA.TabIndex = 5;
            // 
            // textBoxQ
            // 
            this.textBoxQ.Enabled = false;
            this.textBoxQ.Location = new System.Drawing.Point(62, 279);
            this.textBoxQ.Name = "textBoxQ";
            this.textBoxQ.Size = new System.Drawing.Size(747, 20);
            this.textBoxQ.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Запрос:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ответ:";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(768, 35);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(41, 23);
            this.buttonClear.TabIndex = 9;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // groupBoxModes
            // 
            this.groupBoxModes.Controls.Add(this.rbEmulation);
            this.groupBoxModes.Controls.Add(this.rbTeaching);
            this.groupBoxModes.Controls.Add(this.rbListening);
            this.groupBoxModes.Location = new System.Drawing.Point(326, 9);
            this.groupBoxModes.Name = "groupBoxModes";
            this.groupBoxModes.Size = new System.Drawing.Size(232, 46);
            this.groupBoxModes.TabIndex = 10;
            this.groupBoxModes.TabStop = false;
            this.groupBoxModes.Text = "Modes";
            // 
            // rbListening
            // 
            this.rbListening.AutoSize = true;
            this.rbListening.Checked = true;
            this.rbListening.Location = new System.Drawing.Point(6, 19);
            this.rbListening.Name = "rbListening";
            this.rbListening.Size = new System.Drawing.Size(67, 17);
            this.rbListening.TabIndex = 0;
            this.rbListening.TabStop = true;
            this.rbListening.Text = "Listening";
            this.rbListening.UseVisualStyleBackColor = true;
            // 
            // rbTeaching
            // 
            this.rbTeaching.AutoSize = true;
            this.rbTeaching.Location = new System.Drawing.Point(79, 19);
            this.rbTeaching.Name = "rbTeaching";
            this.rbTeaching.Size = new System.Drawing.Size(70, 17);
            this.rbTeaching.TabIndex = 1;
            this.rbTeaching.TabStop = true;
            this.rbTeaching.Text = "Teaching";
            this.rbTeaching.UseVisualStyleBackColor = true;
            // 
            // rbEmulation
            // 
            this.rbEmulation.AutoSize = true;
            this.rbEmulation.Location = new System.Drawing.Point(155, 19);
            this.rbEmulation.Name = "rbEmulation";
            this.rbEmulation.Size = new System.Drawing.Size(71, 17);
            this.rbEmulation.TabIndex = 2;
            this.rbEmulation.TabStop = true;
            this.rbEmulation.Text = "Emulation";
            this.rbEmulation.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 334);
            this.Controls.Add(this.groupBoxModes);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxQ);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.listBoxMessages);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxCommands);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxModes.ResumeLayout(false);
            this.groupBoxModes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCommands;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonConnecting;
        private System.Windows.Forms.ComboBox comboBoxCom;
        private System.Windows.Forms.ListBox listBoxMessages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxEcu;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBaud;
        private System.Windows.Forms.Button buttonDisc;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxModes;
        private System.Windows.Forms.RadioButton rbEmulation;
        private System.Windows.Forms.RadioButton rbTeaching;
        private System.Windows.Forms.RadioButton rbListening;

    }
}

