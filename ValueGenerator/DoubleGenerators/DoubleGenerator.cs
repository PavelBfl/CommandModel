using System;
using System.Collections.Generic;
using System.Text;

namespace ValueGenerator.DoubleGenerators
{
	public class DoubleGenerator : ValueGenerator, IValueGenerator<double>
	{
		public DoubleGenerator(Random random)
			: base(random)
		{
		}

		public double Generate()
		{
			return Random.NextDouble();
		}
	}
}
