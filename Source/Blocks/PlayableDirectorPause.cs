using System;
using UnityEngine;
using UnityEngine.Playables;

namespace ct.ActionBlocks.Blocks
{
    [Serializable]
    public class PlayableDirectorPause : ActionBlockBase
    {
        public PlayableDirector director;
        
        public override bool Execute(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            director.Pause();
            return true;
        }
    }
}