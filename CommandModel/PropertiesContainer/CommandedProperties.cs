using CommandModel.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandModel.PropertiesContainer
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
	}
}
