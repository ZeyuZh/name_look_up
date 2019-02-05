using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.NameLookup
{
    [Serializable]
    public class ZeroHashFunction: IHashFunction
    {
        /// <summary>
        /// method for the hash function
        /// </summary>
        /// <param name="str"></param>
        /// <returns> simply return a 0</returns>
        public int Hash(string str)
        {
            return 0;
        }
    }
}
