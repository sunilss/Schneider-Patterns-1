namespace RentalReport
{
    public class NewReleaseMovie : MovieBase
    {
        public NewReleaseMovie(string title) : base(title)
        {
            
        }
        public override double GetAmount(int daysRented)
        {
            return daysRented * 3;
        }
        public override int GetFrequentRentalPoints(int daysRented)
        {
            if (daysRented > 1)
                return 2;
            return 1;
        }
    }

}