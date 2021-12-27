using DMS.CodeGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.Base.Components
{
	public abstract class CodeField : CodeComponent
	{
		internal protected string Name { get; }
		internal protected Type DataType { get; }
		internal protected object? Value { get; }
		internal protected string? RawValue { get; }

		protected CodeField(AccessModifier accessibility, Type type, string name, object? value, string? rawValue = null)
		{
			Accessibility = accessibility;
			Name = name;
			DataType = type;
			Value = value;
			RawValue = rawValue;
		}

	}
}
