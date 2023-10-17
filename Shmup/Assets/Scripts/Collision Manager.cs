using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : Singleton<CollisionManager>
{
    [SerializeField] private EntityCollider _playerCollider;
    private List<EntityCollider> _enemies;
    private List<EntityCollider> _playerProjectiles;
    private List<EntityCollider> _enemyProjectiles;

    private void Start()
    {
        _enemies = new();
        _playerProjectiles = new();
        _enemyProjectiles = new();
    }

    void Update()
    {
        for (int i = _enemies.Count - 1; i >= 0; i--)
        {
            if (_enemies[i] == null) _enemies.RemoveAt(i);
        }
        for (int i = _playerProjectiles.Count - 1; i >= 0; i--)
        {
            if (_playerProjectiles[i] == null) _playerProjectiles.RemoveAt(i);
        }
        for (int i = _enemyProjectiles.Count - 1; i >= 0; i--)
        {
            if (_enemyProjectiles[i] == null) _enemyProjectiles.RemoveAt(i);
        }

        RunCollisionCheck(_playerCollider, _enemyProjectiles);
        RunCollisionCheck(_playerCollider, _enemies);
        RunCollisionCheck(_enemies, _playerProjectiles);
    }

    private void RunCollisionCheck(EntityCollider collider, List<EntityCollider> colliderSet)
    {
        for (int j = 0; j < colliderSet.Count; j++)
        {
            if (collider != null && colliderSet[j] != null && collider.IsCollidingWith(colliderSet[j]))
            {
                Destroy(collider.gameObject);
                Destroy(colliderSet[j].gameObject);
            }
        }
    }

    private void RunCollisionCheck(List<EntityCollider> colliderSetOne, List<EntityCollider> colliderSetTwo)
    {
        for (int i = 0; i < colliderSetOne.Count; i++)
        {
            for (int j = 0; j < colliderSetTwo.Count; j++)
            {
                if (colliderSetOne[i] != null && colliderSetTwo[j] != null && colliderSetOne[i].IsCollidingWith(colliderSetTwo[j]))
                {
                    Destroy(colliderSetOne[i].gameObject);
                    Destroy(colliderSetTwo[j].gameObject);
                }
            }
        }
    }

    public void AddEnemy(GameObject enemy)
    {
        _enemies.Add(enemy.GetComponent<EntityCollider>());
    }

    public void AddProjectile(EntityCollider collider)
    {
        if (collider.gameObject.tag == "enemy")
        {
            _enemyProjectiles.Insert(0, collider);
        }
        else if (collider.gameObject.tag == "Player")
        {
            _playerProjectiles.Insert(0, collider);
        }
    }
}
