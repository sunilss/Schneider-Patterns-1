﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalReport
{
    public class Movies : IEnumerable<Movie>, IEnumerator<Movie>
    {
        private ArrayList _list = new ArrayList();
        public void Add(Movie movie)
        {
            _list.Add(movie);
        }
        public void Remove(Movie movie)
        {
            _list.Remove(movie);
        }

        public Movie this[int index]
        {
            get { return _list[index] as Movie; }
        }

        //Iterator pattern implementation

        private int index = -1;
        public IEnumerator<Movie> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            index = -1;
        }

        public bool MoveNext()
        {
            index++;
            if (index < _list.Count) return true;
            Reset();
            return false;
        }

        public void Reset()
        {
            index = -1;
        }

        public Movie Current { get { return _list[index] as Movie; } }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Sort()
        {
            Sort(new MovieComparerById());
        }

        public void Sort(IMovieComparer comparer)
        {
            for (int i = 0; i < _list.Count -1; i++)
            {
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (Movie) _list[i];
                    var right = (Movie) _list[j];
                       
                    if (comparer.Compare(left,right) > 0)
                    {
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }

                }
            }
        }

        public void Sort(CompareMovieDelegate compare)
        {
            for (int i = 0; i < _list.Count - 1; i++)
            {
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (Movie)_list[i];
                    var right = (Movie)_list[j];

                    if (compare(left, right) > 0)
                    {
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }

                }
            }
        }

        public IEnumerable<Movie> Filter(IMovieSpecification specification)
        {
            foreach (var item in _list)
            {
                var movie = (Movie) item;
                if (specification.IsSatisfiedBy(movie))
                    yield return movie;
            }
        }

        public IEnumerable<Movie> Filter(IsSatisfiedByDelegate isSatisfiedBy)
        {
            foreach (var item in _list)
            {
                var movie = (Movie)item;
                if (isSatisfiedBy(movie))
                    yield return movie;
            }
        }

    }

    public interface IMovieSpecification
    {
        bool IsSatisfiedBy(Movie movie);
    }

    public class OrSpecification : IMovieSpecification
    {
        private readonly IMovieSpecification _left;
        private readonly IMovieSpecification _right;

        public OrSpecification(IMovieSpecification left, IMovieSpecification right)
        {
            _left = left;
            _right = right;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            return _left.IsSatisfiedBy(movie) || _right.IsSatisfiedBy(movie);
        }
    }



    public delegate bool IsSatisfiedByDelegate(Movie movie);

    public class InverseSpecification : IMovieSpecification
    {
        private readonly IMovieSpecification _specification;

        public InverseSpecification(IMovieSpecification specification)
        {
            _specification = specification;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            return !_specification.IsSatisfiedBy(movie);
        }
    }

    public class MovieSpecificationByPriceCode : IMovieSpecification
    {
        private readonly int _priceCode;
        private readonly bool _inverse;

        public MovieSpecificationByPriceCode(int priceCode)
        {
            _priceCode = priceCode;
        }


        public bool IsSatisfiedBy(Movie movie)
        {
            return movie.PriceCode == _priceCode;
        }
    }

    public interface IMovieComparer
    {
        int Compare(Movie left, Movie right);
    }

    public delegate int CompareMovieDelegate(Movie left, Movie right);

    public class MovieComparerById : IMovieComparer
    {
        public int Compare(Movie left, Movie right)
        {
            if (left.Id < right.Id) return -1;
            if (left.Id > right.Id) return 1;
            return 0;
        }
    }

    public class MovieComparerByReleaseDate : IMovieComparer
    {
        public int Compare(Movie left, Movie right)
        {
            if (left.ReleaseDate < right.ReleaseDate) return -1;
            if (left.ReleaseDate > right.ReleaseDate) return 1;
            return 0;
        }
    }

    public enum MovieSortType
    {
        Id,Title,PriceCode,ReleaseDate
    }
}
