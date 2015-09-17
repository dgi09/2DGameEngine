#include "Input.h"

Input * Input::ptr = nullptr;

Input::Input()
{
	mgr = nullptr;
}

Input::~Input()
{
	mgr = nullptr;
}

Input * Input::GetPtr()
{
	if(ptr == nullptr)
		ptr = new Input;

	return ptr;
}

void Input::SetMgr(InputManager * mgr)
{
	this->mgr = mgr;
}

bool Input::KeyPressed(UINT key)
{
	return mgr->KeyPressed(key);
}


