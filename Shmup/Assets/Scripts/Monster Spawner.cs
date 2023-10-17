using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _monsterPrefab;
    [SerializeField] private CollisionManager _collisionManager;

    private List<GameObject> _monsters;

    void Start()
    {
        _monsters = new(3);
    }

    void Update()
    {
        for (int i = _monsters.Count - 1; i >= 0; i--)
        {
            if (_monsters[i] == null) _monsters.RemoveAt(i);
        }

        for (int i = _monsters.Count; i < 3; i++)
        {
            GameObject monster = Instantiate(_monsterPrefab);
            monster.transform.position = new(GameInfo.CameraWidth / 2, Random.Range((-GameInfo.CameraHeight/2) + 5, (GameInfo.CameraWidth/2) - 5));

            _monsters.Add(monster);
            _collisionManager.AddEnemy(monster);
        }
    }
}
