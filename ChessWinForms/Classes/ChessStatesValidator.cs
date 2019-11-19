using ChessWinForms.Classes.Figures;
using ChessWinForms.Forms.nGameBoardForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ChessWinForms.Forms.nGameBoardForm.GameBoardForm;

namespace ChessWinForms.Classes
{
    public class ChessStatesValidator
    {
        GameBoardForm GameBoard;
        List<Button> gBoard;
        public ChessStatesValidator()
        {

        }

        public ChessStatesValidator(GameBoardForm gb)
        {
            GameBoard = gb;
        }

        public bool ValidateCheck(string player)
        {
            List<Point> attackers = null;
            Figure attacker = null, king = null;

            if (player == "White")
            {
                attackers = GameBoard.WhiteFiguresLocations;
                king = GameBoard.GetFigureByPoint(GameBoard.BlackKing);
            }
            else
            {
                attackers = GameBoard.BlackFiguresLocations;
                king = GameBoard.GetFigureByPoint(GameBoard.WhiteKing);
            }

            for (int i = 0; i < attackers.Count; i++)
            {
                attacker = GameBoard.GetFigureByPoint(attackers[i]);
                if (attacker.Attack(king))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateCheckMate(string player)
        {
            Figure king = null, attacker = null;
            List<Point> attackers = null;
            if (player == "White")
            {
                attackers = GameBoard.WhiteFiguresLocations;
                king = GameBoard.GetFigureByPoint(GameBoard.BlackKing);
            }
            else
            {
                attackers = GameBoard.BlackFiguresLocations;
                king = GameBoard.GetFigureByPoint(GameBoard.WhiteKing);
            }

            for (int i = 0; i < attackers.Count; i++)
            {
                attacker = GameBoard.GetFigureByPoint(attackers[i]);
                if (CanKingMove(king) || CanKingBeCovered(king, attacker) || CanAttackerBeTaken(attacker))
                {
                    return true;
                }
            }

            if (CanKingMove(king) || CanKingBeCovered(king, attacker) || CanAttackerBeTaken(attacker))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidateStaleMate()
        {
            if ((!CanKingMove(GameBoard.GetFigureByPoint(GameBoard.WhiteKing)) && !CanPlayerMoveFigures("White"))
                || (!CanKingMove(GameBoard.GetFigureByPoint(GameBoard.BlackKing)) && !CanPlayerMoveFigures("Black")))
            {
                return true;
            }

            return false;
        }

        public bool ValidateCastling(GameBoardForm gb)
        {
            if (gb.FromFigure is King && gb.ToFigure is Rook)
            {
                if (gb.FromFigure.Side == gb.ToFigure.Side)
                {
                    if (gb.FromFigure.HasMoved && gb.FromFigure.HasMoved)
                    {
                        return false;
                    }
                    DIRECTIONS d = DIRECTIONS.NULL;
                    int xF = gb.FromFigure.Location.X;
                    int xT = gb.ToFigure.Location.X;
                    int res = (Math.Abs(xF - xT) / 64) - 1;
                    d = DirectionValidator.GetDirection(gb.FromFigure.Location, gb.ToFigure.Location);
                    if (IsWayForCastlingFree(d, gb))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ValidateTakePawnOnMove(GameBoardForm gb, ref Figure taker, ref Point position)
        {
            List<Figure> opponentsPawns = GetPawns(gb);
            Figure attacker = null;
            Figure space = null;
            for (int i = 0; i < opponentsPawns.Count; i++)
            {
                attacker = opponentsPawns[i];
                attacker.SetPossibleMoves();
                attacker.SetPossibleAttacks();
                for (int j = 0; j < gb.FromFigure.FigureWay.Count; j++)
                {
                    space = gb.GetFigureByPoint(gb.FromFigure.FigureWay[j]);
                    if (opponentsPawns[i].Attack(space))
                    {
                        position = gb.FromFigure.FigureWay[j];
                        taker = attacker;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool ValidatePawnChange(Figure pawn)
        {
            if (pawn.Location.Y == (pawn as Pawn).End)
            {
                return true;
            }

            return false;
        }

        private List<Figure> GetPawns(GameBoardForm gb)
        {
            List<Figure> pawns = gb.AllFigures.Where(x => (x.Side == gb.Opponent && x.GetType() == typeof(Pawn))).ToList();
            return pawns;
        }

        private bool IsWayForCastlingFree(DIRECTIONS d, GameBoardForm gb)
        {
            Figure nextF = null;
            Point curr = new Point(gb.FromFigure.Location.X, gb.FromFigure.Location.Y);
            Point next = new Point();
            int iterations = Math.Abs(gb.FromFigure.Location.X - gb.ToFigure.Location.X) / 64;
            int counter = 0;
            for (int i = 0; i < iterations; i++)
            {
                next = NextPointGenerator.GetNextPoint(d, curr);
                nextF = gb.GetFigureByPoint(next);
                if (nextF is Space)
                {
                    counter++;
                }
                curr = new Point(next.X, next.Y);
            }

            if (counter == (iterations - 1))
            {
                return true;
            }
            return false;
        }

        private bool CanPlayerMoveFigures(string player)
        {
            List<Point> playersFigures = null, opponentsFigures = null, spaces = null;
            Figure currPlayer = null, opponent = null, space = null, playersKing = null;
            int posFrom = 0, posTo = 0, cantMove = 0;
            bool wasChecked = false;

            switch (player)
            {
                case "White":
                    {
                        playersFigures = GameBoard.WhiteFiguresLocations;
                        opponentsFigures = GameBoard.BlackFiguresLocations;
                        playersKing = GameBoard.GetFigureByPoint(GameBoard.WhiteKing);
                        break;
                    }
                case "Black":
                    {
                        playersFigures = GameBoard.BlackFiguresLocations;
                        opponentsFigures = GameBoard.WhiteFiguresLocations;
                        playersKing = GameBoard.GetFigureByPoint(GameBoard.BlackKing);
                        break;
                    }
                default:
                    break;
            }
            spaces = GameBoard.SpacesLocations;
            gBoard = GameBoard.GetGBoard();

            for (int i = 0; i < playersFigures.Count; i++) // loop through player's figures
            {
                currPlayer = GetFigureByPoint(playersFigures[i]);
                posFrom = GetButtonPosition(currPlayer);
                for (int j = 0; j < spaces.Count; j++) // try to move to any of spaces
                {
                    space = GetFigureByPoint(spaces[j]);
                    posTo = GetButtonPosition(space);
                    if (currPlayer.Move(space))
                    {
                        Swap(posFrom, posTo);
                        for (int k = 0; k < opponentsFigures.Count; k++) // loop through opponent's figures and try to check plaer's king
                        {
                            opponent = GetFigureByPoint(opponentsFigures[k]);
                            if (opponent.Attack(playersKing))
                            {
                                wasChecked = true;
                                gBoard = null;
                                gBoard = GameBoard.GetGBoard();
                                break;
                            }
                        }
                    }
                    else
                    {
                        cantMove++;
                        break;
                    }
                    posTo = -1;
                }
                if (wasChecked)
                {
                    cantMove++;
                    wasChecked = false;
                }
                posFrom = -1;
            }

            if (cantMove != playersFigures.Count)
            {
                return true;
            }

            return false;
        }

        private void Swap(int posF, int posT)
        {
            if (posF != -1 && posT != -1)
            {
                Point fr = (gBoard[posF].Tag as Figure).Location;
                Point t = (gBoard[posT].Tag as Figure).Location;
                Button tmp = gBoard[posF].CloneButton();
                gBoard[posF] = gBoard[posT];
                gBoard[posT] = tmp;

                (gBoard[posF].Tag as Figure).Location = new Point(fr.X, fr.Y);
                (gBoard[posT].Tag as Figure).Location = new Point(t.X, t.Y);
            }
        }

        private int GetButtonPosition(Figure f)
        {
            Point curr = new Point();
            int pos = -1;
            for (int i = 0; i < gBoard.Count; i++)
            {
                curr = (gBoard[i].Tag as Figure).Location;
                if (curr.Equals(f.Location))
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public Figure GetFigureByPoint(Point p)
        {
            Figure f = null;

            for (int i = 0; i < gBoard.Count; i++)
            {
                if (gBoard[i].Location.Equals(p))
                {
                    f = (Figure)gBoard[i].Tag;
                }
            }

            return f;
        }

        private bool CanKingMove(Figure king)
        {
            King k = (king as King);
            List<Point> allies = null;
            if (k.Side == "White")
            {
                allies = GameBoard.WhiteFiguresLocations;
            }
            else
            {
                allies = GameBoard.BlackFiguresLocations;
            }

            int safeZone = 0;
            k.SetSurrounding();

            if (!k.Surrounding.Any())
            {
                return false;
            }

            for (int i = 0; i < allies.Count; i++)
            {
                for (int j = 0; j < k.Surrounding.Count; j++)
                {
                    if (allies[i].Equals(k.Surrounding[j]))
                    {
                        safeZone++;
                    }
                }
            }

            for (int i = 0; i < GameBoard.SpacesLocations.Count; i++)
            {
                for (int j = 0; j < k.Surrounding.Count; j++)
                {
                    if (GameBoard.SpacesLocations[i].Equals(k.Surrounding[j]))
                    {
                        safeZone++;
                    }
                }
            }

            if (safeZone == k.Surrounding.Count)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < GameBoard.SpacesLocations.Count; i++)
                {
                    if (king.Move(GameBoard.GetFigureByPoint(GameBoard.SpacesLocations[i])))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private Figure GetKing(Figure from)
        {
            Point kingLocation = new Point();
            Figure king = null;
            if (from.Side == "White")
            {
                kingLocation = GameBoard.BlackKing;
            }
            else if (from.Side == "Black")
            {
                kingLocation = GameBoard.WhiteKing;
            }

            king = GameBoard.GetFigureByPoint(kingLocation);

            return king;
        }

        private bool CanKingBeCovered(Figure king, Figure from)
        {
            List<Point> defenders = null;
            Figure defender = null, wayPoint = null;
            if (king.Side == "White")
            {
                defenders = GameBoard.WhiteFiguresLocations;
            }
            else if (king.Side == "Black")
            {
                defenders = GameBoard.BlackFiguresLocations;
            }

            for (int i = 0; i < defenders.Count; i++)
            {
                defender = GameBoard.GetFigureByPoint(defenders[i]);
                for (int j = 0; j < from.FigureWay.Count; j++)
                {
                    wayPoint = GameBoard.GetFigureByPoint(from.FigureWay[j]);
                    if (defender.Move(wayPoint))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CanAttackerBeTaken(Figure from)
        {
            List<Point> attackers = null;
            Figure attacker = null;
            if (from.Side == "White")
            {
                attackers = GameBoard.BlackFiguresLocations;
            }
            else if (from.Side == "Black")
            {
                attackers = GameBoard.WhiteFiguresLocations;
            }

            for (int i = 0; i < attackers.Count; i++)
            {
                attacker = GameBoard.GetFigureByPoint(attackers[i]);
                if (attacker.Attack(from))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
