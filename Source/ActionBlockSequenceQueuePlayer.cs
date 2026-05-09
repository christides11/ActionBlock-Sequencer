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
            public bool immediatelyCompleteIfBlockingQueue;
            public ActionBlockSequence sequence;
        }

        public int queueMax = 1;
        public List<QueueItem> currentQueue = new();

        protected void OnDisable()
        {
            currentQueue.Clear();
        }

        public virtual void Update()
        {
            while (currentQueue.Count > queueMax)
            {
                var currentItem = currentQueue[0];
                if (currentItem.sequence.IsValid() && !currentItem.sequence.IsComplete())
                    currentItem.sequence.ForceComplete(gameObject, Time.deltaTime);
                currentQueue.RemoveAt(0);
            }

            if (currentQueue.Count == 0) return;
            
            if (currentQueue.Count > 1 && currentQueue[0].immediatelyCompleteIfBlockingQueue)
            {
                var currentItem = currentQueue[0];
                if (currentItem.sequence.IsValid() && !currentItem.sequence.IsComplete())
                    currentItem.sequence.ForceComplete(gameObject, Time.deltaTime);
                currentQueue.RemoveAt(0);
            }
            else
            {
                var currentItem = currentQueue[0];
                currentItem.sequence.Update(gameObject, Time.deltaTime);
                if (currentItem.sequence.IsComplete())
                    currentQueue.RemoveAt(0);
                else currentQueue[0] = currentItem;
            }
        }

        public virtual void Enqueue(ActionBlockSequence sequence, bool immediatelyEndIfBlockingQueue)
        {
            currentQueue.Add(
                new QueueItem()
                {
                    sequence = sequence,
                    immediatelyCompleteIfBlockingQueue = immediatelyEndIfBlockingQueue
                });
        }

        public virtual void ForceCompleteQueue()
        {
            while (currentQueue.Count > 0)
            {
                var currentItem = currentQueue[0];
                if (currentItem.sequence.IsValid() && !currentItem.sequence.IsComplete())
                    currentItem.sequence.ForceComplete(gameObject, Time.deltaTime);
                currentQueue.RemoveAt(0);
            }
        }
    }
}