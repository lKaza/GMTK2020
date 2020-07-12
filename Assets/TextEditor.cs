using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEditor : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Transform player;
    [SerializeField] float timeforScore=0.5f;
    float score;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddScore());
    }

    private void Update() {
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
    IEnumerator AddScore()
    {

        while (true)
        { //forever
        score++;
        score +=player.transform.position.x;
            yield return new WaitForSeconds(timeforScore);
        }
        
    }
}


