namespace BridgeBreakout
{
    public class Score : GameElement
    {
        private int score = 0;

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