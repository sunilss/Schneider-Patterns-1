namespace RentalReport
{
    public abstract class MovieBase
    {
        protected string _title;

        public string Title
        {
            get { return _title; }
        }

        protected MovieBase(string title)
        {
            _title = title;
        }

        public abstract double GetAmount(int daysRented);

        public virtual int GetFrequentRentalPoints(int daysRented)
        {
            return 1;
        }
    }
}