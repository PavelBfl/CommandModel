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
	class CollectionUniqueCommand<T> : CommandTarget<CommandedCollectionUnique<T>>
	{
		public CollectionUniqueCommand(CommandedCollectionUnique<T> target, CollectionUniqueChanged action, T item)
			: base(target)
		{
			Action = action;
			Item = item;
		}

		public CollectionUniqueChanged Action { get; } = (CollectionUniqueChanged)(-1);
		public T Item { get; } = default!;

		protected override void ExecuteForce()
		{
			using (Target.Disable())
			{
				switch (Action)
				{
					case CollectionUniqueChanged.Add: Target.Add(Item); break;
					case CollectionUniqueChanged.Remove: Target.Remove(Item); break;
					default: throw new InvalidEnumArgumentException();
				} 
			}
		}

		protected override void UndoForce()
		{
			using (Target.Disable())
			{
				switch (Action)
				{
					case CollectionUniqueChanged.Add: Target.Remove(Item); break;
					case CollectionUniqueChanged.Remove: Target.Add(Item); break;
					default: throw new InvalidEnumArgumentException();
				} 
			}
		}
	}
}
