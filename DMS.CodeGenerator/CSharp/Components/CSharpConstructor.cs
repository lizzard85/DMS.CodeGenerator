using DMS.CodeGenerator.Common;
using DMS.CodeGenerator.CSharp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.CSharp.Components
{
	public class CSharpConstructor : CSharpMethod
	{
		public CSharpConstructor(AccessModifier accessibility, StringBuilder body, params CSharpArgument[] arguments) : base(accessibility, "[Constructor]", body, arguments)
		{
		}

		public string? BaseCallArguments { get; set; }

		public override StringBuilder Render()
		{
			StringBuilder sb = new StringBuilder();
			if (Accessibility != AccessModifier.Undefined)
			{
				sb.Append(CSharpStringHelper.GetAccessModifier(Accessibility));
				sb.Append(' ');
			}
			sb.Append(Name);
			sb.Append("(");
			if (Arguments.Count > 0)
			{
				sb.Append(string.Join(", ", Arguments.Select(a => a.Render())));
			}
			sb.Append(")");
			if(!string.IsNullOrWhiteSpace(BaseCallArguments))
			{
				sb.Append($" : base({BaseCallArguments}) ");
			}
			sb.AppendLine();
			sb.AppendLine("{");
			sb.Append(Body);
			sb.AppendLine();
			sb.AppendLine("}");
			return sb;
		}
	}
}
