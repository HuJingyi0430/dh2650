using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    Light tv;
    
    // Start is called before the first frame update
    void Start()
    {
        tv = this.GetComponent<Light>();
        InvokeRepeating("OutputTime", 0f, 1f);  //1s delay, repeat every 1s
    }

    // Update is called once per frame
    void OutputTime()
    {
        tv.intensity = Random.Range(5.0f, 20.0f);
    }
}
