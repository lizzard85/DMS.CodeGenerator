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
		public CSharpField(AccessModifier accessibility, Type type, string name, string? value = null) : base(accessibility, type, name, value)
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
			if(!string.IsNullOrWhiteSpace(Value))
			{
				sb.Append(" = ");
				sb.Append(Value);
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

		public CSharpField(AccessModifier accessibility, string name, string? value = null) : base(accessibility, typeof(T), name, value)
		{
		}
	}
}
