using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandModel
{
	public abstract class CommandTarget<T> : Command where T : ICommandedObject
	{
		protected CommandTarget(T target)
		{
			Target = target;
		}

		public T Target { get; } = default!;

		public sealed override void Execute()
		{
			using (Target.Disable())
			{
				ExecuteForce();
			}
		}
		protected abstract void ExecuteForce();
		public sealed override void Undo()
		{
			using (Target.Disable())
			{
				UndoForce();
			}
		}
		protected abstract void UndoForce();
	}
}
