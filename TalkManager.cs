using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;


    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }
   

    // Update is called once per frame
    void GenerateData()
    {
        // Talk Data
        // 별: 1000, 아재: 2000, 보니: 3000, 뽀삐: 4000, 하늘: 5000, 쿠키: 6000, 두부: 7000

        // BOX:32000 , Desk: 33000, 해바라기씨: 34000, StoneBox: 35000, 은신처: 36000, 보니간식: 37000, StoneBox(1): 38000, StoneBox(2): 39000
        // StoneBox(3): 10000, StoneBox(4): 11000 , 쿠키장난감: 12000, 뽀삐 의자: 13000, 하늘이 닭가슴살: 14000
        // 하늘이닭가슴살(2): 15000, (3): 16000, (4): 17000, (5): 18000, 전설의 낚싯대(Fishing): 19000
        // 몬스터0~5: 20000 ~25000
        //StoneBox(5~6): 30000,31000 , Cave: 29000, Exit: 28000, 낚시터: 26000, 황금 해바라기씨: 27000

        talkData.Add(1000, new string[] { "항상 느끼는 거지만, 여긴 정말 평화로워.:1"});
        talkData.Add(2000, new string[] { "여어.:1", "이 호수는 정말 아름답지?:0",
                                          "사실 이 호수에는 무언가의 비밀이 숨겨져있다고 해.:1" });
        talkData.Add(3000, new string[] { "안녕.:0",
                                          "뭐야, 간식 주는거 아니었어?:3"});
        talkData.Add(4000, new string[] { "하이~ 오늘 날씨가 참 좋지?:0",
                                          "집에만 있는건 너무 답답하잖아?!:3" });
        talkData.Add(5000, new string[] { "안뇽. 난 하늘이야!:1",
                                          "너 혹시 미로의 숲에 가봤어?:2",
                                          "어? 거길 지나왔다고? 대단한걸..:1"});
        talkData.Add(6000, new string[] { "미로의 숲을 아무나 가게 할 수는 없지.:3"});
        talkData.Add(7000, new string[] { "난 미로의 숲 입구를 지키는 문지기, 두부야.:0",
                                          "여긴 못지나가!:3"});


        talkData.Add(32000, new string[] {  "평범한 나무상자다." });
        talkData.Add(33000, new string[] {  "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(35000, new string[] {  "돌로 만들어진 상자다." });
        talkData.Add(38000, new string[] {  "길이 돌로 만들어진 상자로 막혀있다." });
        talkData.Add(39000, new string[] {  "길이 돌로 만들어진 상자로 막혀있다." });
        talkData.Add(10000, new string[] {"길이 돌로 만들어진 상자로 막혀있다." });
        talkData.Add(11000, new string[] {"길이 돌로 만들어진 상자로 막혀있다." });
        talkData.Add(30000, new string[] {"길이 돌로 만들어진 상자로 막혀있다." });
        talkData.Add(31000, new string[] {"길이 돌로 만들어진 상자로 막혀있다." });
        talkData.Add(28000, new string[] {"비밀의 물건을 찾기 전에 돌아갈 순 없지!" });
        talkData.Add(26000, new string[] {"달라진 것이 없다." });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] {  "어서 와.:0",
                                                "이 마을에 놀라운 전설이 있다는데:1",
                                                "오른쪽 호수 쪽에 있는 아재를 찾아가봐.:0"});
        talkData.Add(11 + 1000, new string[] {  "아직 못만났어?:1",
                                                "아재는 오른쪽 호수 쪽에 있어.:0"});
        talkData.Add(11 + 2000, new string[] {  "여어:1",
                                                "이 호수의 전설을 들으러 온거야?:0",
                                                "그럼 일 좀 하나 해주면 좋겠는데...:1",
                                                "내 보라색 집 근처에 떨어진 해바라기씨 좀 주워왔으면 해.:0"});

        talkData.Add(20 + 1000, new string[] {  "아재의 해바라기씨?:1",
                                                "그렇게 중요한걸 흘리면 안되지!:3",
                                                "나중에 아재에게 한마디 해야겠어.:3"});
        talkData.Add(20 + 2000, new string[] {  "찾으면 꼭 좀 가져다 줘.:1" });
        talkData.Add(20 + 34000, new string[] {   "근처에서 해바라기씨를 찾았다." });
        talkData.Add(21 + 1000, new string[] {  "아재한테 해바라기씨 얼른 가져다줘.:1"});
        talkData.Add(21 + 2000, new string[] {  "앗, 찾아줘서 고마워!:1" });
        //talkData.Add(20 + 32000, new string[] { "평범한 나무상자다." });
        //talkData.Add(20 + 33000, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        //talkData.Add(21 + 32000, new string[] { "평범한 나무상자다." });
        //talkData.Add(21 + 33000, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });

        talkData.Add(30 + 1000, new string[] {  "호수의 전설 들으러 온거 아니었어?:2" });
        talkData.Add(30 + 2000, new string[] {  "아 호수의 전설을 듣고 싶다고 했지?:2",
                                                "근데 말이야, 내 소중한 친구 별이가 은신처를 잃어버렸나봐.:3",
                                                "너도 알다시피 우리한테 은신처는 엄청 중요하거든.:1",
                                                "별이 도와준 다음에 다시 와줄래?:0",
                                                "급해서 말이야. 별이한테 가봐.:1",
                                                "부탁해!:0"});
        talkData.Add(31 + 2000, new string[] {  "응? 별이는 왼쪽에 있잖아.:0" });
        talkData.Add(31 + 1000, new string[] {  "앗, 아재한테 소식 듣고 온거야?:0",
                                                "내가 은신처를 잃어버렸지 뭐야.:1",
                                                "낮이라 자야하는데 잘 수가 없어.:3",
                                                "분명 호수 갔을 때만 해도 있었는데 말이야..:1",
                                                "내 은신처 좀 찾아와 주면 고맙겠어.:2" });
        talkData.Add(31 + 35000, new string[]  {  "돌상자 안에서 무언가를 발견했다!" });
        talkData.Add(32 + 36000, new string[] {   "은신처를 얻었다!" });
        talkData.Add(33 + 2000, new string[] {  "은신처 찾았구나? 얼른 별이한테 가봐.:1",
                                                "널 엄청 기다리고 있을거라고!:0"});
        talkData.Add(33 + 1000, new string[] {  "믿고 있었어!:0",
                                                "덕분에 푹 잘 수 있겠다. 고마워!:2",
                                                "이제 아재한테 다시 가봐.:1"});

        talkData.Add(40 + 1000, new string[] {  "아재가 어디있는지 까먹은거 아니지? 오른쪽 호수였잖아.:1" });
        talkData.Add(40 + 2000, new string[] {  "여어.:1",
                                                "드디어 별이한테 은신처 찾아주고 왔구나?:0",
                                                "기다리고 있었어. 전설에 대해 말해주고 싶어서 입이 근질근질 했다고!:2",
                                                "사실 우리 햄찌마을에 있는 이 호수 바닥에는 황금 해바라기씨가 잠들어있어.:0",
                                                "무려 황금 해바라기씨는 평생 먹을 수 있는 전설의 해바라기씨라고!:3",
                                                "어떻게 얻냐고?:0",
                                                "저기 오른쪽에 미로의 숲을 지나면 또 다른 마을이 있다고 들었어. 거기서 힌트를 얻을 수 있을거야.:2",
                                                "근데 미로의 숲은 별로 갈 생각 하지 않는게 좋을거야. 매우 으스스하거든..:1" });

        talkData.Add(50 + 7000, new string[] {  "여긴 못지나간다니까?:1",
                                                "지나가야한다고? 안돼!:3",
                                                "왜 고집부리는거야! 여긴 엄청 위험하다고!!:3"});
        talkData.Add(50 + 1000, new string[] {  "황금 해바라기씨.. 나도 갖고싶다..:0"});
        talkData.Add(50 + 2000, new string[] {  "있잖아, 미로의 숲은.. 정말 미로처럼 되어있나봐.:1",
                                                "사실 무서워서 안가봤지만!:2"});
        talkData.Add(51 + 7000, new string[] {  "꼭 여길 가야겠어?:1",
                                                "그럼 내 부탁 하나만 들어줘. 그럼 지나가게 해줄게.:0",
                                                "이 미로의 숲을 지나가면 댕댕이 마을이 있어.:1",
                                                "보니라는 친구가 여기서 간식을 잃어버렸다지 뭐야.:3",
                                                "간식을 찾아오면 지나가게 해줄게. 물론 보니한테 갖다줬으면 좋겠어.:0" });
        talkData.Add(51 + 1000, new string[] {  "보니? 그러고보니 여기 근처에서 나랑 만난 적이 있어.:2" });
        talkData.Add(51 + 2000, new string[] {  "보니는 나보단 별이랑 친하지.:1"});
        talkData.Add(51 + 32000, new string[] {   "상자 안에서 무언가를 발견했다!" });
        talkData.Add(52 + 37000, new string[] {   "보니의 간식을 찾았다!" });
        talkData.Add(53 + 7000, new string[] {  "간식을 찾아왔구나? 어쩔 수 없지.:0",
                                                "대신 조심해. 길을 잃을지도 몰라.:3",
                                                "보니한테 간식 갖다주는 것도 잊지말고!:2"});
        talkData.Add(53 + 1000, new string[] {  "보니는 간식을 좋아해.:2" });
        talkData.Add(53 + 2000, new string[] {  "하늘이는 먹을 것을 좋아해.:1" });

        talkData.Add(60 + 6000, new string[] {  "뭐야! 미로의 숲을 지나온거야?!:1",
                                                "댕댕이 마을에 들어가기 위해 왔어?:1",
                                                "내가 뭘 믿고 널 들여보내줘야하지?:3",
                                                "정 들어가고 싶으면 미로의 숲 어딘가에서 잃어버린 내 장난감을 찾아와!:0" });
        talkData.Add(61 + 12000, new string[] {   "쿠키의 장난감을 발견했다!" });
        talkData.Add(62 + 6000, new string[] {  "내 장난감을 찾아왔구나! 고마워!:2",
                                                "약속은 약속이니까.. 들어가게 해줄게!:1"});

        talkData.Add(70 + 3000, new string[] {  "어! 너 그거 내 간식 맞지?!:1",
                                                "햄찌 마을에서 잃어버려서 다시는 못 찾나 했었는데!!!:3",
                                                "너 덕분에 살았어! 정말 고마워!:2",
                                                "아! 너 마을 주민들과 인사해야지.:2",
                                                "위쪽 보라색 집 근처에 있는 하늘이가 있으니까 가봐!:0"});
        talkData.Add(80 + 5000, new string[] {  "안녕! 댕댕이 마을에 온 걸 환영해! 다른 애들은 다 만나봤어?:1",
                                                "아래 노란색 집 근처에 뽀삐가 있거든. 찾아가볼래?:2"});
        talkData.Add(81 + 4000, new string[] {  "의자 내놔!! 내 의자 빨리 줘!!:3",
                                                "얼굴은 지금 봤으니까 인사는 됐어.:1",
                                                "내 의자 빨리 갖다줘!:3"});
        talkData.Add(81 + 5000, new string[] {  "뽀삐는 아래 노란색 집 근처에 있을거야.:1"});

        talkData.Add(90 + 4000, new string[] {  "의자 내놔:3",
                                                "하늘이가 가져갔나?! 내 의자 가져와!:1"});
        talkData.Add(90 + 5000, new string[] {  "뽀삐가 의자 찾아?:1",
                                                "쟨 왜 이렇게 의자를 좋아하는거야?:0"});
        talkData.Add(90 + 13000, new string[] { "뽀삐의 의자를 찾았다!" });
        talkData.Add(91 + 5000, new string[] {  "뽀삐 쟨 왜 이렇게 의자를 좋아하는거야?:0"});
        talkData.Add(91 + 4000, new string[] {  "내 의자 찾아왔구나! 고마워.:0",
                                                "너 황금 해바라기씨 때문에 여기 온거였구나?:2",
                                                "그럼 하늘이한테 가봐.:1"});

        talkData.Add(100 + 1000, new string[] { "왜 여기에 있어..?:0" });
        talkData.Add(100 + 2000, new string[] { "왜 아직도 여기에 있니?:0" });
        talkData.Add(100 + 7000, new string[] { "댕댕이 마을 가려는 것 아니었어?:2" });
        talkData.Add(100 + 6000, new string[] { "지금은 돌아갈 때가 아니야:2" });
        talkData.Add(100 + 4000, new string[] { "하늘이가 뭘 찾고있던데..:2" });
        talkData.Add(100 + 3000, new string[] { "간식이 필요해!:3" });
        talkData.Add(100 + 30000, new string[] { "길이 돌로 만들어진 상자로 막혀있다." });
        talkData.Add(100 + 31000, new string[] { "길이 돌로 만들어진 상자로 막혀있다." });
        talkData.Add(100 + 5000, new string[] { "내 건조닭가슴살이 어디갔지..:1",
                                                "너 마침 잘왔다. 제발 내 간식 찾아와줘.:1",
                                                "5개만 찾아오면 돼.:0"});
        talkData.Add(101 + 14000, new string[] {"하늘이의 건조닭가슴살을 찾았다!"});
        talkData.Add(102 + 15000, new string[] {"하늘이의 건조닭가슴살을 찾았다!" });
        talkData.Add(103 + 16000, new string[] {"하늘이의 건조닭가슴살을 찾았다!" });
        talkData.Add(104 + 17000, new string[] {"하늘이의 건조닭가슴살을 찾았다!" });
        talkData.Add(105 + 18000, new string[] {"하늘이의 건조닭가슴살을 모두 찾았다!" });
        talkData.Add(106 + 5000, new string[] { "찾아왔구나! 넌 정말 천사야! 고마워!!:2",
                                                "응? 황금 해바라기씨? 그거 얻으려면 동굴에 있는 비밀의 물건을 찾아와야해.:1",
                                                "동굴에 어떻게 가냐고? 그건 보니에게 물어봐봐.:2"});

        talkData.Add(110 + 3000, new string[] { "동굴에 가는 방법 알려달라고?:1",
                                                "아까 간식도 갖다줬으니 보답은 해야지.:2",
                                                "위쪽으로 쭉 가면 돼. 길이 막혀있는 건 내가 해결했으니까.:0"});
        talkData.Add(110 + 5000, new string[] { "비밀의 물건이 뭔지 나한테도 알려줘!:1" });
        talkData.Add(110 + 4000, new string[] { "의자가 있어서 난 행복해.:1" });


        talkData.Add(120 + 5000, new string[] { "비밀의 물건이 뭔지 나한테도 알려줘!:1" });
        talkData.Add(120 + 4000, new string[] { "의자가 있어서 난 행복해.:1" });
        talkData.Add(120 + 29000, new string[] {"동굴의 입구에 도착했다!"});

        talkData.Add(130 + 28000, new string[] {"비밀의 물건을 얻기 전에 돌아갈 수는 없지!" });
        talkData.Add(130 + 19000, new string[] {"전설의 낚싯대를 발견했다!" });
        talkData.Add(131 + 28000, new string[] {"동굴을 벗어난다!" });


        talkData.Add(140 + 35000,  new string[] { "돌로 만들어진 상자다 " });
        talkData.Add(140 + 29000, new string[] {"동굴은 이미 갔다 왔다." });
        talkData.Add(140 + 3000, new string[] { "비밀의 물건을 결국 발견했구나? 이제 다시 햄찌 마을로 가봐.:1" });
        talkData.Add(140 + 4000, new string[] { "황금 해바라기씨? 난 그것보다 의자가 더 좋아:0"});
        talkData.Add(140 + 5000, new string[] { "비밀의 물건은 전설의 낚싯대였구나!:2" });
        talkData.Add(140 + 6000, new string[] { "조심해서 돌아가!:0" });
        talkData.Add(140 + 7000, new string[] { "댕댕이 마을까지 갔다가 돌아온거야? 대단해!:0" });
        talkData.Add(140 + 1000, new string[] { "뭐? 전설의 낚싯대를 얻었다고?:1" });
        talkData.Add(140 + 2000, new string[] { "결국 전설의 낚싯대를 가져왔구나!:1",
                                                "이제 저 호수의 금색 낚시터에서 그 낚싯대를 써봐!:2"});

        talkData.Add(140 + 32000,   new string[] { "평범한 나무상자다." });
        talkData.Add(140 + 33000,  new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(140 + 26000, new string[] {"달라진 것이 없다." });


        talkData.Add(150 + 1000, new string[] { "안녕:1" });
        talkData.Add(150 + 2000, new string[] { "여어.:0" });
        talkData.Add(150 + 7000, new string[] { "안녕?:2" });
        talkData.Add(150 + 6000, new string[] { "안녕!:1" });
        talkData.Add(150 + 5000, new string[] { "하이~:1" });
        talkData.Add(150 + 4000, new string[] { "하이하이~:1" });
        talkData.Add(150 + 3000, new string[] { "불 좀 꺼줄래?:1" });

        talkData.Add(150 + 26000, new string[] {"전설의 낚싯대를 사용한다!" });
        talkData.Add(150 + 35000,  new string[] { "돌로 만들어진 상자다. " });
        talkData.Add(150 + 32000,  new string[] { "평범한 나무상자다." });
        talkData.Add(150 + 33000,  new string[] { "누군가 사용했던 흔적이 있는 책상이다." });

        talkData.Add(151 + 27000, new string[] {"오예!!! 드디어 황금 해바라기씨를 얻었다!" });

        talkData.Add(151 + 35000,  new string[] { "돌로 만들어진 상자다. " });
        talkData.Add(151 + 32000,  new string[] { "평범한 나무상자다." });
        talkData.Add(151 + 33000,  new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(151 + 26000, new string[] {"황금 해바라기씨를 얻은 낚시터이다." });

        talkData.Add(160 + 1000, new string[] { "황금 해바라기씨? 진짜 멋지다!!:1" });
        talkData.Add(160 + 2000, new string[] { "이 호수의 전설인 황금 해바라기씨를 보게 될 줄은 몰랐어!:0" });
        talkData.Add(160 + 3000, new string[] { "축하해. 내 간식은 없는거야?:1" });
        talkData.Add(160 + 4000, new string[] { "황금 의자가 아니라서 아쉽군.:1" });
        talkData.Add(160 + 5000, new string[] { "멋진걸! 축하해!:1" });
        talkData.Add(160 + 6000, new string[] { "황금 해바라기씨라니.. 대단해:1" });
        talkData.Add(160 + 7000, new string[] { "평생 먹을 수 있겠네?:1" });

        talkData.Add(160 + 32000,  new string[] { "평범한 나무상자다." });
        talkData.Add(160 + 33000,  new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(160 + 35000, new string[] {  "돌로 만들어진 상자다." });
        talkData.Add(160 + 26000, new string[] {"황금 해바라기씨를 얻은 낚시터이다." });

        //초상화 표정 Portrait Data    
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
        portraitData.Add(3000 + 0, portraitArr[8]);
        portraitData.Add(3000 + 1, portraitArr[9]);
        portraitData.Add(3000 + 2, portraitArr[10]);
        portraitData.Add(3000 + 3, portraitArr[11]);
        portraitData.Add(4000 + 0, portraitArr[12]);
        portraitData.Add(4000 + 1, portraitArr[13]);
        portraitData.Add(4000 + 2, portraitArr[14]);
        portraitData.Add(4000 + 3, portraitArr[15]);
        portraitData.Add(5000 + 0, portraitArr[16]);
        portraitData.Add(5000 + 1, portraitArr[17]);
        portraitData.Add(5000 + 2, portraitArr[18]);
        portraitData.Add(5000 + 3, portraitArr[19]);
        portraitData.Add(6000 + 0, portraitArr[20]);
        portraitData.Add(6000 + 1, portraitArr[21]);
        portraitData.Add(6000 + 2, portraitArr[22]);
        portraitData.Add(6000 + 3, portraitArr[23]);
        portraitData.Add(7000 + 0, portraitArr[24]);
        portraitData.Add(7000 + 1, portraitArr[25]);
        portraitData.Add(7000 + 2, portraitArr[26]);
        portraitData.Add(7000 + 3, portraitArr[27]);




    }

    public string GetTalk(int id, int talkIndex)
    {
        //예외처리
        //ContainsKey(): Dictionary안에 Key가 존재하는지 검사
        if (!talkData.ContainsKey(id)) {
            if (!talkData.ContainsKey(id - id % 10))
            {

                return GetTalk(id - id % 100, talkIndex); //Get First Talk 퀘스트 맨 처음 대사마저 없을 때 기본 대사를 가지고 온다.
                
            }
            else {
                return GetTalk(id - id % 10, talkIndex); //Get First Quest 해당 퀘스트 진행 순서 중 대사가 없을 때 퀘스트 맨 처음 대사를 가지고 온다.
            }
        }

        if (talkIndex == talkData[id].Length) //talkIndex와 대화의 문장 개수를 비교하여 끝 확인하기
            return null;
        else
            return talkData[id][talkIndex]; //id가 없으면 퀘스트 대화순서 제거 후 재탐색
            
      }
        
    //지정된 초상화 스프라이트를 반환할 함수
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
