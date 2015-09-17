#pragma once 
#include "Common.h"
#include "Texture.h"
#include <string>
#include <map>

template<class T>
class EXPORT TexturePool
{
	std::map<T,Texture *> pool;
public:

	bool Exists(T key);
	void Add(T key,Texture * val);
	void Remove(T key);
	Texture * Get(T key);

	void Clear();

};

template<class T>
void TexturePool<T>::Clear()
{
	pool.clear();
}

template<class T>
Texture * TexturePool<T>::Get(T key)
{
	return pool[key];
}

template<class T>
void TexturePool<T>::Remove(T key)
{
	pool[T] = nullptr;
}

template<class T>
void TexturePool<T>::Add(T key,Texture * val)
{
	pool[key] = val;
}

template<class T>
bool TexturePool<T>::Exists(T key)
{
	if(pool.count(key) == 0 || pool[key] == nullptr)
		return false;
	
	return true;
}
