#include "ColoredLine.h"
#include "ShaderCode.h"


void ColoredLine::Init(ID3D11Device * device)
{
	line.Init(device);

	pipeLine.Init(device);
	D3D11_INPUT_ELEMENT_DESC inEl[2] = 
	{
		{"POSITION", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0},
		{"COLOR",    0, DXGI_FORMAT_R32G32B32A32_FLOAT, 0, 8, D3D11_INPUT_PER_VERTEX_DATA, 0}
	};

	pipeLine.LoadVertexShader(vShader_ColoredObject,inEl,2);
	pipeLine.LoadPixelShader(pShader_ColoredObject);

}

void ColoredLine::Draw(int x1,int y1,int x2,int y2,Color color)
{
	Vertex_PosColor * v = line.Map();

	v[0].x = (float)x1;
	v[0].y = (float)y1 * -1;
	v[0].color = color;

	v[1].x = (float)x2;
	v[1].y = (float)y2 * -1;
	v[1].color = color;

	line.Unmap();

	pipeLine.Bind();
	line.Draw();
}
