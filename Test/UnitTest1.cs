using NUnit.Framework;
using Task1;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RowColumnTest()
        {
            Matrix m1 = new Matrix(7, 8);
            Assert.AreEqual(7, m1.Rows);
            Assert.AreEqual(8, m1.Columns);

            int[,] initData = new int[4, 2];
            Matrix m2 = new Matrix(initData);
            Assert.AreEqual(4, m2.Rows);
            Assert.AreEqual(2, m2.Columns);

            Matrix m3 = new Matrix(1, 10);
            Assert.AreEqual(1, m3.Rows);
            Assert.AreEqual(10, m3.Columns);
        }

        [Test]
        public void SumInLineTest()
        {
            int[,] initData1 = { { -7, 2, 15 }, { 0, 11, -3 } };
            Matrix m1 = new Matrix(initData1);
            Assert.AreEqual(new int[] { 10, 8 }, Matrix.sum(m1));

            int[,] initData2 = { { 1, 2, 3 }, { 6, 4, 0 }, { -1, -5, 2 } };
            Matrix m2 = new Matrix(initData2);
            Assert.AreEqual(new int[] { 6, 10, -4 }, Matrix.sum(m2));

            int[,] initData3 = { { 21, -4 }, { 13, 7 }, { 4, -4 }, { 8, 3 } };
            Matrix m3 = new Matrix(initData3);
            Assert.AreEqual(new int[] { 17, 20, 0, 11 }, Matrix.sum(m3));
        }

        [Test]
        public void MaxInLineTest()
        {
            int[,] initData1 = { { -7, 2, 15 }, { 0, 11, -3 } };
            Matrix m1 = new Matrix(initData1);
            Assert.AreEqual(new int[] { 15, 11 }, Matrix.max(m1));

            int[,] initData2 = { { 1, 2, 3 }, { 6, 4, 0 }, { -1, -5, 2 } };
            Matrix m2 = new Matrix(initData2);
            Assert.AreEqual(new int[] { 3, 6, 2 }, Matrix.max(m2));

            int[,] initData3 = { { 21, -4 }, { 13, 7 }, { 4, -4 }, { -8, -3 } };
            Matrix m3 = new Matrix(initData3);
            Assert.AreEqual(new int[] { 21, 13, 4, -3 }, Matrix.max(m3));
        }

        [Test]
        public void MinInLineTest()
        {
            int[,] initData1 = { { -7, 2, 15 }, { 0, 11, -3 } };
            Matrix m1 = new Matrix(initData1);
            Assert.AreEqual(new int[] { -7, -3 }, Matrix.min(m1));

            int[,] initData2 = { { 1, 2, 3 }, { 6, 4, 0 }, { -1, -5, 2 } };
            Matrix m2 = new Matrix(initData2);
            Assert.AreEqual(new int[] { 1, 0, -5 }, Matrix.min(m2));

            int[,] initData3 = { { 21, -4 }, { 13, 7 }, { 4, -4 }, { 8, 3 } };
            Matrix m3 = new Matrix(initData3);
            Assert.AreEqual(new int[] { -4, 7, -4, 3 }, Matrix.min(m3));
        }

        [Test]
        public void SortUpSumTest()
        {
            comparison comp = Matrix.sum;

            int[,] initData1 = { { -7, 2, 15 }, { 0, 11, -3 } };
            int[,] expect1 = { { 0, 11, -3 }, { -7, 2, 15 } };
            Matrix m1 = new Matrix(initData1);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    Assert.AreEqual(expect1[i, j], Matrix.BubbleSortUp(m1, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect1).GetMatrix, Matrix.BubbleSortUp(m1, comp).GetMatrix);

            int[,] initData2 = { { 1, 2, 3 }, { 6, 4, 0 }, { -1, -5, 2 } };
            int[,] expect2 = { { -1, -5, 2 }, { 1, 2, 3 }, { 6, 4, 0 } };
            Matrix m2 = new Matrix(initData2);
            for (int i = 0; i < m2.Rows; i++)
            {
                for (int j = 0; j < m2.Columns; j++)
                {
                    Assert.AreEqual(expect2[i, j], Matrix.BubbleSortUp(m2, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect2).GetMatrix, Matrix.BubbleSortUp(m2, comp).GetMatrix);

            int[,] initData3 = { { 21, -4 }, { 13, 7 }, { 4, -4 }, { 8, 3 } };
            int[,] expect3 = { { 4, -4 }, { 8, 3 }, { 21, -4 }, { 13, 7 } };
            Matrix m3 = new Matrix(initData3);
            for (int i = 0; i < m3.Rows; i++)
            {
                for (int j = 0; j < m3.Columns; j++)
                {
                    Assert.AreEqual(expect3[i, j], Matrix.BubbleSortUp(m3, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect3).GetMatrix, Matrix.BubbleSortUp(m3, comp).GetMatrix);
        }

        [Test]
        public void SortDownSumTest()
        {
            comparison comp = Matrix.sum;

            int[,] initData1 = { { -7, 2, 15 }, { 0, 11, -3 } };
            int[,] expect1 = { { -7, 2, 15 }, { 0, 11, -3 } };
            Matrix m1 = new Matrix(initData1);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    Assert.AreEqual(expect1[i, j], Matrix.BubbleSortDown(m1, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect1).GetMatrix, Matrix.BubbleSortDown(m1, comp).GetMatrix);

            int[,] initData2 = { { 1, 2, 3 }, { 6, 4, 0 }, { -1, -5, 2 } };
            int[,] expect2 = { { 6, 4, 0 }, { 1, 2, 3 }, { -1, -5, 2 } };
            Matrix m2 = new Matrix(initData2);
            for (int i = 0; i < m2.Rows; i++)
            {
                for (int j = 0; j < m2.Columns; j++)
                {
                    Assert.AreEqual(expect2[i, j], Matrix.BubbleSortDown(m2, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect2).GetMatrix, Matrix.BubbleSortDown(m2, comp).GetMatrix);

            int[,] initData3 = { { 21, -4 }, { 13, 7 }, { 4, -4 }, { 8, 3 } };
            int[,] expect3 = { { 13, 7 }, { 21, -4 }, { 8, 3 }, { 4, -4 } };
            Matrix m3 = new Matrix(initData3);
            for (int i = 0; i < m3.Rows; i++)
            {
                for (int j = 0; j < m3.Columns; j++)
                {
                    Assert.AreEqual(expect3[i, j], Matrix.BubbleSortDown(m3, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect3).GetMatrix, Matrix.BubbleSortDown(m3, comp).GetMatrix);
        }

        [Test]
        public void SortUpMaxTest()
        {
            comparison comp = Matrix.max;

            int[,] initData1 = { { -7, 2, 15 }, { 0, 11, -3 } };
            int[,] expect1 = { { 0, 11, -3 }, { -7, 2, 15 } };
            Matrix m1 = new Matrix(initData1);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    Assert.AreEqual(expect1[i, j], Matrix.BubbleSortUp(m1, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect1).GetMatrix, Matrix.BubbleSortUp(m1, comp).GetMatrix);

            int[,] initData2 = { { 1, 2, 3 }, { 6, 4, 0 }, { -1, -5, 2 } };
            int[,] expect2 = { { -1, -5, 2 }, { 1, 2, 3 }, { 6, 4, 0 } };
            Matrix m2 = new Matrix(initData2);
            for (int i = 0; i < m2.Rows; i++)
            {
                for (int j = 0; j < m2.Columns; j++)
                {
                    Assert.AreEqual(expect2[i, j], Matrix.BubbleSortUp(m2, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect2).GetMatrix, Matrix.BubbleSortUp(m2, comp).GetMatrix);

            int[,] initData3 = { { 21, -4 }, { 13, 7 }, { 4, -4 }, { -8, -3 } };
            int[,] expect3 = { { -8, -3 }, { 4, -4 }, { 13, 7 }, { 21, -4 } };
            Matrix m3 = new Matrix(initData3);
            for (int i = 0; i < m3.Rows; i++)
            {
                for (int j = 0; j < m3.Columns; j++)
                {
                    Assert.AreEqual(expect3[i, j], Matrix.BubbleSortUp(m3, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect3).GetMatrix, Matrix.BubbleSortUp(m3, comp).GetMatrix);
        }

        [Test]
        public void SortDownMaxTest()
        {
            comparison comp = Matrix.max;

            int[,] initData1 = { { -7, 2, 15 }, { 0, 11, -3 } };
            int[,] expect1 = { { -7, 2, 15 }, { 0, 11, -3 } };
            Matrix m1 = new Matrix(initData1);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    Assert.AreEqual(expect1[i, j], Matrix.BubbleSortDown(m1, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect1).GetMatrix, Matrix.BubbleSortDown(m1, comp).GetMatrix);

            int[,] initData2 = { { 1, 2, 3 }, { 6, 4, 0 }, { -1, -5, 2 } };
            int[,] expect2 = { { 6, 4, 0 }, { 1, 2, 3 }, { -1, -5, 2 } };
            Matrix m2 = new Matrix(initData2);
            for (int i = 0; i < m2.Rows; i++)
            {
                for (int j = 0; j < m2.Columns; j++)
                {
                    Assert.AreEqual(expect2[i, j], Matrix.BubbleSortDown(m2, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect2).GetMatrix, Matrix.BubbleSortDown(m2, comp).GetMatrix);

            int[,] initData3 = { { 21, -4 }, { 13, 7 }, { 4, -4 }, { -8, -3 } };
            int[,] expect3 = { { 21, -4 }, { 13, 7 }, { 4, -4 }, { -8, -3 } };
            Matrix m3 = new Matrix(initData3);
            for (int i = 0; i < m3.Rows; i++)
            {
                for (int j = 0; j < m3.Columns; j++)
                {
                    Assert.AreEqual(expect3[i, j], Matrix.BubbleSortDown(m3, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect3).GetMatrix, Matrix.BubbleSortDown(m3, comp).GetMatrix);
        }

        [Test]
        public void SortUpMinTest()
        {
            comparison comp = Matrix.min;

            int[,] initData1 = { { -7, 2, 15 }, { 0, 11, -3 } };
            int[,] expect1 = { { -7, 2, 15 }, { 0, 11, -3 } };
            Matrix m1 = new Matrix(initData1);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    Assert.AreEqual(expect1[i, j], Matrix.BubbleSortUp(m1, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect1).GetMatrix, Matrix.BubbleSortUp(m1, comp).GetMatrix);

            int[,] initData2 = { { 1, 2, 3 }, { 6, 4, 0 }, { -1, -5, 2 } };
            int[,] expect2 = { { -1, -5, 2 }, { 6, 4, 0 }, { 1, 2, 3 } };
            Matrix m2 = new Matrix(initData2);
            for (int i = 0; i < m2.Rows; i++)
            {
                for (int j = 0; j < m2.Columns; j++)
                {
                    Assert.AreEqual(expect2[i, j], Matrix.BubbleSortUp(m2, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect2).GetMatrix, Matrix.BubbleSortUp(m2, comp).GetMatrix);

            int[,] initData3 = { { 21, -4 }, { 13, 7 }, { 4, -4 }, { 8, 3 } };
            int[,] expect3 = { { 21, -4 }, { 4, -4 }, { 8, 3 }, { 13, 7 } };
            Matrix m3 = new Matrix(initData3);
            for (int i = 0; i < m3.Rows; i++)
            {
                for (int j = 0; j < m3.Columns; j++)
                {
                    Assert.AreEqual(expect3[i, j], Matrix.BubbleSortUp(m3, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect3).GetMatrix, Matrix.BubbleSortUp(m3, comp).GetMatrix);
        }

        [Test]
        public void SortDownMinTest()
        {
            comparison comp = Matrix.min;

            int[,] initData1 = { { -7, 2, 15 }, { 0, 11, -3 } };
            int[,] expect1 = { { 0, 11, -3 }, { -7, 2, 15 } };
            Matrix m1 = new Matrix(initData1);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    Assert.AreEqual(expect1[i, j], Matrix.BubbleSortDown(m1, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect1).GetMatrix, Matrix.BubbleSortDown(m1, comp).GetMatrix);

            int[,] initData2 = { { 1, 2, 3 }, { 6, 4, 0 }, { -1, -5, 2 } };
            int[,] expect2 = { { 1, 2, 3 }, { 6, 4, 0 }, { -1, -5, 2 } };
            Matrix m2 = new Matrix(initData2);
            for (int i = 0; i < m2.Rows; i++)
            {
                for (int j = 0; j < m2.Columns; j++)
                {
                    Assert.AreEqual(expect2[i, j], Matrix.BubbleSortDown(m2, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect2).GetMatrix, Matrix.BubbleSortDown(m2, comp).GetMatrix);

            int[,] initData3 = { { 21, -4 }, { 13, 7 }, { 4, -4 }, { 8, 3 } };
            int[,] expect3 = { { 13, 7 }, { 8, 3 }, { 21, -4 }, { 4, -4 } };
            Matrix m3 = new Matrix(initData3);
            for (int i = 0; i < m3.Rows; i++)
            {
                for (int j = 0; j < m3.Columns; j++)
                {
                    Assert.AreEqual(expect3[i, j], Matrix.BubbleSortDown(m3, comp)[i, j]);
                }
            }
            CollectionAssert.AreEqual(new Matrix(expect3).GetMatrix, Matrix.BubbleSortDown(m3, comp).GetMatrix);
        }
    }
}