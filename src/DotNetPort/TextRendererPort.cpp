#include "TextRendererPort.h"
#include "TextRenderer.h"

void _textRendererInit()
{
	TextRenderer::GetPtr()->Init();
}

void _textRendererDestroy()
{
	TextRenderer::Destroy();
}

Bitmap * _textRendererDrawText(TextRendererOptions_Port opt,const char * text)
{
	TextRenderOptions o;
	GetNormalOptions(opt,o);
	return TextRenderer::GetPtr()->RenderText(o,text);
}

Rect  _textRendererGetTextBounds(TextRendererOptions_Port opt,const char * text)
{
	TextRenderOptions o;
	GetNormalOptions(opt,o);
	return TextRenderer::GetPtr()->GetTextBounds(o,text);
}

void GetNormalOptions(TextRendererOptions_Port opt,TextRenderOptions & out)
{
	out.charOffSet = opt.charOffSet;
	out.fontName = opt.fontName;
	out.size = opt.size;
	out.color.a = 1.0f;
	out.color.r = (float)opt.r / 255.0f;
	out.color.g = (float)opt.g / 255.0f;
	out.color.b = (float)opt.b / 255.0f;

}