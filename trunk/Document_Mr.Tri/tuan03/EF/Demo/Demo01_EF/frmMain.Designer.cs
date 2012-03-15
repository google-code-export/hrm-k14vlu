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
            this.SuspendLayout();
            // 
            // btnDemo01
            // 
            this.btnDemo01.Location = new System.Drawing.Point(12, 12);
            this.btnDemo01.Name = "btnDemo01";
            this.btnDemo01.Size = new System.Drawing.Size(141, 37);
            this.btnDemo01.TabIndex = 0;
            this.btnDemo01.Text = "Demo 01";
            this.btnDemo01.UseVisualStyleBackColor = true;
            this.btnDemo01.Click += new System.EventHandler(this.btnDemo01_Click);
            // 
            // btnDemo02
            // 
            this.btnDemo02.Location = new System.Drawing.Point(12, 55);
            this.btnDemo02.Name = "btnDemo02";
            this.btnDemo02.Size = new System.Drawing.Size(141, 37);
            this.btnDemo02.TabIndex = 1;
            this.btnDemo02.Text = "Demo 02";
            this.btnDemo02.UseVisualStyleBackColor = true;
            this.btnDemo02.Click += new System.EventHandler(this.btnDemo02_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 262);
            this.Controls.Add(this.btnDemo02);
            this.Controls.Add(this.btnDemo01);
            this.Name = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDemo01;
        private System.Windows.Forms.Button btnDemo02;
    }
}

