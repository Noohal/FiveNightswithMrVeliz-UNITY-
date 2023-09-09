using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    // Game Over Status
    public BoolVariable gameOverStatus;

    // --- Power Usage ---
    public IntVariable powerLevel;
    public Text powerText;
    public float lastTimePowerLost = 0;

    const float powerLossRate = 9.6f;

    // --- Clock ---
    public IntVariable currentTime;
    public Text timeText;
    public float lastTime = 0;

    const float hourDuration = 10f;

    // --- Villain Control ---
    public GameObject bonniePrefab;
    public BoolVariable bonnieMoving;

    public GameObject chicaPrefab;
    public BoolVariable chicaMoving;

    void Start()
    {
        powerLevel.value = 100;
        SetPowerLevelText(powerLevel.value);

        currentTime.value = 0;
        SetTimeText(currentTime.value);

        Instantiate(bonniePrefab);
        Instantiate(chicaPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;
        //print(now);
        if(now - lastTime >= hourDuration && currentTime.value < 7)
        {
            currentTime.value++;
            currentTime.value %= 12;
            SetTimeText(currentTime.value);
            lastTime = now;
        }

        if(now - lastTimePowerLost >= powerLossRate)
        {
            powerLevel.value--;
            if(powerLevel.value <= 0)
                powerLevel.value = 0;
            //print(powerLevel.value);
            SetPowerLevelText(powerLevel.value);
            lastTimePowerLost = now;
        }
    }

    void SetPowerLevelText(int _powerLevel)
    {
        powerText.text = _powerLevel + "%";
    }

    void SetTimeText(int _time)
    {
        if (_time == 0)
            timeText.text = "12 AM";
        else
            timeText.text = _time + " AM";
    }
}
