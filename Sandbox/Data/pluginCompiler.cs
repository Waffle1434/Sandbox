using System;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using Microsoft.CSharp;

namespace Sandbox.Data
{
	public class pluginCompiler
	{
		public static H3Tag CompileTagPlugin(string TagPath)
		{
			CSharpCodeProvider myCodeProvider = new CSharpCodeProvider();
			CompilerParameters myCompilerParameters = new CompilerParameters();
			myCompilerParameters.ReferencedAssemblies.Add("System.dll");
			myCompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
			myCompilerParameters.ReferencedAssemblies.Add(Application.StartupPath + "\\Halo3Map.dll");
			myCompilerParameters.GenerateExecutable = false;
			myCompilerParameters.GenerateInMemory = false;
			CompilerResults results = myCodeProvider.CompileAssemblyFromFile(myCompilerParameters, TagPath);
			if (results.Errors.Count > 0)
			{
				foreach (CompilerError CompErr in results.Errors)
				{
					MessageBox.Show("Line number " + CompErr.Line + ", Error Number: " + CompErr.ErrorNumber + ", '" + CompErr.ErrorText + ";" + Environment.NewLine + Environment.NewLine);
				}
				return null;
			}
			H3Tag tag = null;
			Type[] types = results.CompiledAssembly.GetTypes();
			foreach (Type t in types)
			{
				if (t.BaseType == typeof(H3Tag))
				{
					tag = (H3Tag)Activator.CreateInstance(t);
					break;
				}
			}
			return tag;
		}
	}
}
