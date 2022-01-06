namespace LibraryApp
{
    public class Operation
    {
        public int SumNumber(int num1, int num2)
        {
            return num1 + num2;
        }

        public bool IsValuePair(int num)
        {
            return num % 2 == 0;
        }

        public double SumDouble( double dec1, double dec2)
        {
            return dec1 + dec2;
        }
    }
}