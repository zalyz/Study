using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Lab3
{
    class OneDementionArray
    {
        private int[] _array;

        public int GetLength
        {
            get
            {
                return _array.Length;
            }
        }

        public int this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public int GetMultipliedElements()
        {
            if (_array.Length > 0)
            {
                var mult = 1;
                foreach (var elem in _array)
                {
                    if (elem % 2 == 0)
                    {
                        mult *= elem;
                    }
                }

                return mult;
            }

            return 0;
        }

        public int GetMultipliedElements(int indexFrom, int indexTo)
        {
            if (indexFrom > indexTo)
                return 0;

            if (_array.Length > 0 && indexFrom <= _array.Length && indexTo <= _array.Length)
            {
                var mult = 1;
                for (int i = indexFrom; i <= indexTo; i++)
                {
                    mult *= _array[i];
                }

                return mult;
            }

            return 0;
        }

        public void Sort()
        {
            _array = _array.Where(e => e >= 0).OrderBy(t => t).Concat(
                _array.Where(e => e < 0).OrderByDescending(t => t)).ToArray();
        }

        public OneDementionArray(int[] arr)
        {
            _array = arr;
        }

        public OneDementionArray(int sizeOfArray)
        {
            _array = new int[sizeOfArray];
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = 3;
            }
        }
    }
}
