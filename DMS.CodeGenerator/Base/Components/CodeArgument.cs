using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.Base.Components
{
	public abstract class CodeArgument : CodeComponent
	{
		protected CodeArgument(string type, string name, string? defaultValue = null)
		{
			Type = type;
			Name = name;
			DefaultValue = defaultValue;
		}

		public string Type { get; }
		public string Name { get; }
		public string? DefaultValue { get; }
	}
}
