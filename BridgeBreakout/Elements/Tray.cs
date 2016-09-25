using System;
using Bridge.Html5;

namespace BridgeBreakout
{
    public class Tray : GameElement
    {
        private readonly Gameboard gameboard;

        public Tray(Gameboard gameboard) 
            : base("tray")
        {
            this.gameboard = gameboard;
            this.gameboard.OnMouseMove += this.Move;
        }

        private void Move(MouseEvent mouseEvent)
        {
            this.Left = Math.Min(this.gameboard.Width - this.Width, mouseEvent.ClientX);
        }
    }
}