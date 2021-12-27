using DMS.CodeGenerator.Base;
using DMS.CodeGenerator.Base.Components;
using DMS.CodeGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.Generators
{
	public abstract class ClassGenerator<TClass, TInterface, TField, TProperty, TMethod, TNamespace, TArgument> 
		where TClass : CodeClass<TClass, TInterface, TField, TProperty, TMethod, TNamespace>, new()
		where TInterface : CodeInterface<TInterface, TProperty, TMethod, TNamespace>, new()
		where TField : CodeField 
		where TProperty : CodeProperty 
		where TMethod : CodeMethod<TArgument>
		where TNamespace : CodeNameSpace
		where TArgument : CodeArgument
	{
		public abstract TClass CreateClass(string name, AccessModifier accessModifier);
		public abstract TInterface CreateInterface(string name);
	}
}
