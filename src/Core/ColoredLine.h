#pragma once 
#include "Common.h"
#include "Line.h"
#include "PipeLine.h"
#include "Vertex.h"

class EXPORT ColoredLine
{
	Line<Vertex_PosColor> line;
	PipeLine pipeLine;
public:
	
	void Init(ID3D11Device * device);
	void Draw(int x1,int y1,int x2,int y2,Color color);
};