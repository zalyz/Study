using SerializableAPI.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SerializableAPI.Classes
{
    public static class FileProcessing
    {
        public static Train[] Read(string fileName, IRepository<Train> repository)
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            Train[] trains = null;
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                trains = (Train[])repository.ReadFile(file);
            }

            return trains;
        }

        public static void Write(string fileName, ICollection<Train> trains, IRepository<Train> repository)
        {
            using (var file = new FileStream(fileName,FileMode.OpenOrCreate))
            {
                repository.WriteToFile(file, trains);
            }
        }
    }
}
