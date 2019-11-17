﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommandModel
{
	public class CommandedObject : ICommandedObject
	{
		private const string COMMAND_DISPATCHER_NULL_MESSAGE = "Диспетчер команд не может принимать значение null";

		public CommandedObject(CommandDispatcher commandDispatcher)
		{
			CommandDispatcher = commandDispatcher ?? throw new NullReferenceException(COMMAND_DISPATCHER_NULL_MESSAGE);
		}

		public CommandDispatcher CommandDispatcher { get; } = default!;
		public bool CommandRecording { get; private set; } = true;

		public IDisposable Disable()
		{
			return new DisableCommandRecordingToken(this);
		}

		private class DisableCommandRecordingToken : IDisposable
		{
			public DisableCommandRecordingToken(CommandedObject commandedObject)
			{
				CommandedObject = commandedObject;
				if (CommandedObject.CommandRecording)
				{
					CommandedObject.CommandRecording = false;
					isCallback = true;
				}
			}

			public CommandedObject CommandedObject { get; } = default!;

			private readonly bool isCallback = false;

			public void Dispose()
			{
				if (isCallback)
				{
					CommandedObject.CommandRecording = true;
				}
			}
		}
	}
}