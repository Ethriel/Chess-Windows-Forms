using ChessWinForms.Forms.GameBoardForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinForms.Classes.Figures
{
    [Serializable]
    public class Knight : Figure
    {
        public Knight() : base()
        {

        }

        public Knight(string name, string side, int moves, int btnSize, GameBoardForm gb) : base(name, side, moves, btnSize, gb)
        {

        }

        public Knight(Knight k) : base(k)
        {

        }

        public override bool Move(Figure to)
        {
            Point t = to.Location;
            SetPossibleMoves();
            for (int i = 0; i < PossibleMoves.Count; i++)
            {
                if (PossibleMoves[i].Equals(t))
                    return true;
            }
            return false;
        }

        public override bool Attack(Figure to)
        {
            return this.Move(to);
        }

        public override List<Point> SetHighLightPoints()
        {
            SetPossibleMoves();

            List<Point> tmp = new List<Point>(PossibleMoves.ToArray());

            return tmp;
        }

        public override void SetPossibleMoves()
        {
            int x = this.Location.X, y = this.Location.Y;
            List<Point> tmp = new List<Point>();
            Figure f = null;
            string enemy = this.Side == "White" ? "Black" : "White";
            PossibleMoves.Clear();

            tmp.Add(new Point(x - 64, y - 128));
            tmp.Add(new Point(x - 128, y - 64));
            tmp.Add(new Point(x - 64, y + 128));
            tmp.Add(new Point(x - 128, y + 64));

            tmp.Add(new Point(x + 64, y - 128));
            tmp.Add(new Point(x + 128, y - 64));
            tmp.Add(new Point(x + 64, y + 128));
            tmp.Add(new Point(x + 128, y + 64));

            for (int i = 0; i < tmp.Count; i++)
            {
                if (GameBoard.IsFigureOnPoint(tmp[i]))
                {
                    GameBoard.GetFigureOnPoint(tmp[i], ref f);
                    if (f.Side != "None")
                    {
                        if (f.Side == enemy)
                        {
                            PossibleMoves.Add(tmp[i]);
                        }
                    }
                    else
                    {
                        PossibleMoves.Add(tmp[i]);
                    }
                }
            }
        }
    }
}
