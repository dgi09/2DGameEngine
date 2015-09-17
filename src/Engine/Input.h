#pragma once 
#include "Common.h"
#include "InputManager.h"

class EXPORT Input 
{
	InputManager * mgr;

	Input();
	~Input();

	static Input * ptr;
public:

	static Input * GetPtr();

	void SetMgr(InputManager * mgr);

	bool KeyPressed(UINT key);
	
};