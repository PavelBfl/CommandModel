using System;
using System.Collections.Generic;
using System.Text;

namespace CommandModelTests
{
	public interface IValueGenerator<T>
	{
		T Generate();
	}
}
