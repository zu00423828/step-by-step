using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class playermove : MonoBehaviour {
    public NetworkView nv;
    public Vector3[] postion = //new Vector3[]
            {new Vector3(5.1f,-3.3f), new Vector3(4f,-3.3f), new Vector3(2.9f,-3.3f), new Vector3(1.7f,-3.3f),
             new Vector3(0.6f,-3.3f), new Vector3(-0.6f,- 3.3f),new Vector3(-1.7f,-3.3f), new Vector3(-2.9f,-3.3f),
             new Vector3(-4f,-3.3f), new Vector3(-5.1f,-3.3f),
             new Vector3(-5.1f,-2.25f), new Vector3(-5.1f,-1.1f),new Vector3(-5.1f,0f), new Vector3(-5.1f,1.15f),
             new Vector3(-5.1f,2.3f), new Vector3(-5.1f,3.4f),new Vector3(-4f,3.4f), new Vector3(-2.9f,3.4f),
             new Vector3(-1.7f,3.4f), new Vector3(-0.6f,3.4f),
             new Vector3(0.6f,3.4f),new Vector3(1.7f,3.4f), new Vector3(2.9f,3.4f),new Vector3(4f,3.4f),
             new Vector3(5.1f,3.4f),new Vector3(5.1f,2.3f), new Vector3(5.1f,1.15f),new Vector3(5.1f,0f),
             new Vector3(5.1f,-1.1f),new Vector3(5.1f,-2.25f)
            };
    public bool[] question_key = new bool[10]{true,true,true,true,true,true,true,true,true,true };
    public GameObject question;
    public int index,count_index=0;
    public List<string> player_name=new List<string>();
    bool set = false;//用來開始
    bool set1 = false;//用來結束
    // Use this for initialization
    void Start () {
        gameObject.transform.position = postion[0];
        for (int i = 1; i <= 4; i++)
            if (gameObject.name == "player" + i)
                gameObject.SetActive(false);
     
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == Network.player.port.ToString())
        {
            send();
            index = count.sum;
            if (count_index > 29 && dic_block.dic_start == true)  //大於30格
            {
                if (IsInvoking() == false)
                {
                    count_index = -1;
                    count.sum = count.sum % 30;
                    Invoke("time", 0.3f);
                }

            }
            else if (count_index < index && dic_block.dic_start == true) //前進未停止
            {
                if (IsInvoking() == false)
                    Invoke("time", 0.3f);
            }

            else if (count_index >= index && dic_block.dic_start == true) //前進停止
            {
                //mode1();
                mode2();
            }
            if (dic_block.question_count == 10 && set1 == false)
            {
                set1 = true;
                nv.RPC("end", RPCMode.All, gameObject.name, true);
            }
        }
             
    }
    void mode1()
    {
        dic_block.dic_start = false;
        Destroy(GameObject.Find(dic_block.i.ToString()), 0.2f);
        if (gameObject.transform.position == postion[1])
        {
            if (question_key[0])
                Invoke("questionOn", 0.8f);
            question_key[0] = false;
        }
        if (gameObject.transform.position == postion[4])
        {
            if (question_key[1])
                Invoke("questionOn", 0.8f);
            question_key[1] = false;
        }
        if (gameObject.transform.position == postion[7])
        {
            if (question_key[2])
                Invoke("questionOn", 0.8f);
            question_key[2] = false;
        }
        if (gameObject.transform.position == postion[10])
        {
            if (question_key[3])
                Invoke("questionOn", 0.8f);
            question_key[3] = false;
        }
        if (gameObject.transform.position == postion[13])
        {
            if (question_key[4])
                Invoke("questionOn", 0.8f);
            question_key[4] = false;
        }
        if (gameObject.transform.position == postion[16])
        {
            if (question_key[5])
                Invoke("questionOn", 0.8f);
            question_key[5] = false;
        }
        if (gameObject.transform.position == postion[19])
        {
            if (question_key[6])
                Invoke("questionOn", 0.8f);
            question_key[6] = false;
        }
        if (gameObject.transform.position == postion[22])
        {
            if (question_key[7])
                Invoke("questionOn", 0.8f);
            question_key[7] = false;
        }
        if (gameObject.transform.position == postion[25])
        {
            if (question_key[8])
                Invoke("questionOn", 0.8f);
            question_key[8] = false;
        }
        if (gameObject.transform.position == postion[28])
        {
            if (question_key[9])
                Invoke("questionOn", 0.8f);
            question_key[9] = false;
        }
    }
    void mode2()
    {
        dic_block.dic_start = false;
        Destroy(GameObject.Find(dic_block.i.ToString()), 0.2f);
        Invoke("questionOn", 0.8f);
    }
    void time()
    {
        count_index++;
        if(count_index<30)
        gameObject.transform.position = postion[count_index];
        else
            gameObject.transform.position = postion[0];
        send();
    }
    public void send()
    {
        nv.RPC("Message", RPCMode.All, gameObject.name, gameObject.transform.position, dic_block.score_count);
    }
    void questionOn()
    {
        
        question.SetActive(true);
    }
    [RPC]//這行一定要打！
    private void Message(string player,Vector3 vec,int score)//接收伺服器端傳過來的參數
    {
        GameObject.Find(player).transform.position = vec;
        //print(score);
        GameObject.Find(player+"_score").GetComponent<Text>().text="Score："+score;  
    }
    [RPC]//這行一定要打！
    private void end(string player,bool key)//接收伺服器端傳過來的參數
    {
        dic_block.key.Add(key);
    }

}
