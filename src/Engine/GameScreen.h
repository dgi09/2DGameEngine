#pragma once 
#include "Common.h"
#include "Script.h"
#include "Scene.h"
#include "TextureManager.h"
#include <string>
#include "Color.h"


class EXPORT GameScreen 
{
	Scene scene;
	Canvas * canvas;
	TextureManager tMngr;

	Script script;
	std::string name;

	Color backGroundColor;
public:

	GameScreen(Canvas * canvas);
	GameScreen();
	~GameScreen();

	void Init();
	void Clear();
	void Update();
	void Draw();

	void SetName(std::string name);
	std::string GetName();

	Scene * GetScene();

	void LoadEntryScript(const char * scriptName);
	void LoadLogicScript(const char * scriptName);

	void SetCanvas(Canvas * canvas);
	void SetBackgroundColor(Color color);
};