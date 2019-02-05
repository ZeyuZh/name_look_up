using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.NameLookup
{
    public class Dictionary<T>
    {
        /// <summary>
        ///  giving the maximum length of any key (65535).
        /// </summary>
        private const int _maximumKeyLength = 65535;

        /// <summary>
        /// giving the value c + 1
        /// </summary>
        private const double _maximumSecondaryLengthFactor = 49/24.0;

        /// <summary>
        /// giving a hash function that always returns 0
        /// </summary>
        private static IHashFunction _zerohashFunction = new ZeroHashFunction();

        /// <summary>
        /// giving the primary hash function.
        /// </summary>
        private IHashFunction _primaryHashFunction;

        /// <summary>
        /// giving the primary hash table.
        /// </summary>
        private IHashFunction[] _primaryTable;

        /// <summary>
        /// giving the secondary hash tables.
        /// </summary>
        private KeyValuePair<string, T>[] _secondaryTables;

        /// <summary>
        /// giving the offsets of the secondary hash tables into the above array.
        /// </summary>
        private int[] _offsets;

        /// <summary>
        /// get the number of keys in the dictionary
        /// </summary>
        public int Count
        {
            get
            {
                return _primaryTable.Length;
            }
        }

        /// <summary>
        /// get the number of locations in the secondary hash tables
        /// </summary>
        public int SecondaryTableLength
        {
            get
            {
                return _secondaryTables.Length;
            }
        }

        /// <summary>
        /// method to find the maximum length of any key in a given list
        /// </summary>
        /// <param name="list">the list we want to caculate</param>
        /// <returns>giving the maximum length of any key in the given list.</returns>
        private static int MaximumKeyLength(IList<KeyValuePair<string,T>> list)
        {
            int max = 0;
            if(list == null)
            {
                throw new ArgumentException();
            }
            foreach(KeyValuePair<string, T> keyPair in list)
            {
                if(keyPair.Key == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    if(keyPair.Key.Length > max)
                    {
                        max = keyPair.Key.Length;
                    }
                }
                
            }
            return max;
        }

        /// <summary>
        /// find the sum of squares of array lengths in a given list
        /// </summary>
        /// <param name="list">the sum of list </param>
        /// <returns>the sum of squares </returns>
        private static long SumOfSquares(IList<KeyValuePair<string,T>>[] list)
        {
            long sum = 0;
            for(int i = 0; i < list.Length; i++)
            {
                sum += ((long)list[i].Count * list[i].Count);
            }
            return sum;
        }

        /// <summary>
        /// method to find the primary hash function
        /// </summary>
        /// <param name="list"> containing all of the keys and values.</param>
        /// <param name="hashTable">giving a hash table to fill</param>
        /// <param name="maxKeyLength"> giving the maximum length of any key</param>
        /// <returns> giving the sum of the squares of the sizes of each list in the hash table that was filled.</returns>
        private int FindPrimaryHashFunction(IList<KeyValuePair<string, T>> list, IList<KeyValuePair<string, T>>[] hashTable, int maxKeyLength)
        {
            long sum = 0;
            do
            {
                _primaryHashFunction = new RandomHashFunction(list.Count, maxKeyLength);
                for(int i = 0; i < hashTable.Length; i++)
                {
                    hashTable[i] = new List<KeyValuePair<string, T>>();
                }
                
                foreach(KeyValuePair<string, T> keyPair in list)
                {
                    hashTable[_primaryHashFunction.Hash(keyPair.Key)].Add(keyPair);
                }
                sum = SumOfSquares(hashTable);
            } while ((double)sum > (list.Count * _maximumSecondaryLengthFactor));
            return (int)sum;
        }

        /// <summary>
        /// method to determine if a given hash function mapping is perfect
        /// </summary>
        /// <param name="secondHashfunction">giving the secondary hash function to test.</param>
        /// <param name="firstTargetLoc">giving the first array location of the target secondary hash table</param>
        /// <param name="secondHashTableLength">giving the length of the target secondary hash table</param>
        /// <param name="elements">elements to place in the target secondary hash table.</param>
        /// <returns>indicating whether the mapping is perfect </returns>
        private bool IsPerfect(IHashFunction secondHashfunction, int firstTargetLoc, int secondHashTableLength, IList<KeyValuePair<string, T>> elements)
        {
            int loc;
            foreach(KeyValuePair<string,T> keyPair in elements)
            {
                loc = secondHashfunction.Hash(keyPair.Key) + firstTargetLoc;
                if (_secondaryTables[loc].Key == null)
                {
                    _secondaryTables[loc] = keyPair;
                }
                else
                {
                    for (int i = firstTargetLoc; i < firstTargetLoc + secondHashTableLength; i++)
                    {
                        _secondaryTables[i] = default(KeyValuePair<string, T>);
                    }
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// containing the keys and values to be stored in the dictionary.
        /// </summary>
        /// <param name="firstFilledLoc">giving the first location of the secondary hash table to be filled</param>
        /// <param name="list"> containing the keys and values to place in the table.</param>
        /// <returns>maps each key to a distinct location in the secondary hash table</returns>
        private IHashFunction fillSecondaryTable(int firstFilledLoc, IList<KeyValuePair<string,T>> list)
        {
            int length;
            IHashFunction second;
            RandomHashFunction result;
            if (list.Count == 1)
            {
                _secondaryTables[firstFilledLoc] = list[0];
                return _zerohashFunction;
            }
            else
            {
                length = list.Count * list.Count;
                int maxLength = MaximumKeyLength(list);
                do
                {
                    result = new RandomHashFunction(length, maxLength);
                } while (!IsPerfect(result, firstFilledLoc, maxLength, list));
                second = result;
                return second;
            }
        }

        /// <summary>
        ///  method to fill all the tables
        /// </summary>
        /// <param name="hashTable"></param>
        private void fillAllTables(IList<KeyValuePair<string,T>>[] hashTable)
        {
            int sum = 0;
            for(int i = 0; i < hashTable.Length; i++)
            {
                if(hashTable[i].Count > 0)
                {
                    _offsets[i] = sum;
                    _primaryTable[i] = fillSecondaryTable(sum, hashTable[i]);
                    sum += (hashTable[i].Count * hashTable[i].Count);
                }
                
            }
        }

        /// <summary>
        /// to counstruct the class
        /// </summary>
        /// <param name="list">the list containing the keys and values to be stored in the dictionary.</param>
        public Dictionary(IList<KeyValuePair<string, T>> list)
        {
            int maxLen = MaximumKeyLength(list);
            if(maxLen > _maximumKeyLength)
            {
                throw new ArgumentException("A key is longer than 65535.");
            }
            //The input file contains too many names (see under "Universal Families of Hash Functions" above). 
            //In this case, throw an ArgumentException with the message, "The dictionary has too many elements."
            if(list.Count > Int32.MaxValue / _maximumSecondaryLengthFactor)
            {
                throw new ArgumentException("The dictionary has too many elements.");
            }
            List<KeyValuePair<string, T>>[] tem = new List<KeyValuePair<string, T>>[list.Count];
            int find = FindPrimaryHashFunction(list, tem, maxLen);
            _primaryTable = new IHashFunction[list.Count];
            _secondaryTables = new KeyValuePair<string, T>[find];
            _offsets = new int[list.Count];
            fillAllTables(tem);
        }

        /// <summary>
        ///  indicating whether the key was found
        /// </summary>
        /// <param name="key"> giving the key to look for</param>
        /// <param name="value">store the value associated with the given key</param>
        /// <returns></returns>
        public bool TryGetValue(string key, out T value)
        {
            if(key == null)
            {
                throw new ArgumentException();
            }
            
            int firstLoc = _primaryHashFunction.Hash(key);
            value = default(T);
            if (_primaryTable[firstLoc] == null)
            {
                return false;
            }
            else
            {
                firstLoc = _primaryTable[firstLoc].Hash(key) + _offsets[firstLoc];
                if (key.Equals(_secondaryTables[firstLoc].Key))
                {
                    value = _secondaryTables[firstLoc].Value;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
    }
}
