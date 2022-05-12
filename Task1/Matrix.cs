using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Matrix
    {
        //хранение данных
        private int[,] data;

        // Конструкторы

        // конструктор с двумя параметрами целого типа – размерность матрицы
        public Matrix(int nRows, int nCols)
        {
            Rows = nRows;
            Columns = nCols;
            data = new int[Rows, Columns];
        }

        // конструктор с параметром - двумерный массив
        public Matrix(int[,] initData)
        {
            data = initData;
            Rows = data.GetLength(0);
            Columns = data.GetLength(1);
        }

        // доступ к элементам матрицы через свойство-индексатор
        public int this[int i, int j]
        {
            get
            {
                if (i < Rows && j < Columns) return data[i, j];
                else throw new FormatException("Ошибка! Вышли за рамки размера матрицы");
            }
            set
            {
                if (value is int) data[i, j] = value;
                else throw new FormatException("Ошибка! Введено значение, которое не имеет тип int");
            }
        }

        public int[,] GetMatrix => data;

        // Размер матрицы доступен только для чтения через свойства
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        // Сортировка пузырьком в порядке возрастания
        public static Matrix BubbleSortUp(Matrix matr, comparison comp)
        {
            int[] mas = comp(matr);
            int flag = 1;
            while (flag == 1)
            {
                flag = 0;
                for (int i = 0; i < matr.Rows - 1; i++)
                {
                    if (mas[i] > mas[i + 1])
                    {
                        for (int j = 0; j < matr.Columns; j++)
                        {
                            int tmp = matr[i, j];
                            matr[i, j] = matr[i + 1, j];
                            matr[i + 1, j] = tmp;
                        }
                        int tmp1 = mas[i];
                        mas[i] = mas[i + 1];
                        mas[i + 1] = tmp1;
                        flag = 1;
                    }
                }
            }
            return matr;
        }

        // Сортировка пузырьком в порядке убывания
        public static Matrix BubbleSortDown(Matrix matr, comparison comp)
        {
            int[] mas = comp(matr);
            int flag = 1;
            while (flag == 1)
            {
                flag = 0;
                for (int i = 0; i < matr.Rows - 1; i++)
                {
                    if (mas[i] < mas[i + 1])
                    {
                        for (int j = 0; j < matr.Columns; j++)
                        {
                            int tmp = matr[i, j];
                            matr[i, j] = matr[i + 1, j];
                            matr[i + 1, j] = tmp;
                        }
                        int tmp1 = mas[i];
                        mas[i] = mas[i + 1];
                        mas[i + 1] = tmp1;
                        flag = 1;
                    }
                }
            }
            return matr;
        }

        public static int[] sum(Matrix matr)
        {
            int[] sum = new int[matr.Rows];
            for (int i = 0; i < matr.Rows; i++)
            {
                sum[i] = 0;
                for (int j = 0; j < matr.Columns; j++)
                {
                    sum[i] += matr[i, j];
                }
            }
            return sum;
        }
        public static int[] max(Matrix matr)
        {
            int[] max = new int[matr.Rows];
            for (int i = 0; i < matr.Rows; i++)
            {
                max[i] = 0;
                for (int j = 0; j < matr.Columns; j++)
                {
                    if (matr[i, j] > max[i]) max[i] = matr[i, j];
                }
            }
            return max;
        }
        public static int[] min(Matrix matr)
        {
            int[] min = new int[matr.Rows];
            for (int i = 0; i < matr.Rows; i++)
            {
                min[i] = 1000000000;
                for (int j = 0; j < matr.Columns; j++)
                {
                    if (matr[i, j] < min[i]) min[i] = matr[i, j];
                }
            }
            return min;
        }
    }
}
