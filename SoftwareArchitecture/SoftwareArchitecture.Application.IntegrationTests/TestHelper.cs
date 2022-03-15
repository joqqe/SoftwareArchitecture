using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Application.IntegrationTests
{
    public static class TestHelper
    {
        /// <summary>
        /// Method Equals must be overriden of object"
        /// </summary>
        /// <param name="expect"></param>
        /// <param name="actual"></param>
        /// <returns></returns>
        public static bool ListCompare<T>(this List<T> expect, List<T> actual)
        {
            return expect.All(e => actual.Any(a => e.Equals(a)))
                && actual.All(a => expect.Any(e => a.Equals(e)));
        }
    }
}
