using CommandModel.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandModel
{
	public class CommandedProperties : ICommandedObject
	{
		public CommandedProperties(CommandDispatcher commandDispatcher)
		{
			properties = new CommandedDictionary<PropertyKey, object?>(commandDispatcher);
		}

		private readonly CommandedDictionary<PropertyKey, object?> properties = null!;

		public bool CommandRecording => properties.CommandRecording;

		public IDisposable Disable()
		{
			return properties.Disable();
		}

		public void SetValue(PropertyKey key, object? value)
		{
			properties[key] = value;
		}
		public object? GetValue(PropertyKey key)
		{
			return properties[key];
		}

		public override bool Equals(object? obj)
		{
			if (obj is CommandedProperties other)
			{
				if (properties.Count != other.properties.Count)
				{
					return false;
				}
				foreach (var pair in properties)
				{
					if (other.properties.TryGetValue(pair.Key, out var value))
					{
						if (!EqualityComparer<object?>.Default.Equals(pair.Value, value))
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		public override int GetHashCode()
		{
			return properties.Aggregate(0, (accumulate, pair) => accumulate ^ pair.Key.GetHashCode() ^ pair.Value?.GetHashCode() ?? 0);
		}
	}
}
