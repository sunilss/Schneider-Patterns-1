namespace RentalReport
{
    public class Rental
    {
        Movie _movie;
        int _daysRented;

        public Rental(Movie movie, int daysRented)
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

        public Movie Movie
        {
            get { return _movie; }
        }
    }
}