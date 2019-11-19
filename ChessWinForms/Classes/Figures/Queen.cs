using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessWinForms.Forms.GameBoardForm;
using static ChessWinForms.Forms.GameBoardForm.GameBoardForm;

namespace ChessWinForms.Classes.Figures
{
    [Serializable]
    public class Queen : Figure
    {
        public Queen() : base()
        {

        }

        public Queen(string name, string side, int moves, int btnSize, GameBoardForm gb) : base(name, side, moves, btnSize, gb)
        {
            DIRECTIONs = new List<DIRECTIONS>();
            DIRECTIONs.AddRange(
                new DIRECTIONS[]{
                    DIRECTIONS.TOP,
                    DIRECTIONS.RIGHT,
                    DIRECTIONS.BOT,
                    DIRECTIONS.LEFT,
                    DIRECTIONS.DIAGONAL_LB_RT,
                    DIRECTIONS.DIAGONAL_LT_RB,
                    DIRECTIONS.DIAGONAL_RB_LT,
                    DIRECTIONS.DIAGONAL_RT_LB
            });
        }

        public Queen(Queen q):base(q)
        {
            
        }

        public override bool Move(Figure to)
        {
            DIRECTIONS d = DirectionValidator.GetDirection(this.Location, to.Location);

            if (DIRECTIONs.Contains(d))
            {
                SetValidate(ref validate, d);
                if (validate != null)
                {
                    if (validate(this, to, GameBoard))
                        return true;
                }
            }
            return false;
        }
    }
}
