using UnityEngine;
using Zenject;

namespace Player
{
    public class CharacterAnimationController
    {
        private static int WALK_ANIMATION = Animator.StringToHash("Walk");
        private static int WALK_WITH_ITEM_ANIMATION = Animator.StringToHash("WithItem");
        private static int JUMP_ANIMATION = Animator.StringToHash("Grounded");

        private Animator animator;

        [Inject]
        public CharacterAnimationController(Animator animator)
        {
            this.animator = animator;
        }

        public void ItemPickedUp(bool withItem) =>
            animator.SetBool(WALK_WITH_ITEM_ANIMATION, withItem);

        public void Walk(bool stop = false)=>
            animator.SetBool(WALK_ANIMATION, stop);

        public void Jump(bool stop = false) =>
            animator.SetBool(JUMP_ANIMATION, stop);
    }
}