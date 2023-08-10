using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCamera : MonoBehaviour
{
    public static PlayerCamera Instance;
    public float sensX;
    public float sensY;
    public bool letMeDoIt = true;
    public Transform orientation;
    public Transform camholder;

    public bool turnedOnce = false;
    public float yRot;
    public float xRot;
    void Start()
    {
        Instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        yRot += mouseX;
        xRot -= mouseY;

        xRot = Mathf.Clamp(xRot, -90f, 90f);



        camholder.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);

    }
    /*public void doRotation(GameObject hit)
    {
        if (PlayerMovementAdvanced.Instance.isWallRunning)
        {
            letMeDoIt = false;
            if (PlayerMovementAdvanced.Instance.isWallRight && hit.transform.rotation.y > 0f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(1.607f, 92.941f, 28.622f), 6f * Time.deltaTime);
                print(hit.name);
            }
            else if (PlayerMovementAdvanced.Instance.isWallRight && hit.transform.rotation.y < 0f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(2f,-40f, 30f), 6f * Time.deltaTime);
            }
            else if (PlayerMovementAdvanced.Instance.isWallLeft && hit.transform.rotation.y > 0f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-1.607f, -92.941f, -28.622f), 6f * Time.deltaTime);
                print(hit.name);

            }
            else if (PlayerMovementAdvanced.Instance.isWallLeft && hit.transform.rotation.y < 0f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-2f, 40, -30f), 6f * Time.deltaTime);
            }

        }
    }
    public void StopRotation()
    {
        StartCoroutine(SetCamera());
    }
    IEnumerator SetCamera()
    {
        turnedOnce = true;
        yield return new WaitForSeconds(0.5f);
        letMeDoIt = true;
    }*/
    public void DoFov(float endValue)
    {
        GetComponent<Camera>().DOFieldOfView(endValue, 0.25f);
    }
    public void DoTilt(float zTilt)
    {
        transform.DOLocalRotate(new Vector3(0, 0, zTilt),0.25f);
    }

}
