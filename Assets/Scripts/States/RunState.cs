using System;
using UnityEngine;

public class RunState : BaseState
{
    public override void Initialize()
    {
        
    }

    public override void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < Mathf.Epsilon && horizontal > -Mathf.Epsilon)
        {
            Hero.Idle();
            return;
        }

        // The Speed animator parameter is set to the absolute value of the horizontal input.
        //anim.SetFloat("Speed", Mathf.Abs(h)); // todo

        if (horizontal * Hero.Body.velocity.x < Hero.Instance.MaxSpeed)
            Hero.Body.AddForce(Vector2.right * horizontal * Hero.Instance.MoveForce);

        if (Mathf.Abs(Hero.Body.velocity.x) > Hero.Instance.MaxSpeed)
            Hero.Body.velocity = new Vector2(Mathf.Sign(Hero.Body.velocity.x) * Hero.Instance.MaxSpeed, Hero.Body.velocity.y);

        if (horizontal > Mathf.Epsilon && Hero.Direction != HeroDirection.Right)
            Hero.SetHeroDirection(HeroDirection.Right);
        else if (horizontal < -Mathf.Epsilon && Hero.Direction != HeroDirection.Left)
            Hero.SetHeroDirection(HeroDirection.Left);
    }

    public override void End()
    {
    }
}
