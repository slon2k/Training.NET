using System;
using Tasks.Task04;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix1 = new MatrixSquare(3);
            matrix1.SetValue(1, 0, 0);
            
            var matrix2 = new MatrixSymmetric(3);
            matrix2.SetValue(2, 1, 1);

            var matrix3 = new MatrixDiagonal(3);
            matrix3.SetValue(3, 1, 1);

        }
    }
}
