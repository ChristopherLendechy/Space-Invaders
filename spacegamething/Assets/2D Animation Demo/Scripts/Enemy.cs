using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEngine.Random;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour
{
    [FormerlySerializedAs("enemyBullet")] public GameObject bulletPrefab;
    [FormerlySerializedAs("shottingOffset")] public Transform shootOffsetTransform;
    //-----------------------------------------------------------------------------
    public UIManager uiManagerScript;

    
    //private GameObject uiManagerObject;

    //public delegate void enemyDeath();

    public int enemyValue;
    float accumulatedTime;
    public void Update()
    {
        
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > 2)
        {
            enemyShot();
            accumulatedTime = 0;
        }
    }
    
    private void Start()
    {
        GameObject uiManagerObject = GameObject.FindWithTag("UIManagerController");
        uiManagerScript = uiManagerObject.GetComponent<UIManager>();
        
        
        
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
 
        GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
        //Debug.Log("Bang!");

        Destroy(shot, 3f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // todo - trigger death animation

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
        }
        else
        {

            Destroy(collision.gameObject); // destroy bullet

            //enemyDead?.Invoke(score);
            
            uiManagerScript.addScore(enemyValue);
            // remove enemy object
            Destroy(gameObject);
            //Debug.Log("Ouch!");
        }
    }

    void enemyShot()
    {
        float rand = Random.Range(1f, 30f);
        StartCoroutine(ExecuteAfterTime(rand));
    }


}
