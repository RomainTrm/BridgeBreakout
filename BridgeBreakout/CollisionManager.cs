using System.Collections.Generic;

namespace BridgeBreakout
{
    public class CollisionManager
    {
        private readonly Gameboard gameboard;
        private readonly Ball ball;
        private readonly Tray tray;
        private readonly List<Brick> bricks;

        public CollisionManager(Gameboard gameboard, Ball ball, Tray tray, List<Brick> bricks)
        {
            this.gameboard = gameboard;
            this.ball = ball;
            this.tray = tray;
            this.bricks = bricks;
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
                && this.ball.Left >= this.tray.Left + this.tray.Width/3
                && this.ball.Right <= this.tray.Right - this.tray.Width/3;
        }

        private bool BallTouchTop()
        {
            return this.ball.Top == this.gameboard.Top;
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
    }
}