#include "TexturedQuad.h"
#include "ShaderCode.h"


void TexturedQuad::Init(ID3D11Device * device)
{
	device->GetImmediateContext(&context);

	quad.Init(device);
	pipeLine.Init(device);
	pipeLine.LoadPixelShader(pShader_TexturedQuad);

	D3D11_INPUT_ELEMENT_DESC inEl[2] = 
	{
		{"POSITION", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0},
		{"TEXCOORD",    0, DXGI_FORMAT_R32G32_FLOAT, 0, 8, D3D11_INPUT_PER_VERTEX_DATA, 0}
	};


	pipeLine.LoadVertexShader(vShader_TexutredQuad,inEl,2);
}

void TexturedQuad::Draw(Texture * texture,Rect * srcRect)
{

	quad.Bind();
	pipeLine.Bind();

	float tL,tR,tT,tB;
	if(srcRect == nullptr)
	{
		tL = tT = 0.0f;
		tR = tB = 1.0f;
	}
	else 
	{
		tL = (1.0f / texture->GetWidth()) * srcRect->left;
		tR = (1.0f / texture->GetWidth()) * srcRect->right;
		tT = (1.0f / texture->GetHeight()) * srcRect->top;
		tB = (1.0f / texture->GetHeight()) * srcRect->bottom;
	}

	Vertex_PosUV * v = quad.Map();
	v[0].x = 0.0f;//(float)destRect.left - (width/2);
	v[0].y = 0.0f;//(height/2) - (float)destRect.top;
	v[0].u = tL;
	v[0].v = tT;

	v[1].x = 1.0f;//(float)destRect.right - (width/2);
	v[1].y = 0.0f;//(height/2) - (float)destRect.top;
	v[1].u = tR;
	v[1].v = tT;


	v[2].x = 0.0f;//(float)destRect.left - (width/2);
	v[2].y = -1.0f;//(height/2) - (float)destRect.bottom;
	v[2].u = tL;
	v[2].v = tB;

	v[3].x = 1.0f;//(float)destRect.right - (width/2);
	v[3].y = -1.0f;//(height/2) - (float)destRect.bottom;
	v[3].u = tR;
	v[3].v = tB;

	quad.Unmap();


	ID3D11ShaderResourceView * view = texture->GetView();

	context->PSSetShaderResources(0,1,&view);
	quad.Draw();
}
