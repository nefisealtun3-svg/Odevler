using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ödev1_.Models
{
    // Models/Trap.cs
    public class Trap : GameObject
    {
        public override void Draw(Graphics g) => g.FillRectangle(Brushes.Red, X, Y, 20, 20);
    }
}
