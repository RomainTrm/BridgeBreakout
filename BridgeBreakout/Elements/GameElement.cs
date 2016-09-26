using Bridge.Html5;

namespace BridgeBreakout
{
    public abstract class GameElement
    {
        protected readonly HTMLDivElement Div;

        public int Left
        {
            get { return this.Div.OffsetLeft; }
            protected set { this.Div.Style.Left = value + "px"; }
        }

        public int Top
        {
            get { return this.Div.OffsetTop; }
            protected set { this.Div.Style.Top = value + "px"; }
        }

        public int Bottom => this.Top + this.Height;

        public int Right => this.Left + this.Width;

        public int Width => this.Div.OffsetWidth;

        public int Height => this.Div.OffsetHeight;

        public Node Node => this.Div;

        protected GameElement(string elementId)
        {
            this.Div = Document.GetElementById<HTMLDivElement>(elementId);
        }

        protected GameElement(HTMLDivElement divElement)
        {
            this.Div = divElement;
        }
    }
}
