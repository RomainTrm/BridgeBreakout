namespace BridgeBreakout
{
    public class Lives : GameElement
    {
        private int remaining = 3;

        public Lives() 
            : base("lives")
        {
            this.Div.InnerHTML = "Lives : " + this.remaining;
        }

        public int Remaining => this.remaining;

        public void RemoveOneLife()
        {
            this.Div.InnerHTML = "Lives : " + --this.remaining;
        }
    }
}