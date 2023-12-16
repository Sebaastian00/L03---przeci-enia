using System;

class Matrix
{
    private int rows;
    private int cols;
    private int[,] data;

    public Matrix(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        this.data = new int[rows, cols];
    }

    public int Rows
    {
        get { return rows; }
    }

    public int Cols
    {
        get { return cols; }
    }

    public int this[int i, int j]
    {
        get { return data[i, j]; }
        set { data[i, j] = value; }
    }

    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
        {
            throw new ArgumentException("Matrix dimensions do not match for addition");
        }

        Matrix result = new Matrix(m1.Rows, m1.Cols);
        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m1.Cols; j++)
            {
                result[i, j] = m1[i, j] + m2[i, j];
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix m1, Matrix m2)
    {
        if (m1.Cols != m2.Rows)
        {
            throw new ArgumentException("Number of columns in the first matrix must match the number of rows in the second matrix for multiplication");
        }

        Matrix result = new Matrix(m1.Rows, m2.Cols);
        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m2.Cols; j++)
            {
                for (int k = 0; k < m1.Cols; k++)
                {
                    result[i, j] += m1[i, k] * m2[k, j];
                }
            }
        }

        return result;
    }

    public Matrix Transpose()
    {
        Matrix result = new Matrix(cols, rows);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[j, i] = data[i, j];
            }
        }

        return result;
    }

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result += data[i, j] + " ";
            }
            result += "\n";
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        // Przykładowe macierze
        Matrix matrix1 = new Matrix(2, 3);
        matrix1[0, 0] = 1; matrix1[0, 1] = 2; matrix1[0, 2] = 3;
        matrix1[1, 0] = 4; matrix1[1, 1] = 5; matrix1[1, 2] = 6;

        Matrix matrix2 = new Matrix(3, 2);
        matrix2[0, 0] = 7; matrix2[0, 1] = 8;
        matrix2[1, 0] = 9; matrix2[1, 1] = 10;
        matrix2[2, 0] = 11; matrix2[2, 1] = 12;

        Console.WriteLine("Matrix 1:");
        Console.WriteLine(matrix1);

        Console.WriteLine("Matrix 2:");
        Console.WriteLine(matrix2);

        // Dodawanie macierzy
        try
        {
            Matrix resultAddition = matrix1 + matrix2;
            Console.WriteLine("Addition result:");
            Console.WriteLine(resultAddition);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        // Mnożenie macierzy
        try
        {
            Matrix resultMultiplication = matrix1 * matrix2;
            Console.WriteLine("Multiplication result:");
            Console.WriteLine(resultMultiplication);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        // Transpozycja macierzy
        Matrix resultTranspose = matrix1.Transpose();
        Console.WriteLine("Transpose result:");
        Console.WriteLine(resultTranspose);
    }
}