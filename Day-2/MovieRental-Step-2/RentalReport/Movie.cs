using System;

namespace RentalReport
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private readonly int _id;
        string _title;
        int _priceCode;
        private readonly DateTime _releaseDate;

        public Movie(int id,string title,int priceCode,DateTime releaseDate)
        {
            _id = id;
            _title = title;
            _priceCode = priceCode;
            _releaseDate = releaseDate;
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3:d}", Id, Title, PriceCode, ReleaseDate);
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

        public int Id
        {
            get { return _id; }
        }

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
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