using ChessWinForms.Forms.nGameBoardForm;
using ChessWinForms.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static ChessWinForms.Forms.nGameBoardForm.GameBoardForm;

namespace ChessWinForms.Classes.Figures
{
    public delegate bool Validate(Figure from, Figure to, GameBoardForm gameboard);

    [XmlInclude(typeof(Bishop))]
    [XmlInclude(typeof(King))]
    [XmlInclude(typeof(Knight))]
    [XmlInclude(typeof(Pawn))]
    [XmlInclude(typeof(Queen))]
    [XmlInclude(typeof(Rook))]
    [XmlInclude(typeof(Space))]
    [Serializable]
    public class Figure : IFigure
    {
        [XmlIgnore]
        public Validate validate;

        public string Name { get; set; }
        public string Side { get; set; }
        public int Moves { get; set; }
        public bool HasMoved { get; set; }
        public Point Location { get; set; }
        public List<DIRECTIONS> DIRECTIONs;
        [XmlIgnore]
        public GameBoardForm GameBoard;
        public int BtnSize { get; set; }
        public List<Point> PossibleMoves;
        public List<Point> PossibleAttacks;
        public List<Point> FigureWay { get; set; }

        public Figure()
        {

        }

        public Figure(Figure f)
        {
            this.Name = f.Name;
            this.Side = f.Side;
            this.Moves = f.Moves;
            this.Location = new Point(f.Location.X, f.Location.Y);
            this.DIRECTIONs = f.DIRECTIONs;
            this.GameBoard = f.GameBoard;
            this.HasMoved = f.HasMoved;
            this.BtnSize = f.BtnSize;
            this.PossibleMoves = f.PossibleMoves;
            this.FigureWay = f.FigureWay;
            if (this is King)
            {
                (this as King).Surrounding = new List<Point>();
                (this as King).Surrounding = (f as King).Surrounding;
            }
            this.PossibleAttacks = f.PossibleAttacks;
            if(this is Pawn && f is Pawn)
            {
                (this as Pawn).End = (f as Pawn).End;
            }
        }

        public Figure(string name, string side, int moves, int btnSize, GameBoardForm gb)
        {
            Name = name;
            Side = side;
            Moves = moves;
            BtnSize = btnSize;
            GameBoard = gb;
            PossibleMoves = new List<Point>();
            PossibleAttacks = new List<Point>();
            FigureWay = new List<Point>();
        }

        public virtual bool Move(Figure to)
        {
            if (this is Space)
            {
                return false;
            }
            if (this is King)
            {
                if (!(this as King).Surrounding.Any())
                {
                    return false;
                }
            }
            DIRECTIONS d = DirectionValidator.GetDirection(this.Location, to.Location);
            if (DIRECTIONs.Contains(d))
            {
                SetValidate(ref validate, d);
                if (validate != null)
                {
                    this.FigureWay.Clear();
                    if (validate(this, to, GameBoard))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public virtual bool Attack(Figure to)
        {
            DIRECTIONS d = DirectionValidator.GetDirection(this.Location, to.Location);
            if (this.DIRECTIONs.Contains(d))
            {
                if ((Math.Abs(this.Location.Y - to.Location.Y) / BtnSize) != this.Moves
                && (Math.Abs(this.Location.X - to.Location.X) / BtnSize) != this.Moves)
                {
                    return false;
                }
            }
            to = GetFigureForAttack(to);
            if (this.Move(to))
            {
                return true;
            }
            return false;
        }

        protected void SetValidate(ref Validate v, DIRECTIONS d)
        {
            switch (d)
            {
                case DIRECTIONS.TOP:
                    v = DirectionValidator.ValidateVerticalTop;
                    break;
                case DIRECTIONS.RIGHT:
                    v = DirectionValidator.ValidateHorizontalRight;
                    break;
                case DIRECTIONS.BOT:
                    v = DirectionValidator.ValidateVerticalBot;
                    break;
                case DIRECTIONS.LEFT:
                    v = DirectionValidator.ValidateHorizontalLeft;
                    break;
                case DIRECTIONS.DIAGONAL_RB_LT:
                case DIRECTIONS.DIAGONAL_LT_RB:
                case DIRECTIONS.DIAGONAL_LB_RT:
                case DIRECTIONS.DIAGONAL_RT_LB:
                    v = DirectionValidator.ValidateDiagonal;
                    break;
                case DIRECTIONS.NULL:
                    break;
                default:
                    break;
            }
        }
        protected Figure GetFigureForAttack(Figure to)
        {
            Figure f = new Figure(to);

            DIRECTIONS d = DirectionValidator.GetDirection(this.Location, f.Location);

            switch (d)
            {
                case DIRECTIONS.TOP:
                    f.Location = new Point(f.Location.X, f.Location.Y + this.BtnSize);
                    break;
                case DIRECTIONS.RIGHT:
                    f.Location = new Point(f.Location.X - this.BtnSize, f.Location.Y);
                    break;
                case DIRECTIONS.BOT:
                    f.Location = new Point(f.Location.X, f.Location.Y - this.BtnSize);
                    break;
                case DIRECTIONS.LEFT:
                    f.Location = new Point(f.Location.X + this.BtnSize, f.Location.Y);
                    break;
                case DIRECTIONS.DIAGONAL_RB_LT:
                    f.Location = new Point(f.Location.X + this.BtnSize, f.Location.Y + this.BtnSize);
                    break;
                case DIRECTIONS.DIAGONAL_LT_RB:
                    f.Location = new Point(f.Location.X - this.BtnSize, f.Location.Y - this.BtnSize);
                    break;
                case DIRECTIONS.DIAGONAL_LB_RT:
                    f.Location = new Point(f.Location.X - this.BtnSize, f.Location.Y + this.BtnSize);
                    break;
                case DIRECTIONS.DIAGONAL_RT_LB:
                    f.Location = new Point(f.Location.X + this.BtnSize, f.Location.Y - this.BtnSize);
                    break;
                case DIRECTIONS.NULL:
                    break;
                default:
                    break;
            }

            return f;
        }

        public virtual List<Point> SetHighLightPoints()
        {
            PossibleMoves.Clear();
            SetPossibleMoves();
            List<Point> tmp = new List<Point>(this.PossibleMoves.ToArray());
            return tmp;
        }

        public virtual void SetPossibleMoves()
        {
            if (this is Pawn)
                (this as Pawn).SetMoves();

            List<Point> tmp = new List<Point>();
            Point curr = this.Location;

            string enemy = "";

            if (this.Side == "White")
                enemy = "Black";
            else
                enemy = "White";

            DIRECTIONS d = DIRECTIONS.NULL;

            List<Point> defender = null;
            if (enemy == "White")
                defender = GameBoard.WhiteFiguresLocations;
            else
                defender = GameBoard.BlackFiguresLocations;
            for (int i = 0; i < DIRECTIONs.Count; i++)
            {
                d = this.DIRECTIONs[i];
                for (int j = 0; j < GameBoard.SpacesLocations.Count; j++)
                {
                    if (this.Move(GameBoard.GetFigureByPoint(GameBoard.SpacesLocations[j])))
                    {
                        tmp.Add(GameBoard.SpacesLocations[j]);
                    }
                }
                for (int j = 0; j < defender.Count; j++)
                {
                    if (this.Attack(GameBoard.GetFigureByPoint(defender[j])))
                    {
                        tmp.Add(defender[j]);
                    }
                }
            }

            PossibleMoves.AddRange(tmp.ToArray());
        }

        public virtual void SetPossibleAttacks()
        {
            this.PossibleAttacks.Clear();
            this.PossibleAttacks.AddRange(this.PossibleMoves.ToArray());
        }

        public void SetAllNeeded()
        {
            if (this is Space)
            {
                return;
            }
            this.SetPossibleMoves();
            this.SetHighLightPoints();
            this.SetPossibleAttacks();
            if (this is King)
            {
                (this as King).SetSurrounding();
            }
        }
    }
}
