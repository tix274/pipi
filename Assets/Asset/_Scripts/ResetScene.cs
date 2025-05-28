using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResetScene : MonoBehaviour
{
    [SerializeField] private PlatesInfo _plates;
    [SerializeField] private GateInfo _gate;

    private bool _isStart = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isStart = !_isStart;

            if (!(_isStart == false))
            {
                _gate.ResetScene();
                return;
            }

            _gate.ResetScene();
            _plates.ResetScene();
        }
    }
}
