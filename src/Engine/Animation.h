#pragma once 
#include "Common.h"
#include <string>

enum EXPORT PlayStyle
{
	LOOP = 0,
	ONCE 
};

class EXPORT Animation
{
public:
	std::string name;
	PlayStyle playStyle;
	unsigned short startFrame;
	unsigned short endFrame;
};