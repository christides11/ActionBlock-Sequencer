using UnityEngine;

namespace ct.ActionBlocks
{
    public class ActionBlockSequenceQueuer : MonoBehaviour
    {
        public ActionBlockSequenceQueuePlayer queuePlayer;
        
        [SerializeField] protected ActionBlockSequence sequence;
        [SerializeField] protected bool immediatelyEndIfBlockingQueue;
        
        public virtual void Enqueue()
        {
            queuePlayer.Enqueue(sequence, immediatelyEndIfBlockingQueue);
        }
    }
}