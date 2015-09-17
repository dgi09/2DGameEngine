#include "InputManager.h"

InputManager::InputManager()
{
	inputDevice = nullptr;
	keyboard = nullptr;
}

InputManager::~InputManager()
{

	if(keyboard != nullptr)
	{
		keyboard->Unacquire();
		keyboard->Release();
	}

	if(inputDevice != nullptr)
		inputDevice->Release();
}

void InputManager::Init(HWND handle,HINSTANCE hInstance)
{
	DirectInput8Create(hInstance,0x0800,IID_IDirectInput8,(void**)&inputDevice,nullptr);
	inputDevice->CreateDevice(GUID_SysKeyboard, &keyboard, NULL);
	keyboard->SetDataFormat(&c_dfDIKeyboard);
	keyboard->SetCooperativeLevel(handle, DISCL_FOREGROUND | DISCL_EXCLUSIVE);

	keyboard->Acquire();
	//keyboard->GetDeviceState(sizeof(keys),(void**)&keys);
	ZeroMemory(keys,sizeof(keys));
}

void InputManager::Update()
{

	HRESULT res = keyboard->GetDeviceState(sizeof(keys),(void**)&keys);
	if((res == DIERR_INPUTLOST) || (res == DIERR_NOTACQUIRED))
	{
		keyboard->Acquire();
	}
}

bool InputManager::KeyPressed(UINT key)
{
	if(key >= 0 && key <= 256)
	{
		if(keys[key])
			return true;
		else return false;
	}

	return false;
}
