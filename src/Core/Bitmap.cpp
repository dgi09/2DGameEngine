#include "Bitmap.h"

Bitmap::Bitmap()
{
	width = 0;
	height = 0;
	data = nullptr;
}

Bitmap::~Bitmap()
{
	if(data != nullptr)
		delete[] data;
}

unsigned int Bitmap::GetWidth()
{
	return width;
}

unsigned int Bitmap::GetHeight()
{
	return height;
}

unsigned char * Bitmap::GetBuffer()
{
	return data;
}

void Bitmap::Init(unsigned int width,unsigned int height)
{
	this->width = width;
	this->height = height;

	data = new unsigned char[width * height * 4];
}
