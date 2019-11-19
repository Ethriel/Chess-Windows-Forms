using ChessWinForms.Classes;
using ChessWinForms.Classes.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessWinForms.Forms.GameBoardForm
{
    public partial class GameBoardForm
    {
        #region ACTIONS ON GAMEBOARD

        private void Figure_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            //Message(b);

            if (fromFigure == null && (b.Tag as Figure).Side == "None")
            {
                return;
            }

            if (fromFigure == null)
            {
                if (!IsPlayerCorrect(b))
                {
                    return;
                }
            }

            SetFromAndTo(b.Tag.GetType(), b);

            SetInfoText();

            (b.Tag as Figure).SetAllNeeded();

            if (chbxToggleHighlight.Checked)
            {
                HighlightPath();
            }

            CheckForReset();

            TakeAction();
        }
        public void Act()
        {
            posFrom = GetButtonPosition(fromFigure);
            posTo = GetButtonPosition(toFigure);
            if (PerformAction == null)
            {
                return;
            }
            if (fromFigure == toFigure)
            {
            }
            else if (PerformAction(toFigure))
            {
                Swap();
                SwitchPlayer();
                SetFormText();
                AddItemToHistory();
            }
            else
            {
                MessageBox.Show("Invalid move", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            fromFigure = null;
            toFigure = null;
            PerformAction = null;
        }

        private int GetButtonPosition(Figure f)
        {
            Point curr = new Point(NullPoint.X, NullPoint.Y);
            int pos = -1;
            for (int i = 0; i < GBoard.Controls.Count; i++)
            {
                curr = ((GBoard.Controls[i] as Button).Tag as Figure).Location;
                if (curr.Equals(f.Location))
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        private void Swap()
        {
            FromPoint = new Point(fromFigure.Location.X, fromFigure.Location.Y);
            ToPoint = new Point(toFigure.Location.X, toFigure.Location.Y);
            Figure moved = null;
            if (posFrom != -1 && posTo != -1)
            {
                (GBoard.Controls[posFrom].Tag as Figure).HasMoved = true;
                Figure tmpFigure = SetCorrespondingFigure(fromFigure); // set tmp figure = from figure

                Image tmpImage = GBoard.Controls[posFrom].BackgroundImage;
                GBoard.Controls[posFrom].BackgroundImage = GBoard.Controls[posTo].BackgroundImage;
                GBoard.Controls[posTo].BackgroundImage = tmpImage;

                GBoard.Controls[posFrom].Tag = SetCorrespondingFigure(toFigure); // from = to
                GBoard.Controls[posTo].Tag = SetCorrespondingFigure(tmpFigure); // to = tmp (from)

                (GBoard.Controls[posFrom].Tag as Figure).Location = new Point(FromPoint.X, FromPoint.Y); // save locations
                (GBoard.Controls[posTo].Tag as Figure).Location = new Point(ToPoint.X, ToPoint.Y); // of figures at gameboard

                if (toFigure.Side == Opponent)
                {
                    if (toFigure is King)
                    {
                        Checkmate();
                    }
                    Figure space = generator.GetFigureStart(typeof(Space), "Space", "None", 0, 64, this);
                    space.Location = new Point(FromPoint.X, FromPoint.Y);
                    SpacesLocations.Add(space.Location);
                    GBoard.Controls[posFrom].BackgroundImage = null;
                    GBoard.Controls[posFrom].Tag = space;
                }

                RefillFiguresList();
                RefillPointsLists();
                ResetKingsPositions();

                moved = GetFigureByPoint(ToPoint);

                if (ChessValidator.ValidateCheck(Player))
                {
                    Check();
                    if (ChessValidator.ValidateCheckMate(Player))
                    {
                        Checkmate();
                    }
                }
                else
                {
                    if (ChessValidator.ValidateStaleMate())
                    {
                        StaleMate();
                    }
                }
                ResetPoints();
            }
        }

        private void SetFromAndTo(Type t, Button b)
        {
            generator.SetFromAndTo(t, b, ref fromFigure, ref toFigure);
        }

        private Figure SetCorrespondingFigure(Figure f)
        {
            return generator.GetFigureInSwap(f);
        }

        private void SwitchPlayer()
        {
            if (Player == "White")
            {
                Player = "Black";
                Opponent = "White";
            }
            else
            {
                Player = "White";
                Opponent = "Black";
            }
        }

        private void SetFormText()
        {
            this.Text = $@"{Player} player's move";
        }

        private bool IsPlayerCorrect(Button b)
        {
            if ((b.Tag as Figure).Side != Player && (b.Tag as Figure).Side != "None")
            {
                errorProvider.Clear();
                errorProvider.SetError(b, "This is not your figure");
                return false;
            }
            else
            {
                errorProvider.Clear();
                return true;
            }
        }

        public void TakeAction()
        {
            if (fromFigure != null && toFigure != null)
            {
                if (toFigure.Side == Opponent)
                {
                    PerformAction = fromFigure.Attack;
                }
                else if (toFigure.Side == "None")
                {
                    PerformAction = fromFigure.Move;
                }
                else if (FromFigure.Side == ToFigure.Side)
                {
                    Castling();
                }
                Act();
            }
        }

        private int GetButtonPositionByPoint(Point p)
        {
            int pos = -1;
            for (int i = 0; i < GBoard.Controls.Count; i++)
            {
                if (GBoard.Controls[i].Location.Equals(p))
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        private void ResetKingsPositions()
        {
            WhiteKing = WhiteFiguresLocations.Find(x => GetFigureByPoint(x).Name == "King");
            BlackKing = BlackFiguresLocations.Find(x => GetFigureByPoint(x).Name == "King");
        }

        private void SetInfoTextStart()
        {
            labInfoSelected.Text = "";
            labInfoOnto.Text = "";
        }

        private void SetInfoText()
        {
            string from = "";
            string to = "";

            if (fromFigure != null)
            {
                from = $"FROM: {fromFigure.Name}, {fromFigure.Side}";
                labInfoSelected.Text = from;
            }
            if (toFigure != null)
            {
                to = $"TO: {toFigure.Name}, {toFigure.Side}";
                labInfoOnto.Text = to;
            }
        }

        private void Castling()
        {
            if (ChessValidator.ValidateCastling(this))
            {
                DIRECTIONS d = DIRECTIONS.NULL;
                d = DirectionValidator.GetDirection(FromFigure.Location, ToFigure.Location);
                switch (d)
                {
                    case DIRECTIONS.RIGHT:
                        ShortCastling();
                        break;
                    case DIRECTIONS.LEFT:
                        LongCastling();
                        break;
                    default:
                        break;
                }
            }
        }

        private void LongCastling()
        {
            Point newKingLocation = new Point(FromFigure.Location.X - 128, FromFigure.Location.Y); // new location for king
            Point newRookLocation = new Point(ToFigure.Location.X + 192, ToFigure.Location.Y); // new location for rook
            PerformCastling(newKingLocation, newRookLocation);
        }

        private void ShortCastling()
        {
            Point newKingLocation = new Point(FromFigure.Location.X + 128, FromFigure.Location.Y); // new location for king
            Point newRookLocation = new Point(ToFigure.Location.X - 128, ToFigure.Location.Y); // new location for rook
            PerformCastling(newKingLocation, newRookLocation);
        }

        private void PerformCastling(Point newKingLocation, Point newRookLocation)
        {
            Figure tmpKing = generator.GetFigureInSwap(FromFigure); // tmp king
            Image kingImg = GBoard.Controls[GetButtonPosition(tmpKing)].BackgroundImage;

            Figure tmpRook = generator.GetFigureInSwap(ToFigure); // tmp rook
            Image rookImg = GBoard.Controls[GetButtonPosition(tmpRook)].BackgroundImage;

            int posForSpaceKing = GetButtonPosition(tmpKing); // position of king in board controls
            int posForSpaceRook = GetButtonPosition(tmpRook); // position of rook in board controls

            Figure spaceForKing = GetFigureByPoint(newKingLocation); // space, where king will be moved
            Figure spaceForRook = GetFigureByPoint(newRookLocation); // space, where rook will be moved

            int posForKingSpace = GetButtonPosition(spaceForKing); // position of space for king in board controls
            int posForRookSpace = GetButtonPosition(spaceForRook); // position of space for rook in board controls

            GBoard.Controls[posForKingSpace].Tag = generator.GetFigureInSwap(tmpKing);
            (GBoard.Controls[posForKingSpace].Tag as Figure).Location = new Point(newKingLocation.X, newKingLocation.Y);
            GBoard.Controls[posForKingSpace].BackgroundImage = kingImg;

            GBoard.Controls[posForSpaceKing].Tag = generator.GetFigureInSwap(spaceF);
            (GBoard.Controls[posForSpaceKing].Tag as Figure).Location = new Point(tmpKing.Location.X, tmpKing.Location.Y);
            GBoard.Controls[posForSpaceKing].BackgroundImage = null;

            GBoard.Controls[posForRookSpace].Tag = generator.GetFigureInSwap(tmpRook);
            (GBoard.Controls[posForRookSpace].Tag as Figure).Location = new Point(newRookLocation.X, newRookLocation.Y);
            GBoard.Controls[posForRookSpace].BackgroundImage = rookImg;

            GBoard.Controls[posForSpaceRook].Tag = generator.GetFigureInSwap(spaceF);
            (GBoard.Controls[posForSpaceRook].Tag as Figure).Location = new Point(tmpRook.Location.X, tmpRook.Location.Y);
            GBoard.Controls[posForSpaceRook].BackgroundImage = null;
        }

        #endregion
    }
}
