using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpacetMovementSystem
{
    public class PlayerInput : MonoBehaviour
    {
        public PlayerInputActions InputActions { get; private set; }

        public PlayerInputActions.PlayerActions PlayerActions { get; private set; }

        private void Awake()
        {
            InputActions = new PlayerInputActions();

            PlayerActions = InputActions.Player;
        }

        private void OnEnable()
        {
            InputActions.Enable();
        }

        private void OnDisable()
        {
            InputActions.Disable();
        }


        public void DisableActionFor(InputAction action,float seconds)
        {
            StartCoroutine(DisableActionCoroutine(action, seconds));
        }

        private IEnumerator DisableActionCoroutine(InputAction action, float seconds)
        {
            action.Disable();

            yield return new WaitForSeconds(seconds);

            action.Enable();
        }
    }
}
