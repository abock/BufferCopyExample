@import Foundation;

@interface MagicBuffer : NSObject
-(NSUInteger)read:(uint8_t *)buffer length:(NSUInteger)length;
-(NSUInteger)write:(const uint8_t *)buffer length:(NSUInteger)length;
@end;
