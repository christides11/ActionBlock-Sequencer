using System;
using UnityEngine;

namespace ct.ActionBlocks.Blocks
{
    [Serializable]
    public class ExecuteWhileWaiting : ActionBlockBase
    {
        public float waitFor;

        [SerializeReference, SubclassSelector]
        public ActionBlockBase[] actions;
        
        public override bool Execute(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            if (sequence.blockTimer < waitFor)
            {
                foreach (ActionBlockBase action in actions)
                {
                    action.Execute(gameObject, ref sequence);
                }
                return false;
            }
            return true;
        }

        public override void ForceComplete(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            while (sequence.blockTimer < waitFor)
            {
                foreach (ActionBlockBase action in actions)
                {
                    action.Execute(gameObject, ref sequence);
                }
                sequence.blockTimer += sequence.deltaTime;
            }
        }
    }
}