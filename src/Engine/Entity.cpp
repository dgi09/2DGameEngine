#include "Entity.h"

void Entity::Destroy()
{

}

Rect Entity::GetArea()
{
	CalcArea();

	return entityArea;
}

void Entity::CalcArea()
{
	entityArea.left = x;
	entityArea.top = y;
	entityArea.right = x + clipWidth;
	entityArea.bottom = y + clipHeight;
}

void Entity::Init()
{
	texture = nullptr;
	SetPosition(0,0);
	SetRotation(0);
	clipWidth = clipHeight = 0;
	SetVisible(true);
}

void Entity::SetTextureManager(TextureManager * tMngr)
{
	this->tMngr = tMngr;
}

