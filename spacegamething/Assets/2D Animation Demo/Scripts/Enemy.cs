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
    private Animator enemyAnimator;
    private static readonly int ADeath = Animator.StringToHash("aDeath");

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
        enemyAnimator = GetComponent<Animator>();
        
        
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
 
        GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
        //Debug.Log("Bang!");

        Destroy(shot, 5f);
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
            enemyAnimator.SetTrigger(ADeath);
            StartCoroutine(Die());
            //Debug.Log("Ouch!");
        }
    }
    IEnumerator Die(){
        
        yield return new WaitForSeconds(1); //waits 3 seconds
        Destroy(gameObject); //this will work after 3 seconds.
    }
    void enemyShot()
    {
        float rand = Random.Range(1f, 30f);
        StartCoroutine(ExecuteAfterTime(rand));
    }


}
