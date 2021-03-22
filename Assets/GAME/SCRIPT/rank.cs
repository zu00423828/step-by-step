using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
public class rank : MonoBehaviour {
    public Text[] username=new Text[5];
    public Text[] userscore = new Text[5];
    public string rank_web;
    public Button backbutton;
    public GameObject back;
	// Use this for initialization
	void Start () {
        
        backbutton.onClick.AddListener(backclick);
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("studentrank");
    }
    void backclick()
    {
        gameObject.SetActive(false);
        back.SetActive(true);
    }
    IEnumerator studentrank()
    {
        WWW www = new WWW(rank_web);
        yield return www;
        JsonData json = JsonMapper.ToObject<JsonData>(www.text);
        for(int i=0;i<5;i++)
        {
            username[i].text = json[i][0].ToString();
            userscore[i].text = json[i][1].ToString();
        }
    }
}
