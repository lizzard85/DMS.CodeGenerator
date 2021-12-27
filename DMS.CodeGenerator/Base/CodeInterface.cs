using DMS.CodeGenerator.Base.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.Base
{
	public abstract class CodeInterface<TSelf, TProperty, TMethod, TNamespace> : CodeEntity<TSelf, TSelf, TProperty, TMethod, TNamespace>
		where TSelf : CodeInterface<TSelf, TProperty, TMethod, TNamespace>, new()
		where TProperty : CodeProperty
		where TMethod : CodeComponent
		where TNamespace : CodeNameSpace
	{
		protected CodeInterface()
		{
		}

		public string? Name { get; }

		internal static TSelf Create(string name)
		{
			var cls = new TSelf();
			cls.EntityName = name;
			return cls;
		}
	}
}
