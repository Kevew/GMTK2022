using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndlessRunner : MonoBehaviour
{
    public GameObject[] dice;
    public Transform playerHeight;
    public float generateHeight = 20f;

    public float radius;
    float angle;

    public float generateSizeMin;
    public float generateSizeMax;

    public TextMeshProUGUI textGUI;
    public float highest = 0;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void newHighest(float _high)
    {
        if(_high > highest)
        {
            highest = _high;
            textGUI.text = Mathf.Round(highest).ToString();
        }
    }

    void GenerateObjects(float height)
    {
        List<GameObject> newGameObjects = new List<GameObject>();
        int i = Random.Range(3, 6);
        for(int j = 0;j < i; j++)
        {
            int randomG = Random.Range(0, 4);
            angle = Random.Range(0f, 1f) * 2f * 3.14f;
            float r = radius * Mathf.Sqrt(Random.Range(0f, 1f));
            float x = Mathf.Cos(angle) * r;
            float y = Mathf.Sin(angle) * r;
            Debug.Log(x  + "  " + y);
            if(j == 0)
            {
                randomG = 0;
            }
            GameObject a = (GameObject)Instantiate(dice[randomG], transform.position + new Vector3(x, height, y), transform.rotation);
            a.GetComponent<DiceRotation>().RandomRangeValue = Random.Range(0f, 1f);
            bool create = true;
            float generatesize = Random.Range(generateSizeMin, generateSizeMax);
            a.transform.localScale = new Vector3(generatesize, generatesize, generatesize);
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
