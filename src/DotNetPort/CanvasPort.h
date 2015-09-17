#pragma once 
#include "Common.h"
#include "Canvas.h"


extern "C"
{
	EXPORT Canvas * _createCanvas(HWND handle,UINT widht,UINT height);
	EXPORT void _destroyCanvas(Canvas * canvas);
	EXPORT void _canvasSetClearColor(Canvas * canvas,UINT r,UINT g,UINT b);
	EXPORT void _canvasClear(Canvas * canvas);
	EXPORT void _canvasPresent(Canvas * canvas);
	EXPORT void _canvasDrawTextureFull(Canvas * canvas , 
								   Texture * texture,
								   Rect destRect,
								   int rotationAngle
								   );
	EXPORT void _canvasDrawTexturePart(Canvas * canvas,
									   Texture * texture,
									   Rect dstRect,
									   Rect srcRect,
										int rotationAngle);

	EXPORT void _canvasDrawRect(Canvas * canvas,Rect rect,UINT r,UINT g,UINT b);

	EXPORT ID3D11Device * _canvasGetDevice(Canvas * canvas);
};