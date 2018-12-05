using States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.States
{
    public class StateController
    {
        public IState Current;
        private readonly Stack<IState> _stateStack;

        public StateController()
        {
            _stateStack = new Stack<IState>();
        }

        public void Push(IState state)
        {
            if (_stateStack.Count != 0)
                Current.Sleep();

            Current = state;
            _stateStack.Push(state);
            state.Start();
        }

        public void Pop()
        {
            if (_stateStack.Count == 0)
                return;
            Current.End();
            _stateStack.Pop();

            if (_stateStack.Count == 0)
                return;
            Current = _stateStack.Peek();
            Current.Wake();

        }

        public void ChangeState(IState state)
        {
            if (_stateStack.Count == 0)
                return;
            Current.End();
            _stateStack.Pop();

            Current = state;
            _stateStack.Push(state);
            state.Start();
        }

        public void Update(float delta)
        {
            foreach(var state in _stateStack)
            {
                if (state == Current)
                    state.Update(delta);
                else
                    state.Sleeping(delta);
            }
        }

    }
}
