#pragma once 
#include "Common.h"

class EXPORT ScreenObject
{
protected:
	int x,y,rotationAngle;
public:
	void SetPosition(int x,int y);
	void SetX(int val);
	void SetY(int val);

	int GetX();
	int GetY();

	void SetRotation(int angle);
	int GetRotation(int angle);

	void Move(int offSetX,int offSetY);
	void Rotate(int offsetAngle);
};