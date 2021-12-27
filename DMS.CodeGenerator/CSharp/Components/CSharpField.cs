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
	public class CSharpField : CodeField
	{
		public CSharpField(AccessModifier accessibility, Type type, string name) : base(accessibility, type, name, null)
		{
		}
		public CSharpField(AccessModifier accessibility, Type type, string name, object? value, string? rawValue = null) : base(accessibility, type, name, value, rawValue)
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
			sb.Append(CSharpStringHelper.GetClassName(DataType));
			sb.Append(' ');
			sb.Append(Name);
			if(!string.IsNullOrWhiteSpace(RawValue))
			{
				sb.Append(" = ");
				sb.Append(RawValue);
			}
			else if(Value != null)
			{
				sb.Append(" = ");
				sb.Append(CSharpStringHelper.FormatVariable(Value));
			}
			sb.Append(';');
			return sb;
		}
	}

	public class CSharpField<T> : CSharpField
	{
		public CSharpField(AccessModifier accessibility, string name) : base(accessibility, typeof(T), name)
		{
		}

		public CSharpField(AccessModifier accessibility, string name, T value, string? rawValue = null) : base(accessibility, typeof(T), name, value, rawValue)
		{
		}
	}
}
