using DMS.CodeGenerator.Base;
using DMS.CodeGenerator.Base.Components;
using DMS.CodeGenerator.Common;
using DMS.CodeGenerator.CSharp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.CSharp.Components
{
	public class CSharpMethod : CodeMethod<CSharpArgument>
	{
		private IList<CSharpGenericArgument> _genericArguments;
		public CSharpMethod(AccessModifier accessibility, string name, StringBuilder body, params CSharpArgument[] arguments) : base(accessibility, name, body, arguments)
		{
			_genericArguments = new List<CSharpGenericArgument>();
		}

		public CSharpMethod(AccessModifier accessibility, string name, Type returnType, StringBuilder body, params CSharpArgument[] arguments) : this(accessibility, name, CSharpStringHelper.GetClassName(returnType), body, arguments)
		{
		}

		public CSharpMethod(AccessModifier accessibility, string name, string returnType, StringBuilder body, params CSharpArgument[] arguments) : base(accessibility, name, returnType, body, arguments)
		{
			_genericArguments = new List<CSharpGenericArgument>();
		}

		public override StringBuilder Render()
		{
			StringBuilder sb = new StringBuilder();
			if (Accessibility != AccessModifier.Undefined)
			{
				sb.Append(CSharpStringHelper.GetAccessModifier(Accessibility));
				sb.Append(' ');
			}
			if (IsAbstract)
			{
				sb.Append("abstract ");
			}
			sb.Append(ReturnType);
			sb.Append(' ');

			sb.Append(FullName);
			sb.Append($"({GetRenderedArguments()})");
			if (!IsAbstract)
			{
				sb.AppendLine();
				sb.AppendLine("{");
				sb.Append(Body);
				sb.AppendLine("}");
			}
			else
			{
				sb.Append(";");
			}
			return sb;
		}

		public void AddGenericArguments(params CSharpGenericArgument[] args)
		{
			foreach (var arg in args)
			{
				_genericArguments.Add(arg);
			}
		}

		public string FullName
		{
			get
			{
				return CSharpStringHelper.FormatNameWithGenericArguments(Name, _genericArguments);
			}
		}
	}
}
