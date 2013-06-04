using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Threading;

namespace MEFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var tranformer = new MovieTransformer(new InMemoryMovieSource(), new CsvMoviePersistor());
            //tranformer.Transform();

            

            var assemblyCatalog = new AssemblyCatalog(typeof (Program).Assembly);
            var directoryCatalog = new DirectoryCatalog("plugins");
            var aggregateCatalog = new AggregateCatalog(assemblyCatalog, directoryCatalog);

            var container = new CompositionContainer(aggregateCatalog);

            var c = container.GetExport<IMovieTransformer>();
            


            var movieTransformer = container.GetExportedValue<IMovieTransformer>();
            movieTransformer.Transform();
            Console.WriteLine("Done");

            var lazyEmp = new MyLazy<Employee>(GetEmployeeFromDatabase);
            Console.WriteLine(lazyEmp.HasValue);
            Console.WriteLine(DateTime.Now);
            var emp = lazyEmp.Value;
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(lazyEmp.HasValue);
            Console.WriteLine(DateTime.Now);
             emp = lazyEmp.Value;
            Console.WriteLine(DateTime.Now);
            Console.ReadLine();

        }

        public static Employee GetEmployeeFromDatabase()
        {
            Thread.Sleep(5000);
            return new Employee {Id = 101};
        }
    }



    public class Employee
    {
        public int Id { get; set; }
    }
    public class MyLazy<T>
    {
        private readonly Func<T> _initializer;
        private T _value;
        
        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    _value = _initializer();
                    HasValue = true;
                }
                return _value; 
            }
        }

        public bool HasValue { get; private set; }

        public MyLazy(Func<T> initializer )
        {
            _initializer = initializer;
        }
    }
}
