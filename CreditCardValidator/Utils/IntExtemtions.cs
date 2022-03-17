namespace CreditCardValidator.Utils
{
    public static class IntExtemtions
    {
        public static int SumOfDigits(this int num)
        {
            int sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }
    }
}
