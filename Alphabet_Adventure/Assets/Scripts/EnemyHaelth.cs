using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHaelth : MonoBehaviour
{
    public float Heath = 100f;
    bool isDead = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            //disable player controller and show game over screen
            Debug.Log("Enemy Dead");
            anim.SetTrigger("Death");
            float time = 0;
            time += Time.deltaTime;
            if(time > 5)
            {
                Destroy(gameObject);
            }
        }
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
                isDead = true;
            }
        }
    }
}
