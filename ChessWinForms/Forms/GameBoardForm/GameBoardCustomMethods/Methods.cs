using ChessWinForms.Classes;
using ChessWinForms.Classes.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WriteRead.Classes;

namespace ChessWinForms.Forms.nGameBoardForm
{
    public partial class GameBoardForm
    {
        #region GAMEBOARD PUBLIC METHODS
        public bool IsFigureOnPoint(Point p)
        {
            for (int i = 0; i < GBoard.Controls.Count; i++)
            {
                if ((GBoard.Controls[i] as Button).Location.Equals(p))
                    return true;
            }
            return false;
        }

        public void GetFigureOnPoint(Point p, ref Figure f)
        {
            for (int i = 0; i < GBoard.Controls.Count; i++)
            {
                if ((GBoard.Controls[i] as Button).Location.Equals(p))
                {
                    f = (GBoard.Controls[i].Tag as Figure);
                    return;
                }
            }
            f = null;
        }

        public Figure GetFigureByPoint(Point p)
        {
            Figure f = null;
            for (int i = 0; i < GBoard.Controls.Count; i++)
            {
                if ((GBoard.Controls[i].Tag as Figure).Location.Equals(p))
                {
                    f = (Figure)GBoard.Controls[i].Tag;
                }
            }

            return f;
        }

        public List<Button> GetGBoard()
        {
            List<Button> buttons = new List<Button>();
            Button b = null;
            for (int i = 0; i < GBoard.Controls.Count; i++)
            {
                b = GBoard.Controls[i] as Button;
                buttons.Add(b.CloneButton());
            }

            return buttons;
        }
        #endregion

        #region MESSAGES
        private void Message(Button sender)
        {
            Figure f = (sender.Tag as Figure);
            //MessageBox.Show($"CLICKED: {f.Location}, {f.Name}, {f.Side}");
            //MessageBox.Show($"HAS MOVED: {f.HasMoved}"); ;
            //MessageBox.Show($"LOCATION: {sender.Location}");
            MessageBox.Show($"TYPE: {sender.Tag.GetType()}");
        }

        private void StaleMate()
        {
            MessageBox.Show("Stalemate!", "Stalemate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IsCheckmate = true;
            this.Close();
        }

        private void Check()
        {
            MessageBox.Show($"Check to {Opponent} king", "Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Checkmate()
        {
            MessageBox.Show($"Checkmate to {Opponent} king!", "Checkmate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IsCheckmate = true;
            this.Close();
        }
        #endregion

        #region RESETS AND REFILLS
        private void ResetAll()
        {
            ResetPoints();
            RefillFiguresList();
            RefillPointsLists();
        }

        private void ResetPoints()
        {
            FromPoint = new Point(NullPoint.X, NullPoint.Y);
            ToPoint = new Point(NullPoint.X, NullPoint.Y);
        }

        private void RefillPointsLists()
        {
            WhiteFiguresLocations.Clear();
            BlackFiguresLocations.Clear();
            SpacesLocations.Clear();
            for (int i = 0; i < AllFigures.Count; i++)
            {
                if (AllFigures[i].Side == "White")
                {
                    WhiteFiguresLocations.Add(AllFigures[i].Location);
                }
                else if (AllFigures[i].Side == "Black")
                {
                    BlackFiguresLocations.Add(AllFigures[i].Location);
                }
                else
                {
                    SpacesLocations.Add(AllFigures[i].Location);
                }
            }
        }

        private void RefillFiguresList()
        {
            AllFigures.Clear();
            Figure curr = null;
            for (int i = 0; i < GBoard.Controls.Count; i++)
            {
                curr = (GBoard.Controls[i].Tag as Figure);
                AllFigures.Add(curr);
            }
        }
        #endregion

        private void AddItemToHistory()
        {
            string arrow = "→";
            string from = $"{FromFigure.Side} {FromFigure.Name}";
            string to = $"{ToFigure.Side} {ToFigure.Name}";
            string move = $"{from} ({FromFigure.Location}) {arrow} {to} ({ToFigure.Location})";
            lbxHistoryOfMoves.Items.Add(move);
        }

        private void SetAll()
        {
            ChessValidator = new ChessStatesValidator(this);
            AllFigures = new List<Figure>();
            NullPoint = new Point(-1, -1);
            WhiteFiguresLocations = new List<Point>();
            BlackFiguresLocations = new List<Point>();
            SpacesLocations = new List<Point>();
            HighLightPoints = new List<Point>();
            ToCoverPoints = new List<Point>();
            generator = new FigureGenerator();
            DefaultBoardColors = new List<Color>();
            Player = "White";
            Opponent = "Black";
            SetFormText();
            ResetPoints();
            chbxToggleHighlight.Checked = true;
            write = new Write<List<Figure>>("xml", AllFigures);
            read = new Read<List<Figure>>("xml", new List<Figure>());
            PathStandartBoard = @"../../Figures/figures_list.xml";
            PathSavedBoard = @"../../Figures/figures_list_saved_game.xml";
            PathStaleMate = @"../../Figures/figures_list_stalemate.xml";
            PathCheckMate = @"../../Figures/figures_list_checkmate.xml";
            PathCastlingNoBetween = @"../../Figures/figures_list_castling_no_between.xml";
            PathCastlingNormal = @"../../Figures/figures_list_castling_normal.xml";
            PathTakePawnOnMove = @"../../Figures/figures_list_take_pawn_on_way.xml";
            PathChangePawn = @"../../Figures/figures_list_change_pawn.xml";
            SetGameBoard();
            SetInfoTextStart();
            spaceF = generator.GetFigureStart(typeof(Space), "Space", "None", 0, 64, this);
            SelectFigure = new SelectFigureToChangeForm(this);
        }
    }
}
