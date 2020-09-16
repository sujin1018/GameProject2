using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TypeEffect : MonoBehaviour
{
    string targetMsg; //표시할 대화 문자열을 변수로 저장
    public int CharPerSeconds; //글자 재생 속도를 위한 변수
    public GameObject EndCursor;
    public bool isAnim;
    Text msgText;
    AudioSource audioSource;
    int index;
    float interval;

    private void Awake()
    {

        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    //대화 문자열을 받는 함수
    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else {
            targetMsg = msg;
            EffectStart();
        }
    }


    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        //Start Animation
        interval = 1.0f / CharPerSeconds;

        isAnim = true;

        Invoke("Effecting", interval);

    }

    void Effecting()
    {
        //End Animation
        if(msgText.text == targetMsg) {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index]; 

        //Sound
        if(targetMsg[index] != ' ' || targetMsg[index] != '.')
            audioSource.Play();

        index++;

        //Recursive
        Invoke("Effecting", interval);
    }
    void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }
}
