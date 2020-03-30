using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Task3, string> TaskSolver = task =>
            {
                // Your solution goes here
                // You can get all needed inputs from task.[Property]
                // Good luck!
                string UserLongitude = task.UserLongitude;
                string UserLatitude = task.UserLatitude;
                int placesAmount = task.DefibliratorStorages.Length;

                float.TryParse(UserLatitude, out float fUserLatitude);
                float.TryParse(UserLongitude, out float fUserLongitude);

                float distance = float.MaxValue;

                const float degreeToRadCoef = 0.0174533f;

                fUserLongitude *= degreeToRadCoef;
                fUserLatitude *= degreeToRadCoef;

                string resName = "", resAddress = ""; 

                for (int i = 0; i < placesAmount; i++)
                {
                    string defibliratorStorage = task.DefibliratorStorages[i];

                    string[] defibliratorStorageArr = defibliratorStorage.Split(';');
                    
                    float.TryParse(defibliratorStorageArr[2], out float lognitude);
                    float.TryParse(defibliratorStorageArr[3], out float latitude);

                    lognitude *= degreeToRadCoef;
                    latitude *= degreeToRadCoef;

                    float x = (lognitude - fUserLongitude) * MathF.Cos((latitude + fUserLatitude) / 2);
                    float y = latitude - fUserLatitude;

                    float d = MathF.Sqrt(x * x + y * y) * 6371f;

                    if(d < distance)
                    {
                        distance = d;
                        resName = defibliratorStorageArr[0];
                        resAddress = defibliratorStorageArr[1];
                    }
                }
                string result = string.Format("Name: {0}; Address: {1}", resName, resAddress);
                System.Console.WriteLine(result);
                return result;
            };

            Task3.CheckSolver(TaskSolver);

        }
    }
}
