using System;

namespace BridgeBreakout
{
    public class Ball : GameElement
    {
        private VerticalDirection verticalDirection = VerticalDirection.Down;
        private HorizontalDirection horizontalDirection = HorizontalDirection.None;

        public Ball() 
            : base("ball")
        {
        }

        public void Move()
        {
            this.MoveVertically();
            this.MoveHorizontally();
        }

        private void MoveVertically()
        {
            switch (this.verticalDirection)
            {
                case VerticalDirection.Up:
                    this.Top--;
                    break;
                case VerticalDirection.Down:
                    this.Top++;
                    break;
            }
        }

        private void MoveHorizontally()
        {
            switch (this.horizontalDirection)
            {
                case HorizontalDirection.Left:
                    this.Left--;
                    break;
                case HorizontalDirection.Right:
                    this.Left++;
                    break;
            }
        }

        public void Bounce(Collisions collision)
        {
            switch (collision)
            {
                case Collisions.TrayMiddle:
                    this.horizontalDirection = HorizontalDirection.None;
                    this.verticalDirection = VerticalDirection.Up;
                    break;
                case Collisions.TrayLeft:
                    this.verticalDirection = VerticalDirection.Up;
                    this.horizontalDirection = HorizontalDirection.Left;
                    break;
                case Collisions.TrayRight:
                    this.verticalDirection = VerticalDirection.Up;
                    this.horizontalDirection = HorizontalDirection.Right;
                    break;
                case Collisions.Top:
                    this.verticalDirection = VerticalDirection.Down;
                    break;
                case Collisions.Left:
                    this.horizontalDirection = HorizontalDirection.Right;
                    break;
                case Collisions.Right:
                    this.horizontalDirection = HorizontalDirection.Left;
                    break;
                case Collisions.Brick:
                    break;
            }
        }
    }
}