namespace ChessWinForms
{
    partial class MainForm
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
            this.pbxBG = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.game = new System.Windows.Forms.ToolStripMenuItem();
            this.newGame = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSavedGame = new System.Windows.Forms.ToolStripMenuItem();
            this.scenario = new System.Windows.Forms.ToolStripMenuItem();
            this.testStalemate = new System.Windows.Forms.ToolStripMenuItem();
            this.testCheckmate = new System.Windows.Forms.ToolStripMenuItem();
            this.testCastling = new System.Windows.Forms.ToolStripMenuItem();
            this.castlingNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.castlingNoFigures = new System.Windows.Forms.ToolStripMenuItem();
            this.testTakePawnOnMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBG)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxBG
            // 
            this.pbxBG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxBG.InitialImage = null;
            this.pbxBG.Location = new System.Drawing.Point(0, 24);
            this.pbxBG.Name = "pbxBG";
            this.pbxBG.Size = new System.Drawing.Size(651, 498);
            this.pbxBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxBG.TabIndex = 0;
            this.pbxBG.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.game,
            this.scenario});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(651, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // game
            // 
            this.game.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGame,
            this.loadSavedGame});
            this.game.Name = "game";
            this.game.Size = new System.Drawing.Size(59, 20);
            this.game.Text = "&Game...";
            // 
            // newGame
            // 
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(166, 22);
            this.newGame.Text = "&New game";
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // loadSavedGame
            // 
            this.loadSavedGame.Name = "loadSavedGame";
            this.loadSavedGame.Size = new System.Drawing.Size(166, 22);
            this.loadSavedGame.Text = "&Load saved game";
            this.loadSavedGame.Click += new System.EventHandler(this.loadSavedGame_Click);
            // 
            // scenario
            // 
            this.scenario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testStalemate,
            this.testCheckmate,
            this.testCastling,
            this.testTakePawnOnMoveToolStripMenuItem});
            this.scenario.Name = "scenario";
            this.scenario.Size = new System.Drawing.Size(73, 20);
            this.scenario.Text = "&Scenario...";
            // 
            // testStalemate
            // 
            this.testStalemate.Name = "testStalemate";
            this.testStalemate.Size = new System.Drawing.Size(203, 22);
            this.testStalemate.Text = "&Test stalemate";
            this.testStalemate.Click += new System.EventHandler(this.testStalemate_Click);
            // 
            // testCheckmate
            // 
            this.testCheckmate.Name = "testCheckmate";
            this.testCheckmate.Size = new System.Drawing.Size(203, 22);
            this.testCheckmate.Text = "&Test checkmate";
            this.testCheckmate.Click += new System.EventHandler(this.testCheckmate_Click);
            // 
            // testCastling
            // 
            this.testCastling.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.castlingNormal,
            this.castlingNoFigures});
            this.testCastling.Name = "testCastling";
            this.testCastling.Size = new System.Drawing.Size(203, 22);
            this.testCastling.Text = "&Test castling";
            // 
            // castlingNormal
            // 
            this.castlingNormal.Name = "castlingNormal";
            this.castlingNormal.Size = new System.Drawing.Size(253, 22);
            this.castlingNormal.Text = "&Normal";
            this.castlingNormal.Click += new System.EventHandler(this.castlingNormal_Click);
            // 
            // castlingNoFigures
            // 
            this.castlingNoFigures.Name = "castlingNoFigures";
            this.castlingNoFigures.Size = new System.Drawing.Size(253, 22);
            this.castlingNoFigures.Text = "&No figures between king and rook";
            this.castlingNoFigures.Click += new System.EventHandler(this.castlingNoFigures_Click);
            // 
            // testTakePawnOnMoveToolStripMenuItem
            // 
            this.testTakePawnOnMoveToolStripMenuItem.Name = "testTakePawnOnMoveToolStripMenuItem";
            this.testTakePawnOnMoveToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.testTakePawnOnMoveToolStripMenuItem.Text = "&Test take pawn on move";
            this.testTakePawnOnMoveToolStripMenuItem.Click += new System.EventHandler(this.testTakePawnOnMoveToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 522);
            this.Controls.Add(this.pbxBG);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBG)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxBG;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem game;
        private System.Windows.Forms.ToolStripMenuItem newGame;
        private System.Windows.Forms.ToolStripMenuItem loadSavedGame;
        private System.Windows.Forms.ToolStripMenuItem scenario;
        private System.Windows.Forms.ToolStripMenuItem testStalemate;
        private System.Windows.Forms.ToolStripMenuItem testCheckmate;
        private System.Windows.Forms.ToolStripMenuItem testCastling;
        private System.Windows.Forms.ToolStripMenuItem castlingNormal;
        private System.Windows.Forms.ToolStripMenuItem castlingNoFigures;
        private System.Windows.Forms.ToolStripMenuItem testTakePawnOnMoveToolStripMenuItem;
    }
}

