using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleTree : MonoBehaviour 
{

    [Header("Inscribed")]
    public GameObject applePrefab;
    public float[] leftAndRightEdge = { 10f, 15f, 20f, 25f, 30f };
    public float[] speed = { 1f, 2f, 3f, 4f, 5f };
    public float[] changeDirChance = { 0.02f, .04f, .06f, .08f, .1f };
    public float[] appleDropDelay = { 1f , .8f, .6f, .4f, .2f };
    public float startTime;
    public int timeElapsed;
    public int level;

    void Start()
    {
        // Start dropping apples                                          
        Invoke("DropApple", 2f);
        startTime = Time.time;
        level = 0;
    }

    void Update()
    {
        // Changing Level
        timeElapsed = (int)(Time.time - startTime);
        level = timeElapsed / 15;

        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed[level] * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge[level])
        {
            speed[level] = Mathf.Abs(speed[level]);
        }
        else if (pos.x > leftAndRightEdge[level])
        {
            speed[level] = - Mathf.Abs(speed[level]);
        }

        // Out of Levels
        if (level == 4)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance[level])
        {
            speed[level] *= -1;
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay[level]);
    }
}
