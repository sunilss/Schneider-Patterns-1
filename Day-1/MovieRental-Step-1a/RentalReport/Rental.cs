namespace RentalReport
{
    public class Rental
    {
        MovieBase _movie;
        int _daysRented;

        public Rental(MovieBase movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int DaysRented
        {
            get
            {
                return _daysRented;
            }
        }

        public MovieBase Movie
        {
            get { return _movie; }
        }

        public double GetAmount()
        {
            return Movie.GetAmount(_daysRented);
        }

        public int GetFrequentRentalPoints()
        {

            return Movie.GetFrequentRentalPoints(_daysRented);

        }
    }
}