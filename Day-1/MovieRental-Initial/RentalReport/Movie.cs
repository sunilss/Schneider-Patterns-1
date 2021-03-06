﻿namespace RentalReport
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
    }
}