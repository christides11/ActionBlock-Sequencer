using System;
using UnityEngine;

namespace ct.ActionBlocks.Blocks
{
    [Serializable]
    public class ExecuteAction : ActionBlockBase
    {
        public Action action;

        public override bool Execute(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            action?.Invoke();
            return true;
        }
    }
}
