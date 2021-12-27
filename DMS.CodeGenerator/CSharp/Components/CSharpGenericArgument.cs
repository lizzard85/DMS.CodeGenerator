using DMS.CodeGenerator.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.CSharp.Components
{
	public class CSharpGenericArgument : CodeComponent
	{
		public CSharpGenericArgument(string name)
		{
			Name = name;
		}

		public string Name { get; }

		public override StringBuilder Render()
		{
			return new StringBuilder(Name);
		}
	}
}
