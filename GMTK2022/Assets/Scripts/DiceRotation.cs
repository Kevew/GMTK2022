using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRotation : MonoBehaviour
{

    float yaw;
    float pitch;

    float yawChange = 0f;
    float pitchChange = 0f;

    public float RandomRangeValue;
    private float randomYaw;
    private float randomPitch;
    // Start is called before the first frame update
    void Start()
    {
        randomYaw = Random.Range(-RandomRangeValue, RandomRangeValue);
        randomPitch = Random.Range(-RandomRangeValue, RandomRangeValue);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(yawChange < randomYaw)
        {
            yawChange += Time.deltaTime;
            if(yawChange >= randomYaw)
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
        yaw += yawChange;
        pitch += pitchChange;
        var desiredRotation = Quaternion.Euler(pitch, yaw, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * 20f);
    }

    void newRotate()
    {
        randomYaw = Random.Range(-RandomRangeValue, RandomRangeValue);
        randomPitch = Random.Range(-RandomRangeValue, RandomRangeValue);
    }
}
