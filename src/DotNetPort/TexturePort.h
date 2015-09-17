#pragma once 
#include "Common.h"
#include "Texture.h"


extern "C"
{
	EXPORT Texture * _createTexture();
	EXPORT void _textureDeviceInit(Texture * t,ID3D11Device * device);

	EXPORT void _textureDestroy(Texture * t);
	EXPORT void _textureInitFromFile(Texture * t,const char * fileName);
	EXPORT void _textureInitFromBitmap(Texture * t,Bitmap * bitmap);
	EXPORT UINT _textureGetWidth(Texture * t);
	EXPORT UINT _textureGetHeight(Texture * t);
};

