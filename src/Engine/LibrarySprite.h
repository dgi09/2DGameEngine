#pragma once 
#include "Common.h"
#include "Animation.h"
#include <vector>
#include <string>

struct EXPORT LibrarySprite
{
	std::string name;
	int x,y;
    std::string texturePath;
	int frameW,frameH;
	bool animated;
	std::vector<Animation> animations;
};