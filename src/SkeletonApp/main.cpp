#include <Windows.h>
#include "Window.h"
#include "Rect.h"
#include "Texture.h"
#include <d3d11.h>
#include "TextureManager.h"
#include "Script.h"
#include "ScriptBinding.h"
#include "ScreenManager.h"
#include "InputManager.h"
#include "Input.h"
#include "TextRenderer.h"
#include "Heap.h"
#include <iostream>
#include <string>

//int WINAPI WinMain( _In_ HINSTANCE hInstance, _In_opt_ HINSTANCE hPrevInstance, _In_ LPSTR lpCmdLine, _In_ int nShowCmd )
int main()
{

	Window * w = Window::Create(L"game",600,600);
	Canvas * c = w->GetCanves();
	InputManager * input = w->GetInputManager();
	Input::GetPtr()->SetMgr(input);

    TextRenderer * tr = TextRenderer::GetPtr();
	tr->Init();

	ScreenManager * mgr = ScreenManager::GetPtr();
	mgr->SetCanvas(c);


	Script entry;
	ScriptBinding::BindEntryScript(entry);
	entry.LoadFile("..\\Scripts\\entry.lua");
	entry.Execute();


	long long time;

	while(w->IsOpen())
	{
		time = GetTickCount();

		w->HandleEvents();
		
		mgr->UpdateCurrentScreen();

		mgr->DrawCurrentScreen();

		c->Present();

		if(GetTickCount() - time < 40)
		{
			Sleep(40 - (GetTickCount() - (DWORD)time));
		}
		

		time = GetTickCount();
	}

	TextRenderer::Destroy();

	Heap::Free();

	Window::Destroy(w);
	return 0;
}