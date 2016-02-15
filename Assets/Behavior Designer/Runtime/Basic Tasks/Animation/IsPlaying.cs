using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
    [TaskCategory("Basic/Animation")]
    [TaskDescription("Returns Success if the animation is currently playing.")]
    public class IsPlaying : Conditional
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("The name of the animation")]
        public SharedString animationName;

        // cache the animation component
        private Animation targetAnimation;

        public override void OnStart()
        {
            targetAnimation = GetDefaultGameObject(targetGameObject.Value).GetComponent<Animation>();
        }

        public override TaskStatus OnUpdate()
        {
            if (targetAnimation == null) {
                Debug.LogWarning("Animation is null");
                return TaskStatus.Failure;
            }
            
            if (string.IsNullOrEmpty(animationName.Value)) {
                return targetAnimation.isPlaying ? TaskStatus.Success : TaskStatus.Failure;
            } else {
                return targetAnimation.IsPlaying(animationName.Value) ? TaskStatus.Success : TaskStatus.Failure;
            }
        }

        public override void OnReset()
        {
            targetGameObject = null;
            animationName.Value = "";
        }
    }
}