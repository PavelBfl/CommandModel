using System;
using System.Collections.Generic;
using System.Text;

namespace CommandModel
{
	public interface ICommandedObject
	{
		bool CommandRecording { get; }

		IDisposable Disable();
	}
}
