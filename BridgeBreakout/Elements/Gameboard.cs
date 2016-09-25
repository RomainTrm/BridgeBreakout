using System;
using Bridge.Html5;

namespace BridgeBreakout
{
    public class Gameboard : GameElement
    {
        private readonly Tray tray;

        public Gameboard() 
            : base("gameboard")
        {
            this.tray = new Tray(this);
        }

        public Action<MouseEvent> OnMouseMove
        {
            get { return ((HTMLElement)this.Div).OnMouseMove; }
            set { ((HTMLElement)this.Div).OnMouseMove = value; }
        }
    }
}