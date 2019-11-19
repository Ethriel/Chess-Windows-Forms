using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessWinForms.Forms.nGameBoardForm.GameBoardForm;

namespace ChessWinForms.Classes
{
    static public class NextPointGenerator
    {
        static public Point GetNextPoint(DIRECTIONS d, Point curr)
        {
            Point next = new Point();

            switch (d)
            {
                case DIRECTIONS.TOP:
                    next = new Point(curr.X, curr.Y - 64);
                    break;
                case DIRECTIONS.RIGHT:
                    next = new Point(curr.X + 64, curr.Y);
                    break;
                case DIRECTIONS.BOT:
                    next = new Point(curr.X, curr.Y + 64);
                    break;
                case DIRECTIONS.LEFT:
                    next = new Point(curr.X - 64, curr.Y);
                    break;
                case DIRECTIONS.DIAGONAL_RB_LT:
                    next = new Point(curr.X - 64, curr.Y - 64);
                    break;
                case DIRECTIONS.DIAGONAL_LT_RB:
                    next = new Point(curr.X + 64, curr.Y + 64);
                    break;
                case DIRECTIONS.DIAGONAL_LB_RT:
                    next = new Point(curr.X + 64, curr.Y - 64);
                    break;
                case DIRECTIONS.DIAGONAL_RT_LB:
                    next = new Point(curr.X - 64, curr.Y + 64);
                    break;
                default:
                    break;
            }

            return next;
        }
    }
}
