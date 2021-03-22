using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
public class loginscript : MonoBehaviour {
    public Text hint;
    public InputField input_account;
    public InputField input_passsword;
    public Button sign;
    public Toggle teacher_check;
    public Toggle student_check;
    public GameObject teather_block;
    public GameObject student_block;
    public string webpath ;
    public static string account;
    public static string password;
	// Use this for initialization
	void Start () {
        
        teacher_check.onValueChanged.AddListener(toggleison);
        student_check.onValueChanged.AddListener(toggleison1);
        sign.onClick.AddListener(signOnClick);
        input_passsword.inputType = InputField.InputType.Password;
    }
	
	// Update is called once per frame
	void Update () {
  
        
    }

    void signOnClick()
    {
        if (teacher_check.isOn)
        {
            gameObject.SetActive(false);
            teather_block.SetActive(true);
        }
        if (student_check.isOn)
        {
            //gameObject.SetActive(false);
            //student_block.SetActive(true);
            StartCoroutine("web_connect");
           
        }
    }
    void toggleison(bool check)
    {
        student_check.isOn = !check;
    }
    void toggleison1(bool check)
    {
        teacher_check.isOn = !check;
    }
    IEnumerator web_connect()
    {
        account = "";
        password = "";
        account = input_account.text;
        password = input_passsword.text;
        WWWForm form = new WWWForm();
        if (account.IndexOf("u") == 0)
        {
            form.AddField("account", account);
            form.AddField("password", password);
            WWW www = new WWW(webpath, form);
            yield return www;
            hint.text = www.text;
            if (www.text == "success" || www.text == "insert")//登入成功
            {
                gameObject.SetActive(false);
                student_block.SetActive(true);
            }
            else if (account.Length != 8)
                hint.text = "請帳號請輸入學號共8個字";
            else
            {
                hint.text = "密碼錯誤";
            }
        }
        else if (account==""||password=="")
            hint.text = "請輸入帳密";
        else
            hint.text = "請打學號小寫英文開頭";

        /*      
        yield return www;
        JsonData json = JsonMapper.ToObject<JsonData>(www.text);
        print(json[0]["test"].ToString());
        */
    }
}
