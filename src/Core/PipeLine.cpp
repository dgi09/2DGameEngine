#include "PipeLine.h"
#include <d3dcompiler.h>
#include <fstream>
#include <streambuf>
#include <string>
#include "ShaderCode.h"

PipeLine::PipeLine()
{
	layout = nullptr;
	vShader = nullptr;
	pShader = nullptr;
}

PipeLine::~PipeLine()
{
	device = nullptr;

	if(layout != nullptr)
		layout->Release();

	if(vShader != nullptr)
		vShader->Release();

	if(pShader != nullptr)
		pShader->Release();
}

void PipeLine::Init(ID3D11Device * device)
{
	this->device = device;
}

void PipeLine::Bind()
{
	ID3D11DeviceContext * context = GetContext();

	context->IASetInputLayout(layout);
	context->VSSetShader(vShader,nullptr,0);
	context->PSSetShader(pShader,nullptr,0);
}

ID3D11DeviceContext * PipeLine::GetContext()
{
	ID3D11DeviceContext * context;
	device->GetImmediateContext(&context);

	return context;
}

void PipeLine::LoadVertexShader(const char * code,D3D11_INPUT_ELEMENT_DESC * layoutDest,UINT numberOfElements)
{
	ID3D10Blob * vsBlob;

	int size = strlen(code);
	D3DCompile(code,size,nullptr,nullptr,nullptr,"main","vs_5_0",D3DCOMPILE_ENABLE_STRICTNESS,
		0,&vsBlob,nullptr);

	device->CreateVertexShader(vsBlob->GetBufferPointer(),vsBlob->GetBufferSize(),nullptr,&vShader);


	device->CreateInputLayout(layoutDest,numberOfElements,vsBlob->GetBufferPointer(),vsBlob->GetBufferSize(),&layout);

	vsBlob->Release();
}

void PipeLine::LoadPixelShader(const char * code)
{
	ID3D10Blob * psBlob;

	unsigned int size = strlen(code);
	D3DCompile(code,size,nullptr,nullptr,nullptr,"main","ps_5_0",D3DCOMPILE_ENABLE_STRICTNESS,
		0,&psBlob,nullptr);

	device->CreatePixelShader(psBlob->GetBufferPointer(),psBlob->GetBufferSize(),nullptr,&pShader);

	psBlob->Release();
}
