using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.StickyNote;

public class changeSky : MonoBehaviour
{
    [SerializeField] Material colorStart, colorEnd;
    void Start()
    {

    }

    void Update()
    {
        RenderSettings.skybox.Lerp(colorStart, colorEnd,0.1f);
    }
}
