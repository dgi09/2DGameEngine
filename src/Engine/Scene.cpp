#include "Scene.h"
#include "Heap.h"


using namespace std;


void Scene::Init(Canvas * canvans,TextureManager * tManager)
{
	this->canvas = canvans;
	this->tManager = tManager;
}

void Scene::Destroy()
{
	drawables.clear();

	Heap * h = Heap::GetPtr();

	for(Sprite * sprite : sprites)
	{
		h->Sprites.Delete(sprite);
	}


	sprites.clear();

	for(Text * text : texts)
	{
		h->Texts.Delete(text);
	}

	texts.clear();
}

Sprite *  Scene::AddSprite()
{
	Sprite * s = Heap::GetPtr()->Sprites.New();
	s->Init();
	s->SetTextureManager(tManager);

	sprites.push_back(s);
	drawables.push_back(s);
	updateables.push_back(s);


	return s;
}

void Scene::Draw()
{
	for(IDrawable * drawable : drawables)
	{
		drawable->Draw(canvas);
	}
}

void Scene::AddTexture(const char * path)
{
	tManager->AddTexture(path);
}

Text * Scene::AddText()
{
	Text * t = Heap::GetPtr()->Texts.New();
	t->Init();
	t->SetTextureManager(tManager);

	texts.push_back(t);
	drawables.push_back(t);

	return t;
}

void Scene::Update()
{
	for(IUpdateable * ups : updateables)
	{
		ups->Update();
	}
}

void Scene::RemoveSprite(Sprite * sprite)
{
	for(vector<Sprite*>::iterator it = sprites.begin();it != sprites.end();++it)
	{
		if(sprite == *it)
		{
			sprites.erase(it);

			RemoveUpdateable(sprite);
			RemoveDrawable(sprite);

			Heap::GetPtr()->Sprites.Delete(sprite);

			break;
		}
	}


}

void Scene::RemoveText(Text * text)
{
	for(vector<Text*>::iterator it = texts.begin();it != texts.end();++it)
	{
		if(text == *it)
		{
			texts.erase(it);

			
			RemoveDrawable(text);

			Heap::GetPtr()->Texts.Delete(text);

			break;
		}
	}
}

void Scene::RemoveDrawable(IDrawable * drawable)
{
	for(vector<IDrawable*>::iterator it = drawables.begin();it != drawables.end();++it)
	{
		if(drawable == *it)
		{
			drawables.erase(it);

			break;
		}
	}
}

void Scene::RemoveUpdateable(IUpdateable * updateable)
{
	for(vector<IUpdateable*>::iterator it = updateables.begin();it != updateables.end();++it)
	{
		if(updateable == *it)
		{
			updateables.erase(it);

			break;
		}
	}
}

int Scene::AddLibSprite(std::string name)
{
	LibrarySprite lSprite;
	lSprite.name = name;

	lSprites.push_back(lSprite);
	return (int)lSprites.size() - 1;
}

LibrarySprite & Scene::GetLibrarySprite(int index)
{
	return lSprites[index];
}

Sprite * Scene::AddSpriteFromLibrary(std::string name)
{
	for(LibrarySprite & ls : lSprites)
	{
		if(ls.name == name)
		{
			Sprite * s = AddSprite();
			s->SetPosition(ls.x,ls.y);
			s->LoadFromFile(ls.texturePath.c_str());
			s->Animated(ls.animated);

			if(ls.animated)
			{
				s->SetFrameWidth(ls.frameW);
				s->SetFrameHeight(ls.frameH);

				for(Animation anim : ls.animations)
				{
					s->AddAnimation(anim);
				}
			}

			return s;
		}
	}

	return nullptr;
}
