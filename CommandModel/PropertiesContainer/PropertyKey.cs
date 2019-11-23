using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CommandModel.PropertiesContainer
{
	public class PropertyKey : IEquatable<PropertyKey>
	{
		public static PropertyKey Registry<TOwner>(string name, object? initValue = null)
		{
			return new PropertyKey(name, typeof(TOwner), initValue);
		}

		private PropertyKey(string name, Type ownerType, object? initValue)
		{
			Name = name;
			OwnerType = ownerType;
			InitValue = initValue;
		}

		public string Name { get; } = string.Empty;
		public Type OwnerType { get; } = null!;
		public object? InitValue { get; } = null;

		public bool Equals(PropertyKey? other)
		{
			if (other is object)
			{
				return Name == other.Name && OwnerType == other.OwnerType;
			}
			return false;
		}
		public override bool Equals(object? obj)
		{
			return Equals(obj as PropertyKey);
		}
		public override int GetHashCode()
		{
			return Name.GetHashCode() ^ OwnerType.GetHashCode();
		}
	}
}
