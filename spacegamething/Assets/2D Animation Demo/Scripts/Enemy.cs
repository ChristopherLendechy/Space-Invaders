using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //-----------------------------------------------------------------------------
    public UIManager uiManagerScript;
    //private GameObject uiManagerObject;

    public delegate void enemyDeath();

    public int enemyValue;

    private void Start()
    {
        GameObject uiManagerObject = GameObject.FindWithTag("UIManagerController");
        uiManagerScript = uiManagerObject.GetComponent<UIManager>();
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // todo - trigger death animation
        Destroy(collision.gameObject); // destroy bullet
        //enemyDead?.Invoke(score);
        // increase score
        
        
        uiManagerScript.addScore(100);
        // remove enemy object
        Destroy(gameObject);
        Debug.Log("Ouch!");
        
    }

    void enemyIsKilled()
    {
        
    }
}
