using UnityEngine;

public class StaticInfo : MonoBehaviour
{
    private static GameObject _manager;
    private static float _cameraHeight;
    private static float _cameraWidth;

    public static float CameraHeight => _cameraHeight;
    public static float CameraWidth => _cameraWidth;
    public static GameObject Manager => _manager;

    private void Awake()
    {
        _manager = gameObject;
        _cameraHeight = Camera.main.orthographicSize * 2f;
        _cameraWidth = _cameraHeight * Camera.main.aspect;
    }
}
