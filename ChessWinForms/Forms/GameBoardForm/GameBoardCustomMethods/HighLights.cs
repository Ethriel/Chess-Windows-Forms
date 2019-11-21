using ChessWinForms.Classes.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinForms.Forms.nGameBoardForm
{
    public partial class GameBoardForm
    {
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

            Figure toCover = null;
            for (int i = 0; i < CoverFigures.Count; i++)
            {
                cover = CoverFigures[i];
                for (int j = 0; j < ToCoverPoints.Count; j++)
                {
                    toCover = GetFigureByPoint(ToCoverPoints[j]);
                    if (cover.Attack(toCover))
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
    }
}
