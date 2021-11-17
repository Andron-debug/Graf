using System;

namespace Matrix
{
    class MyMatrix
    {
        private double[,] a;
        private int n;
        private int k;

        public int N
        {
            get
            {
                return n;
            }
        }
        public int K
        {
            get
            {
                return k;
            }
        }

        public MyMatrix()
        {
            n = 1;
            a = new double[n, n];
        }
        public MyMatrix(int nn, int kk)
        {

            n = nn;
            k = kk;
            a = new double[n, k];
        }
        public double this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= n || j < 0 || j >= k)
                    throw new ApplicationException("Не верный индекс");
                return a[i, j];
            }
            set
            {
                if (i < 0 || i >= n || j < 0 || j >= k)
                    throw new ApplicationException("Не верный индекс");
                a[i, j] = value;
            }
        }
        public void FillRandom(int min, int max)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < k; j++)
                {
                    a[i, j] = r.Next(min, max + 1);
                }
        }
        public static MyMatrix operator +(MyMatrix m1, MyMatrix m2)
        {
            if ((m1.N != m2.N) || (m1.K != m2.K)) throw new ApplicationException("Матрицы должны быть одной размерности");
            MyMatrix r = new MyMatrix(m1.N, m1.K);
            for (int i = 0; i < r.N; i++)
                for (int j = 0; j < r.K; j++)
                    r[i, j] = m1[i, j] + m2[i, j];
            return r;
        }
        public static MyMatrix operator -(MyMatrix m1, MyMatrix m2)
        {
            if ((m1.N != m2.N) || (m1.K != m2.K)) throw new ApplicationException("Матрицы должны быть одной размерности");
            MyMatrix r = new MyMatrix(m1.N, m1.K);
            for (int i = 0; i < r.N; i++)
                for (int j = 0; j < r.K; j++)
                    r[i, j] = m1[i, j] - m2[i, j];
            return r;
        }
        public static MyMatrix operator *(MyMatrix m1, double k)
        {
            MyMatrix r = new MyMatrix(m1.N, m1.K);
            for (int i = 0; i < r.N; i++)
                for (int j = 0; j < r.K; j++)
                    r[i, j] = m1[i, j] * k;
            return r;
        }

        public static MyMatrix operator *(double k, MyMatrix m1)
        {
            MyMatrix r = new MyMatrix(m1.N, m1.K);
            for (int i = 0; i < r.N; i++)
                for (int j = 0; j < r.K; j++)
                    r[i, j] = m1[i, j] * k;
            return r;
        }
        public static MyMatrix operator *(MyMatrix m1, MyMatrix m2)
        {
            if (m1.K != m2.N) throw new ApplicationException("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            MyMatrix r = new MyMatrix(m1.N, m2.K);

            for (var i = 0; i < m1.N; i++)
                for (var j = 0; j < m2.K; j++)
                    for (var k = 0; k < m1.K; k++)
                        r[i, j] += m1[i, k] * m2[k, j];
            return r;
        }
        public MyMatrix InverseMatrix()
        {
            double det = this.Det();
            if (det == 0) throw new ApplicationException("Определитель 0");
            MyMatrix algeb = new MyMatrix(n, k);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < k; j++)
                    algeb[i, j] = Math.Pow(-1, i + j) * MyMatrix.Det(this.cross(i, j));
            return algeb.Transpose() * (1 / det);
        }

        public MyMatrix Transpose()
        {
            MyMatrix r = new MyMatrix(k, n);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < k; j++)
                    r[j, i] = a[i, j];
            return r;
        }
        private MyMatrix cross(int row, int column)
        {
            MyMatrix r = new MyMatrix(n - 1, k - 1);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < k; j++)
                {
                    if ((i < row) && (j < column)) r[i, j] = a[i, j];
                    if ((i < row) && (j > column)) r[i, j - 1] = a[i, j];
                    if ((i > row) && (j < column)) r[i - 1, j] = a[i, j];
                    if ((i > row) && (j > column)) r[i - 1, j - 1] = a[i, j];
                }
            return r;
        }
        public double Det()
        {
            return MyMatrix.Det(this);
        }

        public static double Det(MyMatrix m)
        {
            double r = 0;
            if (m.N != m.K) throw new ApplicationException("Матрица не квадратная");
            if (m.N != 1)
                for (int j = 0; j < m.K; j++)
                    r += Math.Pow(-1, j) * m[0, j] * Det(m.cross(0, j));
            else r = m[0, 0];
            return r;
        }
        public override string ToString()
        {
            string ret = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    ret += a[i, j] + " ";
                }
                ret += Environment.NewLine;
            }
            return ret;
        }
    }
}
