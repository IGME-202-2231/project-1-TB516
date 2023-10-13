using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : Singleton<CollisionManager>
{
    List<EntityCollider> _colliders;

    private void Start()
    {
        _colliders = new();
    }

    void Update()
    {

    }
}
