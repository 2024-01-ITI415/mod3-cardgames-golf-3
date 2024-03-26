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
   

public class ScoreManager : MonoBehaviour
{

 static private ScoreManager S;

    static public int SCORE_FROM_PREV_ROUND = 0;
    static public int HIGH_SCORE = 0;

    public int chain = 0; 
    public int scoreRun = 0;
    public int score = 0;
    

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

   static public void EVENT(eScoreEvent evt) {
         try{ S.Event(evt);
       } catch (System.NullReferenceException nre) {
             Debug.LogError("ScpreManager:EVENT() called while S=mull.\n"+nre);
        }
   
    }
    void EVENT(eScoreEvent evt) {
        switch (evt) {
              case eScoreEvent.draw:
              case eScoreEvent.gameWin:
              case eScoreEvent.gameLoss:
                    chain = 0;
                    score += scoreRun;
                    scoreRun = 0;
                    break;

              case eScoreEvent.mine:
                   chain++;
                   scoreRun += chain;
                   break;
       }
         switch (evt) {
                case eScoreEvent.gameWin:
                     SCORE_FROM_PREV_ROUND = score;
                     print("You won this round! Round score: "+score);
                     break;
        Default:
                print("score: "+score+" scoreRun:"+scoreRun+" chain:"+chain);
                break;
      }
   }

        static public int CHAIN { get{return S.chain;}}
        static public int SCORE { get{return S.score;}}
        static public int SCORE_RUN { get{return S.scoreRun;}}



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
