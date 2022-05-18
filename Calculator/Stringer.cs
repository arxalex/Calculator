using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Stringer
{
    public static int HowManyTimes(string read, char value)
    {
        string[] ar = read.Split(value);
        int num = ar.Length - 1;
        return num;
    }
}

