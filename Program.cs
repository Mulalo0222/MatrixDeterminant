using System;


namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixDeterminant matrix3x3 = new MatrixDeterminant(new[,]
        {
            {4.0, 4.0, -6.0},
            {1.0, -20.0, 50.0},
            {10.0, 3.0, 7.0},

        });

            double determinant = matrix3x3.determinantMatrix();
            Console.WriteLine("Determinant is: {0}", determinant);

        }
    }

    public class MatrixDeterminant
    {
        private int rows;
        private int columns;
        private double[,] matrix;


        public MatrixDeterminant(double[,] matrix_array)
        {
            matrix = matrix_array;
            rows = matrix.GetLength(0);
            columns = matrix.GetLength(1);
            Console.WriteLine("Constructor matrix of size: {0}", rows, columns);
        }


        public int countRows()
        {
            return rows;
        }


        public int countColumns()
        {
            return columns;
        }

        public double readElement(int row, int column)
        {
            return matrix[row, column];
        }


        public void setElement(double value, int row, int column)
        {
            matrix[row, column] = value;
        }

        public double determinantMatrix()
        {
            double determinant = 0;
            double value = 0;
            int i, j, k;

            i = rows;
            j = columns;
            int n = i;

            if (i != j)
            {
                Console.WriteLine("Determinant can be calculated only for sqaure matrix!");
                return determinant;
            }

            for (i = 0; i < n - 1; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    determinant = (this.readElement(j, i) / this.readElement(i, i));
                    for (k = i; k < n; k++)
                    {
                        value = this.readElement(j, k) - determinant * this.readElement(i, k);
                        this.setElement(value, j, k);
                    }
                }
            }
            determinant = 1;
            for (i = 0; i < n; i++)
                determinant = determinant * this.readElement(i, i);

            return determinant;
        }
    }


}