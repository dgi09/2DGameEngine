#pragma once 
#include "Common.h"
#include <d3d11.h>
#include "Rect.h"

template <class T>
class EXPORT Quad
{
	ID3D11Device * device;
	ID3D11Buffer * vBuffer;
	ID3D11Buffer * iBuffer;

public:

	Quad();
	~Quad();

	void Init(ID3D11Device * device);
	void Draw();
	void Bind();


	T * Map();
	void Unmap();

private:

	ID3D11DeviceContext * GetContext();
};



template <class T>
ID3D11DeviceContext * Quad<T>::GetContext()
{
	ID3D11DeviceContext * context;
	device->GetImmediateContext(&context);

	return context;
}

template <class T>
void Quad<T>::Unmap()
{
	GetContext()->Unmap(vBuffer,0);
}

template <class T>
T * Quad<T>::Map()
{
	ID3D11DeviceContext * context = GetContext();
	D3D11_MAPPED_SUBRESOURCE map;

	context->Map(vBuffer,0,D3D11_MAP_WRITE_DISCARD,0,&map);

	return (T*)map.pData;
}

template <class T>
void Quad<T>::Bind()
{
	ID3D11DeviceContext * context = GetContext();

	UINT stride = sizeof(T);
	UINT offset = 0;

	context->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
	context->IASetVertexBuffers(0,1,&vBuffer,&stride,&offset);
	context->IASetIndexBuffer(iBuffer,DXGI_FORMAT_R8_UINT,0);
}

template <class T>
void Quad<T>::Draw()
{
	ID3D11DeviceContext * context = GetContext();

	context->DrawIndexed(6,0,0);
}

template <class T>
void Quad<T>::Init(ID3D11Device * device)
{
	this->device = device;

	D3D11_BUFFER_DESC vBufferDesc;
	ZeroMemory(&vBufferDesc,sizeof(D3D11_BUFFER_DESC));

	vBufferDesc.Usage = D3D11_USAGE_DYNAMIC;
	vBufferDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
	vBufferDesc.MiscFlags = 0;
	vBufferDesc.CPUAccessFlags = D3D11_CPU_ACCESS_WRITE;
	vBufferDesc.ByteWidth = 4 * sizeof(T);

	device->CreateBuffer(&vBufferDesc,nullptr,&vBuffer);

	unsigned char indexBuffer[6] = {0,2,1,2,3,1};

	D3D11_BUFFER_DESC iBufferDesc;
	ZeroMemory(&iBufferDesc,sizeof(D3D11_BUFFER_DESC));

	iBufferDesc.BindFlags = D3D11_BIND_INDEX_BUFFER;
	iBufferDesc.ByteWidth = sizeof(indexBuffer);
	iBufferDesc.Usage = D3D11_USAGE_DEFAULT;

	D3D11_SUBRESOURCE_DATA data;
	data.pSysMem = indexBuffer;

	device->CreateBuffer(&iBufferDesc,&data,&iBuffer);
}

template <class T>
Quad<T>::~Quad()
{
	device = nullptr;

	if(vBuffer != nullptr)
		vBuffer->Release();

	if(iBuffer != nullptr)
		iBuffer->Release();
}

template <class T>
Quad<T>::Quad()
{
	device = nullptr;
	vBuffer = nullptr;
	iBuffer = nullptr;
}
