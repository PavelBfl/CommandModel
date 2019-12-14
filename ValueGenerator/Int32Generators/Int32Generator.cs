using System;
using System.Collections.Generic;
using System.Text;

namespace ValueGenerator.Int32Generators
{
	public class Int32Generator : ValueGenerator, IValueGenerator<int>, IValuesUniqueGenerator<int>
	{
		public Int32Generator(Random random)
			: base(random)
		{
		}

		public int Generate()
		{
			return Random.Next();
		}

		private readonly SortedSet<int> oldValues = new SortedSet<int>();
		public int GenerateUnique()
		{
			var result = Generate();
			foreach (var oldValue in oldValues)
			{
				if (oldValue == result)
				{
					result++;
				}
			}
			oldValues.Add(result);
			return result;
		}

		public void Reset()
		{
			oldValues.Clear();
		}
	}
}
