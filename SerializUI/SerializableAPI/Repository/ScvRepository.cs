using System;
using System.Collections.Generic;
using System.IO;
using ServiceStack.Text;

namespace SerializableAPI.Repository
{
    public class ScvRepository : IRepository<Train>
    {
        public ICollection<Train> ReadFile(Stream inputStream)
        {
            return CsvSerializer.DeserializeFromStream<Train[]>(inputStream);
        }

        public void WriteToFile(Stream outputStream, ICollection<Train> collection)
        {
            outputStream.WriteCsv(collection);
        }
    }
}
