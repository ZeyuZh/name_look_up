using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.NameLookup
{
    public interface IHashFunction
    {
        /// <summary>
        /// compute a hash function
        /// </summary>
        /// <param name="str">the key we want to compute</param>
        /// <returns>the result we computed</returns>
        int Hash(string str);
    }
}
