using DMS.CodeGenerator.Base.Components;
using DMS.CodeGenerator.Collections;
using DMS.CodeGenerator.Common;
using DMS.CodeGenerator.CSharp.Helpers;
using System.Text;

namespace DMS.CodeGenerator.CSharp.Components
{
	public class CSharpMethod : CodeMethod<CSharpArgument>
	{
		private ComponentCollection<CSharpGenericArgument> _genericArguments = new ComponentCollection<CSharpGenericArgument>();
		public CSharpMethod(AccessModifier accessibility, string name, StringBuilder body, params CSharpArgument[] arguments) : base(accessibility, name, body, arguments)
		{
		}

		public CSharpMethod(AccessModifier accessibility, string name, Type returnType, StringBuilder body, params CSharpArgument[] arguments) : this(accessibility, name, CSharpStringHelper.GetClassName(returnType), body, arguments)
		{
		}

		public CSharpMethod(AccessModifier accessibility, string name, string returnType, StringBuilder body, params CSharpArgument[] arguments) : base(accessibility, name, returnType, body, arguments)
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
			if (IsAbstract)
			{
				sb.Append("abstract ");
			}
			else if (IsOverride)
			{
				sb.Append("override ");
			}
			sb.Append(ReturnType);
			sb.Append(' ');

			sb.Append(FullName);
			sb.Append($"({GetRenderedArguments()})");

			var genericConstraints = string.Join(" ", _genericArguments.Where(ga => ga.HasConstraint).Select(ga => $"where {ga.Name} : {ga.Constraint}")).Trim();
			if (!string.IsNullOrEmpty(genericConstraints))
			{
				sb.Append(" ").Append(genericConstraints);
			}

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

		public override string UniqueIdentifier
		{
			get
			{
				StringBuilder sb = new StringBuilder(Name);
				if (_genericArguments.Count > 0)
				{
					sb.Append('_');
					sb.Append(string.Join("_", _genericArguments.Select(a => a.Name)));
				}
				if (Arguments.Count > 0)
				{
					sb.Append('_');
					sb.Append(string.Join("_", Arguments.Select(a => a.Type)));
				}
				return $"{Name}";
			}
		}
	}
}
