using System;
using System.Collections.Generic;
using System.Text;

namespace NSUtils.NSFSM
{
    public interface FSMState
    {
		void OnEnter();
		void OnExit();
    }
}
