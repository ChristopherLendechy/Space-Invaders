using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float cTime;
    private int  numberOfChildren;
    public float direction = 1;
    public float stopTime = 0.8f;
    public float speed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        numberOfChildren = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {

        if (numberOfChildren != transform.childCount)
        {
            stopTime -= .1f;
            numberOfChildren = transform.childCount;
        } 
        cTime += Time.deltaTime;
        if (cTime > stopTime)
        {
            transform.Translate(speed * direction,0f,0f);
            cTime = 0f;
        }

        numberOfChildren = transform.childCount;
    }

    public void SwitchDirection()
    {
        
        direction = -1 * direction;
        transform.Translate(direction,-1f,0f);
    }
}
