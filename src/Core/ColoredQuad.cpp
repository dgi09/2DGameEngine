#include "ColoredQuad.h"
#include "ShaderCode.h"


void ColoredQuad::Init(ID3D11Device * device)
{
	quad.Init(device);
	pipeLine.Init(device);

	D3D11_INPUT_ELEMENT_DESC inEl[2] = 
	{
		{"POSITION", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0},
		{"COLOR",    0, DXGI_FORMAT_R32G32B32A32_FLOAT, 0, 8, D3D11_INPUT_PER_VERTEX_DATA, 0}
	};

	pipeLine.LoadVertexShader(vShader_ColoredObject,inEl,2);
	pipeLine.LoadPixelShader(pShader_ColoredObject);


}

void ColoredQuad::Draw(Color color)
{
	Vertex_PosColor * v = quad.Map();
	v[0].x = 0.0f;//(float)destRect.left - (width/2);
	v[0].y = 0.0f;//(height/2) - (float)destRect.top;
	v[0].color = color;

	v[1].x = 1.0f;//(float)destRect.right - (width/2);
	v[1].y = 0.0f;//(height/2) - (float)destRect.top;
	v[1].color = color;


	v[2].x = 0.0f;//(float)destRect.left - (width/2);
	v[2].y = -1.0f;//(height/2) - (float)destRect.bottom;
	v[2].color = color;

	v[3].x = 1.0f;//(float)destRect.right - (width/2);
	v[3].y = -1.0f;//(height/2) - (float)destRect.bottom;
	v[3].color = color;

	quad.Unmap();

	pipeLine.Bind();
	quad.Bind();
	quad.Draw();
}
