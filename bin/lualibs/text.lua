Text = {}

function Text:CreateFromPtr(p)
 obj = {ptr = p,x = 0,y = 0,rotation = 0}
 self.__index = self
 return setmetatable(obj,self)
end


function Text:SetText(text)
 hidden_text_setText(self.ptr,text)
end

function Text:SetPosition(x,y)
 self.x = x
 self.y = y

 hidden_entity_setPosition(self.ptr,x,y)
end

function Text:Move(x,y)
 self.x = self.x + x
 self.y = self.y + y
 hidden_entity_move(self.ptr,x,y)
end

function Text:SetRotation(angle)
 self.rotation = angle
 hidden_entity_setRotation(self.ptr,angle)
end

function Text:Rotate(angle)
 self.rotation = self.rotation + angle
 hidden_entity_rotate(self.ptr,angle)
end

function Text:SetColor(r,g,b)
 hidden_text_setColor(self.ptr,r,g,b)
end

function Text:SetFont(fontName)
 hidden_text_setFont(self.ptr,fontName)
end

function Text:SetSize(size)
 hidden_text_setSize(self.ptr,size)
end
function AddText()
 return Text:CreateFromPtr(hidden_addText())
end
