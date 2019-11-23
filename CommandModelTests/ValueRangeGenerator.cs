using System;
using System.Collections.Generic;
using System.Text;

namespace CommandModelTests
{
	public class ValueRangeGenerator<T> : ValueGenerator
	{
		public ValueRangeGenerator(Random random)
			: this(random, null)
		{

		}
		public ValueRangeGenerator(Random random, T min, T max)
			: this(random, new Range<T>(min, max))
		{

		}
		private ValueRangeGenerator(Random random, Range<T>? range)
			: base(random)
		{

		}

		public Range<T>? Range { get; } = null;
	}
}
