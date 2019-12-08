using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandModel.Collections
{
	enum CollectionByKeyChanged
	{
		Remove,
		Insert,
		Update,
	}
	class CollectionByKeyCommand<TKey, TValue> : Command
	{
		public CollectionByKeyCommand(CollectionByKeyChanged action, TKey key, TValue newValue)
		{
			Action = action;
			Key = key;
			NewValue = newValue;
		}

		public CollectionByKeyChanged Action { get; } = (CollectionByKeyChanged)(-1);
		public TKey Key { get; } = default!;
		public TValue NewValue { get; } = default!;
	}
}
