using System;
using UnityEngine;
using UnityEngine.Playables;

namespace ct.ActionBlocks.Blocks
{
    [Serializable]
    public class PlayableDirectorPlay : ActionBlockBase
    {
        public PlayableDirector director;
        public PlayableAsset asset;
        
        public override bool Execute(GameObject gameObject, ref ActionBlockSequence sequence)
        {
            director.Play(asset);
            return true;
        }
    }
}