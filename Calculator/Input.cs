using System;

namespace Calculator
{
    public static class Input
    {
        private static double CalcString(string read)
        {
            var all = read.ToCharArray();
            read = read.Replace(" ", "");
            read = read.Replace(":", "/");
            read = read.Replace('.', ',');
            read = read.Replace('ю', ',');
            read = read.Replace('Ю', ',');
            read = read.Replace('б', ',');
            read = read.Replace('Б', ',');
            read = read.Replace('е', 'e');
            read = read.Replace('Е', 'e');
            read = read.Replace('у', 'e');
            read = read.Replace('У', 'e');
            var lp = Stringer.HowManyTimes(read, '(');
            var rp = Stringer.HowManyTimes(read, ')');
            var blya = lp == rp;
            double result = 0;
            if (blya)
            {
                var w = read.IndexOf(')');
                if (w == -1)
                {
                    var ars = read.Split(new[] {'/', '*', '+', '-', '^'}, StringSplitOptions.RemoveEmptyEntries);
                    var ar = new double[ars.Length];
                    for (var i = 0; i < ar.Length; i++)
                    {
                        ar[i] = Exeption4Double(ref ars[i], out var b);
                        if (!b) blya = false;
                    }

                    if (blya)
                    {
                        var ard = read.Split(new[] {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', 'e'},
                            StringSplitOptions.RemoveEmptyEntries);
                        if (ar.Length == ard.Length)
                        {
                            if (ard[0] == "-")
                            {
                                ar[0] = -ar[0];
                                var temp1 = new string[ard.Length - 1];
                                for (var i = 0; i < temp1.Length; i++) temp1[i] = ard[i + 1];
                                ard = temp1;
                            }
                            else
                            {
                                if (ard[0] == "+")
                                {
                                    var temp1 = new string[ard.Length - 1];
                                    for (var i = 0; i < temp1.Length; i++) temp1[i] = ard[i + 1];
                                    ard = temp1;
                                }
                                else
                                {
                                    //throw new FormatException("Введённое выражение или число содержит ошибку, или не является числом или выражением. 0x01");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(
                                        "\aВведённое выражение или число содержит ошибку, или не является числом или выражением");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                            }
                        }

                        var ardlen = ard.Length;
                        for (var i = 0; i < ardlen; i++)
                            if (ard[i] == "^")
                            {
                                ar[i] = Math.Pow(ar[i], ar[i + 1]);
                                ar = Changer.ArrElemDelete(ar, i + 1);
                                ard = Changer.ArrElemDelete(ard, i);
                                i--;
                                ardlen--;
                            }
                            else
                            {
                                if (ard[i] == "^-")
                                {
                                    ar[i] = Math.Pow(ar[i], -ar[i + 1]);
                                    ar = Changer.ArrElemDelete(ar, i + 1);
                                    ard = Changer.ArrElemDelete(ard, i);
                                    i--;
                                    ardlen--;
                                }
                            }

                        ardlen = ard.Length;
                        for (var i = 0; i < ardlen; i++)
                            if (ard[i] == "*")
                            {
                                ar[i] = ar[i] * ar[i + 1];
                                ar = Changer.ArrElemDelete(ar, i + 1);
                                ard = Changer.ArrElemDelete(ard, i);
                                i--;
                                ardlen--;
                            }
                            else
                            {
                                if (ard[i] == "*-")
                                {
                                    ar[i] = ar[i] * ar[i + 1] * -1;
                                    ar = Changer.ArrElemDelete(ar, i + 1);
                                    ard = Changer.ArrElemDelete(ard, i);
                                    i--;
                                    ardlen--;
                                }
                                else
                                {
                                    if (ard[i] == "/")
                                    {
                                        ar[i] = ar[i] / ar[i + 1];
                                        ar = Changer.ArrElemDelete(ar, i + 1);
                                        ard = Changer.ArrElemDelete(ard, i);
                                        i--;
                                        ardlen--;
                                    }
                                    else
                                    {
                                        if (ard[i] == "/-")
                                        {
                                            ar[i] = ar[i] / ar[i + 1] * -1;
                                            ar = Changer.ArrElemDelete(ar, i + 1);
                                            ard = Changer.ArrElemDelete(ard, i);
                                            i--;
                                            ardlen--;
                                        }
                                    }
                                }
                            }

                        ardlen = ard.Length;
                        for (var i = 0; i < ardlen; i++)
                            if (ard[i] == "+")
                            {
                                ar[i] = ar[i] + ar[i + 1];
                                ar = Changer.ArrElemDelete(ar, i + 1);
                                ard = Changer.ArrElemDelete(ard, i);
                                i--;
                                ardlen--;
                            }
                            else
                            {
                                if (ard[i] == "-")
                                {
                                    ar[i] = ar[i] + ar[i + 1];
                                    ar = Changer.ArrElemDelete(ar, i + 1);
                                    ard = Changer.ArrElemDelete(ard, i);
                                    i--;
                                    ardlen--;
                                }
                                else
                                {
                                    if (ard[i] == "+-")
                                    {
                                        ar[i] = ar[i] - ar[i + 1];
                                        ar = Changer.ArrElemDelete(ar, i + 1);
                                        ard = Changer.ArrElemDelete(ard, i);
                                        i--;
                                        ardlen--;
                                    }
                                    else
                                    {
                                        if (ard[i] == "--")
                                        {
                                            ar[i] = ar[i] + ar[i + 1];
                                            ar = Changer.ArrElemDelete(ar, i + 1);
                                            ard = Changer.ArrElemDelete(ard, i);
                                            i--;
                                            ardlen--;
                                        }
                                    }
                                }
                            }
                    }
                    else
                    {
                        //throw new FormatException("Введённое выражение или число содержит ошибку, или не является числом или выражением. 0x02");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(
                            "\aВведённое выражение или число содержит ошибку, или не является числом или выражением");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    result = ar[0];
                }
                else
                {
                    var read2 = read.Remove(w);
                    var q = read2.LastIndexOf('(');
                    var read3 = read2.Remove(0, q + 1);
                    var res = CalcString(read3);
                    var read21 = read.Remove(q);
                    var c211 = read21.Length;
                    var read212 = read21.TrimEnd('0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
                    var c212 = read212.Length;
                    if (c211 != c212) read21 = read21 + "*";
                    var read4 = read21 + res + read.Remove(0, w + 1);
                    result = CalcString(read4);
                }
            }
            else
            {
                //throw new FormatException("Введённое выражение или число содержит ошибку, или не является числом или выражением. 0x03");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "\aВведённое выражение или число содержит ошибку, или не является числом или выражением");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            return result;
        }

        public static double CalcString(ref string read, out bool flag)
        {
            var curt = Console.CursorTop;
            double result = 0;
            bool blya;
            if (read != "")
            {
                var all = read.ToCharArray();
                read = read.Replace(" ", "");
                read = read.Replace(":", "/");
                read = read.Replace('.', ',');
                read = read.Replace('ю', ',');
                read = read.Replace('Ю', ',');
                read = read.Replace('б', ',');
                read = read.Replace('Б', ',');
                read = read.Replace('е', 'e');
                read = read.Replace('Е', 'e');
                read = read.Replace('у', 'e');
                read = read.Replace('У', 'e');
                var Lp = Stringer.HowManyTimes(read, '(');
                var Rp = Stringer.HowManyTimes(read, ')');
                blya = Lp == Rp;
                if (blya)
                {
                    var w = read.IndexOf(')');
                    if (w == -1)
                    {
                        var ars = read.Split(new[] {'/', '*', '+', '-', '^'}, StringSplitOptions.RemoveEmptyEntries);
                        var ar = new double[ars.Length];
                        var b = true;
                        for (var i = 0; i < ar.Length; i++)
                        {
                            ar[i] = Exeption4Double(ref ars[i], out b);
                            if (!b) blya = false;
                        }

                        if (blya)
                        {
                            var ard = read.Split(new[] {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', 'e'},
                                StringSplitOptions.RemoveEmptyEntries);
                            if (ar.Length == ard.Length)
                            {
                                if (ard[0] == "-")
                                {
                                    ar[0] = -ar[0];
                                    var temp1 = new string[ard.Length - 1];
                                    for (var i = 0; i < temp1.Length; i++) temp1[i] = ard[i + 1];
                                    ard = temp1;
                                }
                                else
                                {
                                    if (ard[0] == "+")
                                    {
                                        var temp1 = new string[ard.Length - 1];
                                        for (var i = 0; i < temp1.Length; i++) temp1[i] = ard[i + 1];
                                        ard = temp1;
                                    }
                                    else
                                    {
                                        blya = false;
                                        //throw new FormatException("Введённое выражение или число содержит ошибку, или не является числом или выражением. 0x01");
                                        /*Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\aВведённое выражение или число содержит ошибку, или не является числом или выражением");
                                    Console.ForegroundColor = ConsoleColor.Gray;*/
                                    }
                                }
                            }

                            var ardlen = ard.Length;
                            for (var i = 0; i < ardlen; i++)
                                if (ard[i] == "^")
                                {
                                    ar[i] = Math.Pow(ar[i], ar[i + 1]);
                                    ar = Changer.ArrElemDelete(ar, i + 1);
                                    ard = Changer.ArrElemDelete(ard, i);
                                    i--;
                                    ardlen--;
                                }
                                else
                                {
                                    if (ard[i] == "^-")
                                    {
                                        ar[i] = Math.Pow(ar[i], -ar[i + 1]);
                                        ar = Changer.ArrElemDelete(ar, i + 1);
                                        ard = Changer.ArrElemDelete(ard, i);
                                        i--;
                                        ardlen--;
                                    }
                                }

                            ardlen = ard.Length;
                            for (var i = 0; i < ardlen; i++)
                                if (ard[i] == "*")
                                {
                                    ar[i] = ar[i] * ar[i + 1];
                                    ar = Changer.ArrElemDelete(ar, i + 1);
                                    ard = Changer.ArrElemDelete(ard, i);
                                    i--;
                                    ardlen--;
                                }
                                else
                                {
                                    if (ard[i] == "*-")
                                    {
                                        ar[i] = ar[i] * ar[i + 1] * -1;
                                        ar = Changer.ArrElemDelete(ar, i + 1);
                                        ard = Changer.ArrElemDelete(ard, i);
                                        i--;
                                        ardlen--;
                                    }
                                    else
                                    {
                                        if (ard[i] == "/")
                                        {
                                            ar[i] = ar[i] / ar[i + 1];
                                            ar = Changer.ArrElemDelete(ar, i + 1);
                                            ard = Changer.ArrElemDelete(ard, i);
                                            i--;
                                            ardlen--;
                                        }
                                        else
                                        {
                                            if (ard[i] == "/-")
                                            {
                                                ar[i] = ar[i] / ar[i + 1] * -1;
                                                ar = Changer.ArrElemDelete(ar, i + 1);
                                                ard = Changer.ArrElemDelete(ard, i);
                                                i--;
                                                ardlen--;
                                            }
                                        }
                                    }
                                }

                            ardlen = ard.Length;
                            for (var i = 0; i < ardlen; i++)
                                if (ard[i] == "+")
                                {
                                    ar[i] = ar[i] + ar[i + 1];
                                    ar = Changer.ArrElemDelete(ar, i + 1);
                                    ard = Changer.ArrElemDelete(ard, i);
                                    i--;
                                    ardlen--;
                                }
                                else
                                {
                                    if (ard[i] == "-")
                                    {
                                        ar[i] = ar[i] - ar[i + 1];
                                        ar = Changer.ArrElemDelete(ar, i + 1);
                                        ard = Changer.ArrElemDelete(ard, i);
                                        i--;
                                        ardlen--;
                                    }
                                    else
                                    {
                                        if (ard[i] == "+-")
                                        {
                                            ar[i] = ar[i] - ar[i + 1];
                                            ar = Changer.ArrElemDelete(ar, i + 1);
                                            ard = Changer.ArrElemDelete(ard, i);
                                            i--;
                                            ardlen--;
                                        }
                                        else
                                        {
                                            if (ard[i] == "--")
                                            {
                                                ar[i] = ar[i] + ar[i + 1];
                                                ar = Changer.ArrElemDelete(ar, i + 1);
                                                ard = Changer.ArrElemDelete(ard, i);
                                                i--;
                                                ardlen--;
                                            }
                                        }
                                    }
                                }
                        }
                        else
                        {
                            blya = false;
                            //throw new FormatException("Введённое выражение или число содержит ошибку, или не является числом или выражением. 0x02");
                            /*Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(0, curt - 1);
                        Console.WriteLine("\aВведённое выражение или число содержит ошибку, или не является числом или выражением");
                        Console.ForegroundColor = ConsoleColor.Gray;*/
                        }

                        result = ar[0];
                    }
                    else
                    {
                        var read2 = read.Remove(w);
                        var q = read2.LastIndexOf('(');
                        var read3 = read2.Remove(0, q + 1);
                        var res = CalcString(read3);
                        var read21 = read.Remove(q);
                        var c211 = read21.Length;
                        var read212 = read21.TrimEnd('0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
                        var c212 = read212.Length;
                        if (c211 != c212) read21 = read21 + "*";
                        var read4 = read21 + res + read.Remove(0, w + 1);
                        result = CalcString(read4);
                    }
                }
                else
                {
                    blya = false;
                    //throw new FormatException("Введённое выражение или число содержит ошибку, или не является числом или выражением. 0x03");
                    /*Console.ForegroundColor = ConsoleColor.Red;
                
                Console.SetCursorPosition(0, curt - 1);
                Console.WriteLine("\aВведённое выражение или число содержит ошибку, или не является числом или выражением");
                Console.ForegroundColor = ConsoleColor.Gray;*/
                }
            }
            else
            {
                blya = false;
                //throw new FormatException("Ничего не было введено. 0x04");
                /*Console.ForegroundColor = ConsoleColor.Red;
            
            Console.SetCursorPosition(0, curt - 1);
            Console.WriteLine("\aВведите выражение или число: ");
            Console.ForegroundColor = ConsoleColor.Gray;*/
            }

            flag = blya;
            read = Convert.ToString(result);
            return result;
        }

        public static double Exeption4Double(ref string read, out bool flag)
        {
            double i;
            try
            {
                i = double.Parse(read);
                flag = true;
            }
            catch (FormatException)
            {
                try
                {
                    read = read.Replace('.', ',');
                    read = read.Replace('ю', ',');
                    read = read.Replace('Ю', ',');
                    read = read.Replace('б', ',');
                    read = read.Replace('Б', ',');
                    read = read.Replace('е', 'e');
                    read = read.Replace('Е', 'e');
                    read = read.Replace('у', 'e');
                    read = read.Replace('У', 'e');
                    i = double.Parse(read);
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.Write("\a");
                    flag = false;
                    i = 0;
                }
            }
            catch (OverflowException)
            {
                Console.Write("\a");
                flag = false;
                i = 0;
            }

            return i;
        }

        public static decimal Exeption4Decimal(ref string read, out bool flag)
        {
            decimal i;
            try
            {
                i = decimal.Parse(read);
                flag = true;
            }
            catch (FormatException)
            {
                try
                {
                    read = read.Replace('.', ',');
                    read = read.Replace('ю', ',');
                    read = read.Replace('б', ',');
                    read = read.Replace('е', 'e');
                    read = read.Replace('Е', 'e');
                    read = read.Replace('у', 'e');
                    read = read.Replace('У', 'e');
                    i = decimal.Parse(read);
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.Write("\a");
                    flag = false;
                    i = 0;
                }
            }
            catch (OverflowException)
            {
                Console.Write("\a");
                flag = false;
                i = 0;
            }

            return i;
        }

        public static float Exeption4Float(ref string read, out bool flag)
        {
            float i;
            try
            {
                i = float.Parse(read);
                flag = true;
            }
            catch (FormatException)
            {
                try
                {
                    read = read.Replace('.', ',');
                    read = read.Replace('ю', ',');
                    read = read.Replace('б', ',');
                    read = read.Replace('е', 'e');
                    read = read.Replace('Е', 'e');
                    read = read.Replace('у', 'e');
                    read = read.Replace('У', 'e');
                    i = float.Parse(read);
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.Write("\a");
                    flag = false;
                    i = 0;
                }
            }
            catch (OverflowException)
            {
                Console.Write("\a");
                flag = false;
                i = 0;
            }

            return i;
        }

        public static bool IfDouble(string str)
        {
            bool flag;
            double i;
            try
            {
                i = double.Parse(str);
                flag = true;
            }
            catch (FormatException)
            {
                flag = false;
            }

            return flag;
        }

        public static int Int()
        {
            bool flag;
            int i;
            Console.Write("Введите число: ");
            do
            {
                try
                {
                    i = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\aНеверный формат, повторите попытку: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    flag = false;
                    i = 0;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\aСлишком длинное число, повторите попытку: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    flag = false;
                    i = 0;
                }
            } while (!flag);

            return i;
        }

        public static int Int(string str)
        {
            var flag = true;
            string read;
            int i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            do
            {
                try
                {
                    if (!flag)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(curl, curt);
                        Console.Write(str);
                        for (var j = 0; j < len; j++) Console.Write(' ');
                        Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                        read = Console.ReadLine();
                        len = read.Length;
                        i = int.Parse(read);
                        flag = true;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.SetCursorPosition(curl, curt);
                        Console.Write(str);
                        read = Console.ReadLine();
                        len = read.Length;
                        i = int.Parse(read);
                        flag = true;
                    }
                }
                catch (FormatException)
                {
                    Console.Write("\a");
                    flag = false;
                    i = 0;
                }
                catch (OverflowException)
                {
                    Console.Write("\a");
                    flag = false;
                    i = 0;
                }
            } while (!flag);

            return i;
        }

        public static byte Byte()
        {
            bool flag;
            byte i;
            Console.Write("Введите число: ");
            do
            {
                try
                {
                    i = byte.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\aНеверный формат, повторите попытку: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    flag = false;
                    i = 1;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\aСлишком длинное число, повторите попытку: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    flag = false;
                    i = 0;
                }
            } while (!flag);

            return i;
        }

        public static byte Byte(string str)
        {
            var flag = true;
            string read;
            byte i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            do
            {
                try
                {
                    if (!flag)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(curl, curt);
                        Console.Write(str);
                        for (var j = 0; j < len; j++) Console.Write(' ');
                        Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                        read = Console.ReadLine();
                        len = read.Length;
                        i = byte.Parse(read);
                        flag = true;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.SetCursorPosition(curl, curt);
                        Console.Write(str);
                        read = Console.ReadLine();
                        len = read.Length;
                        i = byte.Parse(read);
                        flag = true;
                    }
                }
                catch (FormatException)
                {
                    Console.Write("\a");
                    flag = false;
                    i = 0;
                }
                catch (OverflowException)
                {
                    Console.Write("\a");
                    flag = false;
                    i = 0;
                }
            } while (!flag);

            return i;
        }

        public static double Double()
        {
            string read;
            var flag = true;
            double i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            do
            {
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(curl, curt);
                    Console.Write("Неверный формат, повторите попытку: ");
                    for (var j = 0; j < len; j++) Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Double(ref read, out flag);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.SetCursorPosition(curl, curt);
                    Console.Write("Введите число: ");
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Double(ref read, out flag);
                }
            } while (!flag);

            return i;
        }

        public static double Double(string str)
        {
            string read;
            var flag = true;
            double i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            int curln;
            do
            {
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(curl, curt);
                    Console.Write("\a" + str);
                    for (var j = 0; j < len; j++) Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                    curln = Console.CursorLeft;
                    read = Console.ReadLine();
                    len = read.Length + 1;
                    //i = Exeption4Double(ref read, out flag);
                    i = CalcString(ref read, out flag);
                    Console.SetCursorPosition(curln, curt);
                    for (var j = 0; j < len; j++) Console.Write(' ');
                    Console.SetCursorPosition(curln, curt);
                    Console.WriteLine(read);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.SetCursorPosition(curl, curt);
                    Console.Write(str);
                    curln = Console.CursorLeft;
                    read = Console.ReadLine();
                    len = read.Length + 1;
                    //i = Exeption4Double(ref read, out flag);
                    i = CalcString(ref read, out flag);
                    Console.SetCursorPosition(curln, curt);
                    for (var j = 0; j < len; j++) Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                    Console.WriteLine(read);
                }
            } while (!flag);

            return i;
        }

        public static double Double(string str, out string input)
        {
            string read;
            var flag = true;
            double i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            int curln;
            do
            {
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(curl, curt);
                    Console.Write(str);
                    for (var j = 0; j < len; j++) Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                    curln = Console.CursorLeft;
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Double(ref read, out flag);
                    Console.SetCursorPosition(curln, curt);
                    Console.WriteLine(read);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.SetCursorPosition(curl, curt);
                    Console.Write(str);
                    curln = Console.CursorLeft;
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Double(ref read, out flag);
                    Console.SetCursorPosition(curln, curt);
                    Console.WriteLine(read);
                }
            } while (!flag);

            input = read;
            return i;
        }

        public static decimal Decimal()
        {
            string read;
            var flag = true;
            decimal i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            do
            {
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(curl, curt);
                    Console.Write("Неверный формат, повторите попытку: ");
                    for (var j = 0; j < len; j++) Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Decimal(ref read, out flag);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.SetCursorPosition(curl, curt);
                    Console.Write("Введите число: ");
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Decimal(ref read, out flag);
                }
            } while (!flag);

            return i;
        }

        public static decimal Decimal(string str)
        {
            string read;
            var flag = true;
            decimal i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            int curln;
            do
            {
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(curl, curt);
                    Console.Write(str);
                    for (var j = 0; j < len; j++) Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                    curln = Console.CursorLeft;
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Decimal(ref read, out flag);
                    Console.SetCursorPosition(curln, curt);
                    Console.WriteLine(read);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.SetCursorPosition(curl, curt);
                    Console.Write(str);
                    curln = Console.CursorLeft;
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Decimal(ref read, out flag);
                    Console.SetCursorPosition(curln, curt);
                    Console.WriteLine(read);
                }
            } while (!flag);

            return i;
        }

        public static decimal Decimal(string str, out string input)
        {
            string read;
            var flag = true;
            decimal i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            int curln;
            do
            {
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(curl, curt);
                    Console.Write(str);
                    for (var j = 0; j < len; j++) Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                    curln = Console.CursorLeft;
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Decimal(ref read, out flag);
                    Console.SetCursorPosition(curln, curt);
                    Console.WriteLine(read);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.SetCursorPosition(curl, curt);
                    Console.Write(str);
                    curln = Console.CursorLeft;
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Decimal(ref read, out flag);
                    Console.SetCursorPosition(curln, curt);
                    Console.WriteLine(read);
                }
            } while (!flag);

            input = read;
            return i;
        }

        public static float Float()
        {
            string read;
            var flag = true;
            float i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            do
            {
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(curl, curt);
                    Console.Write("Неверный формат, повторите попытку: ");
                    for (var j = 0; j < len; j++) Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Float(ref read, out flag);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.SetCursorPosition(curl, curt);
                    Console.Write("Введите число: ");
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Float(ref read, out flag);
                }
            } while (!flag);

            return i;
        }

        public static float Float(string str)
        {
            string read;
            var flag = true;
            float i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            int curln;
            do
            {
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(curl, curt);
                    Console.Write(str);
                    for (var j = 0; j < len; j++) Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                    curln = Console.CursorLeft;
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Float(ref read, out flag);
                    Console.SetCursorPosition(curln, curt);
                    Console.WriteLine(read);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.SetCursorPosition(curl, curt);
                    Console.Write(str);
                    curln = Console.CursorLeft;
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Float(ref read, out flag);
                    Console.SetCursorPosition(curln, curt);
                    Console.WriteLine(read);
                }
            } while (!flag);

            return i;
        }

        public static float Float(string str, out string input)
        {
            string read;
            var flag = true;
            float i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            int curln;
            do
            {
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(curl, curt);
                    Console.Write(str);
                    for (var j = 0; j < len; j++) Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                    curln = Console.CursorLeft;
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Float(ref read, out flag);
                    Console.SetCursorPosition(curln, curt);
                    Console.WriteLine(read);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.SetCursorPosition(curl, curt);
                    Console.Write(str);
                    curln = Console.CursorLeft;
                    read = Console.ReadLine();
                    len = read.Length;
                    i = Exeption4Float(ref read, out flag);
                    Console.SetCursorPosition(curln, curt);
                    Console.WriteLine(read);
                }
            } while (!flag);

            input = read;
            return i;
        }

        public static char Char()
        {
            bool flag;
            char i;
            Console.Write("Введите символ: ");
            do
            {
                try
                {
                    i = char.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\aНеверный формат, повторите попытку: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    flag = false;
                    i = '0';
                }
            } while (!flag);

            return i;
        }

        public static char Char(string str)
        {
            var flag = true;
            string read;
            char i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            do
            {
                try
                {
                    if (!flag)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(curl, curt);
                        Console.Write(str);
                        for (var j = 0; j < len; j++) Console.Write(' ');
                        Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                        read = Console.ReadLine();
                        len = read.Length;
                        i = char.Parse(read);
                        flag = true;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.SetCursorPosition(curl, curt);
                        Console.Write(str);
                        read = Console.ReadLine();
                        len = read.Length;
                        i = char.Parse(read);
                        flag = true;
                    }
                }
                catch (FormatException)
                {
                    Console.Write("\a");
                    flag = false;
                    i = '0';
                }
            } while (!flag);

            return i;
        }

        public static string String()
        {
            bool flag;
            string i;
            Console.Write("Введите строку: ");
            do
            {
                try
                {
                    i = Console.ReadLine();
                    if (i != "")
                    {
                        flag = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\aВы ничего не ввели, повторите попытку: ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        flag = false;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\aНеверный формат, повторите попытку: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    flag = false;
                    i = null;
                }
                catch (OverflowException)
                {
                    Console.Write("\aСлишком длинная строка, повторите попытку: ");
                    flag = false;
                    i = null;
                }
            } while (!flag);

            return i;
        }

        public static string String(string str)
        {
            var flag = true;
            string i;
            var len = 0;
            var curl = Console.CursorLeft;
            var curt = Console.CursorTop;
            do
            {
                try
                {
                    if (flag)
                    {
                        Console.SetCursorPosition(curl, curt);
                        Console.Write(str);
                        i = Console.ReadLine();
                        len = i.Length;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(curl, curt);
                        Console.Write(str);
                        for (var j = 0; j < len; j++) Console.Write(' ');
                        Console.SetCursorPosition(Console.CursorLeft - len, Console.CursorTop);
                        i = Console.ReadLine();
                        len = i.Length;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (i != "")
                    {
                        flag = true;
                    }
                    else
                    {
                        Console.Write("\a");
                        flag = false;
                    }
                }
                catch (FormatException)
                {
                    Console.Write("\a");
                    flag = false;
                    i = null;
                }
                catch (OverflowException)
                {
                    Console.Write("\a");
                    flag = false;
                    i = null;
                }
            } while (!flag);

            return i;
        }

        public static string[,] StringMatrix(int n, int m)
        {
            Console.WriteLine("Введите матрицу {0}*{1}: ", n, m);
            var mat = new string[n, m];
            {
                var curt = Console.CursorTop;
                for (var i = 0; i < n; i++)
                {
                    for (var j = 0; j < m; j++)
                    {
                        Console.CursorTop = curt + i;
                        Console.CursorLeft = 6 * j;
                        mat[i, j] = String("");
                    }

                    Console.WriteLine();
                }
            }
            return mat;
        }

        public static int[,] IntMatrix(int n, int m)
        {
            Console.WriteLine("Введите матрицу {0}*{1}: ", n, m);
            var mat = new int[n, m];
            var curt = Console.CursorTop;
            var len = 1;
            for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
            {
                Console.CursorTop = curt + i;
                Console.CursorLeft = (len + 1) * j;
                mat[j, i] = Int("");
                if (len < Convert.ToString(mat[j, i]).Length)
                {
                    Console.SetCursorPosition(0, curt);
                    for (var y = 0; y < i; y++)
                    {
                        for (var x = 0; x < n; x++)
                        {
                            Console.CursorLeft = (len + 1) * x;
                            for (var e = 0; e <= len + 1; e++) Console.Write(" ");
                        }

                        Console.WriteLine();
                    }

                    for (var x = 0; x <= j; x++)
                    {
                        Console.CursorLeft = (len + 1) * x;
                        for (var e = 0; e <= len + 1; e++) Console.Write(" ");
                    }

                    len = Convert.ToString(mat[j, i]).Length;
                    Console.SetCursorPosition(0, curt);
                    for (var y = 0; y < i; y++)
                    {
                        for (var x = 0; x < n; x++)
                        {
                            Console.CursorLeft = x * (len + 1);
                            Console.Write(mat[x, y]);
                        }

                        Console.WriteLine();
                    }

                    for (var x = 0; x <= j; x++)
                    {
                        Console.CursorLeft = x * (len + 1);
                        Console.Write(mat[x, i]);
                    }

                    Console.WriteLine();
                }
            }

            return mat;
        }

        public static char[,] CharMatrix(int n, int m)
        {
            Console.WriteLine("Введите матрицу {0}*{1}: ", n, m);
            var mat = new char[n, m];
            {
                var curt = Console.CursorTop;
                for (var i = 0; i < n; i++)
                {
                    for (var j = 0; j < m; j++)
                    {
                        Console.CursorTop = curt + i;
                        Console.CursorLeft = 2 * j;
                        mat[i, j] = Char("");
                    }

                    Console.WriteLine();
                }
            }
            return mat;
        }

        public static double[,] DoubleMatrix(int n, int m)
        {
            Console.WriteLine("Введите матрицу {0}*{1}: ", n, m);
            var mat = new double[n, m];
            var curt = Console.CursorTop;
            var len = 1;
            string input;
            for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
            {
                Console.CursorTop = curt + i;
                Console.CursorLeft = (len + 1) * j;
                mat[j, i] = Double("", out input);
                if (len < input.Length)
                {
                    Console.SetCursorPosition(0, curt);
                    for (var y = 0; y < i; y++)
                    {
                        for (var x = 0; x < n; x++)
                        {
                            Console.CursorLeft = (len + 1) * x;
                            for (var e = 0; e <= len + 1; e++) Console.Write(" ");
                        }

                        Console.WriteLine();
                    }

                    for (var x = 0; x < j; x++)
                    {
                        Console.CursorLeft = (len + 1) * x;
                        for (var e = 0; e <= len + 1; e++) Console.Write(" ");
                    }

                    for (var e = 0; e <= input.Length; e++) Console.Write(" ");
                    if (len < Convert.ToString(mat[j, i]).Length) len = Convert.ToString(mat[j, i]).Length;
                    Console.SetCursorPosition(0, curt);
                    for (var y = 0; y < i; y++)
                    {
                        for (var x = 0; x < n; x++)
                        {
                            Console.CursorLeft = x * (len + 1);
                            Console.Write(mat[x, y]);
                        }

                        Console.WriteLine();
                    }

                    for (var x = 0; x <= j; x++)
                    {
                        Console.CursorLeft = x * (len + 1);
                        Console.Write(mat[x, i]);
                    }

                    Console.WriteLine();
                }
            }

            return mat;
        }

        public static decimal[,] DecimalMatrix(int n, int m)
        {
            Console.WriteLine("Введите матрицу {0}*{1}: ", n, m);
            var mat = new decimal[n, m];
            var curt = Console.CursorTop;
            var len = 1;
            string input;
            for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
            {
                Console.CursorTop = curt + i;
                Console.CursorLeft = (len + 1) * j;
                mat[j, i] = Decimal("", out input);
                if (len < input.Length)
                {
                    Console.SetCursorPosition(0, curt);
                    for (var y = 0; y < i; y++)
                    {
                        for (var x = 0; x < n; x++)
                        {
                            Console.CursorLeft = (len + 1) * x;
                            for (var e = 0; e <= len + 1; e++) Console.Write(" ");
                        }

                        Console.WriteLine();
                    }

                    for (var x = 0; x < j; x++)
                    {
                        Console.CursorLeft = (len + 1) * x;
                        for (var e = 0; e <= len + 1; e++) Console.Write(" ");
                    }

                    for (var e = 0; e <= input.Length; e++) Console.Write(" ");
                    if (len < Convert.ToString(mat[j, i]).Length) len = Convert.ToString(mat[j, i]).Length;
                    Console.SetCursorPosition(0, curt);
                    for (var y = 0; y < i; y++)
                    {
                        for (var x = 0; x < n; x++)
                        {
                            Console.CursorLeft = x * (len + 1);
                            Console.Write(mat[x, y]);
                        }

                        Console.WriteLine();
                    }

                    for (var x = 0; x <= j; x++)
                    {
                        Console.CursorLeft = x * (len + 1);
                        Console.Write(mat[x, i]);
                    }

                    Console.WriteLine();
                }
            }

            return mat;
        }

        public static float[,] FloatMatrix(int n, int m)
        {
            Console.WriteLine("Введите матрицу {0}*{1}: ", n, m);
            var mat = new float[n, m];
            var curt = Console.CursorTop;
            var len = 1;
            string input;
            for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
            {
                Console.CursorTop = curt + i;
                Console.CursorLeft = (len + 1) * j;
                mat[j, i] = Float("", out input);
                if (len < input.Length)
                {
                    Console.SetCursorPosition(0, curt);
                    for (var y = 0; y < i; y++)
                    {
                        for (var x = 0; x < n; x++)
                        {
                            Console.CursorLeft = (len + 1) * x;
                            for (var e = 0; e <= len + 1; e++) Console.Write(" ");
                        }

                        Console.WriteLine();
                    }

                    for (var x = 0; x < j; x++)
                    {
                        Console.CursorLeft = (len + 1) * x;
                        for (var e = 0; e <= len + 1; e++) Console.Write(" ");
                    }

                    for (var e = 0; e <= input.Length; e++) Console.Write(" ");
                    if (len < Convert.ToString(mat[j, i]).Length) len = Convert.ToString(mat[j, i]).Length;
                    Console.SetCursorPosition(0, curt);
                    for (var y = 0; y < i; y++)
                    {
                        for (var x = 0; x < n; x++)
                        {
                            Console.CursorLeft = x * (len + 1);
                            Console.Write(mat[x, y]);
                        }

                        Console.WriteLine();
                    }

                    for (var x = 0; x <= j; x++)
                    {
                        Console.CursorLeft = x * (len + 1);
                        Console.Write(mat[x, i]);
                    }

                    Console.WriteLine();
                }
            }

            return mat;
        }

        public static byte[,] ByteMatrix(int n, int m)
        {
            Console.WriteLine("Введите матрицу {0}*{1}: ", n, m);
            var mat = new byte[n, m];
            var curt = Console.CursorTop;
            var len = 1;
            for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
            {
                Console.CursorTop = curt + i;
                Console.CursorLeft = (len + 1) * j;
                mat[j, i] = Byte("");
                if (len < Convert.ToString(mat[j, i]).Length)
                {
                    Console.SetCursorPosition(0, curt);
                    for (var y = 0; y < i; y++)
                    {
                        for (var x = 0; x < n; x++)
                        {
                            Console.CursorLeft = (len + 1) * x;
                            for (var e = 0; e <= len + 1; e++) Console.Write(" ");
                        }

                        Console.WriteLine();
                    }

                    for (var x = 0; x <= j; x++)
                    {
                        Console.CursorLeft = (len + 1) * x;
                        for (var e = 0; e <= len + 1; e++) Console.Write(" ");
                    }

                    len = Convert.ToString(mat[j, i]).Length;
                    Console.SetCursorPosition(0, curt);
                    for (var y = 0; y < i; y++)
                    {
                        for (var x = 0; x < n; x++)
                        {
                            Console.CursorLeft = x * (len + 1);
                            Console.Write(mat[x, y]);
                        }

                        Console.WriteLine();
                    }

                    for (var x = 0; x <= j; x++)
                    {
                        Console.CursorLeft = x * (len + 1);
                        Console.Write(mat[x, i]);
                    }

                    Console.WriteLine();
                }
            }

            return mat;
        }

        public static int[] IntArray(int n)
        {
            Console.WriteLine("Введите масив: ");
            var arr = new int[n];
            {
                for (var i = 0; i < n; i++) arr[i] = Int("    ");
                Console.WriteLine();
            }
            return arr;
        }

        public static double[] DoubleArray(int n)
        {
            Console.WriteLine("Введите масив: ");
            var arr = new double[n];
            {
                for (var i = 0; i < n; i++) arr[i] = Double("    ");
                Console.WriteLine();
            }
            return arr;
        }

        public static decimal[] DecimalArray(int n)
        {
            Console.WriteLine("Введите масив: ");
            var arr = new decimal[n];
            {
                for (var i = 0; i < n; i++) arr[i] = Decimal("    ");
                Console.WriteLine();
            }
            return arr;
        }

        public static float[] FloatArray(int n)
        {
            Console.WriteLine("Введите масив: ");
            var arr = new float[n];
            {
                for (var i = 0; i < n; i++) arr[i] = Float("    ");
                Console.WriteLine();
            }
            return arr;
        }

        public static byte[] ByteArray(int n)
        {
            Console.WriteLine("Введите масив: ");
            var arr = new byte[n];
            {
                for (var i = 0; i < n; i++) arr[i] = Byte("    ");
                Console.WriteLine();
            }
            return arr;
        }

        public static char[] CharArray(int n)
        {
            Console.WriteLine("Введите масив: ");
            var arr = new char[n];
            {
                for (var i = 0; i < n; i++) arr[i] = Char("    ");
                Console.WriteLine();
            }
            return arr;
        }

        public static string[] StringArray(int n)
        {
            Console.WriteLine("Введите масив: ");
            var arr = new string[n];
            {
                for (var i = 0; i < n; i++)
                {
                    Console.CursorLeft = 6 * i;
                    arr[i] = String("    ");
                }

                Console.WriteLine();
            }
            return arr;
        }
    }
}