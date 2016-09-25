using Bridge.Html5;

namespace BridgeBreakout
{
    public class Brick : GameElement
    {
        public Brick(int left, int top)
            : base(CreateDivElement(left, top))
        {
        }

        private static HTMLDivElement CreateDivElement(int left, int top)
        {
            return new HTMLDivElement
            {
                ClassName = "brick",
                Style = { Left = left + "px", Top = top + "px" }
            };
        }
    }
}