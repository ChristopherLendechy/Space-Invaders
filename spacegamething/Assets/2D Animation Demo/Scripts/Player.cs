using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    [FormerlySerializedAs("shottingOffset")] public Transform shootOffsetTransform;

    private Animator playerAnimator;
    private static readonly int Shoot = Animator.StringToHash("Shoot");
    private
    //-----------------------------------------------------------------------------
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // todo - trigger a "shoot" on the animator
            playerAnimator.SetTrigger(Shoot);
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            //Debug.Log("Bang!");

            Destroy(shot, 5f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0,.05f,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0,-.05f,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        playerAnimator.SetTrigger("Death");
        Destroy(this);
        
        // transition to credits
        SceneManager.LoadScene("Credits");
    }
}
