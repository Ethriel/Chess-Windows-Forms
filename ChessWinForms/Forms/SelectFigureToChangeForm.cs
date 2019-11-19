using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessWinForms.Classes;
using ChessWinForms.Classes.Figures;
using ChessWinForms.Forms.nGameBoardForm;

namespace ChessWinForms.Forms
{
    public partial class SelectFigureToChangeForm : Form
    {
        GameBoardForm GB;
        FigureGenerator generator;
        Figure toChange = null;
        public SelectFigureToChangeForm()
        {
            InitializeComponent();
        }

        public SelectFigureToChangeForm(GameBoardForm gb)
        {
            InitializeComponent();
            GB = gb;
            SetButtons();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            generator = new FigureGenerator();
            string name = b.Name;
            string side = GB.Player;
            int moves = 0;
            moves = name == "Knight" ? -1 : 8;
            Type t = GetTypeOfFigure(name);
            toChange = generator.GetFigureStart(t, name, side, moves, 64, GB);
            GB.ToChange = generator.GetFigureInSwap(toChange);
            this.Close();
        }

        private void SetButtons()
        {
            string name = "";
            string side = GB.Player.ToLower();
            List<Button> buttons = new List<Button>();
            buttons.AddRange(new Button[] { Bishop, Knight, Queen, Rook });
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Text = string.Empty;
                name = buttons[i].Name.ToLower();
                
                buttons[i].BackgroundImageLayout = ImageLayout.Zoom;
                buttons[i].BackgroundImage = Image.FromFile($@"../../pictures/figures/{name}_{side}.png");
            }
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button b = sender as Button;
            toolTip.SetToolTip(b, $"{b.Name}");
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            toolTip.RemoveAll();
        }

        private Type GetTypeOfFigure(string name)
        {
            Type t = null;
            switch (name)
            {
                case "Bishop":
                    {
                        t = typeof(Bishop);
                        break;
                    }
                case "Knight":
                    {
                        t = typeof(Knight);
                        break;
                    }
                case "Queen":
                    {
                        t = typeof(Queen);
                        break;
                    }
                case "Rook":
                    {
                        t = typeof(Rook);
                        break;
                    }
                default:
                    break;
            }

            return t;
        }

        private void SelectFigureToChangeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(toChange != null)
            {
                this.Dispose();
            }
            else
            {
                this.Show();
            }
        }
    }
}
