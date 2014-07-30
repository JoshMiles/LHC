using System;
using Mono.Cecil;

namespace LHC
{
	/// <summary>
	/// This exists simply because I wanted to add the Cecil stuff whilst Splitty was working in Main.cs
	/// They should be merged at some point.
	/// </summary>
	public class CecilHandler
	{
		public static void handleDLL(string DLL_file_path, string entry_point)
		{
			AssemblyDefinition assembly_definition = AssemblyDefinition.ReadAssembly(DLL_file_path);
		}
	}
}

