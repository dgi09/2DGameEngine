#pragma once 
#include "Common.h"
#include "Animation.h"

struct EXPORT Animation_Small
{
	PlayStyle playStyle;
	unsigned short startFrame;
	unsigned short endFrame;
};

struct EXPORT __declspec(align(16)) UpdateComponnent
{
	Animation_Small anim;
	unsigned short currentFrame;
	bool playAnim;
	bool animated;
	bool hasCurrent;
};