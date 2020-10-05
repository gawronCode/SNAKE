using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    public class Snake
    {

        public bool IsAlive { get; private set; }
        
        private readonly Color _snakeColor;

        private LinkedList<BodyPart> _body = new LinkedList<BodyPart>();
        
        public Snake(Color color)
        {
            IsAlive = true;
            _snakeColor = color;
            _body.AddFirst(new BodyPart(280,80, 0, color));
            for (int i = 240; i > 80; i -= 40) _body.AddLast(new BodyPart(i, 80, 0, color));
        }
        
        public BodyPart GetHead()
        {
            return _body.First.Value;
        }

        public bool IsBodyOnThatField(int positionX, int positionY)
        {
            foreach (var bodyPart in _body) if (bodyPart.PositionX == positionX && bodyPart.PositionY == positionY) return true;
            return false;                                                                    
        }

        public int Length()
        {
            return _body.Count;
        }

        public void Move()
        {
            if (!IsAlive) return;
            MoveBody();
            SetBodyPartsDirection();
        }

        private void MoveBody()
        {
            foreach (var bodyPart in _body) bodyPart.Move();
        }

        private void SetBodyPartsDirection()
        {
            if (_body.Count > 1)
            {
                LinkedListNode<BodyPart> tmp = _body.Last;
                while (tmp.Previous != null)
                {
                    tmp.Value.Direction = tmp.Previous.Value.Direction;
                    tmp = tmp.Previous;
                }
            }
        }
        
        public void SetHeadDirection(int direction)
        {
            _body.First.Value.Direction = direction;
        }

        public void CheckForCollision()
        {
            foreach (var bodyPart in _body.Skip(1)) if (HeadHitBodyPart(bodyPart)) {IsAlive = false; return;}
            if (HeadHitBorder()) { IsAlive = false; return; }
        }
        private bool HeadHitBodyPart(BodyPart bodyPart)
        {
            if (_body.First.Value.PositionX == bodyPart.PositionX &&
                _body.First.Value.PositionY == bodyPart.PositionY) return true;
            else return false;
        }
        private bool HeadHitBorder()
        {
            if (_body.First.Value.PositionX > 760 || _body.First.Value.PositionX < 0 ||
                _body.First.Value.PositionY > 760 || _body.First.Value.PositionY < 0) return true;
            else return false;
        }

        public bool HeadEatFood(int foodPositionX, int foodPositionY)
        {
            if (_body.First.Value.PositionX == foodPositionX &&
                _body.First.Value.PositionY == foodPositionY) return true;
            else return false;
        }

        public void Draw(Graphics g)
        {
            foreach (var bodyPart in _body) bodyPart.Draw(g);
        }

        public void AddBodyPart()
        {
            if (_body.Last.Value.PreviousDirection == 0) _body.AddLast(new BodyPart(_body.Last.Value.PositionX - 40, _body.Last.Value.PositionY, 0, _snakeColor));
            if (_body.Last.Value.PreviousDirection == 1) _body.AddLast(new BodyPart(_body.Last.Value.PositionX, _body.Last.Value.PositionY + 40, 1, _snakeColor));
            if (_body.Last.Value.PreviousDirection == 2) _body.AddLast(new BodyPart(_body.Last.Value.PositionX + 40, _body.Last.Value.PositionY, 2, _snakeColor));
            if (_body.Last.Value.PreviousDirection == 3) _body.AddLast(new BodyPart(_body.Last.Value.PositionX, _body.Last.Value.PositionY - 40, 3, _snakeColor));

        }


    }
}
