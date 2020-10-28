/* 
 * MIT License
 * 
 * Copyright (c) 2020 Jacob Palomo
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 */

using System;

namespace Generador_de_CURP
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string tmp = null, curp = "";
            string[] name = new string[4], date = new string[3];

            Console.Write("Ingresa tu nombre completo: ");
            tmp = Console.ReadLine().ToUpper();

            name = tmp.Split(' ');

            byte n = 0, ap = 1, am = 2;
            // Dos nombres
            if(name.Length == 4)
            {
                ap = 2;
                am = 3;
            }
            // Tres nombres
            else if(name.Length == 5)
            {
                ap = 3;
                am = 4;
            }
            // Un solo nombre
            else
            {
                ap = 1;
                am = 2;
            }

            // Primer letra del aPaterno
            if (!name[ap].ToString().Equals("Ñ"))
            {
                curp += name[ap].Substring(0, 1);
            }
            else
            {
                curp += "X";
            }
            

            // Primer vocal del apellido paterno
            for (int i = 1; i < name[ap].Length; i++)
            {
                if (name[ap][i].ToString().Equals("A") || name[ap][i].ToString().Equals("E") || name[ap][i].ToString().Equals("I") || name[ap][i].ToString().Equals("O") || name[ap][i].ToString().Equals("U"))
                {
                    curp += name[ap][i].ToString();
                    break;
                }
            }

            // Primer letra del aMaterno
            if (!name[am].ToString().Equals("Ñ"))
            {
                curp += name[am].Substring(0, 1);
            }
            else
            {
                curp += "X";
            }

            // Primer letra del nombre
            if (!name[n].ToString().Equals("Ñ"))
            {
                curp += name[n].Substring(0, 1);
            }
            else
            {
                curp += "X";
            }

            Console.Write("Ingresa tu día de nacimiento: ");
            date[0] = Console.ReadLine();

            Console.Write("Ingresa el número del mes de tu nacimento: ");
            date[1] = Console.ReadLine();

            Console.Write("Ingresa tu año de nacimiento: ");
            date[2] = Console.ReadLine();

            curp += date[2].Substring(2, date[2].Length-2);

            if (int.Parse(date[1]) < 10 && date[1].Length < 2)
            {
                curp += "0" + date[1].Substring(0, date[1].Length);
            }
            else
            {
                curp += date[1].Substring(0, date[1].Length);
            }

            if (int.Parse(date[0]) < 10 && date[0].Length < 2)
            {
                curp += "0" + date[0].Substring(0, date[0].Length);
            }
            else
            {
                curp += date[0].Substring(0, date[0].Length);
            }

            Console.WriteLine("\nSelecciona tu sexo: ");
            Console.WriteLine("1. Hombre \n2. Mujer");
            Console.Write("Sexo: ");
            tmp = Console.ReadLine();

            if (tmp.Equals("1"))
            {
                curp += "H";
            }
            else if (tmp.Equals("2"))
            {
                curp += "M";
            }
            else
            {
                Console.WriteLine("\nEsa opción no está diponible.");
            }

            Console.WriteLine("\nSelecciona el estado donde naciste: \n");
            Console.WriteLine("1. Aguascalientes | 2. Baja California   | 3. Baja California Sur | 4. Campeche");
            Console.WriteLine("5. Coahuila       | 6. Colima            | 7. Chiapas             | 8. Chihuahua");
            Console.WriteLine("9. Durango        | 10. Distrito Federal | 11. Guanajuato         | 12. Guerrero");
            Console.WriteLine("13. Hidalgo       | 14. Jalisco          | 15. México             | 16. Michoacán");
            Console.WriteLine("17. Morelos       | 18. Nayarit          | 19. Nuevo León         | 20. Oaxaca");
            Console.WriteLine("21. Puebla        | 22. Querétaro        | 23. Quintana Roo       | 24. San Luis Potosí");
            Console.WriteLine("25. Sinaloa       | 26. Sonora           | 27. Tabasco            | 28. Tamaulipas");
            Console.WriteLine("29. Tlaxcala      | 30. Veracruz         | 31. Yucatán            | 32. Zacatecas\n");
            Console.Write("Estado: ");
            int o = int.Parse(Console.ReadLine());

            string[] states = { "AS", "BC", "BS", "CC", "CL", "CM", "CS", "CH", "DG", "DF", "GT", "GR", "HG", "JC", "MC", "MN", "MS", "NT", "NL", "OC", "PL", "QT", "QR", "SP", "SL", "SR", "TC", "TS", "TL", "VZ", "YN", "ZS" };
            if (o > 0 && o < 33)
            {
                curp += states[o-1];
            }
            else
            {
                Console.WriteLine("Esa opción no existe.");
            }

            // Primera consonante después de la primera letra del aPaterno
            for (int i = 1; i < name[ap].Length; i++)
            {
                if (!name[ap][i].ToString().Equals("A") && !name[ap][i].ToString().Equals("E") && !name[ap][i].ToString().Equals("I") && !name[ap][i].ToString().Equals("O") && !name[ap][i].ToString().Equals("U"))
                {
                    if (!name[ap][i].ToString().Equals("Ñ"))
                    {
                        curp += name[ap][i].ToString();
                        break;
                    }
                    else
                    {
                        curp += "X";
                        break;
                    }
                }
            }

            // Primera consonante después de la primera letra del aMaterno
            for (int i = 1; i < name[ap].Length; i++)
            {
                if (!name[am][i].ToString().Equals("A") && !name[am][i].ToString().Equals("E") && !name[am][i].ToString().Equals("I") && !name[am][i].ToString().Equals("O") && !name[am][i].ToString().Equals("U"))
                {
                    if (!name[am][i].ToString().Equals("Ñ"))
                    {
                        curp += name[am][i].ToString();
                        break;
                    }
                    else
                    {
                        curp += "X";
                        break;
                    }
                }
            }

            // Primera consonante después de la primera letra del aMaterno
            for (int i = 1; i < name[ap].Length; i++)
            {
                if (!name[n][i].ToString().Equals("A") && !name[n][i].ToString().Equals("E") && !name[n][i].ToString().Equals("I") && !name[n][i].ToString().Equals("O") && !name[n][i].ToString().Equals("U"))
                {
                    if (!name[n][i].ToString().Equals("Ñ"))
                    {
                        curp += name[n][i].ToString();
                        break;
                    }
                    else
                    {
                        curp += "X";
                        break;
                    }
                }
            }

            // Homoclave
            curp += "**";

            Console.WriteLine("\nTu CURP sería la siguiente: " + curp);
            Console.WriteLine("Toma en cuenta que los ultimos '**', es la homoclave y esa no la podemos obtener nosotros. Esos valores no son reales.");

        }
    }
}
