using UnityEngine;

public class WorldSettings : MonoBehaviour
{
    [Header("Game speed settings")]
    [SerializeField] [Range(1f, 5f)] private float _fastDeltaTime = 2f;
    [SerializeField] [Range(0.5f, 1f)] private float _slowDeltaTime = 0.6f;

    private float _fixedDeltaTime;

    private bool _isFast = true;

    private void Awake()
    {
        Time.fixedDeltaTime = 0.01f;
        _fixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_isFast) { Time.timeScale = _slowDeltaTime; _isFast = false; }
            else { Time.timeScale = _fastDeltaTime; _isFast = true; }
            
            Time.fixedDeltaTime = _fixedDeltaTime * Time.timeScale;
        }
    }
}
