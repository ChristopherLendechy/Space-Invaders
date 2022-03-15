using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipSpawn : MonoBehaviour
{


    private float cTime;

    private float stopTime = .2f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cTime += Time.deltaTime;
        if (cTime > stopTime)
        {
            transform.Translate(-1,0f,0f);
            cTime = 0f;
        }
        
    }


}
