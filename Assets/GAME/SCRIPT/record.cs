using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class record : MonoBehaviour {
    public Text field_number;
    public Text best_score;
    public Text average_score;
    public string record_web;
    public Button backbutton;
    public GameObject back;
	// Use this for initialization
	void Start () {
        
        backbutton.onClick.AddListener(backclick);
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("studentrecord");
    }
    void backclick()
    {
        gameObject.SetActive(false);
        back.SetActive(true);
    }
    IEnumerator studentrecord()
    {
        WWWForm form = new WWWForm();
        form.AddField("id",loginscript.account);

        WWW www = new WWW(record_web,form);
        yield return www;
        JsonData json = JsonMapper.ToObject<JsonData>(www.text);
        print(www.text);
        field_number.text = json[0]["count"].ToString();
        if(json[0]["max"].ToString()!=""|| json[0]["avg"].ToString()!="")
        {
            best_score.text = json[0]["max"].ToString();
            average_score.text =json[0]["avg"].ToString();
        }
        
    }
}
