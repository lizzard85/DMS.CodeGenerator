using DMS.CodeGenerator.Base.Components;
using DMS.CodeGenerator.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.Base
{
	public abstract class CodeEntity<TSelf, TInterface, TProperty, TMethod, TNamespace> : CodeComponent
		where TSelf : CodeEntity<TSelf, TInterface, TProperty, TMethod, TNamespace>
		where TInterface : CodeInterface<TInterface, TProperty, TMethod, TNamespace>, new()
		where TProperty : CodeProperty
		where TMethod : CodeComponent
		where TNamespace : CodeNameSpace
	{
		protected readonly ComponentCollection<TProperty> _properties = new ComponentCollection<TProperty>();
		protected readonly ComponentCollection<TMethod> _methods = new ComponentCollection<TMethod>();

		protected CodeEntity()
		{
			_references = new List<TNamespace>();
			ImplementsEntities = new HashSet<string>();
		}

		public TNamespace? NameSpace { get; set; }
		public List<TNamespace> _references;
		public IReadOnlyCollection<TNamespace> References
		{
			get
			{
				return _references;
			}
		}
		public bool IsAbstract { get; set; }
		internal abstract string FileExtension { get; }
		public string EntityName { get; protected set; } = string.Empty;
		public abstract string FullName { get; }
		protected string? ExtendsEntity { get; private set; }
		protected HashSet<string> ImplementsEntities { get; private set; }
		protected IList<TProperty> Properties
		{
			get { return _properties; }
		}

		protected IList<TMethod> Methods
		{
			get { return _methods; }
		}

		public abstract void AddProperty(TProperty property);

		public abstract void AddMethod(TMethod method);

		public void Extends(TSelf entity)
		{
			if (entity != null)
			{
				Extends(entity.FullName);
			}
		}

		public void Extends(string entity)
		{
			ExtendsEntity = entity;
		}

		public void Implements(params TInterface[] interfaces)
		{
			foreach (var item in interfaces)
			{
				ImplementsEntities.Add(item.FullName);
			}
		}

		public void Implements(params string[] interfaces)
		{
			foreach (var item in interfaces)
			{
				ImplementsEntities.Add(item);
			}
		}

		public string FileName
		{
			get
			{
				return $"{EntityName}.{FileExtension.Trim('.')}";
			}
		}

		public void AddReferences(params TNamespace[] namespaces)
		{
			foreach (var ns in namespaces)
			{
				_references.Add(ns);
			}
		}
	}
}
