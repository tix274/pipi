using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateInfo : MonoBehaviour {

    [SerializeField] private GameObject _gate;
    [SerializeField] private Rigidbody _sphere;

	private Vector3 _sphereStartPos;
	
	void Start () {
        _sphereStartPos = _sphere.transform.position;
	}

	public void ResetScene()
	{
        if (_gate.activeInHierarchy == true)
		{
            _gate.SetActive(false);
        }
		else
		{
            _gate.SetActive(true);
            _sphere.transform.position = _sphereStartPos;
            _sphere.linearVelocity = Vector3.zero;
            _sphere.angularVelocity = Vector3.zero;
        }
    }
}
