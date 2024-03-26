using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScoreEvent
{
    draw,
    mine,
    mineGold,
    gameWin,
    gameLoss
}
    static private ScoreManager S;
    static public int SCORE_FROM_PREV_ROUND = 0;
    static public int HIGH_SCORE = 0;

    public int chain = 0; 
    public int scoreRun = 0;
    public int score = 0;
    public FloatingScore fsRun;

   Void Awake() {
        if (S == null) {
            S = this;
        } else {
               Debug.LogError("Error: ScoreManager.Awake(): S is already set!");
        }
 
        if (PlayerPrefs.HasKey("ProspectorHighScore"))
        {
            HIGH_SCORE = PlayerPrefs.GetInt("ProspectorHighScore");
        }
        score += SCORE_FROM_PREV_ROUND;
        SCORE_FROM_PREV_ROUND = 0;

      }

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
