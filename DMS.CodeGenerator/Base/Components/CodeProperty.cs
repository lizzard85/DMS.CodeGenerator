using DMS.CodeGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.Base.Components
{
	public abstract class CodeProperty : CodeComponent
	{
		public bool IsAbstract { get; set; }
		public string Name { get; }
		public string ReturnType { get; }
		public CodeField? BackingField { get; set; }

		protected CodeProperty(AccessModifier accessibility, string returnType, string name)
		{
			Accessibility = accessibility;
			Name = name;
			ReturnType = returnType;
		}

		public AccessModifier GetterAccessibility { get; set; } = AccessModifier.Undefined;
		public AccessModifier SetterAccessibility { get; set; } = AccessModifier.Undefined;

		public bool RenderSetter { get; set; } = true;
		public bool RenderGetter { get; set; } = true;
	}
}
