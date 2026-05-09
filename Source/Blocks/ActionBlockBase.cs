using UnityEngine;

namespace ct.ActionBlocks.Blocks
{
    [System.Serializable]
    public class ActionBlockBase
    {
        public virtual bool Execute(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            return true;
        }
        
        public virtual void ForceComplete(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            Execute(gameObject, ref sequence);
        }
    }
}