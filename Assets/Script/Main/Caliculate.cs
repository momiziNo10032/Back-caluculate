using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Caliculate : MonoBehaviour
{
int[] figure=new int[3];        //計算式用
public GameObject[] Text_number;
//01:数字 2:記号 345:答え
Text[] Number;
string[] symbol={"+","-","×","÷"};
static public int symbol_number=0;        //記号選択
bool change_problem=false;        //問題を変えるフラグ
//int click_numer=0;//クリック検知
int correct=4;        //正解判定
private float randm;        //ランダム関数用
public GameObject reversible;        //image
static public bool reverse=false;        //逆判定
void Start()
{
        Number =new Text[Text_number.Length];
        for(int i=0; i<Text_number.Length; i++) {
                Number[i]=Text_number[i].GetComponent<Text>();
                //Number[i].text=i.ToString();
        }
        Number[2].text=symbol[symbol_number];
        change_problem=true;
        reversible.gameObject.SetActive (false);        //落ちたら消す
}

void Update()
{
        if(change_problem==true) {
                //問題文生成
                randm=Random.Range(0,100);
                if(randm>80) {
                        reversible.gameObject.SetActive (true);
                        reverse=true;
                }else{
                        reversible.gameObject.SetActive (false);
                        reverse=false;
                }
                figure[0]=1;
                figure[1]=0;
                while(figure[0]>=figure[1]) {
                        randm=Random.Range(0,9);
                        figure[0]=(int)randm;
                        randm=Random.Range(0,18);
                        figure[1]=(int)randm;
                }
                Number[0].text=figure[0].ToString();
                Number[1].text=figure[1].ToString();
                //回答群生成
                correct=(int)Random.Range(0,3);        //どの回答を答えにするか
                if(correct==0) {
                        if(symbol_number==0) {
                                //正解
                                Number[3].text=(figure[1]-figure[0]).ToString();
                                //誤問題
                                randm=Random.Range(0,18);
                                randm=Judgment(figure[1]-figure[0],(int)randm,symbol_number);
                                Number[4].text=randm.ToString();

                                randm=Random.Range(0,18);
                                randm=Judgment(figure[1]-figure[0],(int)randm,symbol_number);
                                Number[5].text=randm.ToString();
                        }
                }
                if(correct==1) {
                        if(symbol_number==0) {
                                Number[4].text=(figure[1]-figure[0]).ToString();

                                randm=Random.Range(0,18);
                                randm=Judgment(figure[1]-figure[0],(int)randm,symbol_number);
                                Number[3].text=randm.ToString();

                                randm=Random.Range(0,18);
                                randm=Judgment(figure[1]-figure[0],(int)randm,symbol_number);
                                Number[5].text=randm.ToString();
                        }
                }
                if(correct==2) {
                        if(symbol_number==0) {
                                Number[5].text=(figure[1]-figure[0]).ToString();

                                randm=Random.Range(0,18);
                                randm=Judgment(figure[1]-figure[0],(int)randm,symbol_number);
                                Number[3].text=randm.ToString();

                                randm=Random.Range(0,18);
                                randm=Judgment(figure[1]-figure[0],(int)randm,symbol_number);
                                Number[4].text=randm.ToString();
                        }
                }
                //Debug.Log(randm);
                change_problem=false;
        }

}
public void Click1() {
        if(correct==0&&reverse==false) {
                Score.pointin=1;
        }else if(correct!=0&&reverse==true) {
                Score.pointin=1;
        }else{
                Score.pointin=2;
        }
        change_problem=true;
        //Debug.Log("押された");
}
public void Click2() {
        if(correct==1&&reverse==false) {
                Score.pointin=1;
        }else if(correct!=1&&reverse==true) {
                Score.pointin=1;

        }else{
                Score.pointin=2;
        }
        change_problem=true;
        //Debug.Log("押された");
}
public void Click3() {
        if(correct==2&&reverse==false) {
                Score.pointin=1;
        }else if(correct!=2&&reverse==true) {
                Score.pointin=1;
        }else{
                Score.pointin=2;
        }
        change_problem=true;
        //Debug.Log("押された");
}
int Judgment(int base_number,int task,int type)
{        //選択肢を被らないようにする
        if(base_number!=task) {
                return task;
        }
        while(base_number==task) {
                if(type==0) task=(int)Random.Range(0,18);
        }
        return task;
}
}
