#pragma once
#include "Common.h"
#include "Entity.h"
#include <string>
#include "TextRenderOptions.h"

class EXPORT Text : public Entity
{
	std::string text;
	TextRenderOptions renderOptions;

	bool needReDraw;
public:

	void Init();
	void Destroy();
	void Draw(Canvas * canvas);

	void SetText(std::string text);
	void SetCharSize(int size);
	void SetCharOffset(int pixels);
	void SetFont(std::string fontPath);
	void SetColor(Color color);

private:
	void Redraw();
	void CalcBounds();
	void DestroyTexture();

};


