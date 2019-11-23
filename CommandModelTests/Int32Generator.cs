using System;
using System.Collections.Generic;
using System.Text;

namespace CommandModelTests
{
	public class Int32Generator : ValueRangeGenerator<int>, IValueGenerator<int>
	{
		public Int32Generator(Random random)
			: base(random)
		{

		}
		public Int32Generator(Random random, int min, int max)
			: base(random, min, max)
		{

		}

		public int Generate()
		{
			if (Range is Range<int> range)
			{
				return Random.Next(range.Min, range.Max + 1);
			}
			else
			{
				return Random.Next();
			}
		}
		public int Generate(int min, int max)
		{
			return Random.Next(min, max);
		}
	}
}
