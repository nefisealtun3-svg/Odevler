using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ödev1_.Models
{
    // Treasure.cs
    public class Treasure : GameObject
    {
        public override void Draw(Graphics g)
        {
            // Resim yerine altın sarısı bir daire çiziyoruz
            g.FillEllipse(Brushes.Gold, X, Y, Width, Height);
            g.DrawEllipse(Pens.Black, X, Y, Width, Height); // Kenarlık
        }
    }
}
