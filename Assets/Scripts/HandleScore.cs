using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleScore : MonoBehaviour
{

    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI win;
    public int requiredScore = 15;
    int score = 0;

    bool won = false;

    void Update() {
        if (score >= requiredScore) {
            win.enabled = true;
            won = true;
        }
    }
    
    public void increaseScore() {
        if (won) {
            return;
        }
        score++;
        textMeshProUGUI.text = "" + score + "/" + requiredScore;
    }

    public int getScore() {
        return score;
    }
}
