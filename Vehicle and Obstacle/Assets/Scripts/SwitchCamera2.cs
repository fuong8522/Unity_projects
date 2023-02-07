using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera2 : MonoBehaviour
{
    public GameObject _camera2;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_camera2.gameObject.activeSelf)
            {
                _camera2.gameObject.SetActive(false);
            }

            else
            {
                _camera2.gameObject.SetActive(true);
            }

        }
    }
}
