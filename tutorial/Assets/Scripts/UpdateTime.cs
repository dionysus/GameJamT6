using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTime : MonoBehaviour
{
    public GameObject TimerObj;

    private Text timerText;

    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        timerText = TimerObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = "Time: " + Mathf.Round(time) + " seconds";
    }
}
