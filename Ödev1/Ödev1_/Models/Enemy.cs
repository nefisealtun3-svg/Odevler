using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ödev1_.Models
{
    // Models/Enemy.cs
    public class Enemy : GameObject
    {
        public bool IsMoving { get; set; }
        private int direction = 1;
        private int speed = 5;

        // Enemy.cs
        public override void Draw(Graphics g)
        {
            // Hareketli olanlar Turuncu, Sabit olanlar Kırmızı kare
            Brush b = IsMoving ? Brushes.Orange : Brushes.Red;
            g.FillRectangle(b, X, Y, Width, Height);
            g.DrawRectangle(Pens.Black, X, Y, Width, Height); // Kenarlık
        }

        public void Move(int screenWidth)
        {
            if (!IsMoving) return;

            X += (speed * direction);
            if (X <= 0 || X >= screenWidth - 25) direction *= -1; // Kenara çarpınca dön
        }
        
    }

}
