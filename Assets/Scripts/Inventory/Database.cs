using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBase
{
    public class Database
    {

        public static int GetMaxCount(int ID)
        {
            switch (ID)
            {
                case (1):
                    return 5;
                case (2):
                    return 4;
                default:
                    return 1;
            }

        }

    }
}

