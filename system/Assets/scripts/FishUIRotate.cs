using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class FishUIRotate : MonoBehaviour
{
    [SerializeField]
    private Transform _camera = null;

    private void Update ()
    {
        transform.LookAt (_camera);
    }
}