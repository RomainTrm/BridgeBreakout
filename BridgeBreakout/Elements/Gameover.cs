using Bridge.Html5;

namespace BridgeBreakout
{
    public class Gameover : GameElement
    {
        public Gameover()
            : base("gameover")
        {
            this.Div.Style.Visibility = Visibility.Hidden;
        }

        public void Show()
        {
            this.Div.Style.Visibility = Visibility.Visible;
        }
    }
}
