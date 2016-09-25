using System;
using System.Collections.Generic;
using Bridge.Html5;
using Bridge.Linq;

namespace BridgeBreakout
{
    public class Gameboard : GameElement
    {
        private readonly Tray tray;
        private readonly List<Brick> bricks;

        public Gameboard()
            : base("gameboard")
        {
            this.tray = new Tray(this);
            this.bricks = new List<Brick>(this.GenerateBricks());
            this.bricks.ForEach(brick => Document.Body.AppendChild(brick.Node));
        }

        private IEnumerable<Brick> GenerateBricks()
        {
            for (var row = 0; row < 5; row++)
                for (var column = 0; column < 51; column++)
                    yield return new Brick(column * 10 + column, 50 + row * 11);
        }

        public Action<MouseEvent> OnMouseMove
        {
            get { return ((HTMLElement)this.Div).OnMouseMove; }
            set { ((HTMLElement)this.Div).OnMouseMove = value; }
        }
    }
}