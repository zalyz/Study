using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SerializableAPI.Repository
{
    public class BinaryRepository : IRepository<Train>
    {
        public ICollection<Train> ReadFile(Stream inputStream)
        {
            try
            {
                var binaryFormatter = new BinaryFormatter();
                return (Train[])binaryFormatter.Deserialize(inputStream);
            }
            catch
            {
                throw;
            }
        }

        public void WriteToFile(Stream outputStream, ICollection<Train> collection)
        {
            try
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(outputStream, collection);
            }
            catch
            {
                throw;
            }
        }
    }
}
