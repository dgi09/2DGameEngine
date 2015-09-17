#include "TextRenderer.h"
#include <Windows.h>
#include <iostream>
#include FT_GLYPH_H

TextRenderer * TextRenderer::ptr = nullptr;


TextRenderer::TextRenderer()
{

}

TextRenderer::~TextRenderer()
{

}

TextRenderer * TextRenderer::GetPtr()
{
	if(ptr == nullptr)
		ptr = new TextRenderer();

	return ptr;
}

void TextRenderer::Destroy()
{
	if(ptr != nullptr)
		delete ptr;
}

void TextRenderer::Init()
{
	FT_Init_FreeType(&lib);
}

Bitmap * TextRenderer::RenderText(TextRenderOptions options,std::string text)
{
	Name_Font * f = nullptr;
	for(unsigned int i = 0; i < fonts.size();i++)
	{
		if(fonts[i].name == options.fontName)
		{
			f = &fonts[i];
			break;
		}
	}

	if(f == nullptr)
	{
		fonts.push_back(Name_Font());

		f = &fonts[fonts.size()-1];
		f->name = options.fontName;

		FT_New_Face(lib,options.fontName.c_str(),0,&f->font);
	}

	FT_Set_Char_Size(f->font,0,options.size * 64,0,96);

	Bitmap * map = new Bitmap;

	int targetW = 0;
	int targetH = 0;

	int originY = 0;
	int maxUp = 0;
	int maxDown = 0;

	FT_GlyphSlot gl = f->font->glyph;
	for(unsigned int i = 0;i < text.size();i++)
	{
		
		FT_Load_Glyph(f->font,FT_Get_Char_Index(f->font,text[i]),FT_LOAD_RENDER);

		if(text[i] == ' ')
		{
			targetW += gl->metrics.horiAdvance/64;
			continue;
		}
		targetW += gl->metrics.width/64 + options.charOffSet;

		if(maxUp < gl->metrics.horiBearingY)
		{
			maxUp = gl->metrics.horiBearingY;
			originY = gl->metrics.horiBearingY;
		}

		if(maxDown < gl->metrics.height - gl->metrics.horiBearingY)
		{
			maxDown = gl->metrics.height - gl->metrics.horiBearingY;
		}
	}


	targetH = (maxUp + maxDown)/64;
	originY/= 64;


	map->Init(targetW,targetH);

	unsigned char * data = map->GetBuffer();
	ZeroMemory(data,map->GetWidth() * map->GetHeight() * 4);
	int posX = 0;
	int posY;

	for(unsigned int i = 0;i<text.size();i++)
	{
		FT_Load_Glyph(f->font,FT_Get_Char_Index(f->font,text[i]),FT_LOAD_RENDER);
		
		if(text[i] == ' ')
		{
			posX += gl->metrics.horiAdvance/64;
			continue;
		}

		FT_Render_Glyph(gl,FT_RENDER_MODE_NORMAL);

		posY = originY - gl->metrics.horiBearingY/64;

		for(int row = posY,locY = 0;row < posY + gl->bitmap.rows;row++,locY++)
		{
			for(int col = posX,locX = 0;col < posX + gl->bitmap.width;col++,locX++)
			{
				unsigned char * pixel = &data[(targetW * row + col) * 4];

				
				pixel[0] = (char)(int(255 * options.color.r));
				pixel[1] = (char)(int(255 * options.color.g));
				pixel[2] = (char)(int(255 * options.color.b));
				pixel[3] = gl->bitmap.buffer[locY * gl->bitmap.width + locX];
			}
		}

		posX += gl->bitmap.width + options.charOffSet;
	}

	return map;
}

Rect TextRenderer::GetTextBounds(TextRenderOptions options,std::string text)
{

	Name_Font * f = nullptr;
	for(unsigned int i = 0; i < fonts.size();i++)
	{
		if(fonts[i].name == options.fontName)
		{
			f = &fonts[i];
			break;
		}
	}

	if(f == nullptr)
	{
		fonts.push_back(Name_Font());

		f = &fonts[fonts.size()-1];
		f->name = options.fontName;

		FT_New_Face(lib,options.fontName.c_str(),0,&f->font);
	}

	FT_Set_Char_Size(f->font,0,options.size * 64,0,96);


	int targetW = 0;
	int targetH = 0;

	int maxUp = 0;
	int maxDown = 0;

	FT_GlyphSlot gl = f->font->glyph;
	for(unsigned int i = 0;i < text.size();i++)
	{

		FT_Load_Glyph(f->font,FT_Get_Char_Index(f->font,text[i]),FT_LOAD_RENDER);

		if(text[i] == ' ')
		{
			targetW += gl->metrics.horiAdvance/64;
			continue;
		}
		targetW += gl->metrics.width/64 + options.charOffSet;

		if(maxUp < gl->metrics.horiBearingY)
		{
			maxUp = gl->metrics.horiBearingY;
			
		}

		if(maxDown < gl->metrics.height - gl->metrics.horiBearingY)
		{
			maxDown = gl->metrics.height - gl->metrics.horiBearingY;
		}
	}


	targetH = (maxUp + maxDown)/64;


	Rect r;
	r.left = r.top = 0;
	r.right = targetW;
	r.bottom = targetH;

	return r;
}


