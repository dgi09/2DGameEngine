#include "Script.h"
#include <iostream>
Script::Script()
{
	state = lua_open();
	luaL_openlibs(state);
}

Script::~Script()
{
	if(state != nullptr)
		lua_close(state);
}

void Script::LoadFile(const char * fileName)
{

	if(luaL_loadfile(state,fileName) != 0)
		std::cout << lua_tostring(state,-1);
}

void Script::Execute()
{

	if(lua_pcall(state,0,0,0) != 0)
		std::cout << lua_tostring(state,-1);
}

void Script::ExecuteFunction(const char * functionName)
{
	lua_getglobal(state,functionName);

	if(lua_pcall(state,0,0,0) != 0)
		std::cout << lua_tostring(state,-1);
}

void Script::BindFunction(const char * functioName,int (*func)(lua_State *state))
{
	lua_register(state,functioName,func);
}
