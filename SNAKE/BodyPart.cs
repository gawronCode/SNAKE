using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SNAKE
{
    public class BodyPart
    {

        public Color BodyPartColor {private get; set; }

        private int _direction; //0-right, 1-up, 2-left, 3-down
        public int PreviousDirection { get; private set; } //0-right, 1-up, 2-left, 3-down

        private const int Width = 38;
        private const int Height = 38;
        private const int Speed = 40;

        public BodyPart(int positionX, int positionY, int direction, Color color)
        {
            PositionX = positionX;
            PositionY = positionY;
            PreviousDirection = direction;
            Direction = direction;
            BodyPartColor = color;
        }

        public int PositionX { get; set; }

        public int PositionY { get; set; }


        public int Direction
        {
            get => _direction;

            set
            {
                if (PreviousDirection == 0 && value != 2) _direction = value;
                if (PreviousDirection == 2 && value != 0) _direction = value;
                if (PreviousDirection == 1 && value != 3) _direction = value;
                if (PreviousDirection == 3 && value != 1) _direction = value;
            }
        }

        public void Move()
        {
            if (MovingRight()) PositionX += Speed;
            if (MovingUp()) PositionY -= Speed;
            if (MovingLeft()) PositionX -= Speed;
            if (MovingDown()) PositionY += Speed;

            PreviousDirection = Direction;
        }

        private bool MovingRight()
        {
            return Direction == 0 ? true : false;
        }
        private bool MovingUp()
        {
            return Direction == 1 ? true : false;
        }
        private bool MovingLeft()
        {
            return Direction == 2 ? true : false;
        }
        private bool MovingDown()
        {
            return Direction == 3 ? true : false;
        }


        public void Draw(Graphics g)
        {
            SolidBrush solidBrush = new SolidBrush(BodyPartColor);
            g.FillRectangle(solidBrush, PositionX+1, PositionY+1, Width, Height);
        }

    }
}
