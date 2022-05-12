using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
        public AudioClip sound1;//タイトルBGM
        public AudioClip sound2;//BGM
        public AudioClip sound3;//ゲームスタート
        public AudioClip sound4;//正解音
        public AudioClip sound5;//不正解
        public AudioClip sound6;//終了
        public static int Mswich=0;//０:デフォルト 1: 2:
        private AudioSource[] sources;
        public bool DontDestroyEnabled = true; //シーンを切り替えても破壊されない
        void Start()
        {
                sources = GetComponents<AudioSource>();
                if (DontDestroyEnabled) {
                        // Sceneを遷移してもオブジェクトが消えないようにする
                        DontDestroyOnLoad (this);
                }
                sources[0].Stop();
                sources[0].volume=1.0f;
                sources[0].clip = sound1; //BGM変更
                sources[0].Play();
        }

        // Update is called once per frame
        void Update()
        {
                if(Mswich!=0) {
                        SE(Mswich);
                }
                //Debug.Log(sources[0].volume);
        }
        void SE(int se){
                if(se==1) sources[1].PlayOneShot(sound4); //正解音
                if(se==2) sources[1].PlayOneShot(sound5); //不正解音
                if(se==3) {//タイトルからメインへBGM変更
                        sources[0].Stop();
                        sources[0].clip = sound2;
                        sources[0].volume=0.3f;
                        sources[0].Play();
                }
                if(se==4) {
                        sources[0].Stop();//BGMを止めてリトライ画面へ
                        sources[1].PlayOneShot(sound6);
                }
                if(se==5) {//タイトルからメインへBGM変更
                        sources[0].Stop();
                        sources[0].volume=1.0f;
                        sources[0].clip = sound1;//BGMをタイトル用へ
                        sources[0].Play();
                }
                if(se==6) sources[1].PlayOneShot(sound3); //pinpon
                Mswich =0;
        }
}
