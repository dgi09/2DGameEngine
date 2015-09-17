#pragma once 
#include "Common.h"

class Texture;

struct __declspec(align(16)) DrawComponent
{
	short x,y;
	short w,h;
	Texture * texture;
	short rotation;
};