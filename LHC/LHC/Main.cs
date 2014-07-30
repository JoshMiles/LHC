using System;
using System.IO;
using System.Collections.Generic;
using Mono.Cecil;

namespace LHC
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args.Length == 0) {
				BanWitches ();
			}

			// Initialize start parameters with default values
			StartParams sp = new StartParams () {
				input = new List<string> (),
				output = "kernel.iso",
				entry = "auto",
				verbose = false,
			};

			// Check for specific arguments
			for (int i = 0; i < args.Length; i++) {
				switch (args[i])
				{
					case "-i":
					case "--include":
						if (args.Length < ++i || !File.Exists (args[i]))
						{
							Console.WriteLine ("Path expected. U mad bro?");
							BanWitches ();
						}
						sp.input.Add (Path.GetFullPath (args[i]));
						break;

					case "-e":
					case "--entry":
						if (args.Length < ++i)
						{
							Console.WriteLine ("String expected. U mad bro?");
							BanWitches ();
						}
						sp.entry = args[i];
						break;

					case "-o":
					case "--output":
						if (args.Length < ++i)
						{
							Console.WriteLine ("Path expected. U mad bro?");
							BanWitches ();
						}
						sp.output = Path.GetFullPath (args[i]);
						break;
					
					case "-v":
					case "--verbose":
						sp.verbose = true;
						break;

					default:
						Console.WriteLine ("Unrecognized argument: \'{0}\'", args[i]);
						BanWitches ();
						break;
				}
			}

			// Let's start..
			Compiler compiler = new Compiler (sp);
			compiler.Start ();
		}

		/// <summary>
		/// Bans the witches.
		/// </summary>
		public static void BanWitches ()
		{
			Console.WriteLine ("Usage: lhc -i kernel.dll [-i witch.dll] -e Kernel.Kernel.Main -o kernel.iso\n");
			Console.WriteLine ("{0}\t\t{1}\t\t{2}", "Simple", "Not so simple", "Description");
			Console.WriteLine ("".PadLeft (Console.WindowWidth, '-'));
			Console.WriteLine ("{0}\t\t{1}\t\t{2}", "-i", "--include", "Include DLL");
			Console.WriteLine ("{0}\t\t{1}\t\t{2}", "-e", "--entry  ", "Main entry point");
			Console.WriteLine ("{0}\t\t{1}\t\t{2}", "-o", "--output ", "Output file");
			Console.WriteLine ("{0}\t\t{1}\t\t{2}", "-v", "--verbose", "Detailled logging");
			Console.WriteLine ("".PadLeft (Console.WindowWidth, '-'));
			Console.WriteLine ("\nNote: The first DLL to include must be the kernel!");
			Environment.Exit (0);
		}
	}
}
