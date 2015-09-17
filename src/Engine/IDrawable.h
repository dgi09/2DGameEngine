#pragma once 
#include "Common.h"
#include "Canvas.h"


class EXPORT IDrawable 
{
	bool visible;
public:
	virtual void Draw(Canvas * canvas) = 0;
	bool Visible();
	void SetVisible(bool val);
};