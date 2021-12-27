using DMS.CodeGenerator.Base.Components;
using DMS.CodeGenerator.Collections;
using DMS.CodeGenerator.Common;
using DMS.CodeGenerator.CSharp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.Base
{
	public abstract class CodeClass<TSelf, TInterface, TField, TProperty, TMethod, TNamespace> : CodeEntity<TSelf, TInterface, TProperty, TMethod, TNamespace>
		where TSelf : CodeClass<TSelf, TInterface, TField, TProperty, TMethod, TNamespace>, new()
		where TInterface : CodeInterface<TInterface, TProperty, TMethod, TNamespace>, new()
		where TField : CodeField
		where TProperty : CodeProperty
		where TMethod : CodeComponent
		where TNamespace : CodeNameSpace
	{
		private readonly ComponentCollection<TField> _fields = new ComponentCollection<TField>();

		internal static TSelf Create(string name, AccessModifier accessModifier)
		{
			var cls = new TSelf();
			cls.EntityName = name;
			cls.Accessibility = accessModifier;
			return cls;
		}

		protected IList<TField> Fields
		{
			get { return _fields; }
		}

		protected CodeClass() : base()
		{
		}

		public void AddField(TField field)
		{
			_fields.Add(field);
		}

		public override void AddProperty(TProperty property)
		{
			if (property != null)
			{
				_properties.Add(property);
				if (property.BackingField != null && property.BackingField is TField)
				{
					AddField((TField)property.BackingField);
				}
			}
		}

		public override void AddMethod(TMethod method)
		{
			_methods.Add(method);
		}
	}
}
