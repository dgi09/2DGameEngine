#include "ShaderCode.h"

const char * vShader_TexutredQuad = 
	"cbuffer Matrixes { matrix viewMatrix; matrix projMatrix; matrix worldMatrix;};"
	"struct VS_OUT { float4 pos :SV_POSITION; float2 uv :TEXCOORD;};"
	"VS_OUT main( float2 pos : POSITION,float2 uv :TEXCOORD ) "
	"{"
	"VS_OUT output = (VS_OUT)0;"
	"float4 p = float4(pos,0.0f,1.0f);"
	"p = mul(p,worldMatrix);"
	"p = mul(p,viewMatrix);"
	"p = mul(p,projMatrix);"
	"output.pos = p;"
	"output.uv = uv;"
	"return output;"
	"}";

  const char * pShader_TexturedQuad =
	"Texture2D tex;"
	"SamplerState Sampler { Filter = MIN_MAG_MIP_LINEAR; AddressU = WRAP; AddressV = WRAP; };"
	"struct VS_OUT { float4 pos :SV_POSITION; float2 uv :TEXCOORD;};"
	"float4 main(VS_OUT input) : SV_TARGET { "
	"return tex.Sample(Sampler,input.uv);}";

  ///////////////////////////////////////////////////////////////////////////////////


  const char * vShader_ColoredObject = 
	  "cbuffer Matrixes { matrix viewMatrix; matrix projMatrix; matrix worldMatrix;};"
	  "struct VS_OUT { float4 pos :SV_POSITION; float4 color :COLOR;};"
	  "VS_OUT main( float2 pos : POSITION,float4 color :COLOR ) "
	  "{"
	  "VS_OUT output = (VS_OUT)0;"
	  "float4 p = float4(pos,0.0f,1.0f);"
	  "p = mul(p,worldMatrix);"
	  "p = mul(p,viewMatrix);"
	  "p = mul(p,projMatrix);"
	  "output.pos = p;"
	  "output.color = color;"
	  "return output;"
	  "}";

  const char * pShader_ColoredObject =
	  "struct VS_OUT { float4 pos :SV_POSITION; float4 color :COLOR;};"
	  "float4 main(VS_OUT input) : SV_TARGET { "
	  "return input.color;}";