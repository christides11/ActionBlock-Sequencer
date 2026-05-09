using System.Collections.Generic;
using ct.ActionBlocks.Blocks;
using UnityEngine;

namespace ct.ActionBlocks
{
    public class ActionBlockSequencerSolo : MonoBehaviour
    {
        [SerializeReference, SubclassSelector]
        public List<ActionBlockBase> actionList = new List<ActionBlockBase>();
        
        protected ActionBlockSequence sequence;

        public bool playOnAwake;

        private void Awake()
        {
            if(playOnAwake) Execute();
        }

        public virtual void Update()
        {
            if (sequence.IsValid() && !sequence.IsComplete())
            {
                sequence.Update(gameObject, Time.deltaTime);
            }
        }

        public virtual void Execute()
        {
            if (sequence.IsValid() && !sequence.IsComplete())
            {
                sequence.ForceComplete(gameObject, Time.fixedDeltaTime);
            }

            sequence = new ActionBlockSequence()
            {
                actionList = actionList.ToArray(),
                currentIndex = 0,
                blockTimer = 0,
                timer = 0
            };
            sequence.Update(gameObject, Time.deltaTime);
        }
    }
}