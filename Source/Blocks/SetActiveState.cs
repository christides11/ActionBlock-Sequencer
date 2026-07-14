using System;
using UnityEngine;

namespace ct.ActionBlocks.Blocks
{
    [Serializable]
    public class SetActiveState : ActionBlockBase
    {
        public GameObject gameObject;
        public bool activeState = true;
        
        public override bool Execute(GameObject go, ref ActionBlockSequence sequence)
        {
            gameObject.SetActive(activeState);
            return true;
        }
    }
}