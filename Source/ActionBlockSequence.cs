using System;
using ct.ActionBlocks.Blocks;
using UnityEngine;

namespace ct.ActionBlocks
{
    [Serializable]
    public struct ActionBlockSequence
    {
        public int id;
        [SerializeReference, SubclassSelector]
        public ActionBlockBase[] actionList;
        public int currentIndex;
        public float timer;
        public float blockTimer;
        public float deltaTime;
        public Action onCompleteAction;
        
        public void Reset()
        {
            currentIndex = 0;
            timer = 0;
            blockTimer = 0;
        }
        
        public void Update(GameObject executedBy, float deltaTime)
        {
            if (IsComplete()) return;

            this.deltaTime = deltaTime;
            while (true)
            {
                if (currentIndex >= actionList.Length) break;
                var action = actionList[currentIndex];

                if (!action.Execute(executedBy, ref this)) break;
                currentIndex++;
                blockTimer = 0;
            }
            
            if (IsComplete())
            {
                onCompleteAction?.Invoke();
                Debug.Log("Complete");
                return;
            }
            
            timer += deltaTime;
            blockTimer += deltaTime;
        }

        public void ForceComplete(GameObject executedBy, float deltaTime)
        {
            if (!IsValid() || IsComplete()) return;
            this.deltaTime = deltaTime;
            while (currentIndex < actionList.Length)
            {
                var action = actionList[currentIndex];
                action.ForceComplete(executedBy, ref this);
                currentIndex++;
                blockTimer = 0;
            }
            onCompleteAction?.Invoke();
        }

        public bool IsValid()
        {
            return actionList != null;
        }
        
        public bool IsComplete()
        {
            if(actionList == null) return false;
            return currentIndex >= actionList.Length;
        }
    }
}