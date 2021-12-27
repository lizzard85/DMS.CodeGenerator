using DMS.CodeGenerator.Base;
using DMS.CodeGenerator.CSharp.Builders;
using DMS.CodeGenerator.CSharp.Components;
using DMS.CodeGenerator.CSharp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.CSharp
{
	public class CSharpInterface : CodeInterface<CSharpInterface, CSharpProperty, CSharpMethod, CSharpNameSpace>
	{
		private IList<CSharpGenericArgument> _genericArguments;
		public CSharpInterface() : base()
		{
			_genericArguments = new List<CSharpGenericArgument>();
		}

		public override string FullName => CSharpStringHelper.FormatNameWithGenericArguments(EntityName, _genericArguments);

		internal override string FileExtension => ".cs";

		public override string UniqueIdentifier => NameSpace?.Render().ToString() + "." + FullName;

		public override void AddMethod(CSharpMethod method)
		{
			_methods.Add(method);
		}

		public override void AddProperty(CSharpProperty property)
		{
			_properties.Add(property);
		}

		public override StringBuilder Render()
		{
			CSharpEntityBuilder builder = new CSharpEntityBuilder();
			builder.AppendUsings(References);
			builder.AppendLine();
			builder.AppendNamespace(NameSpace);
			AppendInterfaceDefinition(builder);
			foreach (var property in _properties)
			{
				builder.AppendLineWithIndentation($"{property.ReturnType} {property.FullName} {property.GetSimpleGetSet()}");
			}

			foreach (var method in _methods)
			{
				builder.AppendLineWithIndentation($"{method.ReturnType} {method.FullName}({method.GetRenderedArguments()})");
			}
			
			builder.CloseScopes();

			return builder.GetStringBuilder();
		}

		private void AppendInterfaceDefinition(CSharpEntityBuilder builder)
		{
			StringBuilder cb = new StringBuilder($"public interface {FullName}");
			if (!string.IsNullOrWhiteSpace(ExtendsEntity))
			{
				cb.Append($" : {ExtendsEntity}");
			}
			if (ImplementsEntities.Count > 0)
			{
				cb.Append(!string.IsNullOrWhiteSpace(ExtendsEntity) ? ", " : " : ");
				cb.Append(string.Join(", ", ImplementsEntities));
			}
			builder.AppendLineWithIndentation(cb.ToString());
			builder.AppendScopeStart();
		}

		public void AddGenericArguments(params CSharpGenericArgument[] args)
		{
			foreach (var arg in args)
			{
				_genericArguments.Add(arg);
			}
		}
	}
}
