LibSprite = {}

function LibSprite:CreateFromIndex(ind)
 obj = {index = ind}
 self.__index = self
 return setmetatable(obj,self)
end

function LibSprite:SetPosition(x,y)
 hidden_lSprite_setPosition(self.index,x,y)
end

function LibSprite:SetTexturePath(path)
 hidden_lSprite_setTexturePath(self.index,path)
end

function LibSprite:SetFrameSize(width,height)
 hidden_lSprite_setFrameSize(self.index,width,height)
end

function LibSprite:Animated(val)
 hidden_lSprite_animated(self.ptr,val)
end

function LibSprite:AddAnimation(name,playStyle,startFrame,endFrame)
 hidden_lSprite_addAnimation(self.index,name,playStyle,startFrame,endFrame)
end

function AddLibrarySprite(name)
 return LibSprite:CreateFromIndex(hidden_addLibrarySprite(name))
end





