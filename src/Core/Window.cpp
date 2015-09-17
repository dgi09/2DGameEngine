#include "Window.h"



LRESULT CALLBACK WinProc(HWND hWindow, UINT msg, WPARAM wParam, LPARAM lParam);


Window::Window(LPCWSTR title,UINT width,UINT height)
{
	WNDCLASSEX win;
	ZeroMemory(&win,sizeof(WNDCLASSEX));
	win.cbClsExtra = 0;
	win.cbWndExtra = 0;
	win.cbSize = sizeof(WNDCLASSEX);
	win.hInstance = GetModuleHandle(NULL);
	win.lpszClassName = L"D3DWindow";
	win.lpfnWndProc = WinProc;
	win.hbrBackground = (HBRUSH)(COLOR_WINDOW+2);



	RegisterClassEx(&win);
	handle = CreateWindowEx(WS_EX_CLIENTEDGE,L"D3DWindow",title,WS_OVERLAPPEDWINDOW,100,100,width,height,NULL
		,NULL,GetModuleHandle(NULL),NULL);

	msg = new MSG;
	isOpen = true;

	canvas = new Canvas(handle,width,height);
	input.Init(handle,GetModuleHandle(NULL));

	ShowWindow(handle,1);
	UpdateWindow(handle);
}

Window::Window()
{

}

Window::~Window()
{
	delete canvas;
}

Window * Window::Create(LPCWSTR title,UINT width,UINT height)
{
	Window * w = new Window(title,width,height);

	return w;
}

void  Window::Destroy(Window * window)
{
	if(window != nullptr)
		delete window;
}

void Window::HandleEvents()
{
	while(PeekMessage(msg, NULL, 0, 0,PM_REMOVE))
	{
		TranslateMessage(msg);
		DispatchMessage(msg);

		if(msg->message == WM_QUIT)
			isOpen = false;
	}

	input.Update();
}

bool Window::IsOpen()
{
	return isOpen;
}

Canvas * Window::GetCanves()
{
	return canvas;
}

InputManager * Window::GetInputManager()
{
	return &input;
}

void Window::SetTitle(const char * title)
{
	SetWindowTextA(handle,title);
}

LRESULT CALLBACK WinProc(HWND hWindow, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_DESTROY:
		PostQuitMessage(0);
	default:
		return DefWindowProc(hWindow,msg,wParam,lParam);
	}

	return 0;
}