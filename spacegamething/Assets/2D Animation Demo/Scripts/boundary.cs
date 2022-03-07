using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyController enemyControllerScript;
    void Start()
    {
        GameObject enemyControllerObject = GameObject.FindWithTag("EnemyControllerObject");
        enemyControllerScript = enemyControllerObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("---------ENTER TRIGGER--------");
        enemyControllerScript.SwitchDirection();
        
    }
}


