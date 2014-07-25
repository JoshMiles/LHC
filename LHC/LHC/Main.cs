using System;
using Mono.Cecil;

namespace LHC
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if(args.Length == 0)
			{
				// ^good one
				Console.WriteLine ("Are you fucking retarded?");
			}
			else
			{
				Console.WriteLine ("Starting...");
				
			}

			// stuff
			Mono.Cecil.AssemblyDefinition swag;
			swag.ToString ();
		}
	}
}
