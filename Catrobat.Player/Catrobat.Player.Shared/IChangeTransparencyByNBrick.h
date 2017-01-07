#pragma once

#include "IBrick.h"
#include "IFormulaTree.h"

namespace Catrobat_Player
{
    namespace NativeComponent
    {
        public interface class IChangeTransparencyByNBrick : public IBrick
        {
        public:
            virtual property IFormulaTree^ Transparency;
        };
    }
}
