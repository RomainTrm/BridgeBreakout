using Bridge.Html5;

namespace BridgeBreakout
{
    public class App
    {
        [Ready]
        public static void Main()
        {
            var gameBoard = new Gameboard();
        }
    }
}