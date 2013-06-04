using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MVVMDemo
{
    public class SalaryCalculator : INotifyPropertyChanged
    {
        private double _basic;
        private double _hra;
        private double _da;
        private int _tax;

        public double Basic
        {
            get { return _basic; }
            set
            {
                _basic = value;
                OnPropertyChanged("Basic");
                OnPropertyChanged("Salary");

            }
        }

        public double Hra
        {
            get { return _hra; }
            set { _hra = value;
            OnPropertyChanged("Hra");
            OnPropertyChanged("Salary");
            }
        }

        public double Da
        {
            get { return _da; }
            set
            {
                _da = value;
                OnPropertyChanged("Da");
                OnPropertyChanged("Salary");

            }
        }

        public int Tax
        {
            get { return _tax; }
            set
            {
                _tax = value;
                OnPropertyChanged("Tax");
                OnPropertyChanged("Salary");

            }
        }

        public double Salary
        {
            get { var net = Basic + Hra + Da;
                var taxable = net*(Tax)/100;
                return net - taxable;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
