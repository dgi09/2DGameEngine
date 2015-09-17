#pragma once 
#include "Common.h"
#include <Windows.h>
#include <dinput.h>


class EXPORT InputManager
{
	IDirectInput8 * inputDevice;
	IDirectInputDevice8 * keyboard;

	unsigned char keys[256];
public:
	InputManager();
	~InputManager();

	void Init(HWND handle,HINSTANCE hInstance);
	void Update();

	bool KeyPressed(UINT key);
};