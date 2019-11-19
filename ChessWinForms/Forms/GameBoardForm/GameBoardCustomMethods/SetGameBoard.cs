using ChessWinForms.Classes;
using ChessWinForms.Classes.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessWinForms.Forms.nGameBoardForm
{
    public partial class GameBoardForm
    {
        #region SET GAMEBOARD
        private void SetGameBoard()
        {
            GBoard.Margin = new Padding(0);

            #region DEFAULT
            /*
            if (TryLoadFile(Scenario))
            {
                SetGameBoardAfterFileLoad();
            }
            else
            {
                SetGameBoardNoLoad();
            }
            */
            #endregion

            #region STALEMATE
            /*
            Player = "White";
            SituationsGenerator.StaleMate(this);

            RefillFiguresList();
            RefillPointsLists();
            */
            #endregion

            #region CHECKMATE
            /*
            Player = "White";
            SituationsGenerator.CheckMate(this);

            RefillFiguresList();
            RefillPointsLists();
            */
            #endregion

            #region CASTLING
            /*
            Player = "White";
            SituationsGenerator.Castling(this);

            RefillFiguresList();
            RefillPointsLists();
            */
            #endregion

            #region TAKE PAWN ON WAY
            /*
            SituationsGenerator.TakePawnOnMove(this);
            RefillFiguresList();
            RefillPointsLists();
            */
            #endregion

            #region CHANGE PAWN
            /*
            SituationsGenerator.ChangePawn(this);
            RefillFiguresList();
            RefillPointsLists();
            */
            #endregion
        }

        private void SetGameBoardNoLoad()
        {
            Button b = null;
            Type t = null;
            string side = "";
            int moves = 0;

            for (int i = 0; i < GBoard.RowCount; i++)
            {
                for (int j = 0; j < GBoard.ColumnCount; j++)
                {
                    b = GetButton();
                    if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        b.BackColor = Color.Coral;
                    }
                    if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                    {
                        b.BackColor = Color.White;
                    }

                    if (i >= 2 && i < 6) // space
                    {
                        t = typeof(Space);
                        side = "None";
                        moves = 0;
                    }
                    else if (i == 6) // white pawns
                    {
                        t = typeof(Pawn);
                        side = "White";
                        moves = 2;
                    }
                    else if (i == 1) // black pawns
                    {
                        t = typeof(Pawn);
                        side = "Black";
                        moves = 2;
                    }
                    else if ((i == 7 && j == 0) || (i == 7 && j == 7)) // white rooks
                    {
                        t = typeof(Rook);
                        side = "White";
                        moves = 8;
                    }
                    else if ((i == 0 && j == 0) || (i == 0 && j == 7)) // black rooks
                    {
                        t = typeof(Rook);
                        side = "Black";
                        moves = 8;
                    }
                    else if ((i == 7 && j == 1) || (i == 7 && j == 6)) // white knights
                    {
                        t = typeof(Knight);
                        side = "White";
                        moves = -1;
                    }
                    else if ((i == 0 && j == 1) || (i == 0 && j == 6)) // black knights
                    {
                        t = typeof(Knight);
                        side = "Black";
                        moves = -1;
                    }
                    else if ((i == 7 && j == 2) || (i == 7 && j == 5)) // white bishops
                    {
                        t = typeof(Bishop);
                        side = "White";
                        moves = 8;
                    }
                    else if ((i == 0 && j == 2) || (i == 0 && j == 5)) // black bishops
                    {
                        t = typeof(Bishop);
                        side = "Black";
                        moves = 8;
                    }
                    else if (i == 7 && j == 4) // white king
                    {
                        t = typeof(King);
                        side = "White";
                        moves = 1;
                    }
                    else if (i == 0 && j == 4) // black king
                    {
                        t = typeof(King);
                        side = "Black";
                        moves = 1;
                    }
                    else if (i == 7 && j == 3) // white queen
                    {
                        t = typeof(Queen);
                        side = "White";
                        moves = 8;
                    }
                    else if (i == 0 && j == 3) // black queen
                    {
                        t = typeof(Queen);
                        side = "Black";
                        moves = 8;
                    }

                    SetButton(ref b, t, side, moves);
                    GBoard.Controls.Add(b);
                    if ((b.Tag != null))
                    {
                        (b.Tag as Figure).Location = b.Location;
                    }

                    if ((b.Tag is King))
                    {
                        if (side == "White")
                        {
                            WhiteKing = new Point(b.Location.X, b.Location.Y);
                        }
                        else if (side == "Black")
                        {
                            BlackKing = new Point(b.Location.X, b.Location.Y);
                        }
                    }

                    DefaultBoardColors.Add(b.BackColor);
                }
            }

            RefillFiguresList();
            RefillPointsLists();
            ResetKingsPositions();
        }

        private void SetGameBoardAfterFileLoad()
        {
            Button b = null;
            string name = "", side = "";

            // populate gameboard with buttons
            for (int i = 0; i < GBoard.RowCount; i++)
            {
                for (int j = 0; j < GBoard.ColumnCount; j++)
                {
                    b = GetButton();
                    if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        b.BackColor = Color.Coral;
                    }
                    if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                    {
                        b.BackColor = Color.White;
                    }

                    GBoard.Controls.Add(b);
                    DefaultBoardColors.Add(b.BackColor);
                }
            }

            // attach corresponding figure to each button
            for (int i = 0; i < GBoard.Controls.Count; i++)
            {
                for (int j = 0; j < AllFigures.Count; j++)
                {
                    if (GBoard.Controls[i].Location.Equals(AllFigures[j].Location))
                    {
                        GBoard.Controls[i].Tag = generator.GetFigureInSwap(AllFigures[j]);
                        if ((GBoard.Controls[i].Tag as Figure).Name != "Space")
                        {
                            name = AllFigures[j].Name.ToLower();
                            side = AllFigures[j].Side.ToLower();
                            GBoard.Controls[i].BackgroundImage = SetImage(name, side);
                        }
                    }
                }
                (GBoard.Controls[i].Tag as Figure).GameBoard = this;
            }

            RefillFiguresList();
            RefillPointsLists();
            ResetKingsPositions();
        }

        public Button GetButton()
        {
            Button b = new Button();
            b.Dock = DockStyle.Fill;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.Margin = new Padding(0);
            b.Click += Figure_Click;
            return b;
        }

        private void SetButton(ref Button b, Type t, string side, int moves)
        {
            b.Tag = (Figure)generator.GetFigureStart(t, t.Name, side, moves, 64, this);

            if ((b.Tag as Figure).Name != "Space")
            {
                b.BackgroundImage = SetImage(t.Name.ToLower(), side.ToLower());
            }
        }

        private bool TryLoadFile(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return false;
            }
            type = type.ToLower();
            string path = "";
            switch (type)
            {
                case "standard":
                    {
                        path = PathStandartBoard;
                        break;
                    }
                case "saved":
                    {
                        path = PathSavedBoard;
                        break;
                    }
                case "stalemate":
                    {
                        path = PathStaleMate;
                        break;
                    }
                case "checkmate":
                    {
                        path = PathCheckMate;
                        break;
                    }
                case "castling_normal":
                    {
                        path = PathCastlingNormal;
                        break;
                    }
                case "castling_no_between":
                    {
                        path = PathCastlingNoBetween;
                        break;
                    }
                case "take_pawn_on_move":
                    {
                        path = PathTakePawnOnMove;
                        break;
                    }
                default:
                    break;
            }
            AllFigures = read.ReadFile(path, new List<Figure>());
            return AllFigures.Any();
        }

        private Image SetImage(string type, string side)
        {
            return Image.FromFile($@"../../pictures/figures/{type}_{side}.png");
        }
        #endregion


    }
}
