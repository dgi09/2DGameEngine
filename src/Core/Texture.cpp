#include "Texture.h"
#include <D3DX11.h>

ID3D11ShaderResourceView * Texture::GetView()
{
	return view;
}

void Texture::InitFromFile(const char * fileName)
{

	D3DX11CreateTextureFromFileA(device,fileName,nullptr,nullptr,(ID3D11Resource**)&texture,nullptr);
	
	if(texture != nullptr)
	{
		D3D11_TEXTURE2D_DESC desc;
		texture->GetDesc(&desc);
		width = desc.Width;
		height = desc.Height;

		device->CreateShaderResourceView(texture,nullptr,&view);
	}
	



}

void Texture::InitFromBitmap(Bitmap * bMap)
{
	this->width = (unsigned short)bMap->GetWidth();
	this->height = (unsigned short)bMap->GetHeight();

	D3D11_TEXTURE2D_DESC desc;
	ZeroMemory(&desc,sizeof(D3D11_TEXTURE2D_DESC));

	desc.Width = width;
	desc.Height = height;
	desc.BindFlags = D3D11_BIND_SHADER_RESOURCE;
	desc.ArraySize = 1;
	desc.MipLevels = 1;
	desc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
	desc.SampleDesc.Count = 1;
	desc.Usage = D3D11_USAGE_DEFAULT;

	D3D11_SUBRESOURCE_DATA pData;
	pData.pSysMem = bMap->GetBuffer();
	pData.SysMemPitch = width * 4;
	pData.SysMemSlicePitch = width * height * 4;

	device->CreateTexture2D(&desc,&pData,&texture);

	if(texture != nullptr)
	{
		D3D11_SHADER_RESOURCE_VIEW_DESC viewDesc;
		ZeroMemory(&viewDesc,sizeof(D3D11_SHADER_RESOURCE_VIEW_DESC));
		viewDesc.Texture2D.MipLevels = 1;
		viewDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
		viewDesc.ViewDimension = D3D11_SRV_DIMENSION_TEXTURE2D;

		HRESULT res = device->CreateShaderResourceView(texture,&viewDesc,&view);

	}

}

unsigned short Texture::GetWidth()
{
	return width;
}

unsigned short Texture::GetHeight()
{
	return height;
}

void Texture::Create(ID3D11Device * device)
{
	this->device = device;
	texture = nullptr;
	view = nullptr;
}

void Texture::Destroy()
{
	device = nullptr;

	if(view != nullptr)
		view->Release();

	if(texture != nullptr)
		texture->Release();
}
