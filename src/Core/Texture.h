#pragma once 
#include "Common.h"
#include <d3d11.h>
#include "Bitmap.h"

class EXPORT Texture 
{
	ID3D11Texture2D * texture;
	ID3D11ShaderResourceView * view;

	ID3D11Device * device;

	unsigned short width;
	unsigned short height;

public:


	void Create(ID3D11Device * device);
	void Destroy();

	ID3D11ShaderResourceView * GetView();

	void InitFromFile(const char * fileName);
	void InitFromBitmap(Bitmap * bMap);

	unsigned short GetWidth();
	unsigned short GetHeight();

};