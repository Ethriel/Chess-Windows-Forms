namespace ChessWinForms.Forms
{
    partial class SelectFigureToChangeForm
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
            this.components = new System.ComponentModel.Container();
            this.Bishop = new System.Windows.Forms.Button();
            this.Knight = new System.Windows.Forms.Button();
            this.Queen = new System.Windows.Forms.Button();
            this.Rook = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Bishop
            // 
            this.Bishop.Location = new System.Drawing.Point(13, 13);
            this.Bishop.Name = "Bishop";
            this.Bishop.Size = new System.Drawing.Size(120, 120);
            this.Bishop.TabIndex = 0;
            this.Bishop.Tag = "";
            this.Bishop.Text = "bishop";
            this.Bishop.UseVisualStyleBackColor = true;
            this.Bishop.Click += new System.EventHandler(this.Btn_Click);
            this.Bishop.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Bishop.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            // 
            // Knight
            // 
            this.Knight.Location = new System.Drawing.Point(139, 13);
            this.Knight.Name = "Knight";
            this.Knight.Size = new System.Drawing.Size(120, 120);
            this.Knight.TabIndex = 1;
            this.Knight.Text = "knight";
            this.Knight.UseVisualStyleBackColor = true;
            this.Knight.Click += new System.EventHandler(this.Btn_Click);
            this.Knight.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Knight.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            // 
            // Queen
            // 
            this.Queen.Location = new System.Drawing.Point(13, 139);
            this.Queen.Name = "Queen";
            this.Queen.Size = new System.Drawing.Size(120, 120);
            this.Queen.TabIndex = 2;
            this.Queen.Text = "queen";
            this.Queen.UseVisualStyleBackColor = true;
            this.Queen.Click += new System.EventHandler(this.Btn_Click);
            this.Queen.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Queen.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            // 
            // Rook
            // 
            this.Rook.Location = new System.Drawing.Point(139, 139);
            this.Rook.Name = "Rook";
            this.Rook.Size = new System.Drawing.Size(120, 120);
            this.Rook.TabIndex = 3;
            this.Rook.Text = "rook";
            this.Rook.UseVisualStyleBackColor = true;
            this.Rook.Click += new System.EventHandler(this.Btn_Click);
            this.Rook.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Rook.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            // 
            // SelectFigureToChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 270);
            this.Controls.Add(this.Rook);
            this.Controls.Add(this.Queen);
            this.Controls.Add(this.Knight);
            this.Controls.Add(this.Bishop);
            this.Name = "SelectFigureToChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select figure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectFigureToChangeForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Bishop;
        private System.Windows.Forms.Button Knight;
        private System.Windows.Forms.Button Queen;
        private System.Windows.Forms.Button Rook;
        private System.Windows.Forms.ToolTip toolTip;
    }
}