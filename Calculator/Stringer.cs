namespace Calculator
{
    public static class Stringer
    {
        public static int HowManyTimes(string read, char value)
        {
            var ar = read.Split(value);
            var num = ar.Length - 1;
            return num;
        }
    }
}