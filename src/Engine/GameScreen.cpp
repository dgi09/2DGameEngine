#include "GameScreen.h"
#include "ScriptBinding.h"
#include "Heap.h"
GameScreen::GameScreen(Canvas * canvas)
{
	tMngr = TextureManager(canvas->GetDevice());

	scene.Init(canvas,&tMngr);
	this->canvas = canvas;

	ScriptBinding::BindScreenScript(script);

	script.LoadFile("../Scripts/Libs/sprite.lua");
	script.Execute();

	script.LoadFile("../Scripts/Libs/input.lua");
	script.Execute();

	script.LoadFile("../Scripts/Libs/text.lua");
	script.Execute();

	script.LoadFile("../Scripts/Libs/librarySprite.lua");
	script.Execute();
}

GameScreen::GameScreen()
{

}

GameScreen::~GameScreen()
{
	Clear();
}


void GameScreen::Update()
{
	script.ExecuteFunction("logic");
	scene.Update();
}

void GameScreen::Draw()
{
	canvas->Clear();
	scene.Draw();
}

void GameScreen::SetName(std::string name)
{
	this->name = name;
}

std::string GameScreen::GetName()
{
	return name;
}

Scene * GameScreen::GetScene()
{
	return &scene;
}

void GameScreen::Clear()
{
	tMngr.ClearPool();
	scene.Destroy();

	Heap::GetPtr()->Textures.DeleteAll();
}

void GameScreen::LoadEntryScript(const char * scriptName)
{
	script.LoadFile(scriptName);
	script.Execute();
}

void GameScreen::Init()
{
	script.ExecuteFunction("autogen_init");
	script.ExecuteFunction("init");


	canvas->SetClearColor(backGroundColor);
}

void GameScreen::SetCanvas(Canvas * canvas)
{
	this->canvas = canvas;
}

void GameScreen::LoadLogicScript(const char * scriptName)
{


	script.LoadFile(scriptName);
	script.Execute();

}

void GameScreen::SetBackgroundColor(Color color)
{
	backGroundColor = color;
}
