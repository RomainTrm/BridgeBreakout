using System;
using Bridge.Html5;

namespace BridgeBreakout
{
    public class Tray : GameElement
    {
        private readonly IGameSpace gamespace;

        public Tray(IGameSpace gamespace) 
            : base("tray")
        {
            this.gamespace = gamespace;
            this.gamespace.OnMouseMove += this.Move;
        }

        private void Move(MouseEvent mouseEvent)
        {
            this.Left = Math.Min(this.gamespace.Width - this.Width, mouseEvent.ClientX);
        }
    }
}