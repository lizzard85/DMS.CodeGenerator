using DMS.CodeGenerator.Common;

namespace DMS.CodeGenerator.Base.Components
{
	public abstract class CodeField : CodeComponent
	{
		internal protected string Name { get; }
		internal protected string DataType { get; }
		internal protected string? Value { get; }

		protected CodeField(AccessModifier accessibility, string type, string name, string? value = null)
		{
			Accessibility = accessibility;
			Name = name;
			DataType = type;
			Value = value;
		}

	}
}
