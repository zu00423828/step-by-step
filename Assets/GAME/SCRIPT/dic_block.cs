using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class dic_block : MonoBehaviour {
    public GameObject[] player_image=new GameObject[4];//提示是玩家幾
    public GameObject[] player_score_text = new GameObject[4];//玩家成績ui
    public int[] score_value = new int[4];//紀錄玩家成績
    public Button dic_button;
    public Text question_num;
    public Text score;
    public static int score_count;
    public static int i=0,question_count=0;  //i是骰子點數,question_count目前題數
    public static List<bool> key = new List<bool>();
    public GameObject dot;
    public GameObject child_dot;
    public GameObject dot_plane;
    public Text winter_title;
    public static bool dic_start=false; //錯開骰子人物移動時間
    public int play_count=0;
    public string updatescore_web;
    bool upkey = true;
    public string[] playername = new string[4];
    // Use this for initialization
    void Start()
    {
        //enabled = false;
        upkey = true;
        score_count = 0;
        i = 0;
        question_count = 0;
        dic_start = false;
        key.Clear();
        for (int i = 1; i <= 4; i++)
            if (GameObject.Find("game_block").transform.GetChild(i).name == Network.player.port.ToString())
                player_image[i-1].SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            if (player_score_text[i].name.IndexOf("player") == -1)
            {
                player_score_text[i].SetActive(true);
                play_count++;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {if ( !GameObject.Find(i.ToString())&&question_count!=10)
        if ( !GameObject.Find(i.ToString()))
            dic_button.interactable = true;
        else
            dic_button.interactable = false;
        //gamemode1();
        gamemode2();
    }
    //30取10要4位玩家結束才結束
    public void gamemode1()
    {
        question_num.text = "共10題，你已完成" + question_count + "題";
        if (question_count == 10)
        {
            question_num.text = "共10題，你已完成" + question_count + "題" + "你的遊戲結束";
            // print(key.Count);
            if (key.Count == play_count)
            {
                for (int i = 0; i < 4; i++)
                {
                    string a = player_score_text[i].transform.GetChild(1).GetComponent<Text>().text.Substring(6, player_score_text[i].transform.GetChild(1).GetComponent<Text>().text.Length - 6);
                    score_value[i] = System.Int32.Parse(a);
                }
                winter_title.transform.gameObject.SetActive(true);
                if (score_value[0] > score_value[1] && score_value[0] > score_value[2] && score_value[0] > score_value[3])
                {
                    winter_title.text = "勝利者是player1";
                    print("player1");
                }
                else if (score_value[1] > score_value[0] && score_value[1] > score_value[2] && score_value[1] > score_value[3])
                {
                    winter_title.text = "勝利者是player2";
                    print("player2");
                }
                else if (score_value[2] > score_value[0] && score_value[2] > score_value[1] && score_value[2] > score_value[3])
                {
                    winter_title.text = "勝利者是player3";
                    print("player3");
                }
                else if (score_value[3] > score_value[0] && score_value[3] > score_value[1] && score_value[3] > score_value[2])
                {
                    winter_title.text = "勝利者是player4";
                    print("player4");
                }
                else
                {
                    winter_title.text = "有人平手";
                    print("有人平手");
                }

            }
            if (upkey)
            {
                for (int i = 1; i <= 4; i++)
                    if (GameObject.Find("game_block").transform.GetChild(i).name == Network.player.port.ToString())
                        StartCoroutine("updatescore", (i - 1));
                upkey = false;
            }

        }
    }
    //最快結束的玩家獲勝
    public void gamemode2()
    {
        //存成績
        for (int i = 0; i < 4; i++)
        {
            question_num.text = "共10題，你已完成" + question_count + "題";
            string a = player_score_text[i].transform.GetChild(1).GetComponent<Text>().text.Substring(6, player_score_text[i].transform.GetChild(1).GetComponent<Text>().text.Length - 6);
            score_value[i] = System.Int32.Parse(a);
            if (score_value[i] == 100)
            {
                winter_title.transform.gameObject.SetActive(true);
                winter_title.text = "勝利者是" + playername[i];
                if (upkey)
                {
                    for (int j = 1; j <= 4; j++)
                        if (GameObject.Find("game_block").transform.GetChild(j).name == Network.player.port.ToString())
                            StartCoroutine("updatescore", (j - 1));
                    upkey = false;
                }                
                dic_button.interactable = false;
                enabled = false;
            }
        }
        
    }
    public void dicclick()
    {     
        Random.InitState(System.Guid.NewGuid().GetHashCode());
        child_dot = Instantiate(dot);
        child_dot.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        Destroy(child_dot, 0.4f);
        i = Random.Range(1, 6);
        dot_plane=(GameObject)Instantiate( Resources.Load((i).ToString()));
        dot_plane.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        dot_plane.gameObject.name = i.ToString();
        dic_button.interactable = false;
        Invoke("timedelay", 0.5f);
        count.sum_count();
    }
    public void restart()
    {
        Network.Disconnect();
        enabled = true;
        dic_button.interactable = true;
        Application.LoadLevel(Application.loadedLevel);
    }
    void timedelay()
    {
       
        dic_start = true;
    }
    IEnumerator updatescore(int i)
    {
        WWWForm form = new WWWForm();
        form.AddField("id",loginscript.account);
        form.AddField("chapter",playscript.chooseindex);
        /*form.AddField("id", "u1035203");
        form.AddField("chapter", 0);*/
        form.AddField("score", score_value[i]);
        WWW www = new WWW(updatescore_web,form);
        yield return www;
        print(www.text);
    }
}
