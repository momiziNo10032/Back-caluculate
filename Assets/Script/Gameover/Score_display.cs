using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score_display : MonoBehaviour
{

        Text Display_point;

        void Start()
        {
                Display_point=GetComponent<Text>();
                Display_point.text="Score:"+Score.point.ToString();
                Debug.Log(Score.point);
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking (Score.point);
                //ランキング呼び出し
        }

        // Update is called once per frame
        void Update()
        {

        }
}
