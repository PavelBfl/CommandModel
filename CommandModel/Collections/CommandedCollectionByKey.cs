using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandModel.Collections
{
	public abstract class CommandedCollectionByKey<TKey, TValue> : CommandedObject
	{
		public CommandedCollectionByKey(CommandDispatcher commandDispatcher)
			: base(commandDispatcher)
		{
		}

		public TValue this[TKey key]
		{
			get => throw new NotImplementedException();
			set
			{
				if (CommandRecording)
				{
					CommandDispatcher.AddAndExecute(CollectionByKeyCommand<TKey, TValue>.Update(this, key, value));
				}
				else
				{
					UpdateForce(key, value);
				}
			}
		}
		protected abstract void UpdateForce(TKey key, TValue value);

		public void Insert(TKey key, TValue value)
		{
			if (CommandRecording)
			{
				CommandDispatcher.AddAndExecute(CollectionByKeyCommand<TKey, TValue>.Insert(this, key, value));
			}
			else
			{
				InsertForce(key, value);
			}
		}
		protected abstract void InsertForce(TKey key, TValue value);

		public void Remove(TKey key)
		{
			if (CommandRecording)
			{
				CommandDispatcher.AddAndExecute(CollectionByKeyCommand<TKey, TValue>.Remove(this, key));
			}
			else
			{
				RemoveForce(key);
			}
		}
		protected abstract void RemoveForce(TKey key);
	}
}
