using DMS.CodeGenerator.Common;
using DMS.CodeGenerator.CSharp;
using DMS.CodeGenerator.CSharp.Components;

namespace DMS.CodeGenerator.Generators
{
	public class CSharpClassGenerator : ClassGenerator<CSharpClass, CSharpInterface, CSharpField, CSharpProperty, CSharpMethod, CSharpNameSpace, CSharpArgument>
	{
		public override CSharpClass CreateClass(string name, AccessModifier accessModifier)
		{
			return CSharpClass.Create(name, accessModifier);
		}

		public override CSharpInterface CreateInterface(string name)
		{
			return CSharpInterface.Create(name);
		}
	}
}
