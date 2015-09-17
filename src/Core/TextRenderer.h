#pragma once 
#include "Common.h"
#include <vector>
#include <string>
#include <ft2build.h>
#include FT_FREETYPE_H
#include "Bitmap.h"
#include "Color.h"
#include "TextRenderOptions.h"
#include "Rect.h"

struct Name_Font 
{
	std::string name;
	FT_Face font;

};

class EXPORT TextRenderer
{
	TextRenderer();
	~TextRenderer();

	static TextRenderer * ptr;

	std::vector<Name_Font> fonts;
	FT_Library lib;
public:

	static TextRenderer * GetPtr();

	static void Destroy();

	void Init();

	Bitmap * RenderText(TextRenderOptions options,std::string text);

	Rect GetTextBounds(TextRenderOptions options,std::string text);
};