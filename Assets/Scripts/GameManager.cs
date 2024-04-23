using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int score;

    public void Scored() {
        score++;
    }

    public int GetScore() {
        return score;
    }

}
