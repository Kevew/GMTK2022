using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceCheckJump : MonoBehaviour
{
    private float scale;

    public ParticleSystem pS;

    private Material shaderMat;

    [Header("Flashing Effects")]
    bool isFlashing = false;
    public float intensity = 2f;
    public float maxIntensity = 25f;

    bool isEndless;

    public Transform parentGameObject;

    Color normalColor;
    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Endless")
        {
            isEndless = true;
        }
        else
        {
            isEndless = false;
        }
        shaderMat = GetComponent<MeshRenderer>().material;
        scale = parentGameObject.localScale.x/2;
        normalColor = shaderMat.GetColor("_ColorValue");
    }


    private void FixedUpdate()
    {
        if (isFlashing)
        {
            intensity += Time.deltaTime * maxIntensity;
            if (intensity >= maxIntensity)
            {
                isFlashing = false;
            }
            
            shaderMat.SetColor("_ColorValue", normalColor * intensity);
        }
        if (!isFlashing)
        {
            if (intensity > 2f)
            {
                intensity -= Time.deltaTime * maxIntensity / 2;
                shaderMat.SetColor("_ColorValue", normalColor * intensity);
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (isEndless)
            {
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<EndlessRunner>().newHighest(transform.position.y);
            }
            pS.Play();
            Vector3 globalpos = collision.contacts[0].point;
            List<Vector3> checkPos = new List<Vector3>();
            int changeSpeedValue = 0;
            float mindistance = 99999f;
            //DO NOT CHANGE THIS ORDER
            checkPos.Add(transform.position - transform.right * scale);
            checkPos.Add(transform.position + transform.forward * scale);
            checkPos.Add(transform.position - transform.up * scale);
            checkPos.Add(transform.position + transform.up * scale);
            checkPos.Add(transform.position - transform.forward * scale);
            checkPos.Add(transform.position + transform.right * scale);
            for (int i = 0;i < checkPos.Count; i++)
            {
                float distance = Vector3.Distance(globalpos, checkPos[i]);
                if(distance < mindistance)
                {
                    mindistance = distance;
                    changeSpeedValue = i;
                }
            }
            isFlashing = true;

            collision.gameObject.GetComponent<PlayerMovement>().changeJump(changeSpeedValue);
        }
    }
}
