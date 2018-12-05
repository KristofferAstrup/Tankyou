using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace States
{
    public interface IState: IUpdate
    {
        bool Start();
        bool End();

        void Sleep();
        void Sleeping(float delta);
        void Wake();
    }
}
