using Bridge.Html5;

namespace BridgeBreakout
{
    public class Brick : GameElement
    {
        public static int Width => 10;
        public static int Height => 10;

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