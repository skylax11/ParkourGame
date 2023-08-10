using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class againstOf : MonoBehaviour
{
    bool once = true;
    GameObject copy;
    [SerializeField] GameObject player;
    [SerializeField] GameObject remote;
    private void Start()
    {
       copy = new GameObject();

    }
    private void OnCollisionEnter(Collision collision)
    {
        print("a");
        if (collision.transform.CompareTag("Playerr") && once == true)
        {
            once = false;
            copy = Instantiate(remote, player.transform.position + new Vector3(20, 0, 0), Quaternion.identity);
            print(copy.name);
        }
    }
}
