using System.Collections.Generic;
using UnityEngine;

public enum HeroState
{
    Idle,
    Run,
    Jump,
    Sit,
    AttackTypeOne,
    AttackTypeTwo
}

public enum HeroDirection
{
    Forward,
    Left,
    Right
}

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Hero : MonoBehaviour
{
    public float MoveForce = 365f;          // Amount of force added to move the player left and right.
    public float MaxSpeed = 5f;             // The fastest the player can travel in the x axis.
    public float JumpForce = 300f;			// Amount of force added when the player jumps.


    public static Hero Instance { get; private set; }
    public static HeroState CurrentState;
    public static Rigidbody2D Body;
    public static HeroDirection Direction { get; private set; }
    public static Animator HeroAnim;

    private static Dictionary<HeroState, BaseState> stateDictionary { get { return Instance.instanceStateDictionary; } set { } }
    private Dictionary<HeroState, BaseState> instanceStateDictionary;
    private static SpriteRenderer spriteRenderer;

    private void Awake()
    {
        Instance = this;
        Direction = HeroDirection.Forward;
        instanceStateDictionary = new Dictionary<HeroState, BaseState>();
        instanceStateDictionary.Add(HeroState.Idle, new IdleState());
        instanceStateDictionary.Add(HeroState.Run, new RunState());
        instanceStateDictionary.Add(HeroState.Jump, new JumpState());
        instanceStateDictionary.Add(HeroState.Sit, new SitState());
        instanceStateDictionary.Add(HeroState.AttackTypeOne, new AttackTypeOneState());
        instanceStateDictionary.Add(HeroState.AttackTypeTwo, new AttackTypeTwoState());

        spriteRenderer = GetComponent<SpriteRenderer>();
        Body = GetComponent<Rigidbody2D>();
        HeroAnim = GetComponent<Animator>();

        if (spriteRenderer == null)
            Debug.LogError("Hero script should be near SpriteRenderer component");

        if (Body == null)
            Debug.LogError("Hero script should be near Rigidbody2D component");

        if (HeroAnim == null)
            Debug.LogError("Hero script should be near Animator component");
    }

    private void Update()
    {
        stateDictionary[CurrentState].Update();
    }

    public static void SetHeroDirection(HeroDirection direction)
    {
        Direction = direction;
    }

    public static void Idle() { SetHeroState(HeroState.Idle); }

    public static void Run() { SetHeroState(HeroState.Run); }

    public static void Jump() { SetHeroState(HeroState.Jump); }

    public static void Sit() { SetHeroState(HeroState.Sit); }

    public static void AttackTypeOne() { SetHeroState(HeroState.AttackTypeOne); }

    public static void AttackTypeTwo() { SetHeroState(HeroState.AttackTypeTwo); }

    private static void SetHeroState(HeroState state)
    {
        stateDictionary[CurrentState].End();
        CurrentState = state;
        stateDictionary[CurrentState].Initialize();
    }
}
