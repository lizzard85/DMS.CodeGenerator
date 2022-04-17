using DMS.CodeGenerator.Base;
using DMS.CodeGenerator.Base.Components;
using DMS.CodeGenerator.Collections;
using DMS.CodeGenerator.Common;
using DMS.CodeGenerator.CSharp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.CSharp.Components
{
	public class CSharpProperty : CodeProperty
	{
		private ComponentCollection<CSharpGenericArgument> _genericArguments = new ComponentCollection<CSharpGenericArgument>();
		public CSharpProperty(AccessModifier accessibility, Type type, string name) : this(accessibility, CSharpStringHelper.GetClassName(type), name)
		{

		}
		public CSharpProperty(AccessModifier accessibility, string type, string name) : base(accessibility, type, name)
		{
		}

		public override StringBuilder Render()
		{
			StringBuilder sb = new StringBuilder();
			if (RenderGetter || RenderSetter)
			{
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
				if (!IsAbstract && BackingField != null)
				{
					sb.AppendLine();
					sb.AppendLine("{");
					if (RenderGetter)
					{
						sb.AppendLine(GetGetter());
						sb.AppendLine("{");
						sb.AppendLine($"return {BackingField.Name};");
						sb.AppendLine("}");
					}
					if (RenderSetter)
					{
						sb.AppendLine(GetSetter());
						sb.AppendLine("{");
						sb.AppendLine($"{BackingField.Name} = value;");
						sb.AppendLine("}");
					}
					sb.AppendLine("}");
				}
				else
				{
					sb.Append(' ').Append(GetSimpleGetSet());
				}
			}
			return sb;
		}

		internal string GetSimpleGetSet()
		{
			StringBuilder sb = new StringBuilder();
			if (RenderGetter && RenderSetter)
			{
				sb.Append($"{{ {GetGetter()}; {GetSetter()}; }}");
			}
			else if (RenderGetter)
			{
				sb.Append($"{{ {GetGetter()}; }}");
			}
			else
			{
				sb.Append($"{{ {GetSetter()}; }}");
			}
			return sb.ToString();
		}

		private string GetGetter()
		{
			if (GetterAccessibility != AccessModifier.Undefined)
			{
				return $"{CSharpStringHelper.GetAccessModifier(GetterAccessibility)} get";
			}
			return "get";
		}

		private string GetSetter()
		{
			StringBuilder builder = new StringBuilder();
			if (SetterAccessibility != AccessModifier.Undefined)
			{
				builder.Append($"{CSharpStringHelper.GetAccessModifier(SetterAccessibility)} ");
			}
			if (UseInitSetter)
			{
				builder.Append("init");
			}
			else
			{
				builder.Append("set");
			}
			return builder.ToString();
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
				if (RenderGetter)
				{
					sb.Append("_get");
				}
				if (RenderSetter)
				{
					sb.Append("_set");
				}
				return sb.ToString();
			}
		}

		public bool UseInitSetter { get; set; }
	}
}
