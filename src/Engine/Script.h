#pragma once 
#include "Common.h"

extern "C"
{
#include "lua.h"
#include "lualib.h"
#include "lauxlib.h"
};




class EXPORT Script 
{
	lua_State * state;
public:
	Script();
	~Script();

	void LoadFile(const char * fileName);
	void Execute();
	void ExecuteFunction(const char * functionName);
	void BindFunction(const char * functioName,int (*func)(lua_State *state));
};