using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public float timer = 0.2f;
    public bool ranged;
    public float rangedTimer = 1f;
    public GameObject swordParticle;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        
        if(timer<=0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetInteger("attackDir",5);
        }

        if (!ranged)
        {
            if (timer <= 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
                Destroy(gameObject);
            }
        }
        else
        {
            rangedTimer -= Time.deltaTime;

            if(rangedTimer<=0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
                Instantiate(swordParticle, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

	}

    public void createParticle()
    {
        Instantiate(swordParticle, transform.position, transform.rotation);
    }
}
