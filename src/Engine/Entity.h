#pragma once 
#include "Common.h"
#include "Texture.h"
#include "TextureManager.h"
#include "ScreenObject.h"
#include "IDrawable.h"
#include "Canvas.h"
#include "Rect.h"

class EXPORT Entity : public ScreenObject , public IDrawable
{
protected:
	Texture * texture;
	TextureManager * tMngr;
	Rect entityArea;

	UINT clipWidth;
	UINT clipHeight;
public:
	virtual void Init();
	virtual void Destroy();
	void SetTextureManager(TextureManager * tMngr);


	virtual void Draw(Canvas * canvas) = 0;

	Rect GetArea();

protected:
	void CalcArea();
};