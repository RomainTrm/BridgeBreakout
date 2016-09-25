using System;
using Bridge.Html5;
using Console = Bridge.Utils.Console;

namespace BridgeBreakout
{
    public class App
    {
        [Ready]
        public static void Main()
        {
            try
            {
                var gameBoard = new Gameboard();
            }
            catch (Exception exception)
            {
                Console.Error(exception.Message);
            }
        }
    }
}