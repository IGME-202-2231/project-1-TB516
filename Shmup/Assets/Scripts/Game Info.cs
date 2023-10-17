using System.Collections;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    private static GameObject _manager;
    private static float _cameraHeight;
    private static float _cameraWidth;
    private static bool _globalCooldownUp;
    private static GameObject _playerRef;

    public static float CameraHeight => _cameraHeight;
    public static float CameraWidth => _cameraWidth;
    public static GameObject Manager => _manager;
    public static bool GCDReady => _globalCooldownUp;
    public static GameObject Player
    {
        get
        {
            if (_playerRef == null) _playerRef = GameObject.Find("Manager");

            return _playerRef;
        }
    }

    private void Awake()
    {
        _manager = gameObject;
        _cameraHeight = Camera.main.orthographicSize * 2f;
        _cameraWidth = _cameraHeight * Camera.main.aspect;
        _globalCooldownUp = true;
        _playerRef = GameObject.Find("Player");
    }

    public static IEnumerator StartGCD()
    {
        _globalCooldownUp = false;

        yield return new WaitForSeconds(.5f);

        _globalCooldownUp = true;
    }
}