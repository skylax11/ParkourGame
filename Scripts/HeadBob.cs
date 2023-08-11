using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 swayPos;
    [SerializeField] Quaternion startRot;
    [SerializeField] Quaternion swayRot;


    [SerializeField] float slerpSpeed;
    [SerializeField] float intensity;
    [SerializeField] float Aimintensity;
    private void Start()
    {

    }
    public void doSway()
    {
        float x = Input.GetAxis("Mouse X") * totalIntensity();
        float y = Input.GetAxis("Mouse Y") * totalIntensity();
        Quaternion xrot = Quaternion.AngleAxis(-y, Vector3.right);
        Quaternion yrot = Quaternion.AngleAxis(x, Vector3.up);
        Quaternion rot = xrot * yrot;
        gameObject.transform.localRotation = Quaternion.Lerp(gameObject.transform.localRotation, rot, slerpSpeed * Time.deltaTime);
    }
    void Update()
    {
        doSway();
    }
    float totalIntensity()
    {
       
        return intensity;
        
    }
}
