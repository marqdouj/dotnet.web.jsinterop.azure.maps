namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models.Atlas
{
    /// <summary>
    /// An Affine Transform class generated from a set of reference points.
    /// </summary>
    /// <remarks>
    /// The transform maps a 2D source reference system to a 2D target reference
    /// system using the affine model:
    /// <code>
    /// x' = a * x + b * y + c
    /// y' = d * x + e * y + f
    /// </code>
    /// The parameters (a, b, c, d, e, f) are obtained by a least-squares fit
    /// between the supplied 'source' and 'target' parameters"/>
    /// reference point pairs.
    /// </remarks>
    public class AffineTransform
    {
        // Forward transform parameters:
        // x' = a * x + b * y + c
        // y' = d * x + e * y + f
        private readonly double _a, _b, _c;
        private readonly double _d, _e, _f;
        private readonly double[][] _source;
        private readonly double[][] _target;

        /// <summary>
        /// Gets a clone of the source reference points used to compute the affine transform.
        /// </summary>
        public double[][] Source => (double[][])_source.Clone();

        /// <summary>
        /// Gets a clone of the target reference points used to compute the affine transform.
        /// </summary>
        public double[][] Target => (double[][])_target.Clone();

        /// <summary>
        /// An Affine Transform class generated from a set of reference points.
        /// </summary>
        /// <param name="source">A set of reference points from the source reference system to transform from.</param>
        /// <param name="target">A set of reference points from the target reference system to transform to.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="target"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when the point sets differ in length or contain fewer than 3 pairs.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the reference points are collinear (singular system).</exception>
        public AffineTransform(double[][] source, double[][] target)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(target);
            if (source.Length != target.Length)
                throw new ArgumentException("Source and target must contain the same number of points.", nameof(target));
            if (source.Length < 3)
                throw new ArgumentException("At least 3 point pairs are required to compute an affine transform.", nameof(source));

            _source = source;
            _target = target;

            // Accumulators for the normal equations AᵀA and Aᵀb.
            double sumX2 = 0, sumY2 = 0, sumXY = 0, sumX = 0, sumY = 0;
            double sumXx = 0, sumYx = 0, sumXp = 0; // right-hand side for x' mapping
            double sumXy = 0, sumYy = 0, sumYp = 0; // right-hand side for y' mapping

            for (int i = 0; i < source.Length; i++)
            {
                double x = source[i][0];
                double y = source[i][1];
                double xp = target[i][0];
                double yp = target[i][1];

                sumX2 += x * x;
                sumY2 += y * y;
                sumXY += x * y;
                sumX += x;
                sumY += y;

                sumXx += x * xp;
                sumYx += y * xp;
                sumXp += xp;

                sumXy += x * yp;
                sumYy += y * yp;
                sumYp += yp;
            }

            int n = source.Length;

            // Symmetric matrix AᵀA (3x3).
            double[,] ata = new double[3, 3]
            {
                { sumX2, sumXY, sumX },
                { sumXY, sumY2, sumY },
                { sumX,  sumY,  n   }
            };

            // Solve for the x' coefficients (a, b, c).
            double[] bx = [sumXx, sumYx, sumXp];
            double[] xCoef = Solve3x3(ata, bx);
            _a = xCoef[0];
            _b = xCoef[1];
            _c = xCoef[2];

            // Solve for the y' coefficients (d, e, f).
            double[] by = [sumXy, sumYy, sumYp];
            double[] yCoef = Solve3x3(ata, by);
            _d = yCoef[0];
            _e = yCoef[1];
            _f = yCoef[2];
        }

        /// <summary>
        /// Converts an array of points from the source reference system to the target reference system.
        /// </summary>
        /// <param name="sourcePoints">An array of points from the source reference system to transform.</param>
        /// <param name="decimals">Number of decimal places to round the results off to. When omitted, no rounding is applied.</param>
        /// <returns>An array of points that have been transformed to the target reference system.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sourcePoints"/> is <c>null</c>.</exception>
        public double[][] ToTarget(double[][] sourcePoints, int? decimals = null)
        {
            ArgumentNullException.ThrowIfNull(sourcePoints);

            var result = new double[sourcePoints.Length][];
            for (int i = 0; i < sourcePoints.Length; i++)
            {
                double x = sourcePoints[i][0];
                double y = sourcePoints[i][1];

                double xp = _a * x + _b * y + _c;
                double yp = _d * x + _e * y + _f;

                result[i] = [Round(xp, decimals), Round(yp, decimals)];
            }
            return result;
        }

        /// <summary>
        /// Converts an array of points from the target reference system to the source reference system.
        /// </summary>
        /// <param name="targetPoints">An array of points from the target reference system to transform.</param>
        /// <param name="decimals">Number of decimal places to round the results off to. When omitted, no rounding is applied.</param>
        /// <returns>An array of points that have been transformed to the source reference system.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="targetPoints"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the transform is singular and cannot be inverted.</exception>
        public double[][] ToSource(double[][] targetPoints, int? decimals = null)
        {
            ArgumentNullException.ThrowIfNull(targetPoints);

            double det = _a * _e - _b * _d;
            if (Math.Abs(det) < 1e-12)
                throw new InvalidOperationException("The affine transform is singular and cannot be inverted.");

            // Inverse affine parameters.
            double ia = _e / det;
            double ib = -_b / det;
            double ic = (_b * _f - _c * _e) / det;
            double id = -_d / det;
            double ie = _a / det;
            double iff = (_c * _d - _a * _f) / det;

            var result = new double[targetPoints.Length][];
            for (int i = 0; i < targetPoints.Length; i++)
            {
                double xp = targetPoints[i][0];
                double yp = targetPoints[i][1];

                double x = ia * xp + ib * yp + ic;
                double y = id * xp + ie * yp + iff;

                result[i] = [Round(x, decimals), Round(y, decimals)];
            }
            return result;
        }

        /// <summary>
        /// Rounds <paramref name="value"/> to the requested number of decimal places when specified.
        /// </summary>
        private static double Round(double value, int? decimals)
        {
            return decimals.HasValue
                ? Math.Round(value, decimals.Value, MidpointRounding.AwayFromZero)
                : value;
        }

        /// <summary>
        /// Solves a 3x3 linear system A * x = b using Gaussian elimination with partial pivoting.
        /// </summary>
        private static double[] Solve3x3(double[,] A, double[] b)
        {
            const int n = 3;
            double[,] m = new double[n, n + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    m[i, j] = A[i, j];
                m[i, n] = b[i];
            }

            for (int col = 0; col < n; col++)
            {
                // Partial pivot: find the row with the largest magnitude in this column.
                int pivot = col;
                for (int r = col + 1; r < n; r++)
                {
                    if (Math.Abs(m[r, col]) > Math.Abs(m[pivot, col]))
                        pivot = r;
                }

                if (Math.Abs(m[pivot, col]) < 1e-12)
                    throw new InvalidOperationException("The system of equations is singular and cannot be solved.");

                if (pivot != col)
                {
                    for (int j = 0; j <= n; j++)
                    {
                        (m[pivot, j], m[col, j]) = (m[col, j], m[pivot, j]);
                    }
                }

                double diag = m[col, col];
                for (int j = col; j <= n; j++)
                    m[col, j] /= diag;

                for (int r = 0; r < n; r++)
                {
                    if (r == col)
                        continue;

                    double factor = m[r, col];
                    for (int j = col; j <= n; j++)
                        m[r, j] -= factor * m[col, j];
                }
            }

            var x = new double[n];
            for (int i = 0; i < n; i++)
                x[i] = m[i, n];
            return x;
        }
    }
}
