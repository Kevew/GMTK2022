using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{

    public Vector3 resetPosition;
    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            other.transform.position = resetPosition;
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
