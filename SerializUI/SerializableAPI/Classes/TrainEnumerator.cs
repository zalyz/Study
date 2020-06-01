using System;
using System.Collections;
using System.Collections.Generic;

namespace SerializableAPI.Classes
{
    /// <summary>
    /// Enumerator for class train.
    /// </summary>
    public class TrainEnumerator : IEnumerator<Train>
    {
        private int position = -1;

        private Train[] arrayOfTrains;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainEnumerator"/> class.
        /// </summary>
        /// <param name="array">Array of ogjects.</param>
        public TrainEnumerator(Train[] array)
        {
            this.ArrayOfTrains = array;
        }

        /// <summary>
        /// Gets or sets array of trains.
        /// </summary>
        public Train[] ArrayOfTrains
        {
            get
            {
                return this.arrayOfTrains;
            }

            set
            {
                this.arrayOfTrains = value;
            }
        }

        /// <summary>
        /// Gets or sets position in the array.
        /// </summary>
        public int Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        /// <summary>
        /// Gets sumthing.
        /// </summary>
        public Train Current
        {
            get
            {
                if (this.Position == -1 || this.Position > this.ArrayOfTrains.Length)
                {
                    throw new InvalidOperationException();
                }

                return this.ArrayOfTrains[this.Position];
            }
        }

        /// <summary>
        /// Sumething.
        /// </summary>
        /// <inheritdoc/>
        object IEnumerator.Current => throw new NotImplementedException();

        /// <summary>
        /// Move to the next element in the sequence.
        /// </summary>
        /// <returns>Bool value.</returns>
        public bool MoveNext()
        {
            if (this.position < this.ArrayOfTrains.Length)
            {
                this.position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sumething.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Sumething.
        /// </summary>
        public void Reset()
        {
            this.position = -1;
        }
    }
}
