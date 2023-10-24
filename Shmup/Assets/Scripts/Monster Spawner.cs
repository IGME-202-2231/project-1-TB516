using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _monsterPrefab;
    [SerializeField] private CollisionManager _collisionManager;
    [SerializeField] private int _maxMonsters = 45;
    [SerializeField] private TextMeshProUGUI _monsterProgressText;

    private List<GameObject> _monsters;
    private bool _canSpawn = true;
    private int _monstersSpawned = 0;
    private int _monstersKilled = 0;

    public int MonstersKilled
    {
        get => _monstersKilled;
        set
        {
            _monstersKilled = value;
        }
    }
    public int MonstersSpawned
    {
        get => _monstersSpawned;
        set
        {
            _monstersSpawned = value;
        }
    }

    void Start()
    {
        _monsters = new(_maxMonsters);
    }

    void Update()
    {
        _monsterProgressText.text = $"Enemies Left\n{_maxMonsters - _monstersKilled}";

        for (int i = _monsters.Count - 1; i >= 0; i--)
        {
            if (_monsters[i] == null) _monsters.RemoveAt(i);
        }

        if (_canSpawn && (_monstersSpawned + 1 <= _maxMonsters))
        {
            GameObject monster = Instantiate(_monsterPrefab);
            monster.transform.position = new(GameInfo.CameraWidth / 2, Random.Range((-GameInfo.CameraHeight / 2) + 5, (GameInfo.CameraWidth / 2) - 5));

            _monsters.Add(monster);
            _collisionManager.AddEnemy(monster);

            _monstersSpawned++;
            

            StartCoroutine(SpawnTimer());
        }
        else if (_monstersKilled == _maxMonsters)
        {
            enabled = false;
            _monsterProgressText.gameObject.SetActive(false);
            _collisionManager.StartBoss();
        }
    }

    private IEnumerator SpawnTimer()
    {
        _canSpawn = false;

        yield return new WaitForSeconds(Random.Range(.2f, 4));

        _canSpawn = true;
    }
}
