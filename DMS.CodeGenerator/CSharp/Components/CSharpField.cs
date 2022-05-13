using DMS.CodeGenerator.Base.Components;
using DMS.CodeGenerator.Common;
using DMS.CodeGenerator.CSharp.Helpers;
using System.Text;

namespace DMS.CodeGenerator.CSharp.Components
{
	public class CSharpField : CodeField
	{
		public CSharpField(AccessModifier accessibility, Type type, string name) : base(accessibility, CSharpStringHelper.GetClassName(type), name, null)
		{
		}
		public CSharpField(AccessModifier accessibility, Type type, string name, string? value = null) : base(accessibility, CSharpStringHelper.GetClassName(type), name, value)
		{
		}

		public CSharpField(AccessModifier accessibility, string type, string name, string? value = null) : base(accessibility, type, name, value)
		{
		}

		public override string UniqueIdentifier => Name;

		public override StringBuilder Render()
		{
			StringBuilder sb = new StringBuilder();
			if (Accessibility != AccessModifier.Undefined)
			{
				sb.Append(CSharpStringHelper.GetAccessModifier(Accessibility));
				sb.Append(' ');
			}
			sb.Append(DataType);
			sb.Append(' ');
			sb.Append(Name);
			if (!string.IsNullOrWhiteSpace(Value))
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
