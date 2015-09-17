#pragma once 
#include "Common.h"
#include <Windows.h>
#include "Canvas.h"
#include "InputManager.h"

class EXPORT Window 
{
	HWND handle;
	UINT w;
	UINT h;

	bool isOpen;

	Window(LPCWSTR title,UINT width,UINT height);
	Window();

	~Window();

	LPMSG msg;

	Canvas * canvas;
	InputManager input;
	
public:

	static Window * Create(LPCWSTR title,UINT width,UINT height);
	static void  Destroy(Window * window);

	void HandleEvents();

	bool IsOpen();

	Canvas * GetCanves();
	InputManager * GetInputManager();

	void SetTitle(const char * title);
};