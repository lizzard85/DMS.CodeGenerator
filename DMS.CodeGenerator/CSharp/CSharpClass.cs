using DMS.CodeGenerator.Base;
using DMS.CodeGenerator.Collections;
using DMS.CodeGenerator.Common;
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
	public class CSharpClass : CodeClass<CSharpClass, CSharpInterface, CSharpField, CSharpProperty, CSharpMethod, CSharpNameSpace>
	{
		internal override string FileExtension => ".cs";
		private int _scopesStarted = 0;
		private IList<CSharpGenericArgument> _genericArguments;

		public override string FullName
		{
			get
			{
				return CSharpStringHelper.FormatNameWithGenericArguments(EntityName, _genericArguments);
			}
		}

		public override string UniqueIdentifier => NameSpace?.Render().ToString() + "." + FullName;

		public CSharpClass() : base()
		{
			_genericArguments = new ComponentCollection<CSharpGenericArgument>();
		}

		public void AddConstructor(CSharpConstructor constructor)
		{
			AddMethod(constructor);
		}

		public void AddGenericArguments(params CSharpGenericArgument[] args)
		{
			foreach (var arg in args)
			{
				_genericArguments.Add(arg);
			}
		}

		#region Rendering
		public override StringBuilder Render()
		{
			CSharpEntityBuilder builder = new CSharpEntityBuilder();

			builder.AppendUsings(References);
			builder.AppendLine();
			builder.AppendNamespace(NameSpace);
			AppendClassDefinition(builder);
			if (Fields.Count > 0)
			{
				AppendFields(builder);
				builder.AppendLine();
			}
			AppendProperties(builder);
			AppendMethods(builder);
			builder.CloseScopes();
			return builder.GetStringBuilder();
		}

		private void AppendClassDefinition(CSharpEntityBuilder builder)
		{
			StringBuilder cb = new StringBuilder();
			if (Accessibility != AccessModifier.Undefined)
			{
				cb.Append(CSharpStringHelper.GetAccessModifier(Accessibility));
				cb.Append(' ');
			}
			if (IsAbstract)
			{
				cb.Append("abstract ");
			}
			cb.Append($"class {FullName}");
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

		private void AppendFields(CSharpEntityBuilder builder)
		{
			foreach (var field in Fields)
			{
				builder.AppendLineWithIndentation(field.Render().ToString());
			}
		}

		private void AppendProperties(CSharpEntityBuilder builder)
		{
			if (Properties != null && Properties.Count > 0)
			{
				foreach (var prop in Properties.OrderBy(p => p.Name))
				{
					builder.AppendLinesWithIndentation(prop.Render().ToString());
					if (prop.BackingField != null)
					{
						builder.AppendLine();
					}
				}

				if (Properties.Last().BackingField == null)
				{
					builder.AppendLine();
				}
			}
		}

		private void AppendMethods(CSharpEntityBuilder builder)
		{
			if (Methods != null && Methods.Count > 0)
			{
				foreach (var method in Methods.OrderBy(m => m.Name))
				{
					var methodBuilder = method.Render().Replace("[Constructor]", EntityName);
					builder.AppendLinesWithIndentation(methodBuilder.ToString());
					builder.AppendLine();
				}
			}
		}

		#endregion
	}
}
