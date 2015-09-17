#pragma once 
#include "Common.h"
#include <string>
#include "Color.h"


struct EXPORT TextRenderOptions
{
	std::string fontName;
	Color color;
	unsigned int size;
	unsigned int charOffSet;
};