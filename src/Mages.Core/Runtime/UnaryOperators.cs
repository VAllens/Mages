﻿namespace Mages.Core.Runtime
{
    using System;

    static class UnaryOperators
    {
        public static Object Not(Object[] args)
        {
            return Logic.IsFalse((Double)args[0]) ? 1.0 : 0.0;
        }

        public static Object Positive(Object[] args)
        {
            return +(Double)args[0];
        }

        public static Object Negative(Object[] args)
        {
            return -(Double)args[0];
        }

        public static Object Factorial(Object[] args)
        {
            var value = (Double)args[0];
            return value.Factorial();
        }

        public static Object Transpose(Object[] args)
        {
            var matrix = (Double[,])args[0];
            return matrix.Transpose();
        }

        public static Object Abs(Object[] args)
        {
            var value = args[0];

            if (value is Double[,])
            {
                return Matrix.Abs((Double[,])value);
            }
            else if (value is Double)
            {
                return Math.Abs((Double)value);
            }

            return value;
        }
    }
}
