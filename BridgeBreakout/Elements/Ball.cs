namespace BridgeBreakout
{
    public class Ball : GameElement
    {
        private readonly int originLeft;
        private readonly int originTop;

        private VerticalDirection verticalDirection = VerticalDirection.Down;
        private HorizontalDirection horizontalDirection = HorizontalDirection.None;
    
        public Ball()
            : base("ball")
        {
            this.originLeft = this.Left;
            this.originTop = this.Top;
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
                case Collisions.BrickTopBottom:
                    this.verticalDirection = this.verticalDirection == VerticalDirection.Up
                        ? VerticalDirection.Down
                        : VerticalDirection.Up;
                    break;
                case Collisions.BrickLeftRight:
                    if (this.horizontalDirection != HorizontalDirection.None)
                    {
                        this.horizontalDirection = this.horizontalDirection == HorizontalDirection.Left
                            ? HorizontalDirection.Right
                            : HorizontalDirection.Left;
                    }
                    break;
            }
        }

        public void ResetPosition()
        {
            this.Left = this.originLeft;
            this.Top = this.originTop;
            this.horizontalDirection = HorizontalDirection.None;
            this.verticalDirection = VerticalDirection.Down;
        }
    }
}