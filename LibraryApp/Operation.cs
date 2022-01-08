namespace LibraryApp
{
    public class Operation
    {
        public List<int> oddNumbers = new();

        public int SumNumber(int num1, int num2)
        {
            return num1 + num2;
        }

        public bool IsEvenValue(int num)
        {
            return num % 2 == 0;
        }

        public double SumDouble(double dec1, double dec2)
        {
            return dec1 + dec2;
        }

        public List<int> GetListOddNumbers(int minInterval, int maxInterval)
        {
            oddNumbers.Clear();
            for (int i = minInterval; i <= maxInterval; i++)
            {
                if (i % 2 != 0)//odd number
                {
                    oddNumbers.Add(i);
                }
            }

            return oddNumbers;
        }
    }
}