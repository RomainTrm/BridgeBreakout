using System;
using Bridge.Html5;
using Console = Bridge.Utils.Console;

namespace BridgeBreakout
{
    public class GameElement
    {
        protected readonly HTMLDivElement Div;

        public int Left
        {
            get { return this.Div.OffsetLeft; }
            set { this.Div.Style.Left = value + "px"; }
        }

        public int Width
        {
            get { return this.Div.OffsetWidth; }
            set { this.Div.Style.Width = value + "px"; }
        }

        protected GameElement(string elementId)
        {
            this.Div = Document.GetElementById<HTMLDivElement>(elementId);

            if (this.Div == null)
            {
                var errorMessage = string.Format("Div {0} not found !", elementId);
                Console.Error(errorMessage);
                throw new ArgumentNullException(errorMessage);
            }
        }
    }
}
