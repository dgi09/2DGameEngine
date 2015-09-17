#pragma  once 
#include "Common.h"
#include "Color.h"

struct EXPORT Vertex_PosUV
{
	float x,y;
	float u,v;
};

struct EXPORT Vertex_PosColor
{
	float x,y;
	Color color;
};