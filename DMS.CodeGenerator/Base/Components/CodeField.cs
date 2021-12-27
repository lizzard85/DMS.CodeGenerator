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
		internal protected string? Value { get; }

		protected CodeField(AccessModifier accessibility, Type type, string name, string? value = null)
		{
			Accessibility = accessibility;
			Name = name;
			DataType = type;
			Value = value;
		}

	}
}
