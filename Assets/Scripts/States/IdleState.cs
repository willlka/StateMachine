using System;
using UnityEngine;

public class IdleState : BaseState
{
    public override void Initialize()
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Hero.Jump();
    }
}
