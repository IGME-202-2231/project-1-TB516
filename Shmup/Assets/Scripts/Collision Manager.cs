using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private EntityCollider _playerCollider;
    private List<EntityCollider> _enemies;
    private List<EntityCollider> _playerProjectiles;
    private List<EntityCollider> _enemyProjectiles;
    private List<EntityCollider> _collidersToRemove;
    [SerializeField] private BossCollider _boss;

    private void Start()
    {
        _enemies = new();
        _playerProjectiles = new();
        _enemyProjectiles = new();
        _collidersToRemove = new();
    }

    void Update()
    {
        RunCollisionCheck(_playerCollider, _enemyProjectiles);
        RunCollisionCheck(_playerCollider, _enemies);
        RunCollisionCheck(_enemies, _playerProjectiles);

        if (_boss.isActiveAndEnabled)
        {
            BossCollisionCheck(_boss, _playerProjectiles);
            BossCollisionCheck(_boss, _playerCollider);
        }

        if (_playerCollider == null)
        {
            GameStateManager.GameOver();
        }

        for (int i = 0; i < _collidersToRemove.Count; i++)
        {
            _enemies.Remove(_collidersToRemove[i]);
            _enemyProjectiles.Remove(_collidersToRemove[i]);
            _playerProjectiles.Remove(_collidersToRemove[i]);
        }
        _collidersToRemove.Clear();
    }

    private void RunCollisionCheck(EntityCollider collider, List<EntityCollider> colliderSet)
    {
        for (int j = 0; j < colliderSet.Count; j++)
        {
            if (collider != null && colliderSet[j] != null && collider.IsCollidingWith(colliderSet[j]))
            {
                Destroy(collider);
                Destroy(colliderSet[j].gameObject);

                _collidersToRemove.Add(collider);
                _collidersToRemove.Add(colliderSet[j]);
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

                    _collidersToRemove.Add(colliderSetOne[i]);
                    _collidersToRemove.Add(colliderSetTwo[j]);
                }
            }
        }
    }

    private void BossCollisionCheck(BossCollider boss, List<EntityCollider> colliderSet)
    {
        for (int i = 0; i < colliderSet.Count; i++)
        {
            BossCollisionCheck(boss, colliderSet[i]);
        }
    }

    private void BossCollisionCheck(BossCollider boss, EntityCollider collider)
    {
        if (collider != null && boss != null && boss.IsCollidingWith(collider))
        {
            boss.Hp -= 1;

            Destroy(collider.gameObject);
            _collidersToRemove.Add(collider);
        }
    }

    public void MarkToRemove(EntityCollider collider)
    {
        _collidersToRemove.Add(collider);
    }

    public void AddEnemy(GameObject enemy)
    {
        _enemies.Add(enemy.GetComponent<EntityCollider>());
    }

    public void AddProjectile(EntityCollider collider)
    {
        if (collider.gameObject.tag == "enemyProjectile")
        {
            _enemyProjectiles.Insert(0, collider);
        }
        else if (collider.gameObject.tag == "PlayerProjectile")
        {
            _playerProjectiles.Insert(0, collider);
        }
    }

    public void StartBoss()
    {
        _boss.gameObject.SetActive(true);
    }
}
