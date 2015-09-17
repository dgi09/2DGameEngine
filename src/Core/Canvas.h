#pragma once
#include "Common.h"
#include <Windows.h>
#include <d3d11.h>
#include "Color.h"
#include <DirectXMath.h>
#include "Rect.h"
#include "Texture.h"
#include "TexturedQuad.h"
#include "ColoredQuad.h"
#include "ColoredLine.h"


class Matrixes
{
public:
	DirectX::XMFLOAT4X4 viewMatrix;
	DirectX::XMFLOAT4X4 projmatrix;
	DirectX::XMFLOAT4X4 worldMatrix;
};
	

class EXPORT Canvas
{
	Color clearColor;
	UINT width;
	UINT height;

	ID3D11Device * device;
	ID3D11RenderTargetView * backBufferView;
	ID3D11DeviceContext * context;
	IDXGISwapChain * swapChain;

	ID3D11DepthStencilState * depthState;
	ID3D11RasterizerState * rasterState;
	ID3D11BlendState * blend;
	
	ID3D11Buffer * matrixBuffer;
	int lastRotationAngle;
	Matrixes mat;

	TexturedQuad tQuad;
	ColoredQuad  cQuad;
	ColoredLine  cLine;
public:
	Canvas(HWND handle, UINT width, UINT height);
	~Canvas();
	
	void SetClearColor(Color color);
	Color GetClearColor();

	void Clear();

	void Present();

	ID3D11Device * GetDevice();

	void DrawRectSolid(Rect & rect,Color color,int rotationAngle);
	void DrawTexture(Texture * texture,Rect & destRect, Rect * srcRect, int rotationAngle);
	void DrawLine(int x1,int y1,int x2,int y2,Color color);
	void DrawRect(Rect rect,Color color);
private:
	void BindWorldMatrix(Rect  & destRect,int rotationAngle);
	void BindWorlMatrix_Identity();
	void BindWorldMatrix();
};