using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ödev1_.Models
{
    public abstract class GameObject
    {
        // Bunların 'public' olduğundan emin ol
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; } = 40;
        public int Height { get; set; } = 40;

        public abstract void Draw(Graphics g);
    }
}
