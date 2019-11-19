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
        #region SET GAMEBOARD
        private void SetGameBoard()
        {
            GBoard.Margin = new Padding(0);

            #region DEFAULT
            
            if (TryLoadFile(Scenario))
            {
                SetGameBoardAfterFileLoad();
            }
            else
            {
                SetGameBoardNoLoad();
            }
            
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

        #region ACTIONS ON GAMEBOARD

        private void Figure_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

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
                else
                {
                    PerformAction = fromFigure.Move;
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
        #endregion

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
                if (GBoard.Controls[i].Location == p)
                    f = (Figure)GBoard.Controls[i].Tag;
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

        #region RESETS AND REFILLS
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

        #region HIGHLIGHTS
        private void HighlightPath()
        {
            ToCoverPoints.Clear();
            if (fromFigure != null)
            {
                if (fromFigure is Pawn)
                {
                    HighLightPawnEnemies();
                }
                HighLightNormal();
                if (ToCoverPoints.Any())
                {
                    HighLightCover();
                }
            }
        }

        private void HighLightPawnEnemies()
        {
            List<Point> pawnAttacks = new List<Point>();

            Figure pAttack = null;

            (fromFigure as Pawn).SetPossibleAttacks();

            pawnAttacks = (fromFigure as Pawn).PossibleAttacks;

            for (int i = 0; i < pawnAttacks.Count; i++)
            {
                pAttack = GetFigureByPoint(pawnAttacks[i]);

                if (pAttack == null)
                {
                    break;
                }

                if (pAttack.Side == Opponent && fromFigure.Attack(pAttack))
                {
                    GBoard.Controls[GetButtonPosition(pAttack)].BackColor = Color.Red;
                    ToCoverPoints.Add(GBoard.Controls[GetButtonPosition(pAttack)].Location);
                }
            }
        }

        private void HighLightNormal()
        {
            Figure f = null;

            HighLightPoints = fromFigure.SetHighLightPoints();

            for (int i = 0; i < GBoard.Controls.Count; i++)
            {
                for (int j = 0; j < HighLightPoints.Count; j++)
                {
                    if (GBoard.Controls[i].Location.Equals(HighLightPoints[j]))
                    {
                        GetFigureOnPoint(HighLightPoints[j], ref f);
                        if (f.Side == Opponent)
                        {
                            GBoard.Controls[i].BackColor = Color.Red;
                            ToCoverPoints.Add(GBoard.Controls[i].Location);
                        }
                        else if (f.Side == "None")
                        {
                            GBoard.Controls[i].BackColor = Color.Green;
                        }
                    }
                }
            }
        }

        private void HighLightCover()
        {
            List<Figure> CoverFigures = new List<Figure>();
            List<Point> DefenderPoints = new List<Point>();
            List<Figure> ToCoverFigures = new List<Figure>();
            List<int> positions = new List<int>();
            Figure space = null;
            Figure cover = null;
            int pos = 0;

            // set defender points
            if (fromFigure.Side == "White")
            {
                DefenderPoints.AddRange(BlackFiguresLocations.ToArray());
            }
            else if (fromFigure.Side == "Black")
            {
                DefenderPoints.AddRange(WhiteFiguresLocations.ToArray());
            }
            else
            {
                return;
            }

            // set defender figures
            for (int i = 0; i < DefenderPoints.Count; i++)
            {
                CoverFigures.Add(GetFigureByPoint(DefenderPoints[i]));
            }

            for (int i = 0; i < ToCoverPoints.Count; i++)
            {
                pos = GetButtonPosition(GetFigureByPoint(ToCoverPoints[i]));
                if (!positions.Contains(pos))
                {
                    positions.Add(pos);
                    ToCoverFigures.Add((Figure)GBoard.Controls[pos].Tag);
                }


                space = generator.GetFigureStart(typeof(Space), "Space", "None", 0, 64, this);
                space.Location = ToCoverPoints[i];
                GBoard.Controls[pos].Tag = generator.GetFigureInSwap(space);
            }

            for (int i = 0; i < CoverFigures.Count; i++)
            {
                cover = CoverFigures[i];
                for (int j = 0; j < ToCoverFigures.Count; j++)
                {
                    if (cover.Move(ToCoverFigures[j]))
                    {
                        pos = GetButtonPositionByPoint(CoverFigures[i].Location);
                        if (pos != -1)
                        {
                            GBoard.Controls[pos].BackColor = Color.Violet;
                        }
                    }
                }
            }

            for (int i = 0; i < positions.Count; i++)
            {
                GBoard.Controls[positions[i]].Tag = generator.GetFigureInSwap(ToCoverFigures[i]);
            }
        }

        private void ResetBoardColors()
        {
            for (int i = 0; i < DefaultBoardColors.Count; i++)
            {
                GBoard.Controls[i].BackColor = DefaultBoardColors[i];
            }
        }

        private void CheckForReset()
        {
            if (toFigure != null)
            {
                ResetBoardColors();
            }
        }

        private void SetPictureBoxesAndLabels()
        {
            labGreen.Text = "Possible moves";
            labRed.Text = "Potentional attacks";
            labViolet.Text = "Cover for potentional attacks";
            pbxGreen.BackColor = Color.Green;
            pbxRed.BackColor = Color.Red;
            pbxViolet.BackColor = Color.Violet;
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

        private void AddItemToHistory()
        {
            string arrow = "→";
            string from = $"{FromFigure.Side} {FromFigure.Name}";
            string to = $"{ToFigure.Side} {ToFigure.Name}";
            string move = $"{from} ({FromFigure.Location}) {arrow} {to} ({ToFigure.Location})";
            lbxHistoryOfMoves.Items.Add(move);
        }
    }
}
