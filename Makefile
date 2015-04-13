MONO_ARCH = $(shell file -b $$(which mono) | awk '/executable/{print $$NF}')
XM_PREFIX = /Library/Frameworks/Xamarin.Mac.framework/Versions/Current
XM_ASSEMBLY = $(XM_PREFIX)/lib/$(MONO_ARCH)/full/Xamarin.Mac.dll

.PHONY: all check-xm bind clean run

all: check-xm SampleApp.exe

check-xm:
	@if [ ! -d $(XM_PREFIX) ]; then \
		echo "Xamarin.Mac is not installed"; \
		exit 1; \
	fi

bind:
	sharpie bind -namespace BufferCopyExample -scope . BufferApi.h && mv ApiDefinitions.cs BufferApi.cs

libbuffer.dylib: BufferApi.m BufferApi.h
	clang -o $@ -dynamiclib -arch $(MONO_ARCH) $< -xobjective-c -fmodules -Wall

BufferApi.dll: BufferApi.cs libbuffer.dylib
	$(XM_PREFIX)/bin/bmac -new-style -baselib $(XM_ASSEMBLY) $< -x BufferApi_additions.cs -o $@

SampleApp.exe: BufferApi.dll SampleApp.cs
	cp $(XM_ASSEMBLY) $(XM_PREFIX)/lib/libxammac.dylib .
	mcs -out:$@ -r:Xamarin.Mac.dll -r:BufferApi.dll SampleApp.cs

clean:
	rm -f libbuffer.dylib BufferApi.dll Xamarin.Mac.dll SampleApp.exe libxammac.dylib

run: SampleApp.exe
	mono SampleApp.exe
