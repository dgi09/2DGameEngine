#pragma once 
#include "Common.h"
#include "Quad.h"
#include "PipeLine.h"
#include "Vertex.h"


class EXPORT ColoredQuad 
{
	Quad<Vertex_PosColor> quad;
	PipeLine pipeLine;

public:

	void Init(ID3D11Device * device);

	void Draw(Color color);
};