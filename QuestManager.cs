using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class QuestManager : MonoBehaviour
{
    public GameObject player;
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("햄찌마을 주민들과 대화하기", 
                                        new int[] {1000, 2000 }));
        questList.Add(20, new QuestData("아재의 해바라기씨 찾아주기",
                                       new int[] { 34000, 2000 }));
        questList.Add(30, new QuestData("별이의 은신처 찾아주기",
                                        new int[] { 2000, 35000, 36000, 1000 }));
        questList.Add(40, new QuestData("호수의 전설 듣기",
                                    new int[] { 2000 }));
        questList.Add(50, new QuestData("미로의 숲 문지기 설득하기",
                                       new int[] { 7000, 32000, 37000, 7000 }));
        questList.Add(60, new QuestData("댕댕이 마을 들어가기",
                                       new int[] { 6000, 12000, 6000 }));
        questList.Add(70, new QuestData("보니에게 간식 전달해주기",
                                       new int[] { 3000 }));
        questList.Add(80, new QuestData("댕댕이마을 주민들과 대화하기",
                                       new int[] { 5000, 4000 }));
        questList.Add(90, new QuestData("뽀삐 의자 찾아주기",
                                       new int[] { 13000, 4000 }));
        questList.Add(100, new QuestData("하늘이의 건조닭가슴살 찾아주기",
                                       new int[] { 5000, 14000, 15000, 16000, 17000, 18000, 5000 }));
        questList.Add(110, new QuestData("보니에게 동굴 들어가는 법 물어보기",
                                       new int[] { 3000 }));
        questList.Add(120, new QuestData("동굴에 들어가기",
                                      new int[] { 29000 }));
        questList.Add(130, new QuestData("동굴에서 비밀의 물건 가져오기",
                                      new int[] { 19000, 28000 }));
        questList.Add(140, new QuestData("햄찌 마을의 아재 찾아가기",
                                      new int[] { 2000 }));
        questList.Add(150, new QuestData("전설의 낚싯대를 이용해서 황금 해바라기씨 얻기",
                                      new int[] { 26000, 27000 }));
        questList.Add(160, new QuestData("퀘스트 올 클리어!",
                                      new int[] { 0 }));

    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        //순서에 맞게 대화했을 때만 퀘스트 대화순서 올라감 Next Talk Target
        if (id == questList[questId].npcId[questActionIndex]) 
            questActionIndex++;

        //Control Quest Object
        ControlObject();

        //NPC랑 대화를 다 나눴으면 Talk Complete & Next Quest
        if (questActionIndex == questList[questId].npcId.Length)
        {
            //다음 퀘스트로
            NextQuest();
        }
        //퀘스트 이름 출력 Quest Name
        return questList[questId].questName;
    }
    public string CheckQuest()
    {
        //Quest Name
        return questList[questId].questName;
    }

    //다음퀘스트를 위한 함수
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    public void ControlObject()
    {
        switch (questId)
        {
            case 10:
                //대화 끝나면
                if(questActionIndex == 2)                 
                    questObject[0].SetActive(true); //해바라기씨 보이도록 설정
                break;
            case 20:
                //해바라기씨를 먹으면
                if (questActionIndex == 1)
                    //해바라기씨 안보이도록 설정
                    questObject[0].SetActive(false);
                break;
            case 30:
                if (questActionIndex == 2)
                    questObject[1].SetActive(true);
                if (questActionIndex == 3)
                    questObject[1].SetActive(false);
                break;
            case 50:
                if (questActionIndex == 2)
                    questObject[2].SetActive(true);
                if (questActionIndex == 3)
                    questObject[2].SetActive(false);
                if (questActionIndex == 4)
                {
                    questObject[3].SetActive(false);
                    questObject[4].SetActive(false);
                }
                break;
            case 60:
                if (questActionIndex == 1)
                    questObject[5].SetActive(true);
                if (questActionIndex == 2)
                    questObject[5].SetActive(false);
                if(questActionIndex == 3) {
                    questObject[6].SetActive(false);
                    questObject[7].SetActive(false);
                }
                break;

            case 90:
                if (questActionIndex == 0)
                    questObject[8].SetActive(true);
                if (questActionIndex == 1)
                    questObject[8].SetActive(false);
                break;
            case 100:
                if (questActionIndex == 1)
                {
                    questObject[9].SetActive(true);
                }
                if (questActionIndex == 2)
                {
                    questObject[9].SetActive(false);
                    questObject[10].SetActive(true);
                }
                if (questActionIndex == 3)
                {
                    questObject[10].SetActive(false);
                    questObject[11].SetActive(true);
                }
                if (questActionIndex == 4)
                {
                    questObject[11].SetActive(false);
                    questObject[12].SetActive(true);
                }
                if (questActionIndex == 5)
                {
                    questObject[12].SetActive(false);
                    questObject[13].SetActive(true);
                }
                if (questActionIndex == 6)
                {
                    questObject[13].SetActive(false);
                }
                break;

            case 110:
                if (questActionIndex == 1)
                {
                    questObject[15].SetActive(false);
                    questObject[16].SetActive(false);
                }
                break;
            case 120:
                if (questActionIndex == 1)
                {
                    player.transform.position = new Vector3(167.496f, -15.464f, 0);
                    questObject[14].SetActive(true);
                }
                break;
            case 130:
                if (questActionIndex == 1) {
                    questObject[14].SetActive(false);
                    questObject[6].SetActive(true);
                    questObject[7].SetActive(true);
                }
                if (questActionIndex == 2)
                {
                    player.transform.position = new Vector3(110.495f, 39.502f, 0);
                    questObject[6].SetActive(false);
                    questObject[7].SetActive(false);

                }
                break;
            case 150:
                if (questActionIndex == 1)
                {
                    questObject[18].SetActive(true);
                }
                if (questActionIndex == 2)
                {
                    questObject[18].SetActive(false);
                }
                break;
            case 160:
                if (questActionIndex == 0)
                {
                    questObject[18].SetActive(false);
                }
                break;
        }
    }

}
