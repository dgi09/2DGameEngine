#include "BitmapPort.h"

Bitmap * _createBitmap()
{
	Bitmap * b = new Bitmap();
	return b;
}
void _destroyBitmap(Bitmap * bitmap)
{
	if(bitmap != nullptr)
	{
		delete bitmap;
	}
}

void _initBitmap(Bitmap * bitmap,unsigned int width,unsigned int height)
{
	bitmap->Init(width,height);
}

unsigned int _bitmapGetWidth(Bitmap * bitmap)
{
	return bitmap->GetWidth();
}

unsigned int _bitmapGetHeight(Bitmap * bitmap)
{
	return bitmap->GetHeight();
}
unsigned char * _bitmapGetBuffer(Bitmap * bitmap)
{
	return bitmap->GetBuffer();
}