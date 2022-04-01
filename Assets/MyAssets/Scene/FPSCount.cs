using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCount : MonoBehaviour
{
    [SerializeField] private Text text;
    private float timer = 0.3f;
    private float deltaTimeSum = 0;
    private int searchCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            deltaTimeSum += Time.deltaTime;
            searchCount++;
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0.3f;
            text.text = "FPS : "+(1 / (deltaTimeSum/ searchCount)).ToString("N1");
            deltaTimeSum = 0;
            searchCount = 0;
}
    }
}
