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
	class CollectionByKeyCommand<TKey, TValue> : CommandTarget<CommandedCollectionByKey<TKey, TValue>>
	{
		private CollectionByKeyCommand(CommandedCollectionByKey<TKey, TValue> target, CollectionByKeyChanged action, TKey key, TValue oldValue, TValue newValue)
			: base(target)
		{
			Action = action;
			Key = key;
			OldValue = oldValue;
			NewValue = newValue;
		}

		public static CollectionByKeyCommand<TKey, TValue> Insert(CommandedCollectionByKey<TKey, TValue> target, TKey key, TValue newValue)
		{
			return new CollectionByKeyCommand<TKey, TValue>(target, CollectionByKeyChanged.Insert, key, default!, newValue);
		}
		public static CollectionByKeyCommand<TKey, TValue> Remove(CommandedCollectionByKey<TKey, TValue> target, TKey key)
		{
			return new CollectionByKeyCommand<TKey, TValue>(target, CollectionByKeyChanged.Remove, key, target[key], default!);
		}
		public static CollectionByKeyCommand<TKey, TValue> Update(CommandedCollectionByKey<TKey, TValue> target, TKey key, TValue newItem)
		{
			return new CollectionByKeyCommand<TKey, TValue>(target, CollectionByKeyChanged.Update, key, target[key], newItem);
		}

		public CollectionByKeyChanged Action { get; } = (CollectionByKeyChanged)(-1);
		public TKey Key { get; } = default!;
		public TValue OldValue { get; } = default!;
		public TValue NewValue { get; } = default!;

		protected override void ExecuteForce()
		{
			using (Target.Disable())
			{
				switch (Action)
				{
					case CollectionByKeyChanged.Insert: Target.Insert(Key, NewValue); break;
					case CollectionByKeyChanged.Remove: Target.Remove(Key); break;
					case CollectionByKeyChanged.Update: Target[Key] = NewValue; break;
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
					case CollectionByKeyChanged.Insert: Target.Remove(Key); break;
					case CollectionByKeyChanged.Remove: Target.Insert(Key, OldValue); break;
					case CollectionByKeyChanged.Update: Target[Key] = OldValue; break;
					default: throw new InvalidEnumArgumentException();
				} 
			}
		}
	}
}
