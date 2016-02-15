using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Start a new behavior tree and return success after it has been started.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=20")]
    [TaskIcon("{SkinColor}StartBehaviorTreeIcon.png")]
    public class StartBehaviorTree : Action
    {
        [Tooltip("The GameObject of the behavior tree that should be started. If null use the current behavior")]
        public SharedGameObject behaviorGameObject;
        [Tooltip("The group of the behavior tree that should be started")]
        public SharedInt group;

        private Behavior behavior;

        public override void OnStart()
        {
            var behaviorTrees = GetDefaultGameObject(behaviorGameObject.Value).GetComponents<Behavior>();
            if (behaviorTrees.Length == 1) {
                behavior = behaviorTrees[0];
            } else if (behaviorTrees.Length > 1) {
                for (int i = 0; i < behaviorTrees.Length; ++i) {
                    if (behaviorTrees[i].Group == group.Value) {
                        behavior = behaviorTrees[i];
                        break;
                    }
                }
                // If the group can't be found then use the first behavior tree
                if (behavior == null) {
                    behavior = behaviorTrees[0];
                }
            }
        }

        public override TaskStatus OnUpdate()
        {
            if (behavior == null) {
                return TaskStatus.Failure;
            }

            // Start the behavior and return success.
            behavior.EnableBehavior();
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            // Reset the properties back to their original values.
            behaviorGameObject = null;
            group = 0;
        }
    }
}