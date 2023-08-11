using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGate : MonoBehaviour
{
    [SerializeField] Animator anm;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Playerr"))
        {
            anm.SetBool("OpenGate", true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Playerr"))
        {
            anm.SetBool("OpenGate", false);
        }
    }
}
