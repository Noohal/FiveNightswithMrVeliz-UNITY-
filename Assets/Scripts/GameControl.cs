using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    // -- Power Usage
    public IntVariable powerLevel;
    public float lastTimePowerLost = 0;

    const float powerLossRate = 1f;

    // --- Clock ---
    public IntVariable currentTime;
    public float lastTime = 0;

    const float hourDuration = 10f;

    void Start()
    {
        powerLevel.value = 100;
        currentTime.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;
        print(now);
        if(now - lastTime >= hourDuration)
        {
            currentTime.value++;
            currentTime.value %= 12;
            lastTime = now;
        }

        if(now - lastTimePowerLost >= powerLossRate)
        {
            powerLevel.value--;
            if(powerLevel.value <= 0)
                powerLevel.value = 0;
            print(powerLevel.value);
            lastTimePowerLost = now;
        }
    }
}
