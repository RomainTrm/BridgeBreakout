using System;
using System.Collections.Generic;
using Bridge.Html5;
using Bridge.Linq;

namespace BridgeBreakout
{
    public class Gameboard : GameElement, IGameSpace
    {
        private readonly List<Brick> bricks;

        public Gameboard()
            : base("gameboard")
        {
            this.bricks = new List<Brick>(this.GenerateBricks());
            this.bricks.ForEach(brick => Document.Body.AppendChild(brick.Node));
        }

        public Action<MouseEvent> OnMouseMove
        {
            get { return ((HTMLElement)this.Div).OnMouseMove; }
            set { ((HTMLElement)this.Div).OnMouseMove = value; }
        }

        public Action<MouseEvent> OnMouseClick
        {
            get { return ((HTMLElement) this.Div).OnClick; }
            set { ((HTMLElement)this.Div).OnClick = value; }
        }

        public IEnumerable<Brick> Bricks => this.bricks;

        private IEnumerable<Brick> GenerateBricks()
        {
            for (var row = 0; row < 5; row++)
                for (var column = 0; column < 55; column++)
                    yield return new Brick(column * Brick.Width, 40 + row * Brick.Height);
        }

        public void RemoveCollideBrick(Brick brick)
        {
            if (brick != null)
            {
                Document.Body.RemoveChild(brick.Node);
                this.bricks.Remove(brick);
            }
        }
    }
}