using System.Collections.Generic;

namespace TasksDay2
{
    public class Task4
    {
        /// <summary>
        /// Filters list of nubers by a pivotal digit
        /// </summary>
        /// <param name="pivot">Source pivotal digit</param>
        /// <param name="listOfNumbers">Source list of Numbers</param>
        /// <returns>Filtered list of numbers which contains source pivotal digit</returns>
        public static List<int> FilterDigit(int pivot, List<int> listOfNumbers)
        {
            List<int> filtredList = new List<int>();
            foreach (int num in listOfNumbers)
            {
                int temp = num;
                bool isChack = true;
                while (temp > 0)
                {
                    if (temp % 10 == pivot)
                    {
                        foreach (var item in filtredList)
                        {
                            if (item== num)
                            {
                                isChack = false;
                                break;
                            }
                            isChack = true;
                        }
                        if (isChack)
                        {
                            filtredList.Add(num);
                        }                        
                    }
                    temp /= 10;
                }
            }
            return filtredList;
        }
    }
}
