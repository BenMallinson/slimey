using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 0.0f;
    public Text text; // used for showing countdown from 3, 2, 1 

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.text = time.ToString("F2");
    }
}
