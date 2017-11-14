using System;
using System.Collections.Generic;
using System.Text;

namespace NSUtils.NSFSM
{
    public interface StackFSMState : FSMState
    {
		void OnPush();
		void OnPop();
    }
}
