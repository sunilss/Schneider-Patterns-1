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
            var result = "Rental Record for " + Name + "\n";
            foreach(Rental each in _rentals)
            {
              
                //show figures for this rental
                result += "\t" + each.Movie.Title + "\t" + each.GetAmount().ToString() + "\n";

            }
            //add footer lines
            result += "Amount owed is " + GetTotalAmount() + "\n";
            result += "You earned " + GetTotalFrequentRentalPoints() + " frequent renter points";

            return result;
        }

        public int GetTotalFrequentRentalPoints()
        {
            var frequentRentalPoints = 0;
            foreach(Rental each in _rentals)
            {

                each.GetFrequentRentalPoints();

            }
            return frequentRentalPoints;
        }

        public double GetTotalAmount()
        {
            double totalAmount = 0;
            foreach (Rental each in _rentals)
            {
                totalAmount += each.GetAmount();
            }
            return totalAmount;
        }

        
    }
}