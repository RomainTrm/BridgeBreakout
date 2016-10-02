namespace BridgeBreakout
{
    public class Score : GameElement
    {
        private int score;

        public Score()
            : base("score")
        {
            this.Div.InnerHTML = "Score : " + this.score;
        }

        public void Increment()
        {
            this.Div.InnerHTML = "Score : " + ++this.score;
        }
    }
}