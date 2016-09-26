using Bridge.Html5;

namespace BridgeBreakout
{
    public class Game
    {
        private int interval;
        private readonly Gameboard gameBoard;
        private readonly Tray tray;
        private readonly Ball ball;
        private readonly CollisionManager collisionManager;

        public Game()
        {
            this.gameBoard = new Gameboard();
            this.tray = new Tray(this.gameBoard);
            this.ball = new Ball();

            this.collisionManager = new CollisionManager(this.gameBoard, this.ball, this.tray, this.gameBoard.Bricks);
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
        }
    }
}