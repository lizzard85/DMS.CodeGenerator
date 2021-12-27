using DMS.CodeGenerator.Base.Components;
using DMS.CodeGenerator.CSharp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.CSharp.Components
{
	public class CSharpArgument : CodeArgument
	{
		public CSharpArgument(string type, string name, string? defaultValue = null) : base(type, name, defaultValue)
		{
		}

		public CSharpArgument(Type type, string name, string? defaultValue = null) : base(CSharpStringHelper.GetClassName(type), name, defaultValue)
		{
		}

		public override StringBuilder Render()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append($"{Type} {Name}");
			if(!string.IsNullOrWhiteSpace(DefaultValue))
			{
				sb.Append($" = {DefaultValue}");
			}
			return sb;
		}
	}
}
