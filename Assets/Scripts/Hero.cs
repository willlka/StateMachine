using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public enum HeroState
    {
        Idle,
        Run,
        Jump,
        Sit,
        AttackTypeOne,
        AttackTypeTwo
    }

    public static Hero Instance { get; private set; }
    public static HeroState CurrentState;

    private static Dictionary<HeroState, BaseState> stateDictionary { get { return Instance.instanceStateDictionary; } set { } }
    private Dictionary<HeroState, BaseState> instanceStateDictionary;

    private void Awake()
    {
        Instance = this;
        instanceStateDictionary = new Dictionary<HeroState, BaseState>();
        instanceStateDictionary.Add(HeroState.Idle, new IdleState());
        instanceStateDictionary.Add(HeroState.Run, new RunState());
        instanceStateDictionary.Add(HeroState.Jump, new JumpState());
        instanceStateDictionary.Add(HeroState.Sit, new SitState());
        instanceStateDictionary.Add(HeroState.AttackTypeOne, new AttackTypeOne());
        instanceStateDictionary.Add(HeroState.AttackTypeTwo, new AttackTypeTwo());
    }

    public static void UpdateCurrentState()
    {
        stateDictionary[CurrentState].Update();
    }

    public static void Idle()
    {
        stateDictionary[CurrentState].End();
        CurrentState = HeroState.Idle;
        stateDictionary[CurrentState].Initialize();
    }

    public static void Jump()
    {
        stateDictionary[CurrentState].End();
        CurrentState = HeroState.Jump;
        stateDictionary[CurrentState].Initialize();
    }

    public static void Sit()
    {
        stateDictionary[CurrentState].End();
        CurrentState = HeroState.Sit;
        stateDictionary[CurrentState].Initialize();
    }

    public static void AttackTypeOne()
    {
        stateDictionary[CurrentState].End();
        CurrentState = HeroState.AttackTypeOne;
        stateDictionary[CurrentState].Initialize();
    }

    public static void AttackTypeTwo()
    {
        stateDictionary[CurrentState].End();
        CurrentState = HeroState.AttackTypeTwo;
        stateDictionary[CurrentState].Initialize();
    }
}
