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
    public class Pawn : Figure
    {
        
        public Pawn() : base()
        {

        }

        public Pawn(Pawn p) : base(p)
        {
            PossibleAttacks = new List<Point>();
        }

        public Pawn(string name, string side, int moves, int btnSize, GameBoardForm gb) : base(name, side, moves, btnSize, gb)
        {
            DIRECTIONs = new List<DIRECTIONS>();
            if (side == "White")
                DIRECTIONs.Add(DIRECTIONS.TOP);
            if (side == "Black")
                DIRECTIONs.Add(DIRECTIONS.BOT);
        }

        public override bool Move(Figure to)
        {
            DIRECTIONS d = DirectionValidator.GetDirection(this.Location, to.Location);
            int moves = (Math.Abs(this.Location.Y - to.Location.Y) / 64);
            SetMoves();
            if (moves > Moves)
                return false;

            return base.Move(to);
        }

        public override bool Attack(Figure to)
        {
            for (int i = 0; i < this.PossibleAttacks.Count; i++)
            {
                if (this.PossibleAttacks[i].Equals(to.Location))
                {
                    return true;
                }
            }

            return false;
        }

        public void SetMoves()
        {
            if (this.HasMoved)
                this.Moves = 1;
        }

        public override void SetPossibleAttacks()
        {
            List<Point> points = new List<Point>();
            this.PossibleAttacks.Clear();
            switch (this.Side)
            {
                case "White":
                    {
                        points.AddRange(new Point[]
                        {
                            new Point(this.Location.X - this.BtnSize, this.Location.Y - this.BtnSize),
                        new Point(this.Location.X + this.BtnSize, this.Location.Y - this.BtnSize)
                        });
                        break;
                    }
                case "Black":
                    {
                        points.AddRange(new Point[]
                        {
                            new Point(this.Location.X - this.BtnSize, this.Location.Y + this.BtnSize),
                        new Point(this.Location.X + this.BtnSize, this.Location.Y + this.BtnSize)
                        });
                        break;
                    }
                default:
                    break;
            }

            PossibleAttacks.AddRange(points.ToArray());
        }
    }
}
