using System;

namespace BridgeBreakout
{
    public class Ball : GameElement
    {
        private BallDirections direction = BallDirections.Down;

        public Ball() 
            : base("ball")
        {
        }

        public BallDirections Direction
        {
            set { this.direction = value; }
        }

        public void Move()
        {
            switch (this.direction)
            {
                case BallDirections.Down:
                    this.Top++;
                    break;
                case BallDirections.DownLeft:
                    this.Top++;
                    this.Left--;
                    break;
                case BallDirections.Left:
                    this.Left--;
                    break;
                case BallDirections.TopLeft:
                    this.Top--;
                    this.Left--;
                    break;
                case BallDirections.Top:
                    this.Top--;
                    this.Left++;
                    break;
                case BallDirections.TopRight:
                    this.Top--;
                    this.Left++;
                    break;
                case BallDirections.Right:
                    this.Left++;
                    break;
                case BallDirections.DownRight:
                    this.Top++;
                    this.Left++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}