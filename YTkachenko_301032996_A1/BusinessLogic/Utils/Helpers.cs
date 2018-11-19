using System;
using System.IO;

namespace BusinessLogic.Utils
{
    public static class Helpers
    {
        private static readonly Random Random = new Random();
        private static readonly object Synclock = new object();

        public static string[] ReadRecordsFromFile(string fileName)
        {
            var records = new string[20];

            var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var reader = new StreamReader(stream);

            string record = reader.ReadLine();
            var counter = 0;

            while (record != null)
            {
                records[counter++] = record;
                record = reader.ReadLine();
            }

            reader.Close();
            stream.Close();

            return records;
        }

        public static bool CheckIfIdExists(int[] ids, int value)
        {
            foreach (var id in ids)
            {
                if (id == value)
                {
                    return true;
                }
            }

            return false;
        }

        public static int GenerateUniqueId(int[] ids)
        {
            int newId;
            lock (Synclock)
            {
                newId = Random.Next(0, int.MaxValue);
            }

            if (CheckIfIdExists(ids, newId))
            {
                newId = GenerateUniqueId(ids);
            }

            return newId;
        }

        public static void InsertValueInArray(int[] ids, int value)
        {
            for(var i = 0; i < ids.Length; i++)
            {
                if (ids[i] == 0)
                {
                    ids[i] = value;
                    break;
                }
            }
        }
    }
}