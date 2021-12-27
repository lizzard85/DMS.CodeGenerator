
using DMS.CodeGenerator.Common;
using DMS.CodeGenerator.CSharp.Components;
using DMS.CodeGenerator.Generators;
using System.Drawing;
using System.Text;

CSharpClassGenerator generator = new CSharpClassGenerator();

var cls = generator.CreateClass("MyList", AccessModifier.Public);
var inface = generator.CreateInterface("MyInterface");

cls.NameSpace = new CSharpNameSpace("DMS.CodeGenerator.TestConsole");
cls.AddReferences(
	new CSharpNameSpace("System"), 
	new CSharpNameSpace("System.Collections.Generic"), 
	new CSharpNameSpace("System.Linq"));
cls.Implements("ICollection<T>", "IReadOnlyCollection<T>");

cls.AddGenericArguments(new CSharpGenericArgument("T"));
cls.Extends("List<T>");

cls.AddConstructor(new CSharpConstructor(AccessModifier.Public, new StringBuilder()));

var addMethodBody = new StringBuilder();
addMethodBody.AppendLine("Add(item);");
addMethodBody.AppendLine("return item;");

var castMethodBody = new StringBuilder();
castMethodBody.AppendLine("return (TCast)this[index];");

var method = new CSharpMethod(AccessModifier.Public, "AddAndReturn", "T", addMethodBody);
method.AddArguments(new CSharpArgument("T", "item"));
cls.AddMethod(method);

var castMethod = new CSharpMethod(AccessModifier.Public, "CastAt", "TCast", castMethodBody);
castMethod.AddArguments(new CSharpArgument(typeof(int), "index"));
castMethod.AddGenericArguments(new CSharpGenericArgument("TCast"));
cls.AddMethod(castMethod);

var prop = new CSharpProperty(AccessModifier.Public, "List<T>", "AllItems");
prop.AddGenericArguments(new CSharpGenericArgument("T"));
cls.AddProperty(prop);
cls.AddMethod(new CSharpAbstractMethod(AccessModifier.Protected, "AbstactTest", "T"));


inface.NameSpace = cls.NameSpace;
inface.AddGenericArguments(new CSharpGenericArgument("T"));
inface.AddReferences(new CSharpNameSpace("System"), new CSharpNameSpace("System.Collections.Generic"));
inface.AddMethod(method);
inface.AddMethod(castMethod);
inface.AddProperty(prop);
inface.Implements("ICollection<T>", "IReadOnlyCollection<T>");


//Console.WriteLine(cls.Render().ToString());

Console.WriteLine(inface.Render().ToString());