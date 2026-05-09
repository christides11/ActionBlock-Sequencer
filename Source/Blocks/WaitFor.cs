using System;
using UnityEngine;

namespace ct.ActionBlocks.Blocks
{
    [Serializable]
    public class WaitFor : ActionBlockBase
    {
        public float waitFor;
        
        public override bool Execute(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            if (sequence.blockTimer < waitFor) return false;
            return true;
        }

        public override void ForceComplete(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            
        }
    }
}