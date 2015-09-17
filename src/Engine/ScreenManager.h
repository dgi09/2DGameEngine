#pragma once 
#include "Common.h"
#include "GameScreen.h"
#include <vector>
#include <string>
#include "Canvas.h"

class EXPORT ScreenManager
{
	std::vector<GameScreen*> screens;

	ScreenManager();
	~ScreenManager();

	GameScreen * currentScreen;
	Canvas * canvas;

	static ScreenManager * ptr;
public:
	static ScreenManager * GetPtr();
	static void Destroy();

	GameScreen * AddScreen(std::string name);

	void SetCurrentScreen(std::string name);

	void DrawCurrentScreen();
	void UpdateCurrentScreen();
	
	void SetCanvas(Canvas * canvas);

	GameScreen * GetCurrentScreen();
};