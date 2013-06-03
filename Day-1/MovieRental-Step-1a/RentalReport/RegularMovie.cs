namespace RentalReport
{
    public class RegularMovie : MovieBase
    {
        public RegularMovie(string title) : base(title)
        {
            
        }
        public override double GetAmount(int daysRented)
        {
            double rentalAmount = 2;
            if (daysRented > 2)
                rentalAmount += (daysRented - 2) * 1.5;
            return rentalAmount;
        }
    }
}