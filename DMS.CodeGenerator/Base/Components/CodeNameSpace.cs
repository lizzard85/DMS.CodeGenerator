using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.Base.Components
{
	public abstract class CodeNameSpace : CodeComponent
	{
		protected List<string> NameSpaceParts { get; }
		protected abstract char Delimiter { get; }

		protected CodeNameSpace(string ns)
		{
			NameSpaceParts = new List<string>();
			NameSpaceParts.AddRange(ns.Split(Delimiter));
		}
	}
}
