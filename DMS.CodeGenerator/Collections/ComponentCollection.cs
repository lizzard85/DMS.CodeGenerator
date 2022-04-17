using DMS.CodeGenerator.Base;
using DMS.CodeGenerator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.Collections
{
	public class ComponentCollection<T> : List<T> where T : CodeComponent
	{
		private HashSet<string> _keys = new HashSet<string>();

		public new void Add(T component)
		{
			if (!_keys.Contains(component.UniqueIdentifier))
			{
				_keys.Add(component.UniqueIdentifier);
				base.Add(component);
			}
			else
			{
				throw new DublicateComponentException(component);
			}
		}

		public new void Remove(T component)
		{
			_keys.Remove(component.UniqueIdentifier);
			base.Remove(component);
		}

		public new void AddRange(IEnumerable<T> collection)
		{
			foreach (T component in collection)
			{
				Add(component);
			}
		}
	}
}
