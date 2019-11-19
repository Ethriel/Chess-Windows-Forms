namespace ChessWinForms.Forms.GameBoardForm
{
    partial class GameBoardForm
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
            this.GBoard = new System.Windows.Forms.TableLayoutPanel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chbxToggleHighlight = new System.Windows.Forms.CheckBox();
            this.pbxGreen = new System.Windows.Forms.PictureBox();
            this.pbxRed = new System.Windows.Forms.PictureBox();
            this.pbxViolet = new System.Windows.Forms.PictureBox();
            this.labGreen = new System.Windows.Forms.Label();
            this.labRed = new System.Windows.Forms.Label();
            this.labViolet = new System.Windows.Forms.Label();
            this.lbxHistoryOfMoves = new System.Windows.Forms.ListBox();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labInfoOnto = new System.Windows.Forms.Label();
            this.labInfoSelected = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxViolet)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBoard
            // 
            this.GBoard.ColumnCount = 8;
            this.GBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.Location = new System.Drawing.Point(12, 10);
            this.GBoard.Name = "GBoard";
            this.GBoard.RowCount = 8;
            this.GBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.GBoard.Size = new System.Drawing.Size(512, 512);
            this.GBoard.TabIndex = 1;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // chbxToggleHighlight
            // 
            this.chbxToggleHighlight.AutoSize = true;
            this.chbxToggleHighlight.Location = new System.Drawing.Point(542, 12);
            this.chbxToggleHighlight.Name = "chbxToggleHighlight";
            this.chbxToggleHighlight.Size = new System.Drawing.Size(103, 17);
            this.chbxToggleHighlight.TabIndex = 2;
            this.chbxToggleHighlight.Text = "Toggle Highlight";
            this.chbxToggleHighlight.UseVisualStyleBackColor = true;
            this.chbxToggleHighlight.CheckedChanged += new System.EventHandler(this.chbxToggleHighlight_CheckedChanged);
            // 
            // pbxGreen
            // 
            this.pbxGreen.Location = new System.Drawing.Point(542, 36);
            this.pbxGreen.Name = "pbxGreen";
            this.pbxGreen.Size = new System.Drawing.Size(30, 30);
            this.pbxGreen.TabIndex = 3;
            this.pbxGreen.TabStop = false;
            this.pbxGreen.Visible = false;
            // 
            // pbxRed
            // 
            this.pbxRed.Location = new System.Drawing.Point(542, 72);
            this.pbxRed.Name = "pbxRed";
            this.pbxRed.Size = new System.Drawing.Size(30, 30);
            this.pbxRed.TabIndex = 4;
            this.pbxRed.TabStop = false;
            this.pbxRed.Visible = false;
            // 
            // pbxViolet
            // 
            this.pbxViolet.Location = new System.Drawing.Point(542, 108);
            this.pbxViolet.Name = "pbxViolet";
            this.pbxViolet.Size = new System.Drawing.Size(30, 30);
            this.pbxViolet.TabIndex = 5;
            this.pbxViolet.TabStop = false;
            this.pbxViolet.Visible = false;
            // 
            // labGreen
            // 
            this.labGreen.AutoSize = true;
            this.labGreen.Location = new System.Drawing.Point(578, 36);
            this.labGreen.Name = "labGreen";
            this.labGreen.Size = new System.Drawing.Size(35, 13);
            this.labGreen.TabIndex = 6;
            this.labGreen.Text = "label1";
            this.labGreen.Visible = false;
            // 
            // labRed
            // 
            this.labRed.AutoSize = true;
            this.labRed.Location = new System.Drawing.Point(578, 72);
            this.labRed.Name = "labRed";
            this.labRed.Size = new System.Drawing.Size(35, 13);
            this.labRed.TabIndex = 7;
            this.labRed.Text = "label2";
            this.labRed.Visible = false;
            // 
            // labViolet
            // 
            this.labViolet.AutoSize = true;
            this.labViolet.Location = new System.Drawing.Point(578, 108);
            this.labViolet.Name = "labViolet";
            this.labViolet.Size = new System.Drawing.Size(35, 13);
            this.labViolet.TabIndex = 8;
            this.labViolet.Text = "label3";
            this.labViolet.Visible = false;
            // 
            // lbxHistoryOfMoves
            // 
            this.lbxHistoryOfMoves.FormattingEnabled = true;
            this.lbxHistoryOfMoves.Location = new System.Drawing.Point(542, 145);
            this.lbxHistoryOfMoves.Name = "lbxHistoryOfMoves";
            this.lbxHistoryOfMoves.Size = new System.Drawing.Size(315, 251);
            this.lbxHistoryOfMoves.TabIndex = 9;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.SystemColors.Info;
            this.panelInfo.Controls.Add(this.labInfoOnto);
            this.panelInfo.Controls.Add(this.labInfoSelected);
            this.panelInfo.Location = new System.Drawing.Point(542, 403);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(315, 100);
            this.panelInfo.TabIndex = 10;
            // 
            // labInfoOnto
            // 
            this.labInfoOnto.AutoSize = true;
            this.labInfoOnto.Location = new System.Drawing.Point(4, 38);
            this.labInfoOnto.Name = "labInfoOnto";
            this.labInfoOnto.Size = new System.Drawing.Size(35, 13);
            this.labInfoOnto.TabIndex = 1;
            this.labInfoOnto.Text = "label1";
            // 
            // labInfoSelected
            // 
            this.labInfoSelected.AutoSize = true;
            this.labInfoSelected.Location = new System.Drawing.Point(4, 15);
            this.labInfoSelected.Name = "labInfoSelected";
            this.labInfoSelected.Size = new System.Drawing.Size(35, 13);
            this.labInfoSelected.TabIndex = 0;
            this.labInfoSelected.Text = "label1";
            // 
            // GameBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(861, 534);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.lbxHistoryOfMoves);
            this.Controls.Add(this.labViolet);
            this.Controls.Add(this.labRed);
            this.Controls.Add(this.labGreen);
            this.Controls.Add(this.pbxViolet);
            this.Controls.Add(this.pbxRed);
            this.Controls.Add(this.pbxGreen);
            this.Controls.Add(this.chbxToggleHighlight);
            this.Controls.Add(this.GBoard);
            this.Name = "GameBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameBoardForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameBoardForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxViolet)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox chbxToggleHighlight;
        private System.Windows.Forms.PictureBox pbxViolet;
        private System.Windows.Forms.PictureBox pbxRed;
        private System.Windows.Forms.PictureBox pbxGreen;
        private System.Windows.Forms.Label labViolet;
        private System.Windows.Forms.Label labRed;
        private System.Windows.Forms.Label labGreen;
        private System.Windows.Forms.ListBox lbxHistoryOfMoves;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labInfoOnto;
        private System.Windows.Forms.Label labInfoSelected;
        public System.Windows.Forms.TableLayoutPanel GBoard;
    }
}