using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpacetMovementSystem
{
    public class PlayerMovementStateMachine :StateMachine
    {
        public Player Player { get; }
        public PlayerStateReusableData ReusableData { get;}
        public PlayerIdlingState IdlingState { get; }
        public PlayerDashingState DashingState { get; }
        public PlayerWalkingState WalkingState { get; }
        public PlayerRunningState RunningState { get; }
        public PlayerSpringtingState SpringtingState { get; }
        public PlayerLightStoppingState LightStoppingState { get; }
        public PlayerMediumStoppingState MediumStoppingState { get; }
        public PlayerHardStoppingState HardStoppingState { get; }
        public PlayerJumpingState JumpingState { get; }
        public PlayerFallingState FallingState { get; }
        public PlayerLightLandingState LightingLandingState { get; }
        public PlayerRollingState RollingState { get; }
        public PlayerHardLandingState HardLandingState { get; }
        public PlayerMovementStateMachine(Player player)
        {
            Player = player;
            ReusableData = new PlayerStateReusableData();

            IdlingState = new PlayerIdlingState(this);

            WalkingState = new PlayerWalkingState(this);

            RunningState = new PlayerRunningState(this);

            SpringtingState = new PlayerSpringtingState(this);

            DashingState = new PlayerDashingState(this);

            LightStoppingState = new PlayerLightStoppingState(this);

            MediumStoppingState = new PlayerMediumStoppingState(this);

            HardStoppingState = new PlayerHardStoppingState(this);

            JumpingState = new PlayerJumpingState(this);

            FallingState = new PlayerFallingState(this);

            LightingLandingState = new PlayerLightLandingState(this);

            HardLandingState = new PlayerHardLandingState(this);

            RollingState = new PlayerRollingState(this);
        }
    }
}
