using ChessWinForms.Classes.Figures;
using ChessWinForms.Forms.nGameBoardForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessWinForms.Classes
{
    class FigureGenerator
    {
        Figure figure;
        public FigureGenerator()
        {

        }

        public Figure GetFigureStart(Type t, string name, string side, int moves, int btnSize, GameBoardForm gb)
        {
            figure = (Figure)Activator.CreateInstance(t, name, side, moves, btnSize, gb);
            //figure.SetPossibleMoves();
            
            return figure;
        }

        public Figure GetFigureInSwap(Figure f)
        {
            Type t = f.GetType();
            figure = (Figure)Activator.CreateInstance(t, f);

            return figure;
        }

        public void SetFromAndTo(Type t, Button b, ref Figure fromFigure, ref Figure toFigure)
        {
            switch (t.Name)
            {
                case "Pawn":
                    {
                        if (fromFigure == null)
                        {
                            fromFigure = (Pawn)b.Tag;
                        }
                        else if (fromFigure != null && toFigure == null)
                        {
                            toFigure = (Pawn)b.Tag;
                        }
                        break;
                    }
                case "Knight":
                    {
                        if (fromFigure == null)
                        {
                            fromFigure = (Knight)b.Tag;
                        }
                        else if (fromFigure != null && toFigure == null)
                        {
                            toFigure = (Knight)b.Tag;
                        }
                        break;
                    }
                case "Bishop":
                    {
                        if (fromFigure == null)
                        {
                            fromFigure = (Bishop)b.Tag;
                        }
                        else if (fromFigure != null && toFigure == null)
                        {
                            toFigure = (Bishop)b.Tag;
                        }
                        break;
                    }
                case "Queen":
                    {
                        if (fromFigure == null)
                        {
                            fromFigure = (Queen)b.Tag;
                        }
                        else if (fromFigure != null && toFigure == null)
                        {
                            toFigure = (Queen)b.Tag;
                        }
                        break;
                    }
                case "Rook":
                    {
                        if (fromFigure == null)
                        {
                            fromFigure = (Rook)b.Tag;
                        }
                        else if (fromFigure != null && toFigure == null)
                        {
                            toFigure = (Rook)b.Tag;
                        }
                        break;
                    }
                case "King":
                    {
                        if (fromFigure == null)
                        {
                            fromFigure = (King)b.Tag;
                        }
                        else if (fromFigure != null && toFigure == null)
                        {
                            toFigure = (King)b.Tag;
                        }
                        break;
                    }
                case "Space":
                    {
                        if (fromFigure != null)
                        {
                            if (toFigure == null)
                            {
                                toFigure = (Space)b.Tag;
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
