using System;
using UnityEngine;

public class JumpState : BaseState
{
    public override void Initialize()
    {
        //Hero.HeroAnim //todo
        Hero.Body.AddForce(new Vector2(0f, Hero.Instance.JumpForce));
        Hero.Idle();
    }

    public override void Update() { }

    public override void End() { }
}
