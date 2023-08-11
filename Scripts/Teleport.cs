using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject cube1;
    [SerializeField] GameObject cube2;
    [SerializeField] int addHooks;
    [SerializeField] Vector3 transport;
    [SerializeField] Teleport otherObject;
    [SerializeField] GrapplingGun grappleGunScript;
    public bool touched;
    public bool setEnableFalse;
    public bool once2=true;
    [Header("Question Section")]
    [SerializeField] public bool askQuestion;
    [SerializeField] public Rigidbody playeRB;
    [SerializeField] public GameObject QuestionCanvas;
    [SerializeField] public GameObject theQuestion;
    [SerializeField] public PlayerCamera cam;
    public bool TF;
    [SerializeField] public int quest_id;
    [SerializeField] public string quest_answer;
    public bool allowed = false;
    public bool doOnce = true;
    public bool finish;
    private void OnCollisionStay(Collision collision)
    {
        if (askQuestion)
        {
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            if (doOnce)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                cam.enabled = false;
                QuestionCanvas.SetActive(true);
                theQuestion.SetActive(true);
                playeRB.useGravity = false;
                Question.instance.whichQuestion(quest_id, quest_answer, QuestionCanvas, theQuestion, gameObject.GetComponent<Teleport>());
                doOnce = false;
            }
            if (finish)
            {
                return;
            }
            if (collision.transform.CompareTag("Playerr") && allowed == true)
            {
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                cam.enabled = true;
                collision.gameObject.transform.localPosition = transport;

            }
            OpenGate();
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            touched = true;
            if (collision.transform.CompareTag("Playerr"))
            {
                collision.gameObject.transform.localPosition = transport;
            }
            OpenGate();
            if (gameObject.GetComponent<changeSky>() != null)
                gameObject.GetComponent<changeSky>().enabled = true;

            if (grappleGunScript != null)
                grappleGunScript.remainingHook += addHooks;
        }

    }
    public void OpenGate()
    {
        if (otherObject != null && once2 == true)
        {
            once2 = false;
            if (otherObject.touched == true)
            {
                if (setEnableFalse == true)
                {

                    if (cube1.GetComponent<Collider>().enabled == false)
                    {
                        print("d");

                        cube1.GetComponent<Collider>().enabled = true;
                        cube1.GetComponent<MeshRenderer>().enabled = true;
                        cube2.GetComponent<Collider>().enabled = false;
                        cube2.GetComponent<MeshRenderer>().enabled = false;

                    }
                    else
                    {
                        print("e");

                        cube1.GetComponent<Collider>().enabled = false;
                        cube1.GetComponent<MeshRenderer>().enabled = false;
                        cube2.GetComponent<Collider>().enabled = true;
                        cube2.GetComponent<MeshRenderer>().enabled = true;
                    }
                    return;
                }
                print("a");
                if (cube1.GetComponent<Collider>().enabled == false)
                {
                    print("b");

                    cube1.GetComponent<Collider>().enabled = true;
                    cube1.GetComponent<MeshRenderer>().enabled = true;
                    cube2.GetComponent<Collider>().enabled = true;
                    cube2.GetComponent<MeshRenderer>().enabled = true;

                }
                else
                {
                    print("c");

                    cube1.GetComponent<Collider>().enabled = false;
                    cube1.GetComponent<MeshRenderer>().enabled = false;
                    cube2.GetComponent<Collider>().enabled = false;
                    cube2.GetComponent<MeshRenderer>().enabled = false;
                }
                

            }
        }
    }
}
