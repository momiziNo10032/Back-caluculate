using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Botton : MonoBehaviour
{
        Text Button;
        GameObject How;
        public bool how_display=false;
        void Start()
        {
                if(how_display==true) {
                        How=GameObject.Find("How_to_play");
                        How.gameObject.SetActive (false);//
                }
                Button=GetComponent<Text>();
        }
        public void Click() {
                Music.Mswich=3;
                SceneManager.LoadScene ("Main");
        }
        public void HowClick() {
                Music.Mswich=6;
                How.gameObject.SetActive (true);
                //SceneManager.LoadScene ("Main");
        }
        public void RankClick() {
                Music.Mswich=6;
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking (Score.point);
                //SceneManager.LoadScene ("Main");
        }
        public void ButtonClick() {
                How=GameObject.Find("How_to_play");
                How.gameObject.SetActive (false);//
                //SceneManager.LoadScene ("Main");
        }
        public void collor_change() {
                Button.color=new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }
        public void As_before() {
                Button.color=new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
}
