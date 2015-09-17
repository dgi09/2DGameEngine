#pragma once 
#include "Script.h"

class EXPORT ScriptBinding
{
public:
	static void BindEntryScript(Script & script);
	static void BindScreenScript(Script & script);

	static int heap_setTextures(lua_State * s);
	static int heap_setSprites(lua_State * s);
	static int heap_setTexts(lua_State * s);

	static int createScreen(lua_State * s);
	static int setCurrentScreen(lua_State * s);

	static int addTextureToCurrentScene(lua_State * s);
	static int setScreenBackColor(lua_State * s);

	//input
	static int keyPressed(lua_State * s);

	//entity
	static int entity_setPosition(lua_State * s);
	static int entity_move(lua_State * s);
	static int entity_setRotation(lua_State * s);
	static int entity_rotate(lua_State * s);

	//sprite
	static int addSprite(lua_State * s);
	static int addSpriteFromLibrary(lua_State * s);
	static int removeSprite(lua_State * s);

	static int sprite_loadTextureFromFile(lua_State * s);
	static int sprite_animated(lua_State * s);
	static int sprite_setFrameSize(lua_State * s);
	static int sprite_setCurrentAnimation(lua_State * s);
	static int sprite_addAnimation(lua_State * s);
	static int sprite_playCurrentAnimation(lua_State * s);
	static int sprite_stopCurrentAnimation(lua_State * s);
	

	//text 

	static int addText(lua_State * s);
	static int removeText(lua_State * s);
	static int text_setText(lua_State * s);
	static int text_setColor(lua_State * s);
	static int text_setFont(lua_State * s);
	static int text_setSize(lua_State * s);

	// library sprite

	static int addLibrarySprite(lua_State * s);
	static int lSprite_setPosition(lua_State * s);
	static int lSprite_setTexturePath(lua_State * s);
	static int lSprite_animated(lua_State * s);
	static int lSprite_setFrameSize(lua_State * s);
	static int lSprite_addAnimation(lua_State * s);
};