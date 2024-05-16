using UnityEngine;

namespace JAM.Movement
{
    public class PlayerMovementController : MovementBase, IPlayerMovement
    {
        public void SetMovementInput(Vector2 moveInput)
        {
            _movementInput = new Vector2(moveInput.x, moveInput.y);
        }
    }
}
