using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ödev1_.Models
{
    // Models/Player.cs
    public class Player : GameObject
    {
        private int score; // Private field
        public int Score => score; // Read-only property

        public void AddScore(int amount)
        {
            if (amount > 0) score += amount;
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Blue, X, Y, 30, 30);
        }
    }
}
