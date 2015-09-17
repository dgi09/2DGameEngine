#include "TextureManager.h"
#include "Heap.h"


TextureManager::TextureManager(ID3D11Device * device)
{
	this->device = device;
}

TextureManager::TextureManager()
{

}

TextureManager::~TextureManager()
{
	device = nullptr;
}

Texture * TextureManager::GetTextureFromFile(const char * fileName)
{
	std::string fn(fileName);

	AddTexture(fileName);

	return pool.Get(fn);

}

void TextureManager::ClearPool()
{
	pool.Clear();
}

void TextureManager::AddTexture(const char * fileName)
{
	std::string fn(fileName);

	if(pool.Exists(fn))
		return;

	Texture * t;
	if(Heap::GetPtr()->Textures.IsFull() == false)
	{
		t = Heap::GetPtr()->Textures.New();
		pool.Add(fn,t);
	}
	else t = new Texture();

	t->Create(device);
	t->InitFromFile(fileName);

}

Texture * TextureManager::GetTextureFromText(TextRenderOptions renderOptions,const char * text)
{

	Bitmap * b = TextRenderer::GetPtr()->RenderText(renderOptions,text);

	if(b == nullptr)
		return nullptr;


	Texture * t;
	if(Heap::GetPtr()->Textures.IsFull() == false)
	{
		t = Heap::GetPtr()->Textures.New();
		
	}
	else t = new Texture();

	t->Create(device);

	t->InitFromBitmap(b);


	return t;
	
}


