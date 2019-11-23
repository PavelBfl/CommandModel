using System;
using System.Collections.Generic;
using System.Text;

namespace CommandModelTests
{
	public class ValueGenerator
	{
		public ValueGenerator(Random random)
		{
			Random = random ?? throw new NullReferenceException();
		}

		protected Random Random { get; } = null!;
	}
}
