using System;
using UnityEngine;
using UnityEngine.Playables;

namespace ct.ActionBlocks.Blocks
{
    [Serializable]
    public class PlayableDirectorStop : ActionBlockBase
    {
        public PlayableDirector director;
        public bool setToEnd;
        
        public override bool Execute(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            if (setToEnd)
            {
                director.time = director.playableAsset.duration;
                director.Evaluate();
            }
            director.Stop();
            return true;
        }
    }
}