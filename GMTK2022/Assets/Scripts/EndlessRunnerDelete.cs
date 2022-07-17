using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunnerDelete : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag != "Player" && collision.transform.tag != "StartingPoint")
        {
            Destroy(collision.gameObject);
        }
    }
}
