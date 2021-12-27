using DMS.CodeGenerator.Collections;
using DMS.CodeGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.Base.Components
{
	public abstract class CodeMethod<TArgument> : CodeComponent
		where TArgument : CodeArgument
	{
		public string Name { get; }
		public StringBuilder Body { get; }
		public string ReturnType { get; }
		protected ComponentCollection<TArgument> Arguments { get; }
		public bool IsAbstract { get; set; }
		public bool IsOverride { get; set; }
		protected CodeMethod(AccessModifier accessibility, string name, StringBuilder body, params TArgument[] arguments) : this(accessibility, name, "void", body, arguments)
		{
		}

		protected CodeMethod(AccessModifier accessibility, string name, string returnType, StringBuilder body, params TArgument[] arguments)
		{
			Arguments = new ComponentCollection<TArgument>();
			Accessibility = accessibility;
			Name = name;
			Body = body;
			ReturnType = returnType;

			if(arguments != null && arguments.Length > 0)
			{
				AddArguments(arguments);
			}
		}

		public void AddArguments(params TArgument[] args)
		{
			foreach (var arg in args)
			{
				Arguments.Add(arg);
			}
		}

		public string GetRenderedArguments()
		{
			return string.Join(", ", Arguments.Select(a => a.Render().ToString()));
		}
	}
}
