#pragma once 
#include "Common.h"
#include <d3d11.h>
#include "Texture.h"
#include "TexturePool.h"
#include <string>
#include "TextRenderer.h"

class EXPORT TextureManager
{
	ID3D11Device * device;
	TexturePool<std::string> pool;

public:

	TextureManager(ID3D11Device * device);
	TextureManager();
	~TextureManager();

	Texture * GetTextureFromFile(const char * fileName);
	Texture * GetTextureFromText(TextRenderOptions renderOptions,const char * text);

	void AddTexture(const char * fileName);

	void ClearPool();
};