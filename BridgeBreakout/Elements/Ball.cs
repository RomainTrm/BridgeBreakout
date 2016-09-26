namespace BridgeBreakout
{
    public class Ball : GameElement
    {
        private BallDirections direction = BallDirections.Down;

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
            switch (this.direction)
            {
                case BallDirections.Down:
                case BallDirections.DownLeft:
                case BallDirections.DownRight:
                    this.Top++;
                    break;
                case BallDirections.TopLeft:
                case BallDirections.Top:
                case BallDirections.TopRight:
                    this.Top--;
                    break;
            }
        }

        private void MoveHorizontally()
        {
            switch (this.direction)
            {
                case BallDirections.DownLeft:
                case BallDirections.Left:
                case BallDirections.TopLeft:
                    this.Left--;
                    break;
                case BallDirections.TopRight:
                case BallDirections.Right:
                case BallDirections.DownRight:
                    this.Left++;
                    break;
            }
        }

        public void Bounce()
        {
            this.direction = BallDirections.Top;
        }

        public void BounceLeft()
        {
            this.direction = BallDirections.TopLeft;
        }

        public void BounceRight()
        {
            this.direction = BallDirections.TopRight;
        }
    }
}