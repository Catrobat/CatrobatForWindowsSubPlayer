#include "pch.h"
#include "LookData.h"
#include "DDSLoader.h"
#include "ProjectDaemon.h"

#include <vector>

using namespace DirectX;

LookData::LookData(string filename, string name) :
	m_filename(filename), m_name(name)
{
	m_texture = new CatrobatTexture();
}

string LookData::Name()
{
	return m_name;
}

unsigned int LookData::Width()
{
	return m_texture->width;
}

unsigned int LookData::Height()
{
	return m_texture->height;
}

string LookData::FileName()
{
	return m_filename;
}

void LookData::LoadTexture(ID3D11Device* d3dDevice)
{
	TextureDaemon::Instance()->LoadTexture(d3dDevice, &m_texture, m_filename);
}

ID3D11ShaderResourceView *LookData::Texture()
{
	return m_texture->texture;
}