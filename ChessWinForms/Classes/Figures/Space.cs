using ChessWinForms.Forms.GameBoardForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinForms.Classes.Figures
{
    [Serializable]
    public class Space:Figure
    {
        public Space() : base()
        {

        }

        public Space(Space s):base(s)
        {

        }

        public Space(string name, string side, int moves, int btnSize, GameBoardForm gb) : base(name, side, moves, btnSize, gb)
        {

        }

        public override void SetPossibleMoves()
        {
            return;
        }
    }
}
