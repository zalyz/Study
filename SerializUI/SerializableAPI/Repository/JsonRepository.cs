using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SerializableAPI.Repository
{
    public class JsonRepository : IRepository<Train>
    {
        public ICollection<Train> ReadFile(Stream inputStream)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Train[]));
            return (Train[])formatter.ReadObject(inputStream);
        }

        public void WriteToFile(Stream outputStream, ICollection<Train> collection)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Train[]));
            formatter.WriteObject(outputStream, collection);
        }
    }
}
