using ChessWinForms.Classes.Figures;
using ChessWinForms.Forms.GameBoardForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessWinForms.Forms.GameBoardForm.GameBoardForm;

namespace ChessWinForms.Classes
{
    static public class DirectionValidator
    {
        static public bool IsHorizontal(Point from, Point to)
        {
            if (from.Y != to.Y) // not horizontal
                return false;
            else
                return true;
        }

        static public bool IsVertical(Point from, Point to)
        {
            if (from.X != to.X) // not vertical
                return false;
            else
                return true;
        }

        static public bool IsDiagonal(Point from, Point to)
        {
            if (Math.Abs((from.X - to.X)) != (Math.Abs(from.Y - to.Y))) // not diagonal
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static public bool ValidateHorizontalLeft(Figure from, Figure to, GameBoardForm gameboard)
        {
            int start = 0, end = 0, iterations = 0, constCoord = 0;
            start = from.Location.X;
            end = to.Location.X;
            constCoord = from.Location.Y;
            iterations = Math.Abs(start - end) / 64;
            string enemy = "";
            if (from.Side == "White")
                enemy = "Black";
            else if (from.Side == "Black")
                enemy = "White";
            else
            {
                return false;
            }
            if (ForReverse(start, end, iterations, constCoord, gameboard, from.Side, enemy, "Left"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool ValidateHorizontalRight(Figure from, Figure to, GameBoardForm gameboard)
        {
            int start = 0, end = 0, iterations = 0, constCoord = 0;
            start = from.Location.X;
            end = to.Location.X;
            constCoord = from.Location.Y;
            iterations = Math.Abs(start - end) / 64;
            string enemy = "";
            if (from.Side == "White")
                enemy = "Black";
            else if (from.Side == "Black")
                enemy = "White";
            else
            {
                return false;
            }
            if (ForOrdinary(start, end, iterations, constCoord, gameboard, from.Side, enemy, "Right"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool ValidateVerticalTop(Figure from, Figure to, GameBoardForm gameboard)
        {
            int start = 0, end = 0, iterations = 0, constCoord = 0;
            start = from.Location.Y;
            end = to.Location.Y;
            constCoord = from.Location.X;
            iterations = Math.Abs(start - end) / 64;
            string enemy = "";
            if (from.Side == "White")
                enemy = "Black";
            else if (from.Side == "Black")
                enemy = "White";
            else
            {
                return false;
            }
            if (ForReverse(start, end, iterations, constCoord, gameboard, from.Side, enemy, "Top"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool ValidateVerticalBot(Figure from, Figure to, GameBoardForm gameboard)
        {
            int start = 0, end = 0, iterations = 0, constCoord = 0;
            start = from.Location.Y;
            end = to.Location.Y;
            constCoord = from.Location.X;
            iterations = Math.Abs(start - end) / 64;
            string enemy = "";
            if (from.Side == "White")
                enemy = "Black";
            else if (from.Side == "Black")
                enemy = "White";
            else
            {
                return false;
            }

            if (ForOrdinary(start, end, iterations, constCoord, gameboard, from.Side, enemy, "Bot"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool ValidateDiagonal(Figure from, Figure to, GameBoardForm gameboard)
        {
            DIRECTIONS d = GetDirection(from.Location, to.Location);
            if (!IsDiagonal(from.Location, to.Location))
            {
                return false;
            }
            string enemy = "";
            if (from.Side == "White")
                enemy = "Black";
            else if (from.Side == "Black")
                enemy = "White";
            else
            {
                return false;
            }
            bool isValid = false;

            switch (d)
            {
                case DIRECTIONS.DIAGONAL_RB_LT:
                    if (ValidateDiagonalRightBotLeftTop(from.Location, to.Location, gameboard, from.Side, enemy))
                    {
                        isValid = true;
                    }
                    break;
                case DIRECTIONS.DIAGONAL_LT_RB:
                    if (ValidateDiagonalLeftTopRightBot(from.Location, to.Location, gameboard, from.Side, enemy))
                    {
                        isValid = true;
                    }
                    break;
                case DIRECTIONS.DIAGONAL_LB_RT:
                    if (ValidateDiagonalLeftBotRightTop(from.Location, to.Location, gameboard, from.Side, enemy))
                    {
                        isValid = true;
                    }
                    break;
                case DIRECTIONS.DIAGONAL_RT_LB:
                    if (ValidateDiagonalRightTopLeftBot(from.Location, to.Location, gameboard, from.Side, enemy))
                    {
                        isValid = true;
                    }
                    break;
                default:
                    break;
            }

            return isValid;
        }

        static private bool ValidateDiagonalRightBotLeftTop(Point from, Point to, GameBoardForm gameboard, string player, string enemy)
        {
            Point p = new Point();
            Figure f = null;
            int start = from.X, end = to.X, counter = 0, iterations = 0, x = 0, y = 0;
            x = from.X;
            y = from.Y;
            iterations = Math.Abs(start - end) / 64;
            bool isValid = false;

            for (int i = 0; i < iterations; i++)
            {
                x -= 64;
                y -= 64;
                p = new Point(x, y);
                gameboard.GetFigureOnPoint(p, ref f);
                if (player == f.Side)
                    continue;
                else if (f.Side == "None")
                {
                    gameboard.FromFigure.FigureWay.Add(p);
                    counter++;
                }
                else if (f.Side == enemy)
                    continue;
            }

            if (counter == iterations)
                isValid = true;
            else
                isValid = false;

            return isValid;
        }

        static private bool ValidateDiagonalLeftTopRightBot(Point from, Point to, GameBoardForm gameboard, string player, string enemy)
        {
            Point p = new Point();
            Figure f = null;
            int start = from.X, end = to.X, counter = 0, iterations = 0, x = 0, y = 0;
            x = from.X;
            y = from.Y;
            iterations = Math.Abs(start - end) / 64;
            bool isValid = false;

            for (int i = 0; i < iterations; i++)
            {
                x += 64;
                y += 64;
                p = new Point(x, y);
                gameboard.GetFigureOnPoint(p, ref f);
                if (player == f.Side)
                    continue;
                else if (f.Side == "None")
                {
                    gameboard.FromFigure.FigureWay.Add(p);
                    counter++;
                }
                else if (f.Side == enemy)
                    continue;
            }

            if (counter == iterations)
                isValid = true;
            else
                isValid = false;

            return isValid;
        }

        static private bool ValidateDiagonalLeftBotRightTop(Point from, Point to, GameBoardForm gameboard, string player, string enemy)
        {
            int x = 0, y = 0, start = from.X, end = to.X, counter = 0, iterations = 0;
            Point p = new Point();
            Figure f = null;
            x = from.X;
            y = from.Y;
            iterations = Math.Abs(start - end) / 64;
            bool isValid = false;
            for (int i = 0; i < iterations; i++)
            {
                x += 64;
                y -= 64;
                p = new Point(x, y);
                gameboard.GetFigureOnPoint(p, ref f);
                if (player == f.Side)
                    continue;
                else if (f.Side == "None")
                {
                    gameboard.FromFigure.FigureWay.Add(p);
                    counter++;
                }
                else if (f.Side == enemy)
                    continue;
            }

            if (counter == iterations)
                isValid = true;
            else
                isValid = false;

            return isValid;
        }

        static private bool ValidateDiagonalRightTopLeftBot(Point from, Point to, GameBoardForm gameboard, string player, string enemy)
        {
            int x = 0, y = 0, start = from.X, end = to.X, counter = 0, iterations = 0;
            Point p = new Point();
            Figure f = null;
            x = from.X;
            y = from.Y;
            iterations = Math.Abs(start - end) / 64;
            bool isValid = false;
            for (int i = 0; i < iterations; i++)
            {
                x -= 64;
                y += 64;
                p = new Point(x, y);
                gameboard.GetFigureOnPoint(p, ref f);
                if (player == f.Side)
                    continue;
                else if (f.Side == "None")
                {
                    gameboard.FromFigure.FigureWay.Add(p);
                    counter++;
                }
                else if (f.Side == enemy)
                    continue;
            }

            if (counter == iterations)
                isValid = true;
            else
                isValid = false;

            return isValid;
        }

        static private bool ForOrdinary(int start, int end, int iterations, int constCoord, GameBoardForm gameboard, string player, string enemy, string direction)
        {
            Point p = new Point();
            int counter = 0;
            Figure f = null;
            if (start < end)
            {
                for (int i = start; i <= end; i += 64)
                {
                    p = GetPoint(i, constCoord, direction);
                    if (gameboard.IsFigureOnPoint(p))
                    {
                        gameboard.GetFigureOnPoint(p, ref f);
                        if (player == f.Side)
                            continue;
                        else if (f.Side == "None")
                        {
                            gameboard.FromFigure.FigureWay.Add(p);
                            counter++;
                        }
                        else if (f.Side == enemy)
                            continue;
                    }
                }
            }
            else
            {
                return false;
            }
            if (counter == iterations)
                return true;
            else
                return false;
        }

        private static bool ForReverse(int start, int end, int iterations, int constCoord, GameBoardForm gameboard, string player, string enemy, string direction)
        {
            Point p = new Point();
            int counter = 0;
            Figure f = null;
            if (start > end)
            {
                for (int i = start; i >= end; i -= 64)
                {
                    p = GetPoint(i, constCoord, direction);
                    if (gameboard.IsFigureOnPoint(p))
                    {
                        gameboard.GetFigureOnPoint(p, ref f);
                        if (player == f.Side)
                            continue;
                        else if (f.Side == "None")
                        {
                            gameboard.FromFigure.FigureWay.Add(p);
                            counter++;
                        }
                        else if (f.Side == enemy)
                            continue;
                    }
                }
            }
            else
            {
                return false;
            }
            if (counter == iterations)
                return true;
            else
                return false;
        }

        static private Point GetPoint(int x, int constCoord, string direction)
        {
            direction = direction.ToUpper();
            switch (direction)
            {
                case "RIGHT":
                case "LEFT":
                    return new Point(x, constCoord);
                case "BOT":
                case "TOP":
                    return new Point(constCoord, x);
                default:
                    throw new Exception("Invalid coordinates");
            }
        }
        static public DIRECTIONS GetDirection(Point from, Point to)
        {
            DIRECTIONS d = DIRECTIONS.NULL;
            if (IsHorizontal(from, to))
            {
                if (from.X > to.X)
                    d = DIRECTIONS.LEFT;
                else if (from.X < to.X)
                    d = DIRECTIONS.RIGHT;
            }
            else if (IsVertical(from, to))
            {
                if (from.Y > to.Y)
                    d = DIRECTIONS.TOP;
                else if (from.Y < to.Y)
                    d = DIRECTIONS.BOT;
            }
            else if (IsDiagonal(from, to))
            {
                if (from.X > to.X && from.Y > to.Y)
                {
                    d = DIRECTIONS.DIAGONAL_RB_LT;
                }
                else if (from.X < to.X && from.Y < to.Y)
                {
                    d = DIRECTIONS.DIAGONAL_LT_RB;
                }
                else if (from.X < to.X && from.Y > to.Y)
                {
                    d = DIRECTIONS.DIAGONAL_LB_RT;
                }
                else if (from.X > to.X && from.Y < to.Y)
                {
                    d = DIRECTIONS.DIAGONAL_RT_LB;
                }
            }
            return d;
        }
    }
}
