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
public class Hero : MonoBehaviour
{
    public Sprite FacingRight;
    public Sprite FacingLeft;
    public Sprite FacingForward;
    public float MoveForce = 365f;          // Amount of force added to move the player left and right.
    public float MaxSpeed = 5f;             // The fastest the player can travel in the x axis.
    public float JumpForce = 300f;			// Amount of force added when the player jumps.


    public static Hero Instance { get; private set; }
    public static HeroState CurrentState;
    public static Rigidbody2D Body;
    public static HeroDirection Direction = HeroDirection.Forward;
    public static Animator HeroAnim;

    private static Dictionary<HeroState, BaseState> stateDictionary { get { return Instance.instanceStateDictionary; } set { } }
    private Dictionary<HeroState, BaseState> instanceStateDictionary;
    private static SpriteRenderer spriteRenderer;

    private void Awake()
    {
        Instance = this;
        instanceStateDictionary = new Dictionary<HeroState, BaseState>();
        instanceStateDictionary.Add(HeroState.Idle, new IdleState());
        instanceStateDictionary.Add(HeroState.Run, new RunState());
        instanceStateDictionary.Add(HeroState.Jump, new JumpState());
        instanceStateDictionary.Add(HeroState.Sit, new SitState());
        instanceStateDictionary.Add(HeroState.AttackTypeOne, new AttackTypeOneState());
        instanceStateDictionary.Add(HeroState.AttackTypeTwo, new AttackTypeTwoState());

        spriteRenderer = GetComponent<SpriteRenderer>();
        Body = GetComponent<Rigidbody2D>();

        if (spriteRenderer == null)
            Debug.LogError("Hero script should be near SpriteRenderer component");
    }

    private void Update()
    {
        stateDictionary[CurrentState].Update();
    }

    public static void SetHeroDirection(HeroDirection direction)
    {
        if (direction == HeroDirection.Forward)
            spriteRenderer.sprite = Instance.FacingForward;
        else if (direction == HeroDirection.Right)
            spriteRenderer.sprite = Instance.FacingRight;
        else if (direction == HeroDirection.Left)
            spriteRenderer.sprite = Instance.FacingLeft;

        Direction = direction;
    }

    public static void Idle()
    {
        stateDictionary[CurrentState].End();
        CurrentState = HeroState.Idle;
        stateDictionary[CurrentState].Initialize();
    }

    public static void Run()
    {
        stateDictionary[CurrentState].End();
        CurrentState = HeroState.Run;
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
