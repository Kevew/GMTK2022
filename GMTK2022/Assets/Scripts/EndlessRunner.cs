using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunner : MonoBehaviour
{
    public GameObject dice;
    public Transform playerHeight;
    public float generateHeight = 20f;

    public float radius;
    float angle;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(generateHeight <= playerHeight.position.y + 500f)
        {
            GenerateObjects(generateHeight);
            generateHeight += Random.Range(13f, 20f);
        }
    }

    void GenerateObjects(float height)
    {
        List<GameObject> newGameObjects = new List<GameObject>();
        int i = Random.Range(2, 3);
        for(int j = 0;j < i; j++)
        {
            angle = Random.Range(0f, 1f) * 2f * 3.14f;
            float r = radius * Mathf.Sqrt(Random.Range(0f, 1f));
            float x = Mathf.Cos(angle) * r;
            float y = Mathf.Sin(angle) * r;
            Debug.Log(x  + "  " + y);
            GameObject a = (GameObject)Instantiate(dice, transform.position + new Vector3(x, height, y), transform.rotation);
            bool create = true;
            foreach(GameObject b in newGameObjects)
            {
                if (Vector3.Distance(b.transform.position, a.transform.position) <= 4f)
                {
                    create = false;
                }
            }
            if (!create)
            {
                Destroy(a);
                j--;
                continue;
            }
            else
            {
                newGameObjects.Add(a);
            }
        }
    }
}
