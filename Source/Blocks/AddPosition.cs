using System;
using UnityEngine;

namespace ct.ActionBlocks.Blocks
{
    [Serializable]
    public class AddPosition : ActionBlockBase
    {
        public GameObject objectToMove;
        public Vector3 moveby;
        public bool instant;
        
        public override bool Execute(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            objectToMove.transform.position += instant ? moveby : (moveby * Time.deltaTime);
            return true;
        }
    }
}