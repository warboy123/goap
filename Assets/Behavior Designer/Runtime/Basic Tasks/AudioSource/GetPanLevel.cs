#if UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Stores the pan level value of the AudioSource. Returns Success.")]
    public class GetPanLevel : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("The pan level value of the AudioSource")]
        [RequiredField]
        public SharedFloat storeValue;

        private AudioSource audioSource;

        public override void OnStart()
        {
            audioSource = GetDefaultGameObject(targetGameObject.Value).GetComponent<AudioSource>();
        }

        public override TaskStatus OnUpdate()
        {
            if (audioSource == null) {
                Debug.LogWarning("AudioSource is null");
                return TaskStatus.Failure;
            }

            storeValue.Value = audioSource.panLevel;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            storeValue = 1;
        }
    }
}
#endif