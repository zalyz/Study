using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SerializableAPI.Repository
{
    public class XMLRepository: IRepository<Train>
    {
        public ICollection<Train> ReadFile(Stream inputStream)
        {
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(Train[]));
            return (Train[])xmlFormatter.Deserialize(inputStream);
        }

        public void WriteToFile(Stream outputStream, ICollection<Train> collection)
        {
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(Train[]));
            xmlFormatter.Serialize(outputStream, collection);
        }
    }
}
