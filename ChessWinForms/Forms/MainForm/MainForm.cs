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
        }

        private void Menu_Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string scenario = "";
            switch (item.Text)
            {
                case "&New game":
                    {
                        scenario = "standard";
                        break;
                    }
                case "&Load saved game":
                    {
                        scenario = "saved";
                        break;
                    }
                case "&Test stalemate":
                    {
                        scenario = "stalemate";
                        break;
                    }
                case "&Test checkmate":
                    {
                        scenario = "checkmate";
                        break;
                    }
                case "&Normal":
                    {
                        scenario = "castling_normal";
                        break;
                    }
                case "&No figures between king and rook":
                    {
                        scenario = "castling_no_between";
                        break;
                    }
                case "&Test take pawn on move":
                    {
                        scenario = "take_pawn_on_move";
                        break;
                    }
                case "&Test change pawn":
                    {
                        scenario = "change_pawn";
                        break;
                    }
                default:
                    break;
            }
            if (!string.IsNullOrWhiteSpace(scenario))
            {
                GameBoard = new GameBoardForm(this, scenario);
                GameBoard.ShowDialog();
            }
        }
    }
}
