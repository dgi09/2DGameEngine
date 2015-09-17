#include "Color.h"

Color Color::White()
{
	Color c;
	c.r = 1.0f;
	c.g = 1.0f;
	c.b = 1.0f;
	c.a = 1.0f;
	
	return c;
}

Color Color::Black()
{
	Color c;
	c.r = 0.0f;
	c.g = 0.0f;
	c.b = 0.0f;
	c.a = 1.0f;

	return c;
}

Color Color::Red()
{
	Color c;
	c.r = 1.0f;
	c.g = 0.0f;
	c.b = 0.0f;
	c.a = 1.0f;

	return c;
}
