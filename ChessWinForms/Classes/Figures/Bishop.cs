using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessWinForms.Forms.nGameBoardForm;
using static ChessWinForms.Forms.nGameBoardForm.GameBoardForm;

namespace ChessWinForms.Classes.Figures
{
    [Serializable]
    public class Bishop : Figure
    {
        public Bishop() : base()
        {

        }

        public Bishop(string name, string side, int moves, int btnSize, GameBoardForm gb) : base(name, side, moves, btnSize, gb)
        {
            DIRECTIONs = new List<DIRECTIONS>();
            DIRECTIONs.AddRange(
                new DIRECTIONS[]{
                    DIRECTIONS.DIAGONAL_LB_RT,
                    DIRECTIONS.DIAGONAL_LT_RB,
                    DIRECTIONS.DIAGONAL_RB_LT,
                    DIRECTIONS.DIAGONAL_RT_LB
            });
        }

        public Bishop(Bishop b):base(b)
        {

        }
    }
}
