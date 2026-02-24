using System.Text;

namespace VectorTask
{
    public class Vector
    {
        private double[] _components;

        public Vector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("Dimension = " + dimension + ". Dimension должно быть больше 0.", nameof(dimension));
            }

            _components = new double[dimension];
        }

        public Vector(Vector vector)
        {
            _components = new double[vector._components.Length];
            Array.Copy(vector._components, _components, vector._components.Length);
        }

        public Vector(double[] components)
        {
            if (components.Length == 0)
            {
                throw new ArgumentException("Components.Length = " + components.Length + ". Components.Length должно быть больше 0.", nameof(components.Length));
            }

            this._components = new double[components.Length];
            Array.Copy(components, this._components, components.Length);
        }

        public Vector(int dimension, double[] components)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("Dimension = " + dimension + ".Dimension должно быть больше 0.", nameof(dimension));
            }

            this._components = new double[dimension];

            Array.Copy(components, this._components, Math.Min(components.Length, dimension));
        }

        public int GetSize()
        {
            return _components.Length;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("{ ");

            foreach (double e in _components)
            {
                stringBuilder.Append(e).Append(", ");
            }

            return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append(" }").ToString();
        }

        public Vector Add(Vector vector)
        {
            if (_components.Length < vector._components.Length)
            {
                Array.Resize(ref _components, vector._components.Length);
            }

            for (int i = 0; i < vector._components.Length; i++)
            {
                _components[i] += vector._components[i];
            }

            return this;
        }

        public Vector Subtract(Vector vector)
        {
            if (_components.Length < vector._components.Length)
            {
                Array.Resize(ref _components, vector._components.Length);
            }

            for (int i = 0; i < vector._components.Length; i++)
            {
                _components[i] -= vector._components[i];
            }

            return this;
        }

        public Vector Multiply(double scalar)
        {
            for (int i = 0; i < _components.Length; i++)
            {
                _components[i] *= scalar;
            }

            return this;
        }

        public Vector Revert()
        {
            return Multiply(-1);
        }

        public double GetLength()
        {
            double squaredComponentsSum = 0;

            foreach (double e in _components)
            {
                squaredComponentsSum += Math.Pow(e, 2);
            }

            return Math.Sqrt(squaredComponentsSum);
        }

        public double GetComponent(int index)
        {
            return _components[index];
        }

        public void SetComponent(int index, double value)
        {
            _components[index] = value;
        }

        public static Vector GetAddition(Vector vector1, Vector vector2)
        {
            var vectorForAddition = new Vector(vector1);

            return vectorForAddition.Add(vector2);
        }

        public static Vector GetSubtraction(Vector vector1, Vector vector2)
        {
            var vectorForSubtraction = new Vector(vector1);

            return vectorForSubtraction.Subtract(vector2);
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            double scalarMultiplicationResult = 0;
            int minVectorLength = Math.Min(vector1._components.Length, vector2._components.Length);

            for (int i = 0; i < minVectorLength; i++)
            {
                scalarMultiplicationResult += vector1._components[i] * vector2._components[i];
            }

            return scalarMultiplicationResult;
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }

            if (ReferenceEquals(o, null) || o.GetType() != GetType())
            {
                return false;
            }

            var vector = (Vector)o;

            if (_components.Length != vector._components.Length)
            {
                return false;
            }

            for (var i = 0; i < _components.Length; i++)
            {
                if (_components[i] != vector._components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            foreach (double e in _components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }
    }
}
