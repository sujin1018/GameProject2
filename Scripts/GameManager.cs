using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI 프로그래밍 전에 넣어줄 것

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public TypeEffect talk;
    public Text questText;
    public Animator talkPanel;
    public TalkManager talkManager;
    public QuestManager questManager;
    public Image portraitImg;
    public Animator portraitAnim;
    public GameObject scanObject;
    public GameObject menuSet;
    public bool isAction; //상태저장용
    public int talkIndex;
    public Sprite prevPortrait;
    public Text nametext;

    void Start()
    {
        GameLoad();
        questText.text = questManager.CheckQuest();



           // player.transform.position.x = 167.494f; , -15.469f, 0);

    }

    void Update()
    {
        //Sub Menu
        if (Input.GetButtonDown("Cancel")) {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }

    }
    public void Action(GameObject scanObj)
    {

        //Get Current Object
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();

        //if (objData.isNpc) {
        //    if (objData.id == 1000)
        //        objData.npcName = "별";
        //    else if (objData.id == 2000)
        //        objData.npcName = "아재";
        //    else if (objData.id == 3000)
        //        objData.npcName = "보니";
        //    else if (objData.id == 4000)
        //        objData.npcName = "뽀삐";
        //    else if (objData.id == 5000)
        //        objData.npcName = "하늘";
        //}

        //Set Name Text
        if (objData.isNpc)
            nametext.text = objData.npcName;
        else
            nametext.text = null;

        //Set Talk Text
        Talk(objData.id, objData.isNpc);


        //Visible Talk for Action
        talkPanel.SetBool("isShow", isAction);


    }


    void Talk(int id, bool isNpc)
    {

        //Set Talk Data
        int questTalkIndex = 0;
        string talkData = "";
        if (talk.isAnim) {
            talk.SetMsg("");
            return;
        }

        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            //퀘스트번호 + NPC Id = 퀘스트 대화 데이터 Id
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }
        //End Talk
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questText.text = questManager.CheckQuest(id);
            return; //강제종료역할
        }

        //Continue Talk
        if (isNpc) {
            //Split(): 구분자를 통하여 배열로 나눠주는 문자열 함수
            talk.SetMsg(talkData.Split(':')[0]);

            //Show Portrait
            //Parse(): 문자열을 해당 타입으로 변환해주는 함수
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1); //NPC일때만 초상화가 보이도록 설정

            //Animation Portrait
            if (prevPortrait != portraitImg.sprite) {
                portraitAnim.SetTrigger("doEffect");
                prevPortrait = portraitImg.sprite;
            }
        }

        else {
            talk.SetMsg(talkData);

            //Hide Portrait
            portraitImg.color = new Color(1, 1, 1, 0);
        }
        //Next Talk
        isAction = true;
        talkIndex++;
    }


//게임 저장
public void GameSave()
    {
        //PlayerPrefs: 간단한 데이터 저장 기능을 지원하는 클래스
        //player.x
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        //player.y
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        //Quest.Id
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        //Quest Action Index
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();

        menuSet.SetActive(false);
    }

    
    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        player.transform.position = new Vector3(x, y, 0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        questManager.ControlObject();
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
