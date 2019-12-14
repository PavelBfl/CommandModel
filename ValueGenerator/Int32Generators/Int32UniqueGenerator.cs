using System;
using System.Collections.Generic;
using System.Text;

namespace ValueGenerator.Int32Generators
{
	/// <summary>
	/// Генератор уникальных целочисленых значений
	/// </summary>
	public class Int32UniqueGenerator : ValueUniqueGenerator<int>
	{
		public Int32UniqueGenerator(IValueGenerator<int> baseGenerator)
			: base(baseGenerator)
		{
		}

		protected override int Increment(int value)
		{
			return ++value;
		}
	}
}
