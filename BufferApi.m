#import "BufferApi.h"

@implementation MagicBuffer : NSObject

-(NSUInteger)read:(uint8_t *)buffer length:(NSUInteger)length
{
	for (int i = 0; i < length; i++)
		buffer [i] = (uint8_t)(i % (UINT8_MAX + 1));
	return length;
}

-(NSUInteger)write:(const uint8_t *)buffer length:(NSUInteger)length
{
	printf ("Writing %lu bytes...\n", (unsigned long)length);
	for (int i = 0; i < length; i++)
		printf ("  write: %d\n", buffer [i]);
	return length;
}

@end;
