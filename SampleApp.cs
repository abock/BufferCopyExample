using System;
using System.IO;
using System.Text;

using ObjCRuntime;
using AppKit;

using BufferCopyExample;

static class SampleApp
{
	static void Main ()
	{
		Dlfcn.dlopen (Path.Combine (
			Path.GetDirectoryName (typeof (MagicBuffer).Assembly.Location),
			"libbuffer.dylib"), 0);
		NSApplication.Init ();

		var buffer = new MagicBuffer ();

		var bytes = new byte [1000];
		Console.WriteLine ("Read {0} bytes:", buffer.Read (bytes));
		foreach (var b in bytes)
			Console.WriteLine ("  read: {0}", b);

		bytes = Encoding.UTF8.GetBytes ("hello world");
		buffer.Write (bytes);
	}
}
