using UnityEngine;

public interface IAttackable : IDamageable
{
    public Vector3 Position { get; }
}