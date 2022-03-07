using UnityEngine;

namespace _2D_Animation_Demo.Scripts
{
    public class Shield : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        void OnCollisionEnter2D(Collision2D collision)
        {
        
            
            Destroy(collision.gameObject); // destroy bullet

            // remove  object
            Destroy(gameObject);
            Debug.Log("Ouch!");
        
        }
    }
}
