using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinForms.Interfaces
{
    interface IFigure
    {
        string Name { get; set; }
        string Side { get; set; }
        int Moves { get; set; }
        Point Location { get; set; }

    }
}