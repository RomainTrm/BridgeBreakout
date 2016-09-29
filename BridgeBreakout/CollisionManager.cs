using System;
using System.Collections.Generic;
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
            {
                return this.GetBrickCollision();
            }

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
            return this.gameboard
                .Bricks
                .Where(brick => this.BallCollideVertically(brick) && this.BallCollideHorizontally(brick))
                .OrderBy(brick => this.GetBricksDeltas(brick).Max(delta => delta.Key))
                .FirstOrDefault();
        }

        private bool BallCollideVertically(Brick brick)
        {
            return this.ball.Bottom >= brick.Top
                && this.ball.Bottom <= brick.Bottom
                || this.ball.Top <= brick.Bottom
                && this.ball.Top >= brick.Top;
        }

        private bool BallCollideHorizontally(Brick brick)
        {
            return this.ball.Right >= brick.Left
                && this.ball.Right <= brick.Right
                || this.ball.Left <= brick.Right
                && this.ball.Left >= brick.Left;
        }

        private IEnumerable<KeyValuePair<int, Sides>> GetBricksDeltas(Brick brick)
        {
            return new List<KeyValuePair<int, Sides>>
            {
                new KeyValuePair<int, Sides>(brick.Left - this.ball.Left, Sides.Left),
                new KeyValuePair<int, Sides>(this.ball.Right - brick.Right, Sides.Right),
                new KeyValuePair<int, Sides>(brick.Top - this.ball.Top, Sides.Top),
                new KeyValuePair<int, Sides>(this.ball.Bottom - brick.Bottom, Sides.Bottom)
            };
        }

        private Collisions GetBrickCollision()
        {
            var brick = this.GetCollideBrick();
            var sidesDeltas = this.GetBricksDeltas(brick);

            var biggestDelta = sidesDeltas
                .OrderByDescending(x => x.Key)
                .ThenBy(x => x.Value)
                .First().Value;

            switch (biggestDelta)
            {
                case Sides.Top:
                case Sides.Bottom:
                    return Collisions.BrickTopBottom;
                case Sides.Right:
                case Sides.Left:
                    return Collisions.BrickLeftRight;
                default:
                    throw new ArgumentException();
            }
        }

        private enum Sides
        {
            Top, Bottom, Right, Left
        }
    }
}