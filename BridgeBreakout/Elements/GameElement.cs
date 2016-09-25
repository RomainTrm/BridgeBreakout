using Bridge.Html5;

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

        public Node Node
        {
            get { return (Node) this.Div; }
        }

        protected GameElement(string elementId)
        {
            this.Div = Document.GetElementById<HTMLDivElement>(elementId);
        }

        public GameElement(HTMLDivElement divElement)
        {
            this.Div = divElement;
        }
    }
}
