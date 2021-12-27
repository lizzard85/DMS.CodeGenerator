using DMS.CodeGenerator.CSharp.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.CodeGenerator.CSharp.Builders
{
	internal class CSharpEntityBuilder
	{
		private StringBuilder _builder;
		private int _scopesStarted = 0;

		internal CSharpEntityBuilder()
		{
			_builder = new StringBuilder();
		}

		public StringBuilder GetStringBuilder()
		{
			return _builder;
		}

		internal void AppendUsings(IReadOnlyCollection<CSharpNameSpace> namespaces)
		{
			foreach (var ns in namespaces.Select(n => n.Render().ToString()).ToHashSet().OrderBy(n => n))
			{
				var nsBuilder = new StringBuilder();
				nsBuilder.Append("using ").Append(ns).AppendLine(";");
				AppendLineWithIndentation(nsBuilder.ToString());
			}
		}

		internal void AppendNamespace(CSharpNameSpace? ns)
		{
			if (ns != null)
			{
				AppendLineWithIndentation($"namespace {ns.Render()}");
				AppendScopeStart();
			}
		}

		internal void AppendLine()
		{
			_builder.AppendLine();
		}

		internal void AppendScopeStart()
		{
			AppendLineWithIndentation("{");
			_scopesStarted++;
		}

		internal void AppendScopeEnd()
		{
			_scopesStarted--;
			AppendLineWithIndentation("}");
		}

		internal void CloseScopes()
		{
			while (_scopesStarted > 0)
			{
				AppendScopeEnd();
			}
		}

		internal void AppendLineWithIndentation(string value)
		{
			string indentation = string.Join("", Enumerable.Range(0, _scopesStarted).Select(x => '\t'));
			_builder.Append(indentation).AppendLine(value.Trim().TrimStart('\t'));
		}

		internal void AppendLinesWithIndentation(string value)
		{
			string[] lines = value.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			foreach (var line in lines)
			{
				var trimmed = line.Trim().TrimStart('\t');
				if (trimmed == "{")
				{
					AppendScopeStart();
				}
				else if (trimmed == "}")
				{
					AppendScopeEnd();
				}
				else
				{
					AppendLineWithIndentation(line);
				}
			}
		}
	}
}
