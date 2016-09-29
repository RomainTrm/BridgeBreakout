using Bridge.Html5;

namespace BridgeBreakout
{
    public class Game
    {
        private int interval;
        private readonly Gameboard gameBoard;
        private readonly Ball ball;
        private readonly CollisionManager collisionManager;
        private readonly Lives lives;
        private readonly Score score;

        public Game()
        {
            this.gameBoard = new Gameboard();
            var tray = new Tray(this.gameBoard);
            this.ball = new Ball();
            this.lives = new Lives();
            this.score = new Score();

            this.collisionManager = new CollisionManager(this.gameBoard, this.ball, tray);
        }

        public void Run()
        {
            if (this.interval == 0)
            {
                this.interval = Window.SetInterval(this.Tick, 1);
            }
        }

        private void Tick()
        {
            this.ball.Move();
            var collision = this.collisionManager.GetCollision();
            this.ball.Bounce(collision);
            var collideBrick = this.collisionManager.GetCollideBrick();
            if (collideBrick != null)
            {
                this.score.Increment();
                this.gameBoard.RemoveCollideBrick(collideBrick);
            }
            this.EndGame(collision);
        }

        private void EndGame(Collisions collision)
        {
            if (collision == Collisions.Bottom)
            {
                this.lives.RemoveOneLife();
                Window.ClearInterval(this.interval);
            }
        }
    }
}