namespace RentalReport
{
    public class ChildrensMovie : MovieBase
    {
        public ChildrensMovie(string title) : base(title)
        {
            
        }
        public override double GetAmount(int daysRented)
        {
            var rentalAmount = 1.5;
            if (daysRented > 3)
                rentalAmount += (daysRented - 3) * 1.5;
            return rentalAmount;
        }
    }
}