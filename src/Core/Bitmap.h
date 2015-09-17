#pragma once 
#include "Common.h"

class EXPORT Bitmap
{
	unsigned int width;
	unsigned int height;
	unsigned char * data;
public:

	Bitmap();
	~Bitmap();

	unsigned int GetWidth();
	unsigned int GetHeight();

	unsigned char * GetBuffer();

	void Init(unsigned int width,unsigned int height);
};