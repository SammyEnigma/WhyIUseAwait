namespace WhyIUseAwait {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGoWithout = new System.Windows.Forms.Button();
            this.buttonGoWith = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSeconds = new System.Windows.Forms.TextBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calculate without using await";
            // 
            // buttonGoWithout
            // 
            this.buttonGoWithout.AutoSize = true;
            this.buttonGoWithout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGoWithout.Location = new System.Drawing.Point(22, 37);
            this.buttonGoWithout.Name = "buttonGoWithout";
            this.buttonGoWithout.Size = new System.Drawing.Size(57, 35);
            this.buttonGoWithout.TabIndex = 2;
            this.buttonGoWithout.Text = "Run";
            this.buttonGoWithout.UseVisualStyleBackColor = true;
            this.buttonGoWithout.Click += new System.EventHandler(this.ButtonGoWithout_Click);
            // 
            // buttonGoWith
            // 
            this.buttonGoWith.AutoSize = true;
            this.buttonGoWith.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGoWith.Location = new System.Drawing.Point(503, 37);
            this.buttonGoWith.Name = "buttonGoWith";
            this.buttonGoWith.Size = new System.Drawing.Size(57, 35);
            this.buttonGoWith.TabIndex = 6;
            this.buttonGoWith.Text = "Run";
            this.buttonGoWith.UseVisualStyleBackColor = true;
            this.buttonGoWith.Click += new System.EventHandler(this.ButtonGoWith_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(503, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Calculate using await";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(862, 33);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 23);
            this.toolStripProgressBar1.Step = 1;
            // 
            // textBoxMain
            // 
            this.textBoxMain.Location = new System.Drawing.Point(22, 78);
            this.textBoxMain.Multiline = true;
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.Size = new System.Drawing.Size(716, 200);
            this.textBoxMain.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Run for this many seconds:";
            // 
            // textBoxSeconds
            // 
            this.textBoxSeconds.Location = new System.Drawing.Point(433, 340);
            this.textBoxSeconds.Name = "textBoxSeconds";
            this.textBoxSeconds.Size = new System.Drawing.Size(100, 29);
            this.textBoxSeconds.TabIndex = 11;
            this.textBoxSeconds.Text = "10";
            this.textBoxSeconds.WordWrap = false;
            // 
            // buttonDone
            // 
            this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDone.AutoSize = true;
            this.buttonDone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonDone.Location = new System.Drawing.Point(777, 420);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(73, 35);
            this.buttonDone.TabIndex = 12;
            this.buttonDone.Text = "Close";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.ButtonDone_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonDone;
            this.ClientSize = new System.Drawing.Size(862, 491);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.textBoxSeconds);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonGoWith);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonGoWithout);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Why I Use Await";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGoWithout;
        private System.Windows.Forms.Button buttonGoWith;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TextBox textBoxMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSeconds;
        private System.Windows.Forms.Button buttonDone;
    }
}

