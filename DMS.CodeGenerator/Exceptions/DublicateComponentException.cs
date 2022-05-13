using DMS.CodeGenerator.Base;

namespace DMS.CodeGenerator.Exceptions
{
	public class DublicateComponentException : Exception
	{
		internal DublicateComponentException(CodeComponent component) : base($"Collection already contains component with the same unique identifier {component.UniqueIdentifier}")
		{
			Component = component;
		}

		public CodeComponent Component { get; }
	}
}
