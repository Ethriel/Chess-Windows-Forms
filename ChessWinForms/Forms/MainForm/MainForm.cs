using ChessWinForms.Forms.nGameBoardForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessWinForms
{
    public partial class MainForm : Form
    {
        GameBoardForm GameBoard;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pbxBG.Image = Image.FromFile(@"../../pictures/chess_background.jpg");
            this.Text = "Chess";
            //GameBoard = new GameBoardForm();
            //GameBoard.ShowDialog();
            //this.Close();
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            GameBoard = new GameBoardForm(this, "standard");
            GameBoard.ShowDialog();
        }

        private void loadSavedGame_Click(object sender, EventArgs e)
        {
            GameBoard = new GameBoardForm(this, "saved");
            GameBoard.ShowDialog();
        }

        private void testStalemate_Click(object sender, EventArgs e)
        {
            GameBoard = new GameBoardForm(this, "stalemate");
            GameBoard.ShowDialog();
        }

        private void testCheckmate_Click(object sender, EventArgs e)
        {
            GameBoard = new GameBoardForm(this, "checkmate");
            GameBoard.ShowDialog();
        }

        private void castlingNormal_Click(object sender, EventArgs e)
        {
            GameBoard = new GameBoardForm(this, "castling_normal");
            GameBoard.ShowDialog();
        }

        private void castlingNoFigures_Click(object sender, EventArgs e)
        {
            GameBoard = new GameBoardForm(this, "castling_no_between");
            GameBoard.ShowDialog();
        }

        private void testTakePawnOnMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameBoard = new GameBoardForm(this, "take_pawn_on_move");
            GameBoard.ShowDialog();
        }
    }
}
