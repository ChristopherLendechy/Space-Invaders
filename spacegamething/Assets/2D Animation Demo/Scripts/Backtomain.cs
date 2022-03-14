using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _2D_Animation_Demo.Scripts
{
    public class Backtomain : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(ReturnCoroutine());
        }

        // Update is called once per frame
        void Update()
        {
           
        }
    
 
 
        
        IEnumerator ReturnCoroutine()
        {
        
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("Menu Transition");
            Destroy(this);
        }
    }
}
