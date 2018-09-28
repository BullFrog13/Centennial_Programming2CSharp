using System;

namespace Assessment_1.Utils
{
    public static class Helpers
    {
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
            var random = new Random();
            var newId = random.Next(0, int.MaxValue);

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