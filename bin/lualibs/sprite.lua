PLAYSTYLE_LOOP = 0
PLAYSTYLE_ONCE = 1

Sprite = {}

function Sprite:CreateFromPtr(p)
 obj = {ptr = p,x = 0,y = 0,rotation = 0}
 self.__index = self
 return setmetatable(obj,self)
end


function Sprite:LoadTextureFromFile(fileName)
 hidden_sprite_loadTextureFromFile(self.ptr,fileName)
end

function Sprite:SetPosition(x,y)
 self.x = x
 self.y = y

 hidden_entity_setPosition(self.ptr,x,y)
end

function Sprite:internal_getPtr()
 return self.ptr
end

function Sprite:Move(x,y)
 self.x = self.x + x
 self.y = self.y + y
 hidden_entity_move(self.ptr,x,y)
end

function Sprite:SetRotation(angle)
 self.rotation = angle
 hidden_entity_setRotation(self.ptr,angle)
end

function Sprite:Rotate(angle)
 self.rotation = self.rotation + angle
 hidden_entity_rotate(self.ptr,angle)
end

function Sprite:Animated(value)
 hidden_sprite_animated(self.ptr,value)
end

function Sprite:SetFrameSize(width,height)
 hidden_sprite_setFrameSize(self.ptr,width,height)
end

function Sprite:AddAnimation(name,playStyle,startFrame,endFrame)
 hidden_sprite_addAnimation(self.ptr,name,playStyle,startFrame,endFrame)
end

function Sprite:SetCurrentAnimation(name)
 hidden_sprite_setCurrentAnimation(self.ptr,name)
end

function Sprite:PlayCurrentAnimation()
 hidden_sprite_playCurrentAnimation(self.ptr)
end

function Sprite:StopCurrentAnimation()
 hidden_sprite_stopCurrentAnimation(self.ptr)
end

function AddSprite()
 return Sprite:CreateFromPtr(hidden_addSprite())
end

function AddSpriteFromLibrary(name)
 return Sprite:CreateFromPtr(hidden_addSpriteFromLibrary(name))
end

function RemoveSprite(sprite)
 hidden_removeSprite(sprite:internal_getPtr())
end
