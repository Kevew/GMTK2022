using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheck : MonoBehaviour
{
    private float scale;

    public ParticleSystem pS;


    private void Start()
    {
        scale = transform.localScale.x/2;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            pS.Play();
            Vector3 globalpos = collision.contacts[0].point;
            List<Vector3> checkPos = new List<Vector3>();
            int changeSpeedValue = 0;
            float mindistance = 99999f;
            checkPos.Add(transform.position + transform.up * scale);
            checkPos.Add(transform.position + transform.right * scale);
            checkPos.Add(transform.position - transform.right * scale);
            checkPos.Add(transform.position + transform.forward * scale);
            checkPos.Add(transform.position - transform.forward * scale);
            checkPos.Add(transform.position - transform.up * scale);
            for (int i = 0;i < checkPos.Count; i++)
            {
                float distance = Vector3.Distance(globalpos, checkPos[i]);
                if(distance < mindistance)
                {
                    mindistance = distance;
                    changeSpeedValue = i + 1;
                }
            }


            collision.gameObject.GetComponent<PlayerMovement>().changeSpeed(changeSpeedValue);
        }
    }
}
