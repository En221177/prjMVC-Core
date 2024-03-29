﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjMVC_Core.Models
{
    public class CLottoGen
    {
        public string getNumbers()
        {
            Random rand = new Random();
            int count = 0;
            int[] numbers = new int[6];


            while (count < 6)
            {
                int temp = rand.Next(1,50);
                if (!is亂數已經存在陣列中(temp,numbers)) 
                {
                    numbers[count] = temp;
                    count++;
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length-1; j++)
                {
                    if (numbers[j]> numbers[j + 1])
                    {
                        int big= numbers[j];
                        numbers[j]= numbers[j+1];
                        numbers[j+1]= big;
                    }
                }
            }

            string s = "";
            foreach (int i in numbers)
                s += i.ToString() + " ";
            return s;
        }

        private bool is亂數已經存在陣列中(int temp, int[] numbers)
        {
            foreach (int i in numbers)
            {
                if(temp==i)
                    return true;
            }
            return false;
        }
    }
}
