using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue;
    public static int score, scoreL1, scoreL2, scoreL3, scoreL4, scoreL5;
    
    
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        score = 10;
        scoreL1 = 50;
        scoreL2 = 100;
        scoreL3 = 150;
        scoreL4 = 200;
        scoreL5 = 250;
        scoreValue = 0;

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreValue.ToString();
    }
    
}
