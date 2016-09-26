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

        public List<Brick> Bricks => this.bricks;

        private IEnumerable<Brick> GenerateBricks()
        {
            for (var row = 0; row < 5; row++)
                for (var column = 0; column < 50; column++)
                    yield return new Brick(column * (Brick.Width + 1), 50 + row * (Brick.Height + 1));
        }
    }
}