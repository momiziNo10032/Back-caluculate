using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Retry_button : MonoBehaviour
{
        Text Button;
        void Start()
        {
                Button=GetComponent<Text>();
        }

        public void Click() {
                Music.Mswich=5;
                SceneManager.LoadScene ("Title");
        }
        public void collor_change() {
                Button.color=new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }
        public void As_before() {
                Button.color=new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
}
