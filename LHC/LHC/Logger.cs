using System;
using System.Collections.Generic;
using System.IO;

namespace LHC
{
	public enum ErrorLevel { None, Info, Warning, Error };

	public class Logger : IDisposable
	{
		private static Queue<string> messages;
		private static FileStream fs;

		public static bool autoFlush = false;

		// using .txt file extension for windows users
		public static string path = "log.txt";

		static Logger ()
		{
			messages = new Queue<string> ();
			fs = new FileStream (path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
		}

		private static string Build (string message, ErrorLevel x)
		{
			return string.Format ("[{0:HH:mm:ss}]\t{1}\t{2}", DateTime.Now,
			                      Enum.GetName (typeof (ErrorLevel), x).ToUpperInvariant (), message);
		}

		public static void Log (string message, ErrorLevel x = ErrorLevel.Info)
		{
			string msg = Build (message, x);

			messages.Enqueue (msg);
			Console.WriteLine (msg);

			if (autoFlush)
				Flush ();
		}

		public static void Log (string message, ErrorLevel x, params string[] args)
		{
			string msg = Build (string.Format (message, args), x);
			Console.WriteLine (msg);

			if (autoFlush)
				Flush ();
		}

		public static void LogInfo (string message, params string[] args)
		{
			Log (message, ErrorLevel.Info, args);
		}

		public static void LogWarning (string message, params string[] args)
		{
			Log (message, ErrorLevel.Warning, args);
		}

		public static void LogError (string message, params string[] args)
		{
			Log (message, ErrorLevel.Error, args);
		}

		public static void Flush ()
		{
			// Flush to file
			using (StreamWriter sw = new StreamWriter (fs)) {
				for (int i = 0; i < messages.Count; i++)
				{
					sw.WriteLine (messages.Dequeue ());
				}
				sw.Flush ();
			}
			fs.Flush ();
		}

		#region IDisposable implementation
		void IDisposable.Dispose ()
		{
			fs.Dispose ();
		}
		#endregion
	}
}

