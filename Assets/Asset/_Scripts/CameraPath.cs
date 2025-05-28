using System.Collections.Generic;
using UnityEngine;

public class CameraPath : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [Header("Orbit's settings")]
    [SerializeField] [Range(0f, 100f)] private float _radius = 5f;
    [SerializeField] [Range(0f, 1f)] private float _speed = 0.1f;
    [SerializeField] private bool _clockwise = true;

    private float angle = 0f;
    private float initialY;

    private const float FULLCIRCLE = 360f;

    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        if (_target == null) return;

        float constSpeed = _speed * Time.unscaledDeltaTime;

        float direction = _clockwise ? -1f : 1f;
        angle += direction * constSpeed * FULLCIRCLE;
        angle %= 360f;

        float rad = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(rad) * _radius;
        float z = Mathf.Sin(rad) * _radius;

        transform.position = new Vector3(_target.position.x + x, initialY, _target.position.z + z);

        Vector3 lookTarget = new Vector3(_target.position.x, _target.position.y, _target.position.z);
        transform.LookAt(lookTarget);
    }
}
