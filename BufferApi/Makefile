CFLAGS = -xobjective-c -fmodules -Wall

.PHONY: all
all: libbuffer.a

libbuffer.iphoneos.a: libbuffer.iphoneos.o
	xcrun -sdk iphoneos libtool -static -o $@ $< -framework Foundation

libbuffer.iphoneos.o: BufferApi.m BufferApi.h
	xcrun -sdk iphoneos clang -c -o $@ $< $(CFLAGS) -arch arm64 -arch armv7 -arch armv7s

libbuffer.iphonesimulator.a: libbuffer.iphonesimulator.o
	xcrun -sdk iphonesimulator libtool -static -o $@ $< -framework Foundation

libbuffer.iphonesimulator.o: BufferApi.m BufferApi.h
	xcrun -sdk iphonesimulator clang -c -o $@ $< $(CFLAGS) -arch x86_64

libbuffer.a: libbuffer.iphoneos.a libbuffer.iphonesimulator.a
	libtool -static -o $@ $+ -framework Foundation

.PHONY: clean
clean:
	rm *.o *.a
