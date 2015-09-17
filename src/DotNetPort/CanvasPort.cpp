#include "CanvasPort.h"


Canvas * _createCanvas(HWND handle,UINT widht,UINT height)
{
	Canvas * c = new Canvas(handle,widht,height);

	return c;
}

void _destroyCanvas(Canvas * canvas)
{
	if(canvas != nullptr)
		delete canvas;
}

void _canvasClear(Canvas * canvas)
{
	canvas->Clear();
}

void _canvasPresent(Canvas * canvas)
{
	canvas->Present();
}

void _canvasSetClearColor(Canvas * canvas,UINT r,UINT g,UINT b)
{
	Color c;
	c.r = (float)r / 255.0f;
	c.g = (float)g / 255.0f;
	c.b = (float)b / 255.0f;
	c.a = 1.0f;

	canvas->SetClearColor(c);
}

void _canvasDrawTextureFull(Canvas * canvas , Texture * texture, Rect destRect, int rotationAngle)
{
	canvas->DrawTexture(texture,destRect,nullptr,rotationAngle);
}

 ID3D11Device * _canvasGetDevice(Canvas * canvas)
{
	return canvas->GetDevice();
}

 void _canvasDrawRect(Canvas * canvas,Rect rect,UINT r,UINT g,UINT b)
 {
	 Color c;
	 c.r = (float)r / 255.0f;
	 c.g = (float)g / 255.0f;
	 c.b = (float)b / 255.0f;
	 c.a = 1.0f;

	 canvas->DrawRect(rect,c);
 }

 void _canvasDrawTexturePart(Canvas * canvas, Texture * texture, Rect dstRect, Rect srcRect, int rotationAngle)
 {
	 canvas->DrawTexture(texture,dstRect,&srcRect,rotationAngle);
 }

