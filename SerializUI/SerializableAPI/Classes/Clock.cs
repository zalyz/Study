using System;
using System.Collections.Generic;
using System.Text;

namespace SerializableAPI.Classes
{
    /// <summary>
    /// My class for time.
    /// </summary>
    [Serializable]
    public class Clock
    {
        private uint hour;
        private uint minute;

        public Clock()
        {
            hour = 0;
            minute = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Clock"/> class.
        /// </summary>
        /// <param name="hour">Hour of current time.</param>
        /// <param name="minute">Minute of current time.</param>
        public Clock(uint hour = 0, uint minute = 0)
        {
            if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60)
            {
                this.hour = hour;
                this.minute = minute;
            }
        }

        public Clock(string time)
        {
            var splitedTime = time.Split(':');
            var hourse = uint.Parse(splitedTime[0]);
            var minutes = uint.Parse(splitedTime[1]);
            if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60)
            {
                this.hour = hourse;
                this.minute = minutes;
            }
        }

        /// <summary>
        /// Gets or sets are hours.
        /// </summary>
        public uint Hour
        {
            get
            {
                return this.hour;
            }

            set
            {
                if (value < 24)
                {
                    this.hour = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets return are minutes.
        /// </summary>
        public uint Minutes
        {
            get
            {
                return this.minute;
            }

            set
            {
                if (value < 60)
                {
                    this.minute = value;
                }
            }
        }

        /// <summary>
        /// Return the objekt in the string form.
        /// </summary>
        /// <returns> string. </returns>
        public override string ToString()
        {
            string getTime = this.hour.ToString() + ":" + this.minute.ToString();
            return getTime;
        }
    }
}
