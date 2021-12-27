using DMS.CodeGenerator.Common;
using DMS.CodeGenerator.CSharp.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.CSharp.Helpers
{
	internal static class CSharpStringHelper
	{
		internal static string GetAccessModifier(AccessModifier accessModifier)
		{
			switch (accessModifier)
			{
				case AccessModifier.Private:
				case AccessModifier.Public:
				case AccessModifier.Protected:
				case AccessModifier.Internal:
					return accessModifier.ToString().ToLower();
				case AccessModifier.ProtectedInternal:
					return "protected internal";
				case AccessModifier.PrivateProtected:
					return "private protected";
				default:
					return string.Empty;
			}
		}

		internal static string GetClassName(Type type)
		{
			if (type.IsGenericType)
			{
				var underlyingTypes = type.GetGenericArguments();
				var name = type.Name.Substring(0, type.Name.IndexOf('`'));

				return $"{name}<{string.Join(", ", underlyingTypes.Select(t => GetClassName(t)))}>";
			}
			return GetTypeNameOrAlias(type);
		}

		internal static string FormatVariable(object? value)
		{
			if (value == null)
			{
				return "null";
			}
			var type = value.GetType();
			if (type == typeof(string))
			{
				string strValue = (string)value;
				if (strValue == string.Empty)
					return "string.Empty";

				return $"\"{strValue}\"";
			}
			return value.ToString();
		}

		private static Dictionary<Type, string> _typeAlias = new Dictionary<Type, string>
		{
			{ typeof(bool), "bool" },
			{ typeof(byte), "byte" },
			{ typeof(char), "char" },
			{ typeof(decimal), "decimal" },
			{ typeof(double), "double" },
			{ typeof(float), "float" },
			{ typeof(int), "int" },
			{ typeof(long), "long" },
			{ typeof(object), "object" },
			{ typeof(sbyte), "sbyte" },
			{ typeof(short), "short" },
			{ typeof(string), "string" },
			{ typeof(uint), "uint" },
			{ typeof(ulong), "ulong" },
			{ typeof(void), "void" }
		};

		private static string GetTypeNameOrAlias(Type type)
		{
			if (_typeAlias.TryGetValue(type, out string? alias))
				return alias;

			return type.Name;
		}

		internal static string FormatNameWithGenericArguments(string entityName, IList<CSharpGenericArgument> genericArguments)
		{
			StringBuilder clsName = new StringBuilder(entityName);
			if (genericArguments.Count > 0)
			{
				clsName.Append("<");
				clsName.Append(string.Join(", ", genericArguments.Select(ga => ga.Render().ToString())));
				clsName.Append(">");
			}
			return clsName.ToString();
		}
	}
}
