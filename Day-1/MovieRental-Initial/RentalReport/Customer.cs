using System.Collections.Generic;

namespace RentalReport
{
    public class Customer
    {
        string _name;
        IList<Rental> _rentals = new List<Rental>();
        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Name
        {
            get { return _name; }
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRentalPoints = 0;
            var rentals = _rentals.GetEnumerator();
            var result = "Rental Record for " + Name + "\n";
            while(rentals.MoveNext())
            {
                double thisAmount = 0;
                Rental each = rentals.Current;
                
                //determine amounts for each item
                switch (each.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                            thisAmount += (each.DaysRented - 2)*1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.DaysRented*3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                            thisAmount += (each.DaysRented - 3)*1.5;
                        break;
                }
                
                //add frequent renter points
                frequentRentalPoints++;

                //add bonus for a two day new release rental
                if ((each.Movie.PriceCode == Movie.NEW_RELEASE) && each.DaysRented > 1)
                    frequentRentalPoints++;

                //show figures for this rental
                result += "\t" + each.Movie.Title + "\t" + thisAmount.ToString() + "\n";

                totalAmount += thisAmount;

            }
            //add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRentalPoints + " frequent renter points";

            return result;
        }
    }
}