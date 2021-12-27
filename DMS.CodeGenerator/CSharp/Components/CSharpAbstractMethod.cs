using DMS.CodeGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.CSharp.Components
{
	public class CSharpAbstractMethod : CSharpMethod
	{
		public CSharpAbstractMethod(AccessModifier accessibility, string name) : base(accessibility, name, new StringBuilder())
		{
			IsAbstract = true;
		}

		public CSharpAbstractMethod(AccessModifier accessibility, string name, Type returnType) : base(accessibility, name, returnType, new StringBuilder())
		{
			IsAbstract = true;
		}

		public CSharpAbstractMethod(AccessModifier accessibility, string name, string returnType) : base(accessibility, name, returnType, new StringBuilder())
		{
			IsAbstract = true;
		}
	}
}
