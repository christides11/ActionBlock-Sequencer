using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace ct.ActionBlocks
{
    public class ActionBlockSequenceQueuePlayer : MonoBehaviour
    {
        [System.Serializable]
        public struct QueueItem
        {
            public DirectorWrapMode queueWrapMode;
            public bool immediatelyCompleteIfBlockingQueue;
            public ActionBlockSequence sequence;
            public Action onCompleteAction;
        }

        public int queueMax = 1;
        public List<QueueItem> currentQueue = new List<QueueItem>();

        private void OnDisable()
        {
            currentQueue.Clear();
        }

        public void Update()
        {
            if (currentQueue.Count == 0) return;

            while (currentQueue.Count > queueMax)
            {
                //if (!currentSequence.isAlive) BuildSequence();
                //CompleteCurrentSequence();
                Pop();
            }

            if (currentQueue.Count == 0) return;
            
            switch (currentQueue[0].queueWrapMode)
            {
                case DirectorWrapMode.Hold:
                case DirectorWrapMode.Loop:
                    if (currentQueue.Count == 1) return;
                    break;
            }

            if ((currentQueue.Count > 1 && currentQueue[0].immediatelyCompleteIfBlockingQueue))
            {
                //CompleteCurrentSequence();
                Pop();
            }
        }

        public virtual void Enqueue(ActionBlockSequence sequence, DirectorWrapMode queueWrapMode,
            bool immediatelyEndIfBlockingQueue, Action onCompleteAction = null)
        {
            currentQueue.Add(new QueueItem()
            {
                queueWrapMode = queueWrapMode,
                sequence = sequence,
                immediatelyCompleteIfBlockingQueue = immediatelyEndIfBlockingQueue,
                onCompleteAction = onCompleteAction
            });

            //if (currentQueue.Count == 1) BuildSequence();
        }

        public virtual void Pop()
        {
            if(currentQueue.Count == 0) return;
            currentQueue.RemoveAt(0);
            //if (currentQueue.Count > 0) BuildSequence();
        }

        public virtual void PopAll()
        {
            while (currentQueue.Count > 0)
            {
                // Execute & End blocks
                Pop();
            }
        }
    }
}