using DMS.CodeGenerator.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.Esceptions
{
	public class DublicateComponentException : Exception
	{
		internal DublicateComponentException(CodeComponent component) : base("Collection already contains component with the same unique identifier")
		{
			Component = component;
		}

		public CodeComponent Component { get; }
	}
}
