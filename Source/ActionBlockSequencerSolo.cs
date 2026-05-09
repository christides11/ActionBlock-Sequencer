using System.Collections.Generic;
using ct.ActionBlocks.Blocks;
using UnityEngine;

namespace ct.ActionBlocks
{
    public class ActionBlockSequencerSolo : MonoBehaviour
    {
        private ActionBlockSequence runningSequence;
        
        [SerializeField] protected ActionBlockSequence sequence;

        public bool playOnAwake;

        private void Awake()
        {
            if(playOnAwake) Execute();
        }

        public virtual void Update()
        {
            if (runningSequence.IsValid() && !runningSequence.IsComplete())
            {
                runningSequence.Update(gameObject, Time.deltaTime);
            }
        }

        public virtual void Execute()
        {
            if (runningSequence.IsValid() && !runningSequence.IsComplete())
            {
                runningSequence.ForceComplete(gameObject, Time.fixedDeltaTime);
            }

            runningSequence = new ActionBlockSequence()
            {
                actionList = sequence.actionList,
                currentIndex = 0,
                blockTimer = 0,
                timer = 0,
                onCompleteAction = sequence.onCompleteAction
            };
            runningSequence.Update(gameObject, Time.deltaTime);
        }

        public virtual void ForceComplete()
        {
            if (runningSequence.IsValid() && !runningSequence.IsComplete())
            {
                runningSequence.ForceComplete(gameObject, Time.fixedDeltaTime);
            }
        }
    }
}