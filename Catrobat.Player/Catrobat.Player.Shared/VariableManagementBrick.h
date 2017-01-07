#pragma once

#include "Brick.h"
#include "UserVariable.h"
#include "FormulaTree.h"
#include "IVariableManagementBrick.h"

namespace ProjectStructure
{
    class VariableManagementBrick :
        public Brick
    {
    public:
        VariableManagementBrick(TypeOfBrick brickType, Catrobat_Player::NativeComponent::IVariableManagementBrick^ brick, Script* parent);
        virtual void Execute() = 0;

    protected:
        std::string m_variableName;
        std::shared_ptr<FormulaTree> m_variableFormula;
    };
}