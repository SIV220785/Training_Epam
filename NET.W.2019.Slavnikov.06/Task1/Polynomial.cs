namespace Task1
{
    using System;
    using System.Text;

    public sealed class Polynomial
    {
        private const double Eps = double.Epsilon;
        private readonly double[] coefficients;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// Polynomial class constructor.
        /// </summary>
        /// <param name="coefficients"> polynomial coefficients.</param>
        public Polynomial(params double[] coefficients)
        {
            this.coefficients = coefficients;
        }

        /// <summary>
        /// Gets degree of polynomial.
        /// </summary>
        public int Order
        {
            get { return this.coefficients.Length; }
        }

        /// <summary>
        /// Getting or setting the polynomial coefficient value.
        /// </summary>
        /// <param name="n">coefficient number.</param>
        /// <returns> coefficient value.</returns>
        public double this[int n]
        {
            get { return this.coefficients[n]; }
            set { this.coefficients[n] = value; }
        }

        /// <summary>
        /// Quick calculation of the polynomial value according to Horner's scheme.
        /// </summary>
        /// <param name="x"> The argument of the polynomial.</param>
        /// <returns> The value of the polynomial.</returns>
        public double Calculate(double x)
        {
            int n = this.coefficients.Length - 1;
            double result = this.coefficients[n];
            for (int i = n - 1; i >= 0; i--)
            {
                result = x * (result + this.coefficients[i]);
            }

            return result;
        }

        /// <summary>
        /// Method that overrides GetHashCode method.
        /// </summary>
        /// <returns>HashCode of polynomial.</returns>
        public override int GetHashCode()
        {
            int hash = 1;
            foreach (var factor in this.coefficients)
            {
                hash *= (int)factor;
                hash += this.Order;
            }

            return hash;
        }

        /// <summary>
        /// Override method ToString().
        /// </summary>
        /// <returns>value.</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (i == 0 && Math.Abs(this.coefficients[i]) > Eps)
                {
                    str.AppendFormat($"{this.coefficients[i]}");
                    continue;
                }

                if (Math.Abs(this.coefficients[i]) > Eps)
                {
                    if (this.coefficients[i] > 0 && str.Length > 0)
                    {
                        _ = str.AppendFormat($" + {this.coefficients[i]}*x^{i}");
                    }
                    else
                    {
                        _ = str.AppendFormat($" {this.coefficients[i]}*x^{i}");
                    }
                }
            }

            return str.ToString().Trim();
        }

        /// <summary>
        /// Method that overrides Equals method.
        /// </summary>
        /// <param name="obj">Boxed polynomial.</param>
        /// <returns>True if polynomials are equal, else false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != this.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var other = obj as Polynomial;
            if (this.coefficients.Length != other.coefficients.Length)
            {
                return false;
            }

            for (var i = 0; i < this.coefficients.Length; i++)
            {
                if (!this.coefficients[i].Equals(other.coefficients[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Override operator *.
        /// </summary>
        /// <param name="pFirst">1st polynomial.</param>+
        /// <param name="pSecond">2nd polynomial.</param>
        /// <returns>pFirst*pSecond.</returns>
        public static Polynomial operator *(Polynomial pFirst, Polynomial pSecond)
        {
            int itemsCount = pFirst.coefficients.Length + pSecond.coefficients.Length - 1;
            var result = new double[itemsCount];
            for (int i = 0; i < pFirst.coefficients.Length; i++)
            {
                for (int j = 0; j < pSecond.coefficients.Length; j++)
                {
                    result[i + j] += pFirst[i] * pSecond[j];
                }
            }

            return new Polynomial(result);
        }

        /// Elements should appear in the correct order
        /// <summary>
        /// Override operator +.
        /// </summary>
        /// <param name="pFirst">1st polynomial.</param>
        /// <param name="pSecond">2nd polynomial.</param>
        /// <returns>pFirst + pSecond.</returns>
        public static Polynomial operator +(Polynomial pFirst, Polynomial pSecond)
        {
            int itemsCount = Math.Max(pFirst.coefficients.Length, pSecond.coefficients.Length);
            var result = new double[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                double a = 0;
                double b = 0;
                if (i < pFirst.coefficients.Length)
                {
                    a = pFirst[i];
                }

                if (i < pSecond.coefficients.Length)
                {
                    b = pSecond[i];
                }

                result[i] = a + b;
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Override operator ==.
        /// </summary>
        /// <param name="pFirst">1st polynomial.</param>
        /// <param name="pSecond">2nd polynomial.</param>
        /// <returns> true or flase.</returns>
        public static bool operator ==(Polynomial pFirst, Polynomial pSecond)
        {
            if (ReferenceEquals(pFirst, pSecond))
            {
                return true;
            }

            if (pFirst is null || pSecond is null)
            {
                return false;
            }

            return pFirst.Equals(pSecond);
        }

        /// <summary>
        /// Override operator -.
        /// </summary>
        /// <param name="pFirst">1st polynomial.</param>
        /// <param name="pSecond">2nd polynomial.</param>
        /// <returns>true or flase.</returns>
        public static Polynomial operator -(Polynomial pFirst, Polynomial pSecond)
        {
            int itemsCount = Math.Max(pFirst.coefficients.Length, pSecond.coefficients.Length);
            var result = new double[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                double a = 0;
                double b = 0;
                if (i < pFirst.coefficients.Length)
                {
                    a = pFirst[i];
                }

                if (i < pSecond.coefficients.Length)
                {
                    b = pSecond[i];
                }

                result[i] = a - b;
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Override operator !=.
        /// </summary>
        /// <param name="pFirst">1st polynomial.</param>
        /// <param name="pSecond">2nd polynomial.</param>
        /// <returns>true or false.</returns>
        public static bool operator !=(Polynomial pFirst, Polynomial pSecond) => !pFirst.Equals(pSecond);
    }
}
