using System;
using System.Collections.Generic;
using System.IO;

namespace SerializableAPI.Repository
{
    public interface IRepository<T>
    {
        public ICollection<T> ReadFile(Stream inputStream);

        public void WriteToFile(Stream outputStream, ICollection<T> collection);
    }
}
