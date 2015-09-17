#pragma once 
#include "Common.h"
#include <d3d11.h>

template <class T>
class EXPORT Line
{
	ID3D11Device * device;
	ID3D11DeviceContext * context;

	ID3D11Buffer * vBuffer;

public:

	Line();
	~Line();

	void Init(ID3D11Device * device);

	void Draw();

	T * Map();

	void Unmap();

};

template <class T>
void Line<T>::Unmap()
{
	context->Unmap(vBuffer,0);
}

template <class T>
T * Line<T>::Map()
{
	D3D11_MAPPED_SUBRESOURCE map;

	context->Map(vBuffer,0,D3D11_MAP_WRITE_DISCARD,0,&map);

	return (T*)map.pData;
}

template <class T>
void Line<T>::Draw()
{
	UINT stride = sizeof(T);
	UINT offset = 0;

	context->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_LINELIST);
	context->IASetVertexBuffers(0,1,&vBuffer,&stride,&offset);
	context->Draw(2,0);
}

template <class T>
void Line<T>::Init(ID3D11Device * device)
{
	this->device = device;
	device->GetImmediateContext(&context);


	D3D11_BUFFER_DESC vBufferDesc;
	ZeroMemory(&vBufferDesc,sizeof(D3D11_BUFFER_DESC));

	vBufferDesc.Usage = D3D11_USAGE_DYNAMIC;
	vBufferDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
	vBufferDesc.MiscFlags = 0;
	vBufferDesc.CPUAccessFlags = D3D11_CPU_ACCESS_WRITE;
	vBufferDesc.ByteWidth = 2 * sizeof(T);

	device->CreateBuffer(&vBufferDesc,nullptr,&vBuffer);

}

template <class T>
Line<T>::~Line()
{
	context = nullptr;
	device = nullptr;

	if(vBuffer != nullptr)
		vBuffer->Release();

}

template <class T>
Line<T>::Line()
{
	device = nullptr;
	context = nullptr;

	vBuffer = nullptr;
}
