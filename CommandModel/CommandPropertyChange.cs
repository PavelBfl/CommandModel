using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommandModel
{
	class CommandPropertyChange : CommandTarget<CommandedProperties>
	{
		private const string DEPENDECY_PROPERTY_NULL_MESSAGE = "Ключ свойства не может принимать значение null";

		public CommandPropertyChange(CommandedProperties target, PropertyKey propertyKey, object? oldValue, object? newValue)
			: base(target)
		{
			PropertyKey = propertyKey ?? throw new NullReferenceException(DEPENDECY_PROPERTY_NULL_MESSAGE);
			OldValue = oldValue;
			NewValue = newValue;
		}

		public PropertyKey PropertyKey { get; } = null!;
		public object? OldValue { get; } = null;
		public object? NewValue { get; } = null;

		protected override void ExecuteForce()
		{
			Target.SetValue(PropertyKey, NewValue);
		}

		protected override void UndoForce()
		{
			Target.SetValue(PropertyKey, OldValue);
		}
	}
}
