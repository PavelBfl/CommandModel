using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandModel
{
	/// <summary>
	/// Диспетчер команд
	/// </summary>
	public class CommandDispatcher
	{
		public CommandDispatcher(IOffsetTokenDispatcher offsetTokenDispatcher)
		{
			OffsetTokenDispatcher = offsetTokenDispatcher;
		}

		/// <summary>
		/// Список выполненых команд
		/// </summary>
		private readonly Stack<TokenCommand> commands = new Stack<TokenCommand>();
		/// <summary>
		/// Список отменёных команд
		/// </summary>
		private readonly Stack<TokenCommand> undoCommands = new Stack<TokenCommand>();

		/// <summary>
		/// Диспетчер токенов сдвига команд
		/// </summary>
		public IOffsetTokenDispatcher OffsetTokenDispatcher { get; } = default!;

		/// <summary>
		/// Сдвинуть команды до указаного токена
		/// </summary>
		/// <param name="token">Токен до которого необходимо сдвинуть команды</param>
		public void Offset(object token)
		{
			switch (OffsetTokenDispatcher.Vector(token))
			{
				case TokenVector.Direct: Offset(token, TokenVector.Direct, undoCommands, commands); break;
				case TokenVector.Revert: Offset(token, TokenVector.Revert, commands, undoCommands); break;
				default: throw new InvalidEnumArgumentException();
			}
		}
		private void Offset(object token, TokenVector tokenVector, Stack<TokenCommand> giver, Stack<TokenCommand> taker)
		{
			while (giver.Any())
			{
				var tokenCommand = giver.Pop();
				switch (tokenVector)
				{
					case TokenVector.Direct: tokenCommand.Command.Execute(); break;
					case TokenVector.Revert: tokenCommand.Command.Undo(); break;
					default: throw new InvalidEnumArgumentException();
				}
				taker.Push(tokenCommand);
				if (tokenCommand.OffsetToken.Equals(token))
				{
					return;
				}
			}
		}

		/// <summary>
		/// Добавить и выполнить команду
		/// </summary>
		/// <param name="command">Команда</param>
		public void AddAndExecute(Command command)
		{
			Add(command);
			command.Execute();
		}
		/// <summary>
		/// Добавить команду
		/// </summary>
		/// <param name="command">Команда</param>
		public void Add(Command command)
		{
			undoCommands.Clear();
			commands.Push(new TokenCommand(command, OffsetTokenDispatcher.CreateToken()));
		}

		private struct TokenCommand
		{
			public TokenCommand(Command command, object offsetToken)
			{
				Command = command;
				OffsetToken = offsetToken;
			}

			public Command Command { get; set; }
			public object OffsetToken { get; set; }
		}
	}
}
