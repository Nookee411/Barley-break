namespace Barley_break
{
    partial class EndGameForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.labelRecords = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Congratulations! You won!";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelScore.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScore.Location = new System.Drawing.Point(0, 29);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(152, 29);
            this.labelScore.TabIndex = 1;
            this.labelScore.Text = "Your score:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Your Time:";
            // 
            // textBoxScore
            // 
            this.textBoxScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxScore.Enabled = false;
            this.textBoxScore.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxScore.Location = new System.Drawing.Point(158, 28);
            this.textBoxScore.Name = "textBoxScore";
            this.textBoxScore.Size = new System.Drawing.Size(169, 30);
            this.textBoxScore.TabIndex = 3;
            this.textBoxScore.Text = "0";
            // 
            // textBoxTime
            // 
            this.textBoxTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTime.Enabled = false;
            this.textBoxTime.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTime.Location = new System.Drawing.Point(158, 57);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(169, 30);
            this.textBoxTime.TabIndex = 4;
            this.textBoxTime.Text = "0";
            // 
            // labelRecords
            // 
            this.labelRecords.AutoSize = true;
            this.labelRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRecords.Location = new System.Drawing.Point(5, 91);
            this.labelRecords.Name = "labelRecords";
            this.labelRecords.Size = new System.Drawing.Size(60, 24);
            this.labelRecords.TabIndex = 5;
            this.labelRecords.Text = "label2";
            // 
            // EndGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 450);
            this.Controls.Add(this.labelRecords);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.textBoxScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label1);
            this.Name = "EndGameForm";
            this.Text = "EndGameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EndGameForm_FormClosing);
            this.Load += new System.EventHandler(this.EndGameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxScore;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label labelRecords;
    }
}