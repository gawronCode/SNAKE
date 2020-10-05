using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SNAKE
{
    class Food
    {

        public int PositionX { get; }
        public int PositionY { get; }
        public int Points { get; }

        public Color Color {private get; set; }

        private const int Width = 30;
        private const int Height = 30;

        public Food(int positionX, int positionY, int points, Color foodColor)
        {
            PositionX = positionX;
            PositionY = positionY;
            Points = points;
            Color = foodColor;
        }

        public void Draw(Graphics g)
        {
            SolidBrush solidBrush = new SolidBrush(Color);
            g.FillRectangle(solidBrush, PositionX+5, PositionY+5, Width, Height);
        }

    }
}
