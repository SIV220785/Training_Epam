﻿using System;
using System.Collections.Generic;

namespace TasksDay2
{
    public class Task2
    {

        /// <summary>
        /// Finding the nearest number which is bigger then source
        /// </summary>
        /// <param name="number">Source number </param>
        /// <returns>Next bigger number</returns>
        public static int? FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                return null;
            }
            var digitCount = (int)Math.Log10(number);
            int tmpNumber = number + 1;
            var listNumbers = ParseNumber(number);
            while(true)
            {
                if (tmpNumber == (int)Math.Pow(10, digitCount + 1))
                {
                    return null;
                }
                if (IsChack(tmpNumber, listNumbers))
                {
                    return tmpNumber;
                }
                else
                {
                    tmpNumber++;
                }                
            }
            
        }

        /// <summary>
        /// Method of dividing a number into numbers
        /// </summary>
        /// <param name="number">Source number</param>
        /// <returns>Digits collection of numbers</returns>
        private static List<int> ParseNumber(int number)
        {
            int tmpNumber = number;
            List<int> listNumbs = new List<int>();

            while (tmpNumber > 0)
            {
                listNumbs.Add(tmpNumber % 10);
                tmpNumber /= 10;
            }
            return listNumbs;
        }

        /// <summary>
        /// Search for the desired number
        /// </summary>
        /// <param name="number">Checked Number</param>
        /// <param name="listNumbers">Source list numbers</param>
        /// <returns>Is the number found</returns>
        private static bool IsChack(int number , List<int> listNumbers)
        {
            var digitCount = (int)Math.Log10(number)+1;
            List<int> sourseList = new List<int>();
            foreach (var item in listNumbers)
            {
                sourseList.Add(item);
            }
            List<int> tmpNumbers = ParseNumber(number);
            while (tmpNumbers.Count != 0)
            {
                foreach (var item in sourseList)
                {
                    foreach (var item2 in tmpNumbers)
                    {
                        if (item == item2)
                        {
                            tmpNumbers.Remove(item2);
                            break;
                        }                    
                    }              
                }
                break;
            }
            if (tmpNumbers.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
