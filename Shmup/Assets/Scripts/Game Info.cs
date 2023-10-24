using System.Collections;
using TMPro;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    private static CollisionManager _collisionManager;
    private static MonsterSpawner _spawner;
    private static GameObject _playerRef;
    private static TextMeshProUGUI _scoreElement;
    private static float _cameraHeight;
    private static float _cameraWidth;
    private static bool _globalCooldownUp;
    private static int _points = 0;

    public static float CameraHeight => _cameraHeight;
    public static float CameraWidth => _cameraWidth;
    public static CollisionManager CollisionManager => _collisionManager;
    public static bool GCDReady => _globalCooldownUp;
    public static MonsterSpawner Spawner => _spawner;
    public static GameObject Player
    {
        get
        {
            if (_playerRef == null)
            {
                _playerRef = _collisionManager.gameObject;
            }

            return _playerRef;
        }
    }
    public static int Score
    {
        get => _points;
        set
        {
            _points = value;
            _scoreElement.text = "Score: " + _points;
        }
    }

    private void Awake()
    {
        _cameraHeight = Camera.main.orthographicSize * 2f;
        _cameraWidth = _cameraHeight * Camera.main.aspect;
        _playerRef = GameObject.Find("Player");
        _collisionManager = GetComponent<CollisionManager>();
        _spawner = GetComponent<MonsterSpawner>();
        _scoreElement = GameObject.Find("Progress").GetComponent<TextMeshProUGUI>();

        StartCoroutine(StartGCD());
    }

    public static IEnumerator StartGCD()
    {
        _globalCooldownUp = false;

        yield return new WaitForSeconds(.5f);

        _globalCooldownUp = true;
    }
}