#pragma once 
#include "Common.h"
#include <d3d11.h>

class EXPORT PipeLine
{
	ID3D11InputLayout * layout;
	ID3D11VertexShader * vShader;
	ID3D11PixelShader * pShader;

	ID3D11Device * device;

public:

	PipeLine();
	~PipeLine();

	void Init(ID3D11Device * device);
	void Bind();

	void LoadVertexShader(const char * code,D3D11_INPUT_ELEMENT_DESC * layoutDest,UINT numberOfElements);
	void LoadPixelShader(const char * code);

private:

	ID3D11DeviceContext * GetContext();
};