using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] public Transform camPos;
    void Update()
    {
        transform.position = camPos.position;
    }
}
