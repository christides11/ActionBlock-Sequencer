using System;
using UnityEngine;
using UnityEngine.Events;

namespace ct.ActionBlocks.Blocks
{
    [Serializable]
    public class CallUnityEvent : ActionBlockBase
    {
        public UnityEvent evt = new UnityEvent();

        public override bool Execute(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            evt?.Invoke();
            return true;
        }
    }
}