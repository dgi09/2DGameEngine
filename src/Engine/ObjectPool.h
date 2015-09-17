#pragma once 
#include "Common.h"
#include <stdio.h>
#include <malloc.h>

template <class T,unsigned int alignment>
class EXPORT ObjectPool 
{
	unsigned int size;
	T * mem;
	bool * used;
	unsigned int allocatedObjects;
public:
	ObjectPool();
	~ObjectPool();

	void Allocate(unsigned int size);
	T * New();
	void Delete(T * obj);
	void DeleteAll();
	bool IsFull();
	bool Contains(T * obj);
};



template <class T,unsigned int alignment>
bool ObjectPool<T,alignment>::Contains(T * obj)
{
	int objAddr = (int)obj;
	int beginAddress = (int)mem;
	int endAddress = beginAddress + (size * sizeof(T));

	return (objAddr >= beginAddress && objAddr <= endAddress);
}

template <class T,unsigned int alignment>
bool ObjectPool<T,alignment>::IsFull()
{
	return size == allocatedObjects;
}


template <class T,unsigned int alignment>
void ObjectPool<T,alignment>::DeleteAll()
{
	for(unsigned int i = 0;i < size;i++)
	{
		used[i] = false;
	}
}


template <class T,unsigned int alignment>
ObjectPool<T,alignment>::~ObjectPool()
{
	if(mem != nullptr)
		_aligned_free(mem);

	if(used != nullptr)
		delete[] used;
}

template <class T,unsigned int alignment>
ObjectPool<T,alignment>::ObjectPool()
{
	mem = nullptr;
	used = nullptr;
	allocatedObjects = 0;
}

template <class T,unsigned int alignment>
void ObjectPool<T,alignment>::Delete(T * obj)
{
	UINT index = ((UINT)obj - (UINT)mem)/sizeof(T);
	used[index] = false;
}

template <class T,unsigned int alignment>
T * ObjectPool<T,alignment>::New()
{

	for(unsigned int i = 0 ;i < size;i++)
	{
		if(used[i] == false)
		{
			used[i] = true;
			allocatedObjects++;
			return new (&mem[i])T();
		}
	}

	return nullptr;
}

template <class T,unsigned int alignment>
void ObjectPool<T,alignment>::Allocate(unsigned int size)
{

	this->size = size;
	mem = (T*)_aligned_malloc(size * sizeof(T),alignment);
	used = new bool[size];

	memset(used,0,sizeof(bool) * size);
}
