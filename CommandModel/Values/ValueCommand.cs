using System;
using System.Collections.Generic;
using System.Text;

namespace CommandModel
{
	public class ValueCommand<T> : Command
	{
		public ValueCommand(T newValue)
		{
			NewValue = newValue;
		}

		public T NewValue { get; } = default!;
	}
}
