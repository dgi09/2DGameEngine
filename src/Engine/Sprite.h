#pragma once 
#include "Common.h"
#include "Entity.h"
#include "IUpdateable.h"
#include <vector>
#include "Animation.h"
#include "DrawComonent.h"
#include "UpdateComponent.h"

class EXPORT Sprite : public Entity , public IUpdateable
{
	Rect frameBounds;
	unsigned short frameWidth;
	unsigned short frameHeight;


	std::vector<Animation> animations;
	

	DrawComponent * drawComponent;
	UpdateComponnent * upComponent;

public:

	void Init() override;

	void Destroy();

	virtual void Draw(Canvas * canvas) override;

	void Update() override;

	void LoadFromFile(const char * fileName);

	void Animated(bool value);
    bool IsAnimated();

	void SetFrameWidth(unsigned int value);
	unsigned int GetFrameWidth();

	void SetFrameHeight(unsigned int value);
	unsigned int GetFrameHeight();

	void AddAnimation(Animation animation);
	
	void SetCurrentAnimation(std::string name);

	void PlayCurrentAnimation();
	void StopCurrentAnimation();
};