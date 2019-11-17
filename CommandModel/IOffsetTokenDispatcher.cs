using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandModel
{
	public enum TokenVector
	{
		None,
		Direct,
		Revert,
	}
	public interface IOffsetTokenDispatcher
	{
		TokenVector Vector(object token);
		object CreateToken();
	}
}
