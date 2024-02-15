using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHaelth : MonoBehaviour
{
    public float Heath = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            print("Enemy Hit");
            Heath -= 10;
            if (Heath <= 0)
            {
                //diable player controller and show game over screen
                Debug.Log("Enemy Dead");
                Destroy(gameObject);
            }
        }
    }
}
