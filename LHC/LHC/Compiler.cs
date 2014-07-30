using System;
using System.IO;
using Mono.Cecil;

namespace LHC
{
	public class Compiler
	{
		private StartParams arguments;

		private string output_asm;

		public Compiler (StartParams args)
		{
			arguments = args;
			output_asm = string.Format ("{0}.asm", args.output);
		}

		public void Start ()
		{
			Logger.LogInfo ("Started compilation process.");

			foreach (string lib in arguments.input) {
				ProcessAssembly (lib);
			}
		}

		private void ProcessAssembly (string lib)
		{
			string filename = Path.GetFileName (lib);

			Logger.LogInfo ("Processing assembly {0}", filename);

			AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly (lib);

			// Find entry point
			// I have no idea why I'm doing this lol
			foreach (TypeDefinition typedef in assembly.MainModule.Types) {
				foreach (MethodDefinition method in typedef.Methods)
				{
					foreach (CustomAttribute attr in method.CustomAttributes)
					{
						string attribute = attr.Constructor.DeclaringType.ToString ();
						if (attribute == "libLHC.Entry")
						{
							Logger.LogInfo ("Found entry point: {0}", method.ToString ());
						}
					}
				}
			}
		}
	}
}

