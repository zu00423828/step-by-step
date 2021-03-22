using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
public class playscript : MonoBehaviour {
    public Dropdown choose_chart;
    public Button choose_start;
    public GameObject game_block;
    public Button Server_button;
    public Text ip_text;
    public GameObject player_num;
    public Button Client_button;
    public GameObject input_ip;
    public NetworkView nv;
    public Text[] ts = new Text[4];
    public List<string> player_name = new List<string>();
    bool set = false;
    public static int chooseindex;
    public Button backbutton;
    public GameObject back;
    public GameObject wait;
    public string ch_url;
    // Use this for initialization
    void Start()
    {
        chooseindex = 0;
        StartCoroutine("get_ch");
    }
	// Update is called once per frame
	void Update (){
        if (Network.isClient && player_name.Count == 4)
        {
            int i = 0;
            while (i < player_name.Count)
            {
                ts[i].transform.name = player_name[i]+"_score";
                ts[i].transform.parent.name = player_name[i] + "_score_text";
                game_block.transform.GetChild(1 + i).name = player_name[i];
                i++;
            }
        }
        if(Network.isClient)
        {
            Client_button.GetComponentInChildren<Text>().text = "用 戶 端 斷 線";
            input_ip.GetComponent<InputField>().text = "";
            input_ip.SetActive(false);
            wait.SetActive(true);
        }
        if (Network.isServer)
        {
            if (Network.connections.Length > 0 && Network.connections.Length <= 3 && set == false)
            {
                player_num.GetComponent<Text>().text = "人數=" + Network.connections.Length;
                game_block.transform.GetChild(1).name = Network.player.port.ToString();                
                player_name[0] = Network.player.port.ToString();
                ts[0].transform.name = player_name[0] + "_score";
                ts[0].transform.parent.name = player_name[0] + "_score_text";
                nv.RPC("setting", RPCMode.OthersBuffered, 0, Network.player.port.ToString());
                for (int i = 0; i < Network.connections.Length; i++)
                {
                    game_block.transform.GetChild(2 + i).name = Network.connections[i].port.ToString();
                    player_name[i+1] = Network.connections[i].port.ToString();
                    ts[i+1].transform.name = player_name[1+i] + "_score";
                    ts[i + 1].transform.parent.name = player_name[1 + i] + "_score_text";
                    nv.RPC("setting", RPCMode.OthersBuffered, i + 1, Network.connections[i].port.ToString());
                }
                if (Network.connections.Length == 3)
                {
                    choose_start.interactable = true;
                    set = true;

                }

                // print(Network.connections[0].ipAddress);
            }
            else
            {
                player_num.GetComponent<Text>().text = "人數=" + Network.connections.Length;
            }
        }
    }
    public void choseclick()
    {
        if(Network.isServer&&Network.connections.Length==3)
        {
            chooseindex = choose_chart.value;
            nv.RPC("playset", RPCMode.OthersBuffered,chooseindex);
            gameObject.SetActive(false);
            game_block.SetActive(true);
        }
            
    }
    public void serverOnclick()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)//若當前未連線(伺服器未開啟)
        {
            //顯示Button，Button的文字為Start Server
            if (Server_button.GetComponentInChildren<Text>().text=="伺 服 器")
            {
                Network.InitializeServer(4, 8000, !Network.HavePublicAddress());//初始化伺服器。第一個參數為連線的人數上限，第二個參數為連線的port，第三個參數為是否要使用NAT
                MasterServer.RegisterHost("AAA", "BBB", "CCC");//第一個參數為連線時要搜尋的字串，字串相同則會連線，可使用中文；第二個為遊戲名稱；第三個為遊戲註解；第二個和第三個參數對於連線之間並沒用影響。此程式碼必須寫在初始化伺服器之後，由客戶端搜尋特定的字串(像是這邊為"AAA")，來建立連線。
                ip_text.text = Network.player.ipAddress;
                Server_button.GetComponentInChildren<Text>().text = "伺 服 器 關 閉";
                player_num.SetActive(true);
                choose_chart.transform.gameObject.SetActive(true);
                choose_start.transform.gameObject.SetActive(true);
            }
        }
        
        else//伺服器初始化成功(伺服器已開啟)
        {
            if (Server_button.GetComponentInChildren<Text>().text == "伺 服 器 關 閉")
            {
                Network.Disconnect();//中斷伺服器連線，一旦伺服器中斷則客戶端也會自動中斷
                Server_button.GetComponentInChildren<Text>().text = "伺 服 器";
                ip_text.text = "";
                player_num.SetActive(false);
                choose_chart.transform.gameObject.SetActive(false);
                choose_start.transform.gameObject.SetActive(false);
            }
        }

    }
    public void clientOnclink()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)//若是未連線
        {
            input_ip.SetActive(true);
            Client_button.GetComponentInChildren<Text>().text = "用 戶 端 連 線";
            if(Client_button.GetComponentInChildren<Text>().text == "用 戶 端 連 線"&&string.IsNullOrEmpty(input_ip.GetComponent<InputField>().text)==false)
            {
                Network.Connect(input_ip.GetComponent<InputField>().text, 8000);

                
            }
           
        }

        else
        {
            if (Client_button.GetComponentInChildren<Text>().text == "用 戶 端 斷 線")
            {
                Network.Disconnect();//中斷伺服器連線，一旦伺服器中斷則客戶端也會自動中斷
                Client_button.GetComponentInChildren<Text>().text = "用 戶 端";
                //ip_text.text = "";
                input_ip.SetActive(false);
                wait.SetActive(false);
            }
        }
        
    }
    [RPC]//這行一定要打！
    private void setting(int i,string player)//接收伺服器端傳過來的參數
    {
        player_name[i] = player;
    }
    [RPC]//這行一定要打！
    private void playset(int i)//接收伺服器端傳過來的參數
    {
        chooseindex = i;
        gameObject.SetActive(false);
        game_block.SetActive(true);
    }
    public void backclick()
    {
        Network.Disconnect();

        player_num.SetActive(false);
        choose_chart.transform.gameObject.SetActive(false);
        choose_start.transform.gameObject.SetActive(false);      
        Server_button.GetComponentInChildren<Text>().text = "伺 服 器";

        ip_text.text = "";
        input_ip.SetActive(false);
        Client_button.GetComponentInChildren<Text>().text = "用 戶 端";
        wait.SetActive(false);
        gameObject.SetActive(false);
        back.SetActive(true);
    }
    IEnumerator get_ch()
    {
        WWW www = new WWW(ch_url);
        yield return www;
        JsonData json = JsonMapper.ToObject<JsonData>(www.text);
        choose_chart.options.Clear();
        for (int i = 0; i < json.Count; i++)
        {
            choose_chart.options.Add(new Dropdown.OptionData { text = json[i][0].ToString() });
        }
    }
}
