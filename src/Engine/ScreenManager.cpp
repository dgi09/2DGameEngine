#include "ScreenManager.h"


ScreenManager * ScreenManager::ptr = nullptr;


ScreenManager::ScreenManager()
{
	currentScreen = nullptr;
}

ScreenManager::~ScreenManager()
{
	currentScreen = nullptr;

	for(UINT i = 0; i < screens.size();i++)
	{
		delete screens[i];
	}

	screens.clear();
}

ScreenManager * ScreenManager::GetPtr()
{
	if(ptr == nullptr)
		ptr = new ScreenManager();

	return ptr;
}

void ScreenManager::Destroy()
{
	if(ptr != nullptr)
		delete ptr;
}

GameScreen * ScreenManager::AddScreen(std::string name)
{
	GameScreen * screen = new GameScreen(canvas);
	screen->SetName(name);
	screen->SetCanvas(canvas);

	screens.push_back(screen);

	return screen;
}

void ScreenManager::SetCurrentScreen(std::string name)
{
	GameScreen * found = nullptr;
	for(UINT i = 0; i < screens.size();i++)
	{
		if(screens[i]->GetName() == name)
		{
			found = screens[i];
			break;
		}
	}

	if(found)
	{
		if(currentScreen != nullptr)
			currentScreen->Clear();

		currentScreen = found;
		currentScreen->Init();	
	}
}

void ScreenManager::DrawCurrentScreen()
{
	if(currentScreen != nullptr)
		currentScreen->Draw();
}

void ScreenManager::UpdateCurrentScreen()
{
	if(currentScreen != nullptr)
		currentScreen->Update();
}

void ScreenManager::SetCanvas(Canvas * canvas)
{
	this->canvas = canvas;
}

GameScreen * ScreenManager::GetCurrentScreen()
{
	return currentScreen;
}
