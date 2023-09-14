using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{

    Text scoreText;
    float startTime;
    int timeElapsed;
    int level;

    void Start()
    {
        scoreText = GetComponent<Text>();
        startTime = Time.time;
        level = 1;
    }

    void Update()
    {
        timeElapsed = (int)(Time.time - startTime);
        level = 1 + timeElapsed / 15;

        scoreText.text = "lvl" + level.ToString();
    }
}
