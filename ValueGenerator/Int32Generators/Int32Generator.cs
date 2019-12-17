using System;
using System.Collections.Generic;
using System.Text;

namespace ValueGenerator.Int32Generators
{
	public class Int32Generator : ValueGenerator, IValueGenerator<int>
	{
		public Int32Generator(Random random)
			: base(random)
		{
		}

		public int Generate()
		{
			return Random.Next();
		}
	}
}
