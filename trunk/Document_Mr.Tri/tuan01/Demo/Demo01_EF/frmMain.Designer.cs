namespace Demo01_EF
{
    partial class frmMain
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
            this.btnDemo01 = new System.Windows.Forms.Button();
            this.btnDemo02 = new System.Windows.Forms.Button();
            this.btnDemo03 = new System.Windows.Forms.Button();
            this.btnDemo04 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDemo01
            // 
            this.btnDemo01.Location = new System.Drawing.Point(12, 12);
            this.btnDemo01.Name = "btnDemo01";
            this.btnDemo01.Size = new System.Drawing.Size(139, 45);
            this.btnDemo01.TabIndex = 0;
            this.btnDemo01.Text = "Demo 01";
            this.btnDemo01.UseVisualStyleBackColor = true;
            this.btnDemo01.Click += new System.EventHandler(this.btnDemo01_Click);
            // 
            // btnDemo02
            // 
            this.btnDemo02.Location = new System.Drawing.Point(12, 63);
            this.btnDemo02.Name = "btnDemo02";
            this.btnDemo02.Size = new System.Drawing.Size(139, 45);
            this.btnDemo02.TabIndex = 1;
            this.btnDemo02.Text = "Demo 02";
            this.btnDemo02.UseVisualStyleBackColor = true;
            this.btnDemo02.Click += new System.EventHandler(this.btnDemo02_Click);
            // 
            // btnDemo03
            // 
            this.btnDemo03.Location = new System.Drawing.Point(11, 114);
            this.btnDemo03.Name = "btnDemo03";
            this.btnDemo03.Size = new System.Drawing.Size(139, 45);
            this.btnDemo03.TabIndex = 2;
            this.btnDemo03.Text = "Demo 03";
            this.btnDemo03.UseVisualStyleBackColor = true;
            this.btnDemo03.Click += new System.EventHandler(this.btnDemo03_Click);
            // 
            // btnDemo04
            // 
            this.btnDemo04.Location = new System.Drawing.Point(11, 165);
            this.btnDemo04.Name = "btnDemo04";
            this.btnDemo04.Size = new System.Drawing.Size(139, 45);
            this.btnDemo04.TabIndex = 3;
            this.btnDemo04.Text = "Demo 04";
            this.btnDemo04.UseVisualStyleBackColor = true;
            this.btnDemo04.Click += new System.EventHandler(this.btnDemo04_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(162, 221);
            this.Controls.Add(this.btnDemo04);
            this.Controls.Add(this.btnDemo03);
            this.Controls.Add(this.btnDemo02);
            this.Controls.Add(this.btnDemo01);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDemo01;
        private System.Windows.Forms.Button btnDemo02;
        private System.Windows.Forms.Button btnDemo03;
        private System.Windows.Forms.Button btnDemo04;
    }
}

