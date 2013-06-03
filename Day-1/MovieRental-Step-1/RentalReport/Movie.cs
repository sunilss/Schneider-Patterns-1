namespace RentalReport
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        string _title;
        int _priceCode;

        public Movie(string title,int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public int PriceCode
        {
            get { return _priceCode; }
            set { _priceCode = value;}
        }

        public string Title
        {
            get { return _title; }
        }

        public double GetAmount(int daysRented)
        {
            double rentalAmount = 0;
            switch (PriceCode)
            {
                case Movie.REGULAR:
                    rentalAmount += 2;
                    if (daysRented > 2)
                        rentalAmount += (daysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    rentalAmount += daysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    rentalAmount += 1.5;
                    if (daysRented > 3)
                        rentalAmount += (daysRented - 3) * 1.5;
                    break;
            }
            return rentalAmount;
        }

        public int GetFrequentRentalPoints(int daysRented)
        {
            var frequentRentalPoints = 1;

            //add bonus for a two day new release rental
            if ((PriceCode == Movie.NEW_RELEASE) && daysRented > 1)
                frequentRentalPoints++;
            return frequentRentalPoints;
        }
    }
}