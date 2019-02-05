using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.NameLookup
{
    [Serializable]
    public class RandomHashFunction: IHashFunction
    {
        /// <summary>
        /// which is a pseudo-random number generator.
        /// </summary>
        private static Random _randomNumbers = new Random();

        /// <summary>
        /// giving the number of locations in the hash table.
        /// </summary>
        private int _tableLength;

        /// <summary>
        /// giving the random value to add
        /// </summary>
        private int _addedValue;

        /// <summary>
        /// giving the random value to be multiplied by the key's length
        /// </summary>
        private int _lengthMultiplier;

        /// <summary>
        /// contain the values to be multiplied by the characters in the key
        /// </summary>
        private int[] _characterMultipliers;

        /// <summary>
        /// the constructor of the RandomHashFunction
        /// </summary>
        /// <param name="loc">giving the number of locations</param>
        /// <param name="maxLen">giving the maximum length of any key for this hash table</param>
        public RandomHashFunction(int loc, int maxLen)
        {
            _tableLength = loc;                                       //m
            _addedValue = _randomNumbers.Next(Int32.MaxValue);        //a0
            _lengthMultiplier = _randomNumbers.Next(Int32.MaxValue);  //a1
            _characterMultipliers = new int[maxLen];                  //b
            for(int i = 0; i < _characterMultipliers.Length; i++)
            {
                _characterMultipliers[i] = _randomNumbers.Next(Int32.MaxValue);
            }
        }

        /// <summary>
        /// method to compute the hash function
        /// </summary>
        /// <param name="str">the key we want to hash</param>
        /// <returns>get the result of the hash function</returns>
        public int Hash(string str)
        {
            long sum = 0;
            for(int i = 0; i < str.Length; i++)
            {
                sum += ((long)_characterMultipliers[i] * str[i]);
            }

            return (int)(((long)_addedValue + _lengthMultiplier * str.Length + sum) % Int32.MaxValue % _tableLength);
        }
    }
}
