using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectLMU : MonoBehaviour
{
    [SerializeField] private Text L;
    [SerializeField] private Text M;
    [SerializeField] private Text U;
    private BoxCollider2D boxCol;

    public AudioSource soundCoin;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCol = gameObject.GetComponent<BoxCollider2D>();
        L.enabled = false;
        M.enabled = false;
        U.enabled = false;

        soundCoin = GameObject.FindWithTag("SoundCoin").GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if edgeCollider2d was Hit
        if(collision.gameObject.name == "L(Clone)"){
            
            //write letter on canvas
            L.enabled = true;
            //soundCoin started
            soundCoin.Play();
            //Element destroyed
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.name == "M(Clone)"){ 
            //write letter on canvas
            M.enabled = true;
            //soundCoin started
            soundCoin.Play();
            //Element destroyed
            Destroy(collision.gameObject);
            
        }
        if(collision.gameObject.name == "U(Clone)"){

            //write letter on canvas
            U.enabled = true;
            //soundCoin started
            soundCoin.Play();
            //Element destroyed
            Destroy(collision.gameObject);
            
        }
        
    }
}
