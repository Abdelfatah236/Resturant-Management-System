
namespace menu
{
    partial class admin
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
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Italic);
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(186, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(148, 56);
            this.button7.TabIndex = 6;
            this.button7.Text = "Sign up";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Italic);
            this.button4.Location = new System.Drawing.Point(186, 219);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 56);
            this.button4.TabIndex = 9;
            this.button4.Text = "crystal";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Italic);
            this.button5.Location = new System.Drawing.Point(12, 219);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(148, 56);
            this.button5.TabIndex = 10;
            this.button5.Text = "bill";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Italic);
            this.button6.Location = new System.Drawing.Point(186, 117);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(148, 56);
            this.button6.TabIndex = 11;
            this.button6.Text = "profile";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Italic);
            this.button8.Location = new System.Drawing.Point(12, 117);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(148, 56);
            this.button8.TabIndex = 12;
            this.button8.Text = "login";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(352, 306);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "admin";
            this.Text = "admin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
    }
}