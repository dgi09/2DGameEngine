#pragma once 
#include "Common.h"
#include "Rect.h"
#include "Texture.h"
#include "Quad.h"
#include "PipeLine.h"
#include "Vertex.h"

class EXPORT TexturedQuad
{
	Quad<Vertex_PosUV> quad;
	PipeLine pipeLine;

	ID3D11DeviceContext * context;

public:
	void Init(ID3D11Device * device);

	void Draw(Texture * texture,Rect * srcRect);

};