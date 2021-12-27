using DMS.CodeGenerator.Base.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.CSharp.Components
{
	public class CSharpNameSpace : CodeNameSpace
	{
		public CSharpNameSpace(string ns) : base(ns)
		{
		}

		protected override char Delimiter => '.';

		public override StringBuilder Render()
		{
			return new StringBuilder(string.Join(Delimiter, NameSpaceParts));
		}
	}
}
