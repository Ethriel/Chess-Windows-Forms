using ChessWinForms.Forms.nGameBoardForm;
using ChessWinForms.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ChessWinForms.Forms.nGameBoardForm.GameBoardForm;

namespace ChessWinForms.Classes.Figures
{
    [Serializable]
    public class Rook : Figure
    {

        public Rook() : base()
        {

        }

        public Rook(Rook r) : base(r)
        {

        }

        public Rook(string name, string side, int moves, int btnSize, GameBoardForm gb) : base(name, side, moves, btnSize, gb)
        {
            DIRECTIONs = new List<DIRECTIONS>();
            DIRECTIONs.AddRange(
                new DIRECTIONS[]{
                    DIRECTIONS.TOP,
                    DIRECTIONS.RIGHT,
                    DIRECTIONS.BOT,
                    DIRECTIONS.LEFT
            });
        }
    }
}
