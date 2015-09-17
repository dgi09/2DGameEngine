#include "Canvas.h"

using namespace DirectX;


Canvas::Canvas(HWND handle, UINT width, UINT height)
{
	this->width = width;
	this->height = height;

	DXGI_SWAP_CHAIN_DESC desc;
	ZeroMemory(&desc,sizeof(DXGI_SWAP_CHAIN_DESC));
	desc.BufferCount = 2;
	desc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
	desc.BufferDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
	desc.BufferDesc.Width = width;
	desc.BufferDesc.Height = height;
	desc.OutputWindow = handle;
	desc.SampleDesc.Count = 1;
	desc.Windowed = TRUE;

	D3D_FEATURE_LEVEL ftr;
	ftr = D3D_FEATURE_LEVEL_11_0;

	D3D11CreateDeviceAndSwapChain(NULL,D3D_DRIVER_TYPE_HARDWARE,
		nullptr,0,&ftr,1,
		D3D11_SDK_VERSION,
		&desc,
		&swapChain,
		&device,
		nullptr,
		&context);

	ID3D11Texture2D * backBuffer = nullptr;
	swapChain->GetBuffer(0,__uuidof(ID3D11Texture2D),(LPVOID*)&backBuffer);
	device->CreateRenderTargetView(backBuffer,nullptr,&backBufferView);

	context->OMSetRenderTargets(1,&backBufferView,nullptr);

	D3D11_DEPTH_STENCIL_DESC depthDesc;
	ZeroMemory(&depthDesc,sizeof(D3D11_DEPTH_STENCIL_DESC));
	depthDesc.DepthEnable = false;

	D3D11_RASTERIZER_DESC rasterDesc;
	ZeroMemory(&rasterDesc,sizeof(D3D11_RASTERIZER_DESC));

	rasterDesc.CullMode = D3D11_CULL_NONE;
	rasterDesc.FillMode = D3D11_FILL_SOLID;

	device->CreateRasterizerState(&rasterDesc,&rasterState);

	context->RSSetState(rasterState);

	device->CreateDepthStencilState(&depthDesc,&depthState);
	context->OMSetDepthStencilState(depthState,0);


	D3D11_BLEND_DESC blendStateDescription;
	ZeroMemory(&blendStateDescription,sizeof(D3D11_BLEND_DESC));

	blendStateDescription.RenderTarget[0].BlendEnable = TRUE;
	blendStateDescription.RenderTarget[0].SrcBlend = D3D11_BLEND_SRC_ALPHA;
	blendStateDescription.RenderTarget[0].DestBlend = D3D11_BLEND_INV_SRC_ALPHA;
	blendStateDescription.RenderTarget[0].BlendOp = D3D11_BLEND_OP_ADD;
	blendStateDescription.RenderTarget[0].SrcBlendAlpha = D3D11_BLEND_ONE;
	blendStateDescription.RenderTarget[0].DestBlendAlpha = D3D11_BLEND_ZERO;
	blendStateDescription.RenderTarget[0].BlendOpAlpha = D3D11_BLEND_OP_ADD;
	blendStateDescription.RenderTarget[0].RenderTargetWriteMask = 0x0f;


	device->CreateBlendState(&blendStateDescription,&blend);

	float factor[] = {0.0f,0.0f,0.0f,0.0f};

	context->OMSetBlendState(blend,factor,0xffffffff);
	D3D11_VIEWPORT view;
	ZeroMemory(&view,sizeof(D3D11_VIEWPORT));

	view.TopLeftX = 0.0f;
	view.TopLeftY = 0.0f;
	view.Width = (UINT)width;
	view.Height = (UINT)height;
	view.MinDepth = 0.0f;
	view.MaxDepth = 1.0f;

	context->RSSetViewports(1,&view);

	tQuad.Init(device);
	cQuad.Init(device);
	cLine.Init(device);

	lastRotationAngle = 0;

	XMMATRIX viewMat = XMMatrixLookAtLH(XMVectorSet(0.0f,0.0f,0.0f,1.0f),XMVectorSet(0.0f,0.0f,1.0f,1.0f),XMVectorSet(0.0f,1.0f,0.0f,1.0f));
	XMMATRIX proj = XMMatrixOrthographicLH((float)width,(float)height,0.1f,1.0f);

	XMStoreFloat4x4(&mat.viewMatrix,XMMatrixTranspose(viewMat));
	XMStoreFloat4x4(&mat.projmatrix,XMMatrixTranspose(proj));
	XMStoreFloat4x4(&mat.worldMatrix,XMMatrixTranspose(XMMatrixIdentity()));


	D3D11_BUFFER_DESC cDesc;
	cDesc.BindFlags = D3D11_BIND_CONSTANT_BUFFER;
	cDesc.ByteWidth = sizeof(Matrixes);
	cDesc.CPUAccessFlags = D3D11_CPU_ACCESS_WRITE;
	cDesc.MiscFlags = 0;
	cDesc.StructureByteStride = 0;
	cDesc.Usage = D3D11_USAGE_DYNAMIC;

	D3D11_SUBRESOURCE_DATA data;
	data.pSysMem = &mat;

	device->CreateBuffer(&cDesc,&data,&matrixBuffer);

	context->VSSetConstantBuffers(0,1,&matrixBuffer);

}

Canvas::~Canvas()
{
	rasterState->Release();
	depthState->Release();
	matrixBuffer->Release();
	backBufferView->Release();
	context->Release();
	device->Release();
	swapChain->Release();

}

void Canvas::SetClearColor(Color color)
{
	clearColor = color;
}

Color Canvas::GetClearColor()
{
	return clearColor;
}

void Canvas::Clear()
{
	context->ClearRenderTargetView(backBufferView,(float*)&clearColor);
}

void Canvas::Present()
{
	swapChain->Present(0,0);
}

void Canvas::DrawRectSolid(Rect & rect,Color color,int rotationAngle)
{
	BindWorldMatrix(rect,rotationAngle);

	cQuad.Draw(color);
}

void Canvas::DrawTexture(Texture * texture,Rect & destRect, Rect * srcRect, int rotationAngle)
{

	BindWorldMatrix(destRect,rotationAngle);

	tQuad.Draw(texture,srcRect);

}

void Canvas::DrawLine(int x1,int y1,int x2,int y2,Color color)
{
	BindWorldMatrix();
	cLine.Draw(x1,y1,x2,y2,color);
}

void Canvas::DrawRect(Rect rect,Color color)
{
	BindWorldMatrix();
	cLine.Draw(rect.left,rect.top,rect.right,rect.top,color);
	cLine.Draw(rect.right,rect.top,rect.right,rect.bottom,color);
	cLine.Draw(rect.left,rect.top,rect.left,rect.bottom,color);
	cLine.Draw(rect.left,rect.bottom,rect.right,rect.bottom,color);
}

ID3D11Device * Canvas::GetDevice()
{
	return device;
}

void Canvas::BindWorldMatrix(Rect & destRect,int rotationAngle)
{
	XMMATRIX scale = XMMatrixScaling((float)(destRect.right - destRect.left),(float)(destRect.bottom - destRect.top),1.0f); 
	XMMATRIX rotation = XMMatrixRotationZ(XMConvertToRadians((float)rotationAngle));
	XMMATRIX translation = XMMatrixTranslation((float)destRect.left - (float)(width/2),(float)(height/2) - (float)destRect.top,0.0f);

	XMStoreFloat4x4(&mat.worldMatrix,XMMatrixTranspose(scale * rotation * translation));

	D3D11_MAPPED_SUBRESOURCE map;
	context->Map(matrixBuffer,0,D3D11_MAP_WRITE_DISCARD,0,&map);
	memcpy(map.pData,&mat,sizeof(mat));

	context->Unmap(matrixBuffer,0);
}

void Canvas::BindWorldMatrix()
{
	XMMATRIX translation = XMMatrixTranslation(-(float)(width/2),(float)(height/2),0.0f);

	XMStoreFloat4x4(&mat.worldMatrix,XMMatrixTranspose(translation));

	D3D11_MAPPED_SUBRESOURCE map;
	context->Map(matrixBuffer,0,D3D11_MAP_WRITE_DISCARD,0,&map);
	memcpy(map.pData,&mat,sizeof(mat));

	context->Unmap(matrixBuffer,0);
}



void Canvas::BindWorlMatrix_Identity()
{
	XMStoreFloat4x4(&mat.worldMatrix,XMMatrixIdentity());

	D3D11_MAPPED_SUBRESOURCE map;
	context->Map(matrixBuffer,0,D3D11_MAP_WRITE_DISCARD,0,&map);
	memcpy(map.pData,&mat,sizeof(mat));

	context->Unmap(matrixBuffer,0);
}


