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
    }
}