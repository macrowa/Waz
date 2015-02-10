using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Waz.Core.Extension
{
    public interface IExtension
    {
        void Initialize();

        void UnInitialize();
    }
}
