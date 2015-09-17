#pragma once 
#include "Common.h"
#include "TextRendererOptions_Port.h"
#include "Bitmap.h"
#include "TextRenderOptions.h"
#include "Rect.h"


extern "C"
{
	EXPORT void _textRendererInit();
	EXPORT void _textRendererDestroy();

	EXPORT Bitmap * _textRendererDrawText(TextRendererOptions_Port opt,const char * text);
	EXPORT Rect  _textRendererGetTextBounds(TextRendererOptions_Port opt,const char * text);
	
	void GetNormalOptions(TextRendererOptions_Port opt,TextRenderOptions & out);
};