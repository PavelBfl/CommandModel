﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandModel.Collections
{
	public class CommandedDictionary<TKey, TValue> : CommandedCollectionByKey<TKey, TValue>, IDictionary<TKey, TValue> where TKey : notnull
	{
		public CommandedDictionary(CommandDispatcher commandDispatcher)
			: base(commandDispatcher)
		{
			
		}

		private readonly Dictionary<TKey, TValue> items = new Dictionary<TKey, TValue>();

		public ICollection<TKey> Keys => ((IDictionary<TKey, TValue>)items).Keys;

		public ICollection<TValue> Values => ((IDictionary<TKey, TValue>)items).Values;

		public int Count => items.Count;

		public bool IsReadOnly => ((IDictionary<TKey, TValue>)items).IsReadOnly;

		protected override TValue GetValue(TKey key)
		{
			return items[key];
		}

		protected override void UpdateForce(TKey key, TValue value)
		{
			items[key] = value;
		}

		protected override void InsertForce(TKey key, TValue value)
		{
			items.Add(key, value);
		}

		protected override void RemoveForce(TKey key)
		{
			items.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return items.ContainsKey(key);
		}

		public void Add(TKey key, TValue value)
		{
			Insert(key, value);
		}

		bool IDictionary<TKey, TValue>.Remove(TKey key)
		{
			var result = ContainsKey(key);
			Remove(key);
			return result;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return items.TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		public void Clear()
		{
			foreach (var key in Keys.ToArray())
			{
				Remove(key);
			}
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return ((IDictionary<TKey, TValue>)items).Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			((IDictionary<TKey, TValue>)items).CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return ((IDictionary<TKey, TValue>)this).Remove(item.Key);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return ((IDictionary<TKey, TValue>)items).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IDictionary<TKey, TValue>)items).GetEnumerator();
		}
	}
}
