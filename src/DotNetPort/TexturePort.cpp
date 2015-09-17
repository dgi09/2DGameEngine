#include "TexturePort.h"


Texture * _createTexture()
{
	Texture * t = new Texture();
	return t;
}

void _textureDestroy(Texture * t)
{
	if(t != nullptr)
	{
		t->Destroy();
		delete t;
	}
}

void _textureDeviceInit(Texture * t,ID3D11Device * device)
{
	t->Create(device);
}



void _textureInitFromFile(Texture * t,const char * fileName)
{
	t->InitFromFile(fileName);
}

void _textureInitFromBitmap(Texture * t,Bitmap * bitmap)
{
	t->InitFromBitmap(bitmap);
}

UINT _textureGetWidth(Texture * t)
{
	return t->GetWidth();
}

UINT _textureGetHeight(Texture * t)
{
	return t->GetHeight();
}

