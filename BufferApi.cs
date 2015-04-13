using System;
using Foundation;

namespace BufferCopyExample
{
	// @interface MagicBuffer : NSObject
	[BaseType (typeof(NSObject))]
	interface MagicBuffer
	{
		// -(NSUInteger)read:(uint8_t *)buffer length:(NSUInteger)length;
		[Internal, Export ("read:length:")]
		nuint Read (IntPtr buffer, nuint length);

		// -(NSUInteger)write:(const uint8_t *)buffer length:(NSUInteger)length;
		[Internal, Export ("write:length:")]
		nuint Write (IntPtr buffer, nuint length);
	}
}
