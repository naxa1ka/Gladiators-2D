using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : Character
{
    public override void ReceiveDamage(float damage)
    {
        ReceivingDamage(damage);
    }
}