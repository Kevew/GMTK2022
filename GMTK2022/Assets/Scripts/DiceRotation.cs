using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRotation : MonoBehaviour
{

    public float yaw;
    public float pitch;
    public float zRot;

    float yawChange = 0f;
    float pitchChange = 0f;
    float zChange;

    public float RandomRangeValue;
    private float randomYaw;
    private float randomPitch;
    private float randomZ;
    // Start is called before the first frame update
    void Start()
    {
        randomYaw = Random.Range(-RandomRangeValue, RandomRangeValue);
        randomPitch = Random.Range(-RandomRangeValue, RandomRangeValue);
        randomZ = Random.Range(-RandomRangeValue, RandomRangeValue);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(RandomRangeValue != 0)
        {
            if (yawChange < randomYaw)
            {
                yawChange += Time.deltaTime;
                if (yawChange >= randomYaw)
                {
                    newRotate();
                }
            }
            else
            {
                yawChange -= Time.deltaTime;
                if (yawChange <= randomYaw)
                {
                    newRotate();
                }
            }

            if (pitchChange < randomPitch)
            {
                pitchChange += Time.deltaTime;
                if (pitchChange >= randomPitch)
                {
                    newRotate();
                }
            }
            else
            {
                pitchChange -= Time.deltaTime;
                if (pitchChange <= randomPitch)
                {
                    newRotate();
                }
            }

            if (zChange < randomPitch)
            {
                zChange += Time.deltaTime;
                if (zChange >= randomZ)
                {
                    newRotate();
                }
            }
            else
            {
                zChange -= Time.deltaTime;
                if (zChange <= randomZ)
                {
                    newRotate();
                }
            }
            yaw += yawChange;
            pitch += pitchChange;
            zRot += zChange;
            var desiredRotation = Quaternion.Euler(pitch, yaw, zRot);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * 20f);
        }
    }

    void newRotate()
    {
       randomYaw = Random.Range(-RandomRangeValue, RandomRangeValue);
        randomPitch = Random.Range(-RandomRangeValue, RandomRangeValue);
        randomZ = Random.Range(-RandomRangeValue, RandomRangeValue);
    }
}
