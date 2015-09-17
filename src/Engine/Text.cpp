#include "Text.h"
#include "TextRenderer.h"
#include "Heap.h"

void Text::Draw(Canvas * canvas)
{

	if(needReDraw)
	{
		Redraw();
		needReDraw = false;
	}

	if(texture != nullptr && Visible())
	{
		CalcArea();
	
		canvas->DrawTexture(texture,entityArea,nullptr,rotationAngle);
	}
}

void Text::SetText(std::string text)
{
	if(this->text != text)
	{
		this->text = text;
		needReDraw = true;
		CalcBounds();
	}
}

void Text::SetCharSize(int size)
{
	if(renderOptions.size != size)
	{
		renderOptions.size = size;
		needReDraw = true;
		CalcBounds();
	}
}

void Text::SetCharOffset(int pixels)
{
	if(renderOptions.charOffSet != pixels)
	{
		renderOptions.charOffSet = pixels;
		needReDraw = true;
		CalcBounds();
	}
}

void Text::SetFont(std::string fontPath)
{
	if(renderOptions.fontName != fontPath)
	{
		renderOptions.fontName = fontPath;
		needReDraw = true;
		CalcBounds();
	}
}

void Text::Redraw()
{
	DestroyTexture();

	texture = tMngr->GetTextureFromText(renderOptions,text.c_str());


}

void Text::CalcBounds()
{
	if(renderOptions.fontName != "" && renderOptions.size > 0 && renderOptions.charOffSet >= 1)
	{
			Rect r = TextRenderer::GetPtr()->GetTextBounds(renderOptions,text);
			clipWidth = r.right;
			clipHeight = r.bottom;
	}
	else 
	{
		clipWidth = 40;
		clipHeight = 40;
	}
	
}

void Text::Destroy()
{
	DestroyTexture();
}

void Text::DestroyTexture()
{
	if(texture != nullptr)
	{
		texture->Destroy();
		if(Heap::GetPtr()->Textures.Contains(texture))
		{
			Heap::GetPtr()->Textures.Delete(texture);
		}
		else delete texture;

		texture = nullptr;
			
	}
}

void Text::Init()
{
	Entity::Init();
	needReDraw = true;
	renderOptions.charOffSet = 1;
	renderOptions.size = 16;
	renderOptions.color = Color::White();
}

void Text::SetColor(Color color)
{
	renderOptions.color = color;
	needReDraw = true;
}
