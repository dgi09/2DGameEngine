#include "Sprite.h"
#include "Canvas.h"
#include "TextureManager.h"
#include "Heap.h"


void Sprite::Init()
{
	Entity::Init();

	frameBounds.left = frameBounds.top = 0;

	drawComponent = Heap::GetPtr()->DrawComponents.New();
	drawComponent->rotation = 0;

	upComponent = Heap::GetPtr()->UpdateComponents.New();
	upComponent->hasCurrent = false;
	upComponent->currentFrame = 0;
	upComponent->playAnim = false;
	upComponent->animated = false;

}

void Sprite::Destroy()
{
	if(!Heap::GetPtr()->Textures.Contains(texture))
	{
		texture->Destroy();
		delete texture;
	}
}

void Sprite::Draw(Canvas * canvas)
{
	if(drawComponent->texture != nullptr)
	{
		drawComponent->x = GetX();
		drawComponent->y = GetY();
		if(IsAnimated())
		{
			frameBounds.right = frameBounds.left + frameWidth;
			frameBounds.bottom = frameBounds.top + frameHeight;

			Rect r;
			r.left = drawComponent->x;
			r.top = drawComponent->y;
			r.right = drawComponent->x + clipWidth;
			r.bottom = drawComponent->y + clipHeight;

			canvas->DrawTexture(texture,r,&frameBounds,rotationAngle);
		}
		else 
		{
			Rect r;
			r.left = drawComponent->x;
			r.top = drawComponent->y;
			r.right = drawComponent->x + drawComponent->w;
			r.bottom = drawComponent->y + drawComponent->h;

			canvas->DrawTexture(drawComponent->texture,r,nullptr,drawComponent->rotation);
		}
	}
	
}

void Sprite::LoadFromFile(const char * fileName)
{
	texture = tMngr->GetTextureFromFile(fileName);
	drawComponent->texture = texture;

	if(IsAnimated() == false)
	{
		clipWidth = texture->GetWidth();
		clipHeight = texture->GetHeight();

		drawComponent->w = clipWidth;
		drawComponent->h = clipHeight;
	}

}

void Sprite::Update()
{
	if(upComponent->animated)
	{
		if(upComponent->hasCurrent)
		{
			if(upComponent->playAnim)
			{
				unsigned int frame = upComponent->currentFrame + upComponent->anim.startFrame;
				if(frame > upComponent->anim.endFrame-1)
				{
					if(upComponent->anim.playStyle == ONCE)
						return;

					upComponent->currentFrame = 0;
					frame = upComponent->currentFrame + upComponent->anim.startFrame-1;

				}

				int rows = texture->GetWidth() / frameWidth;

				unsigned int locY = frame / rows;
				unsigned int locX = frame % rows;

				frameBounds.left = (int)(locX * frameWidth);
				frameBounds.top = (int)(locY * frameHeight);

				upComponent->currentFrame++;
			}
		}
	}
}

void Sprite::Animated(bool value)
{
	upComponent->animated = value;
	if(value)
	{
		clipWidth = frameWidth;
		clipHeight = frameHeight;

		drawComponent->w = frameWidth;
		drawComponent->h = frameHeight;
	}
}

bool Sprite::IsAnimated()
{
	return upComponent->animated;
}

void Sprite::SetFrameWidth(unsigned int value)
{
	frameWidth = value;

	if(IsAnimated())
	{
		clipWidth = value;
	}
}

unsigned int Sprite::GetFrameWidth()
{
	return frameWidth;
}

void Sprite::SetFrameHeight(unsigned int value)
{
	frameHeight = value;

	if(IsAnimated())
		clipHeight = value;
}

unsigned int Sprite::GetFrameHeight()
{
	return frameHeight;
}

void Sprite::AddAnimation(Animation animation)
{
	animations.push_back(animation);
}

void Sprite::SetCurrentAnimation(std::string name)
{
	for(Animation & anim : animations)
	{
		if(name == anim.name)
		{
			upComponent->hasCurrent = true;
			upComponent->anim.playStyle = anim.playStyle;
			upComponent->anim.startFrame = anim.startFrame;
			upComponent->anim.endFrame = anim.endFrame;

			upComponent->playAnim = false;
			break;
		}
	}
}

void Sprite::PlayCurrentAnimation()
{
	upComponent->playAnim = true;
}

void Sprite::StopCurrentAnimation()
{
	upComponent->playAnim = false;
}



