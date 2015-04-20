using System;
using System.Text;

using Foundation;
using UIKit;

using BufferCopyExample;

namespace BufferApp
{
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window { get; set; }

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			var buffer = new MagicBuffer ();

			var bytes = new byte [1000];
			Console.WriteLine ("Read {0} bytes:", buffer.Read (bytes));
			foreach (var b in bytes)
				Console.WriteLine ("  read: {0}", b);

			bytes = Encoding.UTF8.GetBytes ("hello world");
			buffer.Write (bytes);

			return true;
		}
	}
}