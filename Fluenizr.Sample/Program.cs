using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluenizr;

namespace Fluenizr.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person()
                .Fluenize()
                .FirstName("Omar")
                .LastName("Garcia")
                .TypedInstance;

            Person ap = Fluenizr.New<Person>()
                .FirstName("Omar")
                .LastName("Garcia");
        }
    }
}
