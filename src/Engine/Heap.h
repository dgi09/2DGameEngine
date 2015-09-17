#pragma once 
#include "Common.h"
#include "ObjectPool.h"
#include "Texture.h"
#include "Sprite.h"
#include "Text.h"
#include "DrawComonent.h"
#include "UpdateComponent.h"


class EXPORT Heap 
{
	static Heap * ptr;

public:
	
	static Heap * GetPtr();
	static void Free();
	
	ObjectPool<Texture,64> Textures;
	ObjectPool<Sprite,64> Sprites;
	ObjectPool<Text,64> Texts;
	ObjectPool<DrawComponent,64> DrawComponents;
	ObjectPool<UpdateComponnent,64> UpdateComponents;
};