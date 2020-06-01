using SerializableAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SerializableAPI
{

    /// <summary>
    /// Train class.
    /// </summary>
    [Serializable]
    public class Train
    {
        private Clock arrivalTime = new Clock();

        private Clock departureTime = new Clock();

        public Train()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Station"/> class.
        /// </summary>
        /// <param name="numberOfTrain">Number of the train.</param>
        /// <param name="trainName">Train name.</param>
        /// <param name="category">Category of the train.</param>
        public Train(uint numberOfTrain = 0, string trainName = "", string category = "")
        {
            this.TrainNumber = numberOfTrain;
            this.TrainName = trainName;
            this.Category = category;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Station"/> class.
        /// </summary>
        /// <param name="numberOfTrain">Train number.</param>
        /// <param name="trainName">Train name.</param>
        /// <param name="category">Category of the train.</param>
        /// <param name="arrivalTime">Arrval time of the train.</param>
        /// <param name="departureTime">Departure time of the train.</param>
        public Train(uint numberOfTrain, string trainName, string category, Clock arrivalTime, Clock departureTime)
            : this(numberOfTrain, trainName, category)
        {
            this.arrivalTime = arrivalTime;
            this.departureTime = departureTime;
        }

        /// <summary>
        /// Gets or sets train number.
        /// </summary>
        public uint TrainNumber { get; set; }

        /// <summary>
        /// Gets or sets train name.
        /// </summary>
        public string TrainName { get; set; }

        /// <summary>
        /// Gets or sets category of the train.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets arrival time of the train.
        /// </summary>
        public Clock ArrivalTime
        {
            get
            {
                return this.arrivalTime;
            }

            set
            {
                this.arrivalTime = value;
            }
        }

        /// <summary>
        /// Gets or sets departure time of the train.
        /// </summary>
        public Clock DepartureTime
        {
            get
            {
                return this.departureTime;
            }

            set
            {
                this.departureTime = value;
            }
        }

        /// <summary>
        /// Return train in string form.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            string infAboutTrain = this.TrainNumber.ToString() + "|" + this.TrainName.ToString() + "|" + this.Category.ToString() + "|" + this.arrivalTime.ToString() + "/" + this.departureTime.ToString() + "|";
            return infAboutTrain;
        }
    }
}
