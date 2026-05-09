using System;
using UnityEngine;
using UnityEngine.Playables;

namespace ct.ActionBlocks.Blocks
{
    [Serializable]
    public class PlayableDirectorResume : ActionBlockBase
    {
        public PlayableDirector director;
        
        public override bool Execute(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            director.Resume();
            return true;
        }
    }
}