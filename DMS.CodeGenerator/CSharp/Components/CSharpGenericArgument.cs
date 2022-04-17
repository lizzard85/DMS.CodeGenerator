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
		public CSharpGenericArgument(string name, string? constraint = null)
		{
			Name = name;
			Constraint = constraint;
		}

		public string Name { get; }
		public string? Constraint { get; }

		public override string UniqueIdentifier => Name;

		public override StringBuilder Render()
		{
			return new StringBuilder(Name);
		}

		public bool HasConstraint => !string.IsNullOrEmpty(Constraint);
		public StringBuilder RenderConstraint()
		{
			StringBuilder result = new StringBuilder();
			result.AppendFormat("where {0} : {1}", Name, Constraint);
			return result;
		}
	}
}
