using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandModel.Collections
{
	enum CollectionUniqueChanged
	{
		Add,
		Remove
	}
	class CollectionUniqueCommand<T> : Command
	{
		public CollectionUniqueCommand(CollectionUniqueChanged action, T item)
		{
			Action = action;
			Item = item;
		}

		public CollectionUniqueChanged Action { get; } = (CollectionUniqueChanged)(-1);
		public T Item { get; } = default!;
	}
}
