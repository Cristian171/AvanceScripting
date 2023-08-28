using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Animator anim);
}

public class Jump : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isJumping");
    }
}
public class MoveFoward : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isWalking");
    }
}
public class DoNothing : Command
{
    public override void Execute(Animator anim)
    {
        
    }
}