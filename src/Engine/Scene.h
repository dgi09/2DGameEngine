#pragma once 
#include "Common.h"
#include "Sprite.h"
#include <vector>
#include "TextureManager.h"
#include "Canvas.h"
#include "Text.h"
#include "LibrarySprite.h"


class EXPORT Scene 
{
	std::vector<Sprite*> sprites;
	std::vector<Text*> texts;
	std::vector<IDrawable*> drawables;
	std::vector<IUpdateable*> updateables;
	std::vector<LibrarySprite> lSprites;

	Canvas * canvas;
	TextureManager * tManager;

public:
	
	void Init(Canvas * canvans,TextureManager * tManager);
	void Destroy();

	Sprite * AddSprite();
	Text * AddText();


	int AddLibSprite(std::string name);

	LibrarySprite & GetLibrarySprite(int index);

	Sprite * AddSpriteFromLibrary(std::string name);

	void RemoveSprite(Sprite * sprite);
	void RemoveText(Text * text);

	void AddTexture(const char * path);

	void Draw();
	void Update();

private:
	void RemoveDrawable(IDrawable * drawable);
	void RemoveUpdateable(IUpdateable * updateable);
};