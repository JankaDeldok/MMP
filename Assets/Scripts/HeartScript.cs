using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    private Vector2 screenBounds;

// Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));

    }

    // Update is called once per frame
    void Update()
    {
        if (-transform.position.y > screenBounds.y * 1.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
