using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksDay2
{
    public class Task1
    {
        /// <summary>
        /// Method that inserts bits from i to j position
        /// </summary>
        /// <param name="numSource">Source number</param>
        /// <param name="numInsert">Inserted number</param>
        /// <param name="i">Begin(right) position</param>
        /// <param name="j">End(left) position</param>
        /// <returns></returns>
        public static int InsertNumber(int numSource, int numInsert, int i, int j)
        {
            if (i > j || i < 0 || i > 31 || j < 0 || j > 31)
            {
                throw new ArgumentOutOfRangeException("Incorrect bits' positions index");
            }

            int point = ((2 << (j - i)) - 1) << i;
            return (numSource & ~point) | ((numInsert << i) & point);
        }
    }
}
