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
        Attack
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
        instanceStateDictionary.Add(HeroState.Jump, new IdleState()); //todo
        instanceStateDictionary.Add(HeroState.Sit, new IdleState()); //todo
        instanceStateDictionary.Add(HeroState.Attack, new IdleState()); //todo
    }

    public static void UpdateCurrentState()
    {
        stateDictionary[CurrentState].Update();
    }

    public static void Jump()
    {
        stateDictionary[HeroState.Jump].Initialize();
        CurrentState = HeroState.Jump;
    }

    public static void Sit()
    {
        stateDictionary[HeroState.Sit].Initialize();
        CurrentState = HeroState.Sit;
    }

    public static void Attack()
    {
        stateDictionary[HeroState.Attack].Initialize();
        CurrentState = HeroState.Attack;
    }
}
