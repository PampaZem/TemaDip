using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChM
{
    class Newton
    {
        public Newton(double[] x, double[] y)
        {
            X = x;
            Y = y;
            Time = 0;
            Setka();
        }
        public double InterpolatedValue { get; set; }
        public double Time { get; set; }
        public double Error { get; set; }
        protected double[] X { get; set; }
        protected double[] Y { get; set; }
        protected double[] _Setka { get; set; }
        private void Setka()
        {
            _Setka = new double[X.Length];
            _Setka[0] = Y[0];
            for (int i = 1; i < _Setka.Length; i++)
            {
                double result = 0;
                for (int j = 0; j < i + 1; j++)
                {
                    result += Y[j] / Mult(i, j);
                }
                _Setka[i] = result;
            }
        }
        private double Mult(int i, int j)
        {
            double mult = 1;
            for (int a = 0; a < i + 1; a++)
            {
                if (X[j] != X[a])
                    mult *= X[j] - X[a];
            }
            return mult;

        }
        private double P_Mult(int i, double value)
        {
            double mult = 1;
            for (int j = 0; j < i; j++)
                mult *= value - X[j];
            return mult;
        }
        public double Interpolate(double value)
        {
            double P = _Setka[0];
            for (int i = 1; i < _Setka.Length; i++)
            {
                double PMult = P_Mult(i, value);
                P += _Setka[i] * PMult;
            }
            return P;
        }
        public void Start(double value, double exactValue)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 10000; i++)
            {
                stopwatch.Restart();
                InterpolatedValue = Interpolate(value);
                stopwatch.Stop();
                Time += stopwatch.ElapsedMilliseconds;
            }
            Error = Math.Abs(InterpolatedValue - exactValue);
        }
    }
}

