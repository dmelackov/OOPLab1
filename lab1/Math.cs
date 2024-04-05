static class MyMath
{
    public static int NOK(int a, int b)
    {
        return Math.Abs(a*b)/MyMath.NOD(a, b);
    }
    public static int NOD(int a, int b)
    {
        if (b < 0)
            b = -b;
        if (a < 0)
            a = -a;
        while (b > 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}