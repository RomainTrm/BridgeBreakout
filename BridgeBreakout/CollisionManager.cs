using System.Linq;

namespace BridgeBreakout
{
    public class CollisionManager
    {
        private readonly Gameboard gameboard;
        private readonly Ball ball;
        private readonly Tray tray;

        public CollisionManager(Gameboard gameboard, Ball ball, Tray tray)
        {
            this.gameboard = gameboard;
            this.ball = ball;
            this.tray = tray;
        }

        public Collisions GetCollision()
        {
            if (this.BallTouchTrayOnLeft())
                return Collisions.TrayLeft;
            if (this.BallTouchTrayOnRight())
                return Collisions.TrayRight;
            if (this.BallTouchTrayOnMiddle())
                return Collisions.TrayMiddle;
            if (this.BallTouchBottom())
                return Collisions.Bottom;
            if (this.BallTouchTop())
                return Collisions.Top;
            if (this.BallTouchLeft())
                return Collisions.Left;
            if (this.BallTouchRight())
                return Collisions.Right;
            if (this.BallTouchBrick())
                return Collisions.Brick;

            return Collisions.None;
        }

        private bool BallTouchTrayOnLeft()
        {
            return this.ball.Bottom >= this.tray.Top
                && this.ball.Left >= this.tray.Left
                && this.ball.Right <= this.tray.Left + this.tray.Width / 3;
        }

        private bool BallTouchTrayOnRight()
        {
            return this.ball.Bottom >= this.tray.Top
                && this.ball.Left >= this.tray.Right - this.tray.Width / 3
                && this.ball.Right <= this.tray.Right;
        }

        private bool BallTouchTrayOnMiddle()
        {
            return this.ball.Bottom >= this.tray.Top
                && this.ball.Left >= this.tray.Left
                && this.ball.Right <= this.tray.Right;
        }

        private bool BallTouchTop()
        {
            return this.ball.Top <= this.gameboard.Top;
        }

        private bool BallTouchBottom()
        {
            return this.ball.Bottom >= this.gameboard.Bottom;
        }

        private bool BallTouchLeft()
        {
            return this.ball.Left == this.gameboard.Left;
        }

        private bool BallTouchRight()
        {
            return this.ball.Right == this.gameboard.Right;
        }

        private bool BallTouchBrick()
        {
            return this.GetCollideBrick() != null;
        }

        public Brick GetCollideBrick()
        {
            return this.gameboard.Bricks.FirstOrDefault(brick => this.BallCollideVertically(brick) && this.BallCollideHorizontally(brick));
        }

        private bool BallCollideVertically(Brick brick)
        {
            return this.ball.Bottom >= brick.Top
                && this.ball.Bottom < brick.Bottom
                || this.ball.Top <= brick.Bottom
                && this.ball.Top > brick.Top;
        }

        private bool BallCollideHorizontally(Brick brick)
        {
            return this.ball.Right >= brick.Left
                && this.ball.Right < brick.Right
                || this.ball.Left <= brick.Right
                && this.ball.Left > brick.Left;
        }
    }
}