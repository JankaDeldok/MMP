using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead; 

    private EdgeCollider2D edgeCol;
    private BoxCollider2D boxCol;
    private Boolean hit;

    private AudioSource background;

    [NonSerialized] public double waitForSeconds = 2.0; 


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        edgeCol = gameObject.GetComponent<EdgeCollider2D>();
        boxCol = gameObject.GetComponent<BoxCollider2D>();
        background = GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                background.Stop();
                
                //Sound for GameOver 
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();

                dead = true;

                //SceneManager.LoadScene("Menu Screen/GameOverMenu");
                StartCoroutine(loadGameOverScreen());

            }

            
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            AddHealth(1);
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        //check if edgeCollider2d was hit
        if(collision.otherCollider == edgeCol){
            if(collision.gameObject.tag=="Letter")
            {
                Debug.Log("collision with letter");
                //letter disabled & destroy
                collision.gameObject.GetComponent<Renderer>().enabled = false;

                //Sound for Collision with letter 
                AudioSource audio = collision.gameObject.GetComponent<AudioSource>();
                audio.Play();

                //destroy letter
                Destroy(collision.gameObject, audio.clip.length);

                //only take damage if lastColName is not the same as last collision,
                //otherwise takedamage will repeat as long as letterbox is touching the edgeCollider2d
                TakeDamage(1);
            }
        }
        if(collision.otherCollider == boxCol || collision.otherCollider == edgeCol){

            if (collision.gameObject.tag == "Heart")
            {
                Debug.Log("collision with heart");
                //heart disabled
                collision.gameObject.GetComponent<Renderer>().enabled = false;
                
                //Sound for Energy
                AudioSource audio = collision.gameObject.GetComponent<AudioSource>();
                audio.Play();
                
                //destroy heart
                Destroy(collision.gameObject, audio.clip.length);
                
                //get 10points for score
                if(currentHealth == startingHealth){
                    ScoreScript.scoreValue += ScoreScript.score;
                }
                else{
                    //get 1 energy
                AddHealth(1);
                }
            } 
            
        }
    }

    IEnumerator loadGameOverScreen()
    {
        yield return new WaitForSeconds(seconds: 1);
        SceneManager.LoadScene("Menu Screen/GameOverMenu");
    }
}
