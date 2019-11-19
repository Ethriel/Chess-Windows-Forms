using ChessWinForms.Classes.Figures;
using ChessWinForms.Forms.GameBoardForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessWinForms.Classes
{
    static class SituationsGenerator
    {
        static public void StaleMate(GameBoardForm gb)
        {
            string name = "", side = "";
            Button b = null;
            // populate gameboard with buttons
            for (int i = 0; i < gb.GBoard.RowCount; i++)
            {
                for (int j = 0; j < gb.GBoard.ColumnCount; j++)
                {
                    b = gb.GetButton();
                    if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        b.BackColor = Color.Coral;
                    }
                    if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                    {
                        b.BackColor = Color.White;
                    }

                    if (i == 0 && j == 7)
                    {
                        name = "King";
                        side = "Black";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(King), "King", "Black", 1, 64, gb);
                    }
                    else if ((i == 2 && j == 7) || (i == 3 && j == 2) || (i == 4 && j == 1))
                    {
                        name = "Pawn";
                        side = "White";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(Pawn), "Pawn", "White", 2, 64, gb);
                    }
                    else if (i == 2 && j == 5)
                    {
                        name = "King";
                        side = "White";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(King), "King", "White", 1, 64, gb);
                    }
                    else if ((i == 2 && j == 2) || (i == 3 && j == 1))
                    {
                        name = "Pawn";
                        side = "Black";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(Pawn), "Pawn", "Black", 2, 64, gb);
                    }
                    else if (i == 6 && j == 2)
                    {
                        name = "Bishop";
                        side = "White";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(Bishop), "Bishop", "White", 8, 64, gb);
                    }
                    else
                    {
                        name = "Space";
                        side = "None";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(Space), "Space", "None", 0, 64, gb);
                    }
                    SetButton(ref b, name, side);
                    gb.GBoard.Controls.Add(b);

                    (b.Tag as Figure).Location = b.Location;

                    gb.DefaultBoardColors.Add(b.BackColor);
                }
            }
        }

        static public void CheckMate(GameBoardForm gb)
        {
            string name = "", side = "";
            Button b = null;
            // populate gameboard with buttons
            for (int i = 0; i < gb.GBoard.RowCount; i++)
            {
                for (int j = 0; j < gb.GBoard.ColumnCount; j++)
                {
                    b = gb.GetButton();
                    if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        b.BackColor = Color.Coral;
                    }
                    if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                    {
                        b.BackColor = Color.White;
                    }

                    if (i == 0 && j == 7)
                    {
                        name = "King";
                        side = "Black";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(King), "King", "Black", 1, 64, gb);
                    }
                    else if ((i == 1 && j == 7) || (i == 3 && j == 2) || (i == 4 && j == 1))
                    {
                        name = "Pawn";
                        side = "White";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(Pawn), "Pawn", "White", 2, 64, gb);
                    }
                    else if (i == 2 && j == 5)
                    {
                        name = "King";
                        side = "White";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(King), "King", "White", 1, 64, gb);
                    }
                    else if ((i == 2 && j == 2) || (i == 3 && j == 1))
                    {
                        name = "Pawn";
                        side = "Black";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(Pawn), "Pawn", "Black", 2, 64, gb);
                    }
                    else if (i == 6 && j == 2)
                    {
                        name = "Bishop";
                        side = "White";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(Bishop), "Bishop", "White", 8, 64, gb);
                    }
                    else if (i == 1 && j == 0)
                    {
                        name = "Rook";
                        side = "White";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(Rook), "Rook", "White", 8, 64, gb);
                    }
                    else
                    {
                        name = "Space";
                        side = "None";
                        b.Tag = (Figure)Activator.CreateInstance(typeof(Space), "Space", "None", 0, 64, gb);
                    }
                    SetButton(ref b, name, side);
                    gb.GBoard.Controls.Add(b);

                    (b.Tag as Figure).Location = b.Location;

                    gb.DefaultBoardColors.Add(b.BackColor);
                }
            }
        }

        static public void Castling(GameBoardForm gb)
        {
            string name = "", side = "";
            Type t = null;
            int moves = 0;
            Button b = null;
            // populate gameboard with buttons
            for (int i = 0; i < gb.GBoard.RowCount; i++)
            {
                for (int j = 0; j < gb.GBoard.ColumnCount; j++)
                {
                    b = gb.GetButton();
                    if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        b.BackColor = Color.Coral;
                    }
                    if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                    {
                        b.BackColor = Color.White;
                    }

                    if ((i == 7 && j == 0) || (i == 7 && j == 7)) // white rooks
                    {
                        name = "Rook";
                        side = "White";
                        moves = 8;
                        t = typeof(Rook);
                    }
                    else if (i == 7 && j == 4) // white king
                    {
                        name = "King";
                        side = "White";
                        moves = 1;
                        t = typeof(King);
                    }
                    else if ((i == 0 && j == 0) || (i == 0 && j == 7)) // black rooks
                    {
                        name = "Rook";
                        side = "Black";
                        moves = 8;
                        t = typeof(Rook);
                    }
                    else if (i == 0 && j == 4) // black king
                    {
                        name = "King";
                        side = "Black";
                        moves = 1;
                        t = typeof(King);
                    }
                    else if (i == 7 && j == 5 || i == 7 && j == 3)
                    {
                        name = "Bishop";
                        side = "White";
                        moves = 8;
                        t = typeof(Bishop);
                    }
                    else if (i == 0 && j == 5 || i == 0 && j == 3)
                    {
                        name = "Bishop";
                        side = "Black";
                        moves = 8;
                        t = typeof(Bishop);
                    }
                    else
                    {
                        name = "Space";
                        side = "None";
                        moves = 0;
                        t = typeof(Space);
                    }
                    b.Tag = (Figure)Activator.CreateInstance(t, name, side, moves, 64, gb);
                    SetButton(ref b, name, side);
                    gb.GBoard.Controls.Add(b);

                    (b.Tag as Figure).Location = b.Location;

                    gb.DefaultBoardColors.Add(b.BackColor);
                }
            }
        }

        static private void SetButton(ref Button b, string name, string side)
        {
            if ((b.Tag as Figure).Name != "Space")
            {
                b.BackgroundImage = SetImage(name.ToLower(), side.ToLower());
            }
        }

        static private Image SetImage(string type, string side)
        {
            return Image.FromFile($@"../../pictures/figures/{type}_{side}.png");
        }

    }
}
