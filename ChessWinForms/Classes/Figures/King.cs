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
    public class King : Figure
    {
        public List<Point> Surrounding { get; set; }
        public King() : base()
        {

        }

        public King(string name, string side, int moves, int btnSize, GameBoardForm gb) : base(name, side, moves, btnSize, gb)
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

            Surrounding = new List<Point>();
        }

        public King(King k) : base(k)
        {
            Surrounding = new List<Point>();
        }

        public override bool Move(Figure to)
        {
            DIRECTIONS d = DirectionValidator.GetDirection(this.Location, to.Location);
            if (!this.DIRECTIONs.Contains(d) || !this.Surrounding.Contains(to.Location))
            {
                return false;
            }
            return base.Move(to);
        }

        public void SetSurrounding()
        {
            this.Surrounding.Clear();
            int x = this.Location.X;
            int y = this.Location.Y;
            int n = BtnSize;

            Surrounding.Add(new Point(x, y - n));
            Surrounding.Add(new Point(x + n, y - n));
            Surrounding.Add(new Point(x + n, y));
            Surrounding.Add(new Point(x + n, y + n));

            Surrounding.Add(new Point(x, y + n));
            Surrounding.Add(new Point(x - n, y + n));
            Surrounding.Add(new Point(x - n, y));
            Surrounding.Add(new Point(x - n, y - n));
            RemoveInvalidPoints();
        }

        private void RemoveInvalidPoints()
        {
            Point surrPoint = new Point();
            Point attackerPoint = new Point();
            List<Point> attackers = null;
            Figure attacker = null;
            Figure near = null;
            string player = this.Side, opponent = "";

            if (player == "White")
            {
                attackers = GameBoard.BlackFiguresLocations;
                opponent = "Black";
            }
            else
            {
                attackers = GameBoard.WhiteFiguresLocations;
                opponent = "White";
            }

            for (int i = 0; i < this.Surrounding.Count; i++)
            {
                surrPoint = this.Surrounding[i];
                if (surrPoint.X < 0 || surrPoint.X > 448 || surrPoint.Y < 0 || surrPoint.Y > 448)
                {
                    this.Surrounding.Remove(surrPoint);
                    i--;
                }
            }

            for (int i = 0; i < this.Surrounding.Count; i++)
            {
                surrPoint = this.Surrounding[i];
                near = GameBoard.GetFigureByPoint(surrPoint);
                if (near.Side == opponent)
                {
                    this.Surrounding.Remove(surrPoint);
                    i--;
                }
            }

            for (int i = 0; i < attackers.Count; i++)
            {
                attacker = GameBoard.GetFigureByPoint(attackers[i]);
                attacker.SetPossibleMoves();
                attacker.SetPossibleAttacks();
                for (int j = 0; j < attacker.PossibleAttacks.Count; j++)
                {
                    attackerPoint = attacker.PossibleAttacks[j];
                    for (int k = 0; k < this.Surrounding.Count; k++)
                    {
                        surrPoint = this.Surrounding[k];
                        if (attackerPoint.Equals(surrPoint))
                        {
                            this.Surrounding.Remove(surrPoint);
                            k--;
                        }
                    }
                }
            }
        }

        public void SetNewSurroundingIfChecked(Figure attacker)
        {
            if (this.Side == attacker.Side)
            {
                return;
            }
            Point p = new Point();

            for (int i = 0; i < attacker.FigureWay.Count; i++)
            {
                p = attacker.FigureWay[i];
                if (this.Surrounding.Contains(p))
                {
                    this.Surrounding.Remove(p);
                }
            }
        }

        public override void SetPossibleMoves()
        {
            this.PossibleMoves.Clear();

            for (int i = 0; i < this.Surrounding.Count; i++)
            {
                if (GameBoard.GetFigureByPoint(this.Surrounding[i]).Side == "None")
                {
                    this.PossibleMoves.Add(this.Surrounding[i]);
                }
            }
        }
    }
}
