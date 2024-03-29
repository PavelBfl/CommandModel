﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ValueGenerator.DoubleGenerators
{
	/// <summary>
	/// Объект сравнения дробных чисел
	/// </summary>
	public class DoubleComparer : IEqualityComparer<double>
	{
		public DoubleComparer(double epsilon)
		{
			if (epsilon <= 0)
			{
				throw new Exception();
			}
			Epsilon = epsilon;
		}

		/// <summary>
		/// Погрешность сравнения
		/// </summary>
		public double Epsilon { get; } = 1;
		
		public bool Equals([AllowNull] double x, [AllowNull] double y)
		{
			return Math.Floor(x / Epsilon) == Math.Floor(y / Epsilon);
		}

		public int GetHashCode([DisallowNull] double obj)
		{
			return Math.Floor(obj / Epsilon).GetHashCode();
		}
	}
}
