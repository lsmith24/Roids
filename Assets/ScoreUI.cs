using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private Global globalObj;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        this.globalObj = g.GetComponent<Global>();
        this.scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        this.scoreText.text = this.globalObj.score.ToString();
    }
}
