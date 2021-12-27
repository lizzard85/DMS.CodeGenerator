using DMS.CodeGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.Base
{
	public abstract class CodeComponent
	{
		public AccessModifier Accessibility { get; set; }

		public abstract StringBuilder Render();
	}
}
