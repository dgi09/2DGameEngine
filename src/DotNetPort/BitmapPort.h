#pragma once 
#include "Common.h"
#include "Bitmap.h"

extern "C"
{
	EXPORT  Bitmap * _createBitmap();
	EXPORT void _destroyBitmap(Bitmap * bitmap);

	EXPORT void _initBitmap(Bitmap * bitmap,unsigned int width,unsigned int height);
	EXPORT unsigned int _bitmapGetWidth(Bitmap * bitmap);
	EXPORT unsigned int _bitmapGetHeight(Bitmap * bitmap);
	EXPORT unsigned char * _bitmapGetBuffer(Bitmap * bitmap);
};