using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMatrix
{
    class Matrix : IEnumerable
    {
        private int[,] matr;
        private int rowCount = 1;
        private int columnCount = 1;

        public Matrix(int rowCount = 1, int columnCount = 1)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
        }

        public void InitArray()
        {
            Random random = new Random();
            for (int i = 0; i < RowCount; ++i)
            {
                for (int j = 0; j < ColumnCount; ++j)
                {
                    matr[i, j] = random.Next(-100, 100);
                }
            }
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < RowCount; ++i)
            {
                for (int j = 0; j < ColumnCount; ++j)
                {
                    res += matr[i, j] + "  ";
                }
                res += "\n";
            }

            return res;
        }

        public int this[int row, int column]
        {
            get
            {
                return matr[row, column];
            }
        }

        public int RowCount
        {
            get
            {
                return rowCount;
            }
            set
            {
                if (value > 0)
                {
                    rowCount = value;
                    matr = new int[this.rowCount, this.columnCount];
                }
                else
                {
                    throw new ArgumentException("Incorrect value of size");
                }
            }
        }

        public int ColumnCount
        {
            get
            {
                return columnCount;
            }
            set
            {
                if (value > 0)
                {
                    columnCount = value;
                    matr = new int[this.rowCount, this.columnCount];
                }
                else
                {
                    throw new ArgumentException("Incorrect value of size");
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new MatrixEnum(matr);
        }

        class MatrixEnum : IEnumerator
        {
            private int positionRow = -1;
            private int positionColumn = -1;
            public int[,] matrix;

            public MatrixEnum(int[,] matrix)
            {
                this.matrix = matrix;
                positionRow = matrix.GetLength(0) - 1;
                positionColumn = matrix.GetLength(1);
            }

            public object Current => matrix[positionRow, positionColumn];

            public bool MoveNext()
            {
                    positionColumn -= 1;
                    if (positionColumn  == -1)
                    {
                        positionRow -= 1;
                        positionColumn = matrix.GetLength(1) - 1;
                    }
                if (positionColumn > -1 && positionRow > -1)
                {
                    return true;
                }
                return false;

            }

            public void Reset()
            {
                positionRow = matrix.GetLength(0);
                positionColumn = matrix.GetLength(1);
            }
        }
    }
}
