using System;
using UnityEngine;

public class IdleState : BaseState
{
    public override void Initialize()
    {
        Hero.SetHeroDirection(HeroDirection.Forward);
    }

    public override void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Hero.CurrentState != HeroState.Run && (horizontal > Mathf.Epsilon || horizontal < -Mathf.Epsilon))
            Hero.Run();
        else if (Hero.CurrentState == HeroState.Run && horizontal < Mathf.Epsilon && horizontal > -Mathf.Epsilon)
            Hero.Idle();

        if (Input.GetButtonDown("Jump"))
            Hero.Jump();
    }

    public override void End() { }
}
