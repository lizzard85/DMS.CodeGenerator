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
		public CSharpConstructor(AccessModifier accessibility, StringBuilder body) : base(accessibility, "[ConstructorNamePlaceholder]", body)
		{
		}

		public override StringBuilder Render()
		{
			StringBuilder sb = new StringBuilder();
			if (Accessibility != AccessModifier.Undefined)
			{
				sb.Append(CSharpStringHelper.GetAccessModifier(Accessibility));
				sb.Append(' ');
			}
			sb.Append(Name);
			sb.AppendLine("()");
			sb.AppendLine("{");
			sb.Append(Body);
			sb.AppendLine("}");
			return sb;
		}
	}
}
