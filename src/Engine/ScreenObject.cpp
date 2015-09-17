#include "ScreenObject.h"


void ScreenObject::SetPosition(int x,int y)
{
	this->x = x;
	this->y = y;
}

void ScreenObject::SetX(int val)
{
	x = val;
}

void ScreenObject::SetY(int val)
{
	y = val;
}

int ScreenObject::GetX()
{
	return x;
}

int ScreenObject::GetY()
{
	return y;
}

void ScreenObject::SetRotation(int angle)
{
	rotationAngle = angle;
}

int ScreenObject::GetRotation(int angle)
{
	return rotationAngle;
}

void ScreenObject::Move(int offSetX,int offSetY)
{
	x += offSetX;
	y += offSetY;
}

void ScreenObject::Rotate(int offsetAngle)
{
	rotationAngle += offsetAngle;
}
