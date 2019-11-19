using ChessWinForms.Classes;
using ChessWinForms.Classes.Figures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WriteRead.Classes;

namespace ChessWinForms.Forms.GameBoardForm
{
    public delegate bool PerformAction(Figure to);
    [Serializable]
    public partial class GameBoardForm : Form
    {
        public enum DIRECTIONS
        {
            TOP,
            RIGHT,
            BOT,
            LEFT,
            DIAGONAL_RB_LT,
            DIAGONAL_LT_RB,
            DIAGONAL_LB_RT,
            DIAGONAL_RT_LB,
            NULL
        }
        MainForm Base;
        Figure fromFigure, toFigure, spaceF;
        FigureGenerator generator;
        PerformAction PerformAction;
        public List<Color> DefaultBoardColors;
        public List<Figure> AllFigures;
        Write<List<Figure>> write;
        Read<List<Figure>> read;
        public Figure FromFigure
        {
            get
            {
                return fromFigure;
            }
            set
            {
                if (value != null)
                    fromFigure = value;
            }
        }
        public Figure ToFigure
        {
            get
            {
                return toFigure;
            }
            set
            {
                if (value != null)
                    toFigure = value;
            }
        }
        ChessStatesValidator ChessValidator;
        public List<Point> WhiteFiguresLocations, BlackFiguresLocations, SpacesLocations, HighLightPoints, ToCoverPoints, Defenders;
        Point FromPoint, ToPoint, NullPoint;
        public Point WhiteKing, BlackKing;
        int posFrom, posTo;
        public string Player { get; set; }
        public string Opponent { get; set; }
        public string Scenario { get; set; }
        string PathStandartBoard, PathSavedBoard, PathStaleMate, PathCheckMate, PathCastlingNoBetween, PathCastlingNormal;
        public bool IsCheckmate, WasChecked;

        public GameBoardForm()
        {
            InitializeComponent();
            SetAll();
        }

        public GameBoardForm(MainForm parent, string scenario)
        {
            InitializeComponent();
            Base = parent;
            Scenario = string.Empty;
            Scenario = scenario;
            SetAll();
        }

        private void chbxToggleHighlight_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbxToggleHighlight.Checked)
            {
                labGreen.Visible = labRed.Visible = labViolet.Visible = pbxGreen.Visible = pbxRed.Visible = pbxViolet.Visible = false;
                ResetBoardColors();
            }
            else
            {
                labGreen.Visible = labRed.Visible = labViolet.Visible = pbxGreen.Visible = pbxRed.Visible = pbxViolet.Visible = true;
                SetPictureBoxesAndLabels();
            }
        }

        private void GameBoardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsCheckmate)
            {
                //RefillFiguresList();
                //write.WriteFile(PathSavedBoard, AllFigures);
            }
        }

    }
}
