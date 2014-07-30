using System;
using Mono.Cecil;

namespace LHC
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Large Hadron Compiler\n");
			if (args.Length == 0) {
				BanWitches ();
			}

			for (int i = 0; i < args.Length; i++) {
				switch (args[i])
				{
					case "-i":
					case "--include":
						break;

					case "-e":
					case "--entry":
						break;

					case "-o":
					case "--output":
						break;

					default:
						Console.WriteLine ("Unrecognized argument: \'{0}\'", args[i]);
						BanWitches ();
						break;
				}
			}
		}

		public static void BanWitches ()
		{
			Console.WriteLine ("Usage: lhc -i kernel.dll [-i witch.dll] -e Kernel.Kernel.Main -o kernel.iso\n");
			Console.WriteLine ("{0}\t\t{1}\t\t{2}", "Simple", "Not so simple", "Description");
			Console.WriteLine ("".PadLeft (Console.WindowWidth, '-'));
			Console.WriteLine ("{0}\t\t{1}\t\t{2}", "-i", "--include", "Include DLL");
			Console.WriteLine ("{0}\t\t{1}\t\t{2}", "-e", "--entry  ", "Main entry point");
			Console.WriteLine ("{0}\t\t{1}\t\t{2}", "-o", "--output ", "Output file");
			Console.WriteLine ("".PadLeft (Console.WindowWidth, '-'));
			Console.WriteLine ("\nNote: The first DLL to include must be the kernel!");
			Environment.Exit (0);
		}
	}
}
