using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpacetMovementSystem
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour
    {
        [field:Header("References")]
        [field:SerializeField] public PlayerSO Data { get; private set; }
        [field:Header("Collisions")]
        [field:SerializeField] public PlayerCapsuleColliderUtility ColliderUtility { get; private set; }
        [field:SerializeField] public PlayerLayerData LayerData { get; private set; }
        [field: Header("Cameras")]
        [field:SerializeField] public PlayerCameraUtility CameraUtility { get; private set; }

        [field:Header("Animations")]
        [field:SerializeField] public PlayerAnimationData AnimationData { get; private set; }
        public Rigidbody rb { get; private set; }
        public Animator animator { get; private set; }
        public Transform MainCameraTransform { get; private set; }
        public PlayerInput Input { get; private set; }

        private PlayerMovementStateMachine movementStateMachine;
        
        private void Awake()
        {
            movementStateMachine = new PlayerMovementStateMachine(this);
            animator = GetComponentInChildren<Animator>();
            ColliderUtility.Initialize(gameObject);

            ColliderUtility.CaculateCapsuleColliderDimensions();

            CameraUtility.Initialize();

            AnimationData.Initialize();

            rb = GetComponent<Rigidbody>();

            Input = GetComponent<PlayerInput>(); 

            MainCameraTransform = Camera.main.transform;
        }

        private void OnValidate()
        {
            ColliderUtility.Initialize(gameObject);
            ColliderUtility.CaculateCapsuleColliderDimensions();
        }

        private void Start()
        {
   
            movementStateMachine.ChangeState(movementStateMachine.IdlingState);
        }

        private void OnTriggerEnter(Collider collider)
        {
            movementStateMachine.OnTriggerEnter(collider);
        }

        private void OnTriggerExit(Collider collider)
        {
            movementStateMachine.OnTriggerExit(collider);
        }

        private void Update()
        {
            movementStateMachine.HandleInput();

            movementStateMachine.Update();
        }

        private void FixedUpdate()
        {
            movementStateMachine.PhysicsUpdate();
        }

        public void OnMovementStateAnimationEnterEvent()
        {
            movementStateMachine.OnAnimationEnterEvent();
        }

        public void OnMovementStateAnimationExitEvent()
        {
            movementStateMachine.OnAnimationExitEvent();
        }

        public void OnMovementStateAnimationTransitionEvent()
        {
            movementStateMachine.OnAnimationTransitionEvent();
        }
    }
}
