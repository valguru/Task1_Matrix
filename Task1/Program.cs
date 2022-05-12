using Task1;
using System.Globalization;
using System.Text.RegularExpressions;
using System;

namespace Task1
{
    public delegate int[] comparison(Matrix matr);
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введите матрицу");
            Console.Write("Количество строк: ");
            int Rows = int.Parse(Console.ReadLine());
            Console.Write("Количество столбцов: ");
            int Col = int.Parse(Console.ReadLine());
            Matrix m = new Matrix(Rows, Col);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    Console.Write("m[{0},{1}] = ", i, j);
                    m[i, j] = int.Parse(Console.ReadLine());
                }
            }

            while (true)
            {
                Console.WriteLine("\n___________________________________________________________________\n" + 
                    "\nВаша матрица:");
                ShowMatrix(m);

                Console.WriteLine("\nВыберите тип сортировки:\n" +
                    "Сравнение сумм элементов строк матрицы;\n" +
                    "   1 - по возрастанию сумм\n" +
                    "   2 - по убыванию\n" +
                    "Сравнение максимальных элементов в строках матрицы;\n" +
                    "   3 - по возрастанию максимального элемента\n" +
                    "   4 - по убыванию максимального элемента\n" +
                    "Сравнение минимальных элементов в строках матрицы;\n" +
                    "   5 - по возрастанию минимального элемента\n" +
                    "   6 - по убывания минимального элемента\n\n" +
                    "   7 - Выход\n");

                int menu = int.Parse(Console.ReadLine());

                Matrix resmatrix = new Matrix(m.Rows, m.Columns);
                comparison comp;
                switch (menu)
                {
                    case 1:
                        comp = new comparison(Matrix.sum);
                        resmatrix = Matrix.BubbleSortUp(m, comp);
                        break;
                    case 2:
                        comp = new comparison(Matrix.sum);
                        resmatrix = Matrix.BubbleSortDown(m, comp);
                        break;
                    case 3:
                        comp = new comparison(Matrix.max);
                        resmatrix = Matrix.BubbleSortUp(m, comp);
                        break;
                    case 4:
                        comp = new comparison(Matrix.max);
                        resmatrix = Matrix.BubbleSortDown(m, comp);
                        break;
                    case 5:
                        comp = new comparison(Matrix.min);
                        resmatrix = Matrix.BubbleSortUp(m, comp);
                        break;
                    case 6:
                        comp = new comparison(Matrix.min);
                        resmatrix = Matrix.BubbleSortDown(m, comp);
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                }

                Console.WriteLine("\nРезультат сортировки:");
                ShowMatrix(resmatrix);
            }
        }

        public static void ShowMatrix(Matrix matr)
        {
            for (int i = 0; i < matr.Rows; i++)
            {
                for (int j = 0; j < matr.Columns; j++)
                {
                    Console.Write(matr[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
