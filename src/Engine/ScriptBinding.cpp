#include "ScriptBinding.h"
#include "Heap.h"
#include "ScreenManager.h"
#include "GameScreen.h"
#include "Scene.h"
#include "Sprite.h"
#include "Input.h"
#include "Entity.h"
#include "Animation.h"


void ScriptBinding::BindEntryScript(Script & script)
{
	script.BindFunction("SetNumberOfHeapTextures",heap_setTextures);
	script.BindFunction("SetNumberOfHeapSprites",heap_setSprites);
	script.BindFunction("SetNumberOfHeapTexts",heap_setTexts);

	script.BindFunction("CreateScreen",createScreen);
	script.BindFunction("SetCurrentScreen",setCurrentScreen);
}

void ScriptBinding::BindScreenScript(Script & script)
{
	script.BindFunction("AddTexture",addTextureToCurrentScene);
	script.BindFunction("KeyPressed",keyPressed);
	script.BindFunction("SetBackgroundColor",setScreenBackColor);

	script.BindFunction("hidden_addSprite",addSprite);
	script.BindFunction("hidden_addSpriteFromLibrary",addSpriteFromLibrary);
	script.BindFunction("hidden_removeSprite",removeSprite);

	script.BindFunction("hidden_sprite_loadTextureFromFile",sprite_loadTextureFromFile);
	script.BindFunction("hidden_sprite_animated",sprite_animated);
	script.BindFunction("hidden_sprite_setFrameSize",sprite_setFrameSize);
	script.BindFunction("hidden_sprite_addAnimation",sprite_addAnimation);
	script.BindFunction("hidden_sprite_setCurrentAnimation",sprite_setCurrentAnimation);
	script.BindFunction("hidden_sprite_playCurrentAnimation",sprite_playCurrentAnimation);
	script.BindFunction("hidden_sprite_stopCurrentAnimation",sprite_stopCurrentAnimation);

	script.BindFunction("hidden_entity_setPosition",entity_setPosition);
	script.BindFunction("hidden_entity_move",entity_move);
	script.BindFunction("hidden_entity_setRotation",entity_setRotation);
	script.BindFunction("hidden_entity_rotate",entity_rotate);

	script.BindFunction("hidden_addText",addText);
	script.BindFunction("hidden_removeText",removeText);
	script.BindFunction("hidden_text_setText",text_setText);
	script.BindFunction("hidden_text_setColor",text_setColor);
	script.BindFunction("hidden_text_setFont",text_setFont);
	script.BindFunction("hidden_text_setSize",text_setSize);

	script.BindFunction("hidden_addLibrarySprite",addLibrarySprite);
	script.BindFunction("hidden_lSprite_setPosition",lSprite_setPosition);
	script.BindFunction("hidden_lSprite_setTexturePath",lSprite_setTexturePath);
	script.BindFunction("hidden_lSprite_setFrameSize",lSprite_setFrameSize);
	script.BindFunction("hidden_lSprite_animated",lSprite_animated);
	script.BindFunction("hidden_lSprite_addAnimation",lSprite_addAnimation);
}

// Entry API
int ScriptBinding::heap_setTextures(lua_State * s)
{
	unsigned int n = lua_tointeger(s,1);
	Heap::GetPtr()->Textures.Allocate(n);

	return 0;
}

int ScriptBinding::heap_setSprites(lua_State * s)
{
	unsigned int n = lua_tointeger(s,1);
	Heap::GetPtr()->Sprites.Allocate(n);

	Heap::GetPtr()->DrawComponents.Allocate(n);
	Heap::GetPtr()->UpdateComponents.Allocate(n);
	return 0;
}

int ScriptBinding::heap_setTexts(lua_State * s)
{
	unsigned int n = lua_tointeger(s,1);
	Heap::GetPtr()->Texts.Allocate(n);

	return 0;
}




int ScriptBinding::createScreen(lua_State * s)
{
	const char * name = lua_tostring(s,1);
	const char * entryFileName = lua_tostring(s,2);
	const char * logicFileName = lua_tostring(s,3);

	ScreenManager * mgr = ScreenManager::GetPtr();
	GameScreen * screen = mgr->AddScreen(name);
	screen->LoadEntryScript(entryFileName);
	screen->LoadLogicScript(logicFileName);

	return 0;
}

int ScriptBinding::setCurrentScreen(lua_State * s)
{
	const char * name = lua_tostring(s,1);

	ScreenManager::GetPtr()->SetCurrentScreen(name);
	return 0;
}

//////////////////////////////////////////////////////////////////////////


// Screen API

int ScriptBinding::addTextureToCurrentScene(lua_State * s)
{
	const char * path = lua_tostring(s,1);
	Scene * scene = ScreenManager::GetPtr()->GetCurrentScreen()->GetScene();
	scene->AddTexture(path);

	return 0;
}

int ScriptBinding::setScreenBackColor(lua_State * s)
{
	int r = lua_tointeger(s,1);
	int g = lua_tointeger(s,2);
	int b = lua_tointeger(s,3);

	Color c;
	c.a = 1.0f;
	c.r = (float)r / 255.0f;
	c.g = (float)g / 255.0f;
	c.b = (float)b / 255.0f;

	ScreenManager::GetPtr()->GetCurrentScreen()->SetBackgroundColor(c);

	return 0;
}

//Sprite API

int ScriptBinding::addSprite(lua_State * s)
{
	Scene * scene = ScreenManager::GetPtr()->GetCurrentScreen()->GetScene();
	
	Sprite * sprite = scene->AddSprite();

	lua_pushinteger(s,(int)sprite);

	return 1;
}

int ScriptBinding::addSpriteFromLibrary(lua_State * s)
{
	const char * name = lua_tostring(s,1);

	Sprite * sprite = ScreenManager::GetPtr()->GetCurrentScreen()->GetScene()->AddSpriteFromLibrary(name);
	lua_pushinteger(s,(int)sprite);

	return 1;
}

int ScriptBinding::sprite_loadTextureFromFile(lua_State * s)
{
	Sprite * sprite  = (Sprite*)lua_tointeger(s,1);
	const char * fileName = lua_tostring(s,2);

	sprite->LoadFromFile(fileName);

	return 0;
}

int ScriptBinding::removeSprite(lua_State * s)
{
	Sprite * sprite  = (Sprite*)lua_tointeger(s,1);
	ScreenManager::GetPtr()->GetCurrentScreen()->GetScene()->RemoveSprite(sprite);

	return 0;
}

int ScriptBinding::sprite_animated(lua_State * s)
{
	Sprite * sprite  = (Sprite*)lua_tointeger(s,1);
	int val = lua_toboolean(s,2);
	sprite->Animated((bool)lua_toboolean(s,2));

	return 0;
}

int ScriptBinding::sprite_setFrameSize(lua_State * s)
{
	Sprite * sprite  = (Sprite*)lua_tointeger(s,1);
	sprite->SetFrameWidth(lua_tointeger(s,2));
	sprite->SetFrameHeight(lua_tointeger(s,3));

	return 0;
}

int ScriptBinding::sprite_addAnimation(lua_State * s)
{
	Sprite * sprite  = (Sprite*)lua_tointeger(s,1);
	Animation anim;
	anim.name = lua_tostring(s,2);
	anim.playStyle = (PlayStyle)lua_tointeger(s,3);
	anim.startFrame = lua_tointeger(s,4);
	anim.endFrame = lua_tointeger(s,5);

	sprite->AddAnimation(anim);

	return 0;
}

int ScriptBinding::sprite_setCurrentAnimation(lua_State * s)
{
	Sprite * sprite  = (Sprite*)lua_tointeger(s,1);
	sprite->SetCurrentAnimation(lua_tostring(s,2));

	return 0;
}

int ScriptBinding::sprite_playCurrentAnimation(lua_State * s)
{
	Sprite * sprite  = (Sprite*)lua_tointeger(s,1);
	sprite->PlayCurrentAnimation();

	return 0;
}

int ScriptBinding::sprite_stopCurrentAnimation(lua_State * s)
{
	Sprite * sprite  = (Sprite*)lua_tointeger(s,1);
	sprite->StopCurrentAnimation();

	return 0;
}

//////////////////////////////////////////////////////////////////////////

// Entity API
int ScriptBinding::entity_setPosition(lua_State * s)
{
	Entity * entity  = (Entity*)lua_tointeger(s,1);
	int x = lua_tointeger(s,2);
	int y = lua_tointeger(s,3);

	entity->SetPosition(x,y);

	return 0;
}

int ScriptBinding::entity_move(lua_State * s)
{
	Entity * entity  = (Entity*)lua_tointeger(s,1);
	int x = lua_tointeger(s,2);
	int y = lua_tointeger(s,3);

	entity->Move(x,y);

	return 0;
}

int ScriptBinding::entity_setRotation(lua_State * s)
{
	Entity * entity  = (Entity*)lua_tointeger(s,1);
	int rot = lua_tointeger(s,2);

	entity->SetRotation(rot);

	return 0;
}

int ScriptBinding::entity_rotate(lua_State * s)
{
	Entity * entity  = (Entity*)lua_tointeger(s,1);
	int rot = lua_tointeger(s,2);

	entity->Rotate(rot);

	return 0;
}

//////////////////////////////////////////////////////////////////////////


// Text API

int ScriptBinding::addText(lua_State * s)
{
	Scene * scene = ScreenManager::GetPtr()->GetCurrentScreen()->GetScene();

	Text * text = scene->AddText();

	lua_pushinteger(s,(int)text);

	return 1;
}

int ScriptBinding::removeText(lua_State * s)
{
	Scene * scene = ScreenManager::GetPtr()->GetCurrentScreen()->GetScene();
	
	Text * text = (Text*)lua_tointeger(s,1);
	scene->RemoveText(text);

	return 0;
}

int ScriptBinding::text_setText(lua_State * s)
{
	Text * text  = (Text*)lua_tointeger(s,1);
	const char * string = lua_tostring(s,2);

	text->SetText(string);

	return 0;
}

int ScriptBinding::text_setColor(lua_State * s)
{
	Text * text = (Text*)lua_tointeger(s,1);
	Color c;
	c.r = (float)lua_tointeger(s,2)/255.0f;
	c.g = (float)lua_tointeger(s,3)/255.0f;
	c.b = (float)lua_tointeger(s,4)/255.0f;

	text->SetColor(c);

	return 0;
}

int ScriptBinding::text_setFont(lua_State * s)
{
	Text * text  = (Text*)lua_tointeger(s,1);
	const char * string = lua_tostring(s,2);

	text->SetFont(string);

	return 0;
}

int ScriptBinding::text_setSize(lua_State * s)
{
	Text * text  = (Text*)lua_tointeger(s,1);

	text->SetCharSize(lua_tointeger(s,2));

	return 0;
}

//////////////////////////////////////////////////////////////////////////

int ScriptBinding::keyPressed(lua_State * s)
{
	int key = lua_tointeger(s,1);

	bool val = Input::GetPtr()->KeyPressed(key);

	lua_pushboolean(s,(int)val);
	return 1;
}


// Library Sprite API
int ScriptBinding::addLibrarySprite(lua_State * s)
{
	const char * name = lua_tostring(s,1);
	int index = ScreenManager::GetPtr()->GetCurrentScreen()->GetScene()->AddLibSprite(name);

	lua_pushinteger(s,index);

	return 1;
}

int ScriptBinding::lSprite_setPosition(lua_State * s)
{
	int index = lua_tointeger(s,1);
	LibrarySprite & sp = ScreenManager::GetPtr()->GetCurrentScreen()->GetScene()->GetLibrarySprite(index);

	int x = lua_tointeger(s,2);
	int y = lua_tointeger(s,3);

	sp.x = x;
	sp.y = y;

	return 0;
}

int ScriptBinding::lSprite_setTexturePath(lua_State * s)
{
	int index = lua_tointeger(s,1);
	LibrarySprite & sp = ScreenManager::GetPtr()->GetCurrentScreen()->GetScene()->GetLibrarySprite(index);

	sp.texturePath = lua_tostring(s,2);

	return 0;
}

int ScriptBinding::lSprite_animated(lua_State * s)
{
	int index = lua_tointeger(s,1);
	LibrarySprite & sp = ScreenManager::GetPtr()->GetCurrentScreen()->GetScene()->GetLibrarySprite(index);

	sp.animated = (bool)lua_toboolean(s,2);

	return 0;
}

int ScriptBinding::lSprite_setFrameSize(lua_State * s)
{
	int index = lua_tointeger(s,1);
	LibrarySprite & sp = ScreenManager::GetPtr()->GetCurrentScreen()->GetScene()->GetLibrarySprite(index);

	sp.frameW = lua_tointeger(s,2);
	sp.frameH = lua_tointeger(s,3);

	return 0;
}

int ScriptBinding::lSprite_addAnimation(lua_State * s)
{
	int index = lua_tointeger(s,1);
	LibrarySprite & sp = ScreenManager::GetPtr()->GetCurrentScreen()->GetScene()->GetLibrarySprite(index);

	Animation anim;
	anim.name = lua_tostring(s,2);
	anim.playStyle = (PlayStyle)lua_tointeger(s,3);
	anim.startFrame = lua_tointeger(s,4);
	anim.endFrame = lua_tointeger(s,5);

	sp.animations.push_back(anim);

	return 0;
}

















