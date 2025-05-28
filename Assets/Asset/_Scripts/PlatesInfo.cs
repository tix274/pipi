using System.Collections.Generic;
using UnityEngine;

public class Plate
{
    private Transform _objectTransform;

    private Rigidbody _rigidBody;
    private Vector3 _startPos;
    private Quaternion _startRot;

    public Plate(Rigidbody rigidbody, Vector3 startPos, Quaternion startRot)
    {
        _objectTransform = rigidbody.transform;

        _rigidBody = rigidbody;
        _startPos = startPos;
        _startRot = startRot;
    }

    public void ResetState()
    {
        _objectTransform.position = _startPos;
        _objectTransform.rotation = _startRot;

        _rigidBody.linearVelocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;
    }
}

public class PlatesInfo : MonoBehaviour
{
    private GameObject _folder;
    private List<Plate> _plates = new List<Plate>();

    void Start()
    {
        _folder = transform.gameObject;

        for (int i = 0; i < _folder.transform.childCount; i++)
        {
            Transform child = _folder.transform.GetChild(i);
            _plates.Add(new Plate(child.GetComponent<Rigidbody>(), child.position, child.rotation));
        }
    }

    public void ResetScene()
    {
        foreach (Plate plate in _plates)
        {
            plate.ResetState();
        }
    }
}
