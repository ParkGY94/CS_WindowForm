using System;

namespace PI_100
{
    class Program
    {
        static void Main(string[] args)
        {
            int SCALE = 10000;
            int MAX_ARRAY = 1400;
            int array_ = 2000;
            int i, j, sum, carry = 0;
            int[] array= new int[MAX_ARRAY + 1];
            int result = 0;
            string output = "";
            for (i = 0; i <= MAX_ARRAY; ++i) array[i] = array_; 

            for (i = MAX_ARRAY; i > 0; i -= 56)
            {
                sum = 0;
                for (j = i; j > 0; --j)
                {
                    sum = sum * j + SCALE * array[j];
                    array[j] = sum % (j * 2 - 1);
                    sum /= (j * 2 - 1);
                }
                result = carry + sum / SCALE;
                if (result / 1000 == 0)
                {
                    if (result / 100 == 0)
                    {
                        if (result / 10 == 0)
                        {
                            output = "0" + result.ToString();
                        }
                        output = "0" + result.ToString();
                    }
                    output = "0" + result.ToString();
                }
                else output = result.ToString();
                if (i == MAX_ARRAY)
                {
                    output = (result / 1000).ToString() + "." + (result % 1000).ToString();
                }
                Console.Write(output);
                carry = sum % SCALE;
            }
        }
    }
}
