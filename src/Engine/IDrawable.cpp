#include "IDrawable.h"

bool IDrawable::Visible()
{
	return visible;
}

void IDrawable::SetVisible(bool val)
{
	visible = val;
}
