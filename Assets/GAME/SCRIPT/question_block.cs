
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
public class question_block : MonoBehaviour {
    public Text question;
    public Button answer1;
    public Button answer2;
    public Button answer3;
    public Button answer4;
    public int index;
    public int index2;
    public List<quetion_and_answer> question_bank = new List<quetion_and_answer>();
    int random_num;
    public string quesyion_url;
    // Use this for initialization
    void Start () {

        //setquestion();
        StartCoroutine("connect_question");
        //index =question_bank.FindIndex(x => x.chapter == playscript.chooseindex);
        //index2 = index;
        index = 0;


    }

    // Update is called once per frame
    void Update() {
        /*
        question.text = question_bank[index2].question_value;
        answer1.GetComponentInChildren<Text>().text = question_bank[index2].answer1_value;
        answer2.GetComponentInChildren<Text>().text = question_bank[index2].answer2_value;
        answer3.GetComponentInChildren<Text>().text = question_bank[index2].answer3_value;
        answer4.GetComponentInChildren<Text>().text = question_bank[index2].answer4_value;
        */
        if(question_bank.Count!=0)
        {
            question.text = question_bank[random_num].question_value;
            answer1.GetComponentInChildren<Text>().text = question_bank[random_num].answer1_value;
            answer2.GetComponentInChildren<Text>().text = question_bank[random_num].answer2_value;
            answer3.GetComponentInChildren<Text>().text = question_bank[random_num].answer3_value;
            answer4.GetComponentInChildren<Text>().text = question_bank[random_num].answer4_value;
        }

    }
    public void Onclick(GameObject g)
    {
        /*
         if (g.name == question_bank[index2].keybutton)
         {
             print("答對");
             dic_block.score_count += 10;
             gameObject.SetActive(false);
             //index++;
             index2++;
             dic_block.question_count++;
         }
         else
         {
             gameObject.SetActive(false);
             //index++;
             index2++;
         }    
         if (index2-index==9)
             index2 = index;*/
        if (g.name == question_bank[random_num].keybutton)
        {
            print("答對");
            dic_block.score_count += 10;
            gameObject.SetActive(false);
            dic_block.question_count++;
        }
        else
        {
            gameObject.SetActive(false);
        }
        rand();
    }
    void rand()
    {
        Random.InitState(System.Guid.NewGuid().GetHashCode());
        random_num = Random.Range(index, (question_bank.Count-1));
        print(question_bank.Count);
    }
    void setquestion()
    {
        //第0章
        question_bank.Add(new quetion_and_answer { chapter = 0, question_value = "關於組合語言下列敘述何者正確？", answer1_value = "為低階語言", answer2_value = "需經翻譯才能執行", answer3_value= "隨機器種類而不同", answer4_value= "以上皆是", keybutton="answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 0, question_value = "下列那一項不是高階語言的優點？", answer1_value = "佔記憶體的空間小", answer2_value = "程式容易維護", answer3_value = "程式可攜性高", answer4_value = "易學", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 0, question_value = "下列有關直譯器(interpreter)的敘述何者錯誤？", answer1_value = "直譯器將高階語言翻譯成機器碼", answer2_value = "翻譯過程中，遇到語法的錯誤即停止", answer3_value = "翻譯成機器碼後立即執行", answer4_value = "翻譯後會產生目的檔", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 0, question_value = "下列何者不屬於物件導向程式特性？", answer1_value = "繼承性(Inheritance)", answer2_value = "結構性(Structuralism)", answer3_value = "封裝性(Encapsulation)", answer4_value = "多型性(Polymorphism)", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 0, question_value = "能直接讓電腦接受的程式語言是？", answer1_value = "C", answer2_value = "BASIC", answer3_value = "機器語言", answer4_value = "組合語言", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 0, question_value = "執行速度最快的語言是？", answer1_value = "機器語言", answer2_value = "組合語言", answer3_value = "COBOL", answer4_value = "PASCAL", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 0, question_value = "美國國防部基於軍事需要設計的標準語言是？", answer1_value = "LISP", answer2_value = "ADA", answer3_value = "LOGO", answer4_value = "FORTH", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 0, question_value = "下列何種程式語言適合應用在人工智慧的軟體開發？", answer1_value = "LISP", answer2_value = "C++", answer3_value = "JAVA", answer4_value = "BASIC", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 0, question_value = "下列何種程式語言適合適合科學及工程方面的計算？", answer1_value = "COBOL", answer2_value = "FORTRAN", answer3_value = "JAVA", answer4_value = "C", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 0, question_value = "下列有關編譯器(Compiler)的敘述何者錯誤？", answer1_value = "編譯時間較長", answer2_value = "具有碼的最佳化(code optimization)功能", answer3_value = "翻譯成機器碼後立即執行", answer4_value = "翻譯後會產生目的檔", keybutton = "answer3" });

        //第1章
        question_bank.Add(new quetion_and_answer { chapter = 1, question_value = "C# 專案檔副檔名為何？", answer1_value = "cs", answer2_value = "proj", answer3_value = "csproj", answer4_value = "sln", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 1, question_value = "C# 是以什麼單位來管理大型應用程式？", answer1_value = "視窗", answer2_value = "方案", answer3_value = "專案", answer4_value = "Form", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 1, question_value = "「按鈕」工具是一種什麼？", answer1_value = "類別", answer2_value = "物件", answer3_value = "事件", answer4_value = "屬性", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 1, question_value = "「Button1」控制項是什麼？", answer1_value = "類別", answer2_value = "物件", answer3_value = "事件", answer4_value = "屬性", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 1, question_value = "描述「Label1」與「Label2」兩個不一樣的物件是什麼？", answer1_value = "屬性", answer2_value = "物件", answer3_value = "事件", answer4_value = "類別", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 1, question_value = "設定Form標題欄文字，需更改哪個屬性？", answer1_value = "Title", answer2_value = "Name", answer3_value = "Caption", answer4_value = "Text", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 1, question_value = "C# 支援下列何種程式語言？", answer1_value = "C++", answer2_value = "JavaScript", answer3_value = "Python", answer4_value = "以上皆是", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 1, question_value = "下列何種程式語言不支援C#？", answer1_value = "C++", answer2_value = "JavaScript", answer3_value = "Assembly", answer4_value = "F#", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 1, question_value = "在Visual Studio 2015環境中，哪一種版本是提供給小型團隊軟體開發？", answer1_value = "快速版(Express)", answer2_value = "社群版(Community)", answer3_value = "MSDN專業版(Professional)", answer4_value = "MSDN企業版(Enterprise)", keybutton = "answe3" });
        question_bank.Add(new quetion_and_answer { chapter = 1, question_value = ".NET Framework 支援下列何種程式語言？", answer1_value = "C++", answer2_value = "Visual Basic", answer3_value = "C#", answer4_value = "以上皆是", keybutton = "answer4" });

        //第2章
        question_bank.Add(new quetion_and_answer { chapter = 2, question_value = "控制項Text屬性功能為何？", answer1_value = "設定控制項背景色", answer2_value = "設定控制項標題", answer3_value = "設定控制項前景色", answer4_value = "設定物件名稱", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 2, question_value = "下列哪些 Data Type在記憶體中所佔據的空間不是8 bytes？", answer1_value = "double", answer2_value = "DateTime", answer3_value = "long", answer4_value = "float", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 2, question_value = "儲存「身分證字號」的Data Type下列何者最適合？", answer1_value = "float", answer2_value = "long", answer3_value = "string", answer4_value = "byte", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 2, question_value = "儲存「98000」的Data Type下列何者最適合？", answer1_value = "float", answer2_value = "long", answer3_value = "int", answer4_value = "byte", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 2, question_value = "下列何者不是C# 的關鍵字？", answer1_value = "int", answer2_value = "case", answer3_value = "ref", answer4_value = "num", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 2, question_value = "儲存「姓名」的Data Type下列何者最適合？", answer1_value = "string", answer2_value = "char", answer3_value = "DateTime", answer4_value = "byte", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 2, question_value = "儲存「生日」的Data Type下列何者最適合？", answer1_value = "string", answer2_value = "char", answer3_value = "DateTime", answer4_value = "byte", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 2, question_value = "儲存「員工薪水」的Data Type下列何者最適合？", answer1_value = "decimal", answer2_value = "double", answer3_value = "int", answer4_value = "float", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 2, question_value = "假設有一資料常值為true，要儲存此資料的Data Type為何？", answer1_value = "string", answer2_value = "int", answer3_value = "bool", answer4_value = "byte", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 2, question_value = "敘述 int score=55 ，要將score變數顯示在lblScore標籤上，其程式敘述應如何撰寫？", answer1_value = "lblScore.Name = score", answer2_value = "lblScore.Caption=score", answer3_value = "lblScore.Text=score.ToString()", answer4_value = "lblScore.Text=score", keybutton = "answer3" });

        //第3章
        question_bank.Add(new quetion_and_answer { chapter = 3, question_value = "Windows Form應用程式會使用哪一個控制項來當容器？", answer1_value = "Form", answer2_value = "標籤控制項", answer3_value = "Button控制項", answer4_value = "TextBox控制項", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 3, question_value = "在Form設計階段要修改控制項屬性設定，要開啟什麼？", answer1_value = "方案總管", answer2_value = "專案視窗", answer3_value = "屬性視窗", answer4_value = "程式碼視窗", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 3, question_value = "要改變一個物件的性質，是要改變物件的什麼？", answer1_value = "方法", answer2_value = "屬性", answer3_value = "常數", answer4_value = "事件", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 3, question_value = "哪個屬性是所有物件都有？", answer1_value = "Text", answer2_value = "Name", answer3_value = "Font", answer4_value = "BackColor", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 3, question_value = "要改變Form標題欄的圖示，須設定哪個屬性？", answer1_value = "BackColor", answer2_value = "BackgroundImage", answer3_value = "Icon", answer4_value = "ControlBox", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 3, question_value = "在Form設計階段，快按兩下Form空白處，會進入哪個事件處理函式？", answer1_value = "Click", answer2_value = "Load", answer3_value = "DoubleClick", answer4_value = "Activated 事件", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 3, question_value = "在Form上快按兩下，請問下面哪個事件不會被觸動？", answer1_value = "Load", answer2_value = "DoubleClick", answer3_value = "Click", answer4_value = "Activated 事件", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 3, question_value = "Button控制項無法點按，須設定哪個屬性？", answer1_value = "Enabled", answer2_value = "TabIndex", answer3_value = "TabStop", answer4_value = "Visible", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 3, question_value = "下列敘述何者錯誤？", answer1_value = "Form只能在Form設計階段設定，無法在程式執行階段設定", answer2_value = "Form是一個容器，可以放置多個控制項", answer3_value = "Form本身可視為一個物件", answer4_value = "Form載入時會觸發Load事件", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 3, question_value = "例外處理中發生錯誤時要處理的程式碼，要寫在哪個區塊中？", answer1_value = "try", answer2_value = "if", answer3_value = "catch", answer4_value = "else", keybutton = "answer3" });

        //第4章
        question_bank.Add(new quetion_and_answer { chapter = 4, question_value = "下列敘述哪項不是選擇結構？", answer1_value = "if…else", answer2_value = "if…else if…else", answer3_value = "switch", answer4_value = "for", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 4, question_value = "下列敘述哪項執行時會造成錯誤？", answer1_value = "if (i>0) x= \"OK\"", answer2_value = "if (i>0) { x=\"OK\"} else { x=\"NO\" }", answer3_value = "if (i>5) x= \"OK\"", answer4_value = "if (i>0 And i<100) x=\"OK\"",keybutton="answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 4, question_value = "a在大於等於60，小於等於100之間的條件式寫法為何？", answer1_value = "(a >= 60 && a <= 100)", answer2_value = "60 <=a<=100", answer3_value = "(a>=60 || a<=100)", answer4_value = "(a>=60 Or a>=100)", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 4, question_value = "得知選項按鈕是否被選取，要檢查哪個屬性值？", answer1_value = "Checked", answer2_value = "CheckState", answer3_value = "Enable", answer4_value = "AutoCheck", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 4, question_value = "下列何種情況不能作為switch敘述的條件值？", answer1_value = "1", answer2_value = "\"A\"", answer3_value = "\"a\"", answer4_value = "1 To 10", keybutton = "answer4" });
        //question_bank.Add(new quetion_and_answer { chapter = 4, question_value = "if的條件判斷敘述為(x && y || z)，下列何為false？", answer1_value = "x=true  y=true  z=false", answer2_value = " x=true  y=true  z=true", answer3_value = "x=false  y=true  z=false", answer4_value = "x=false  y=true  z=true", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 4, question_value = "同群組的選項按鈕維持只有一個被選取是靠哪個屬性？", answer1_value = "Appearance", answer2_value = "AutoCheck", answer3_value = "Checked", answer4_value = "Enabled", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 4, question_value = "GroupBox控制項左上角標題是由哪個屬性來設定？", answer1_value = "Caption", answer2_value = "Title", answer3_value = "Text", answer4_value = "Value", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 4, question_value = "RadionButton與CheckBox群組何者可以做多選？", answer1_value = "RadionButton", answer2_value = "CheckBox", answer3_value = "兩者都可以", answer4_value = "兩者都不可以", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 4, question_value = "哪個控制項可以包含其他控制項？", answer1_value = " RadionButton", answer2_value = "Panel", answer3_value = "TextBox", answer4_value = "Button", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 4, question_value = "若RadionButton有多組選項要隔離，可使用哪個控制項來達成？", answer1_value = "RadionButton", answer2_value = "GroupBox", answer3_value = "TextBox", answer4_value = "Button", keybutton = "answer2" });

        //第5章
        question_bank.Add(new quetion_and_answer { chapter = 5, question_value = "何者不是C# 的重複結構指令？", answer1_value = "for", answer2_value = "switch…", answer3_value = "do…while", answer4_value = "while…", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 5, question_value = "Timer控制項物件每1秒執行1次Tick事件，Interval屬性值設定多少？", answer1_value = "1", answer2_value = "10", answer3_value = "100", answer4_value = "1000", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 5, question_value = "若 C# 迴圈內數值變數會有規則遞減或遞增時，哪一種重複結構較為適合？", answer1_value = "switch…", answer2_value = "while…", answer3_value = "for", answer4_value = "do…while", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 5, question_value = "下面敘述何者正確？", answer1_value = "while…迴圈內的敘述一定會被執行", answer2_value = "for迴圈的終值必須大於初值", answer3_value = "當迴圈內的敘述執行次數無法預知時應該使用while…迴圈", answer4_value = "for迴圈的增值變數不可以是小數", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 5, question_value = "for(int k=-5 k<=6 k++){x += \" * \" }，請問執行後x字串的*有幾個？", answer1_value = "5", answer2_value = "10", answer3_value = "11", answer4_value = "12", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 5, question_value = "迴圈內敘述區段可能不會執行應該使用哪一種迴圈？", answer1_value = "do…while", answer2_value = "while…", answer3_value = "for", answer4_value = "foreach…", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 5, question_value = "do…while敘述可搭配哪個指令，來跳離迴圈？", answer1_value = "end", answer2_value = "exit do", answer3_value = "goto", answer4_value = "break", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 5, question_value = "PictureBox控制項中圖片大小等比例自動調整，須設定SizeMod	e屬性值為何？", answer1_value = "AutoSize", answer2_value = "CenterImage", answer3_value = " StretchImage", answer4_value = "Zoom", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 5, question_value = "哪個控制項隱含有重複結構功能？", answer1_value = "Form", answer2_value = "ImageList", answer3_value = "PictureBox", answer4_value = "Timer", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 5, question_value = "如果要取得目前日期與時間可哪個控制項？", answer1_value = "DateTime.Now", answer2_value = "DateTime.Date", answer3_value = "DateTime.Year", answer4_value = "DateTime.Today", keybutton = "answer1" });

        //第6章
        question_bank.Add(new quetion_and_answer { chapter = 6, question_value = "int[] A = new int[6] ，請問陣列A共有多少個陣列元素？", answer1_value = "4", answer2_value = "5", answer3_value = "6", answer4_value = "7", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 6, question_value = "對於陣列敘述下列何者錯誤？", answer1_value = "將不同性質資料集中放在連續記憶體位址", answer2_value = "陣列元素括號內的數字稱為註標或索引", answer3_value = "一個陣列元素相當於一個變數名稱", answer4_value = "註標值(index)可存取陣列中的任何一個元素", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 6, question_value = "對於陣列敘述下列何者正確？", answer1_value = "將同性質資料集中放在連續記憶體位址", answer2_value = "不是一種資料結構", answer3_value = "註標由 1 開始", answer4_value = "取代多個不同性質變數", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 6, question_value = "要取得清單控制項的項目個數，可使用哪個方法或屬性？", answer1_value = "AddRange", answer2_value = "Count", answer3_value = "FindString", answer4_value = "SetSelected", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 6, question_value = "清除陣列指定元素內容，要使用哪個方法？", answer1_value = "Clear", answer2_value = "Eease", answer3_value = "Remove", answer4_value = "RemoveAt", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 6, question_value = "哪一種清單控制項可以讓使用者輸入文字資料？", answer1_value = "CheckBox", answer2_value = "CheckListBox", answer3_value = "ComboBox", answer4_value = "ListBox", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 6, question_value = "ListBox控制項中項目可以複選，須設定哪個屬性？", answer1_value = "MultiColumns", answer2_value = "SelectedIndex", answer3_value = "SelectedItem", answer4_value = "SelectionMode", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 6, question_value = "ListBox控制項要插入新的項目到指定位置時，可使用哪個方法？", answer1_value = "Add", answer2_value = "AddRange", answer3_value = "CopyTo", answer4_value = "Insert", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 6, question_value = "要取得ListBox控制項存放資料的總數，可從哪個屬性取得？", answer1_value = "Items.Count", answer2_value = "Items.Num", answer3_value = "Items.Total", answer4_value = "Count", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 6, question_value = "清除ListBox控制項中的所有資料項目，須使用哪個方法？", answer1_value = "Clear", answer2_value = "Items.Clear", answer3_value = "Cls", answer4_value = "Items.Reomve", keybutton = "answer2" });

        //第7章
        question_bank.Add(new quetion_and_answer { chapter = 7, question_value = "LinkLabel控制項按下但未放開時，超連結文字顯示的顏色須設定哪個屬性？", answer1_value = "ActiveLinkColor", answer2_value = "LinkColor", answer3_value = "LinkVisited", answer4_value = "VisitedLinkColor", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 7, question_value = "ToolTip控制項顯示提示時間，須設定哪個屬性？", answer1_value = "Active", answer2_value = "AutoPopDelay", answer3_value = "InitialDalay", answer4_value = "ReShowDelay", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 7, question_value = "TrackBar控制項目前滑動鈕數值，設定或取得要使用哪個屬性？", answer1_value = "Maximum", answer2_value = "Minimum", answer3_value = "TickFrequency", answer4_value = "Value", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 7, question_value = "ScrollBar控制項使用者能輸入的最大數值，設定或取得要使用哪個屬性？", answer1_value = "Maximum", answer2_value = "Minimum", answer3_value = "LargeChange", answer4_value = "Value", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 7, question_value = "MonthCalender控制項使用者選取開始日期，要使用哪個屬性？", answer1_value = "MaxDate", answer2_value = "MinDate", answer3_value = "SelectionEnd", answer4_value = "SelectionRange.Start", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 7, question_value = "DateTimePicker控制項顯示MonthCalender，要使用哪個屬性？", answer1_value = "Checked", answer2_value = "Format", answer3_value = "ShowCheckBox", answer4_value = "ShowUpDown", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 7, question_value = "linkLabel1.Text = \"tw.yahoo.com\" linkLabel1.LinkArea = new LinkArea(8，3) 哪幾個字有超連結功能？", answer1_value = ".yaho", answer2_value = "yahoo", answer3_value = "tw.yahoo", answer4_value = "com", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 7, question_value = "改變捲軸控制項Value屬性值時，會觸動哪個事件？", answer1_value = "LargeChange", answer2_value = "SmallChange", answer3_value = "Scroll", answer4_value = "ValueChanged", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 7, question_value = "NumericUpDown數字鈕控制項顯示小數位數，須設定哪個屬性？", answer1_value = "DecimalPlaces", answer2_value = "Increment", answer3_value = "Minimum", answer4_value = "Value", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 7, question_value = "MonthCalendar控制項選取日期同時處理，程式碼要寫在哪個事件中？", answer1_value = "DateChanged", answer2_value = "DateSelected", answer3_value = "SetDate", answer4_value = "ValueChanged", keybutton = "answer1" });

        //第8章
        question_bank.Add(new quetion_and_answer { chapter = 8, question_value = "哪個是屬於C# 的方法？", answer1_value = "系統提供", answer2_value = "使用者自訂", answer3_value = "事件處理函式", answer4_value = "以上皆是", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 8, question_value = "自訂方法傳遞引數最多可以有幾個？", answer1_value = "2", answer2_value = "4", answer3_value = "8", answer4_value = "沒有限制", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 8, question_value = "C# 自訂方法參數傳遞不可採用何種方式？", answer1_value = "傳值", answer2_value = "傳參考", answer3_value = "傳名稱", answer4_value = "傳值與傳參考搭配使用", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 8, question_value = "自訂方法內虛引數不可以是哪種Data Type？", answer1_value = "變數", answer2_value = "運算式", answer3_value = "陣列", answer4_value = "物件", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 8, question_value = "離開方法可使用哪個敘述？", answer1_value = "End void", answer2_value = "End", answer3_value = "return", answer4_value = "break void", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 8, question_value = "下列何者不屬於方法的特色？", answer1_value = "無法擁有自已名稱", answer2_value = "宣告的變數是區域變數", answer3_value = "方法具有特定功能", answer4_value = "不同方法內是允許使用相同區域變數名稱", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 8, question_value = "關於傳值呼叫(Call By Value)下列敘述何者錯誤？", answer1_value = "引數傳遞方式預設為傳值呼叫", answer2_value = "呼叫程式實引數與被呼叫程式虛引數兩者佔用相同記憶體位址", answer3_value = "是一種副本概念", answer4_value = "不用再將資料回傳給原呼叫程式", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 8, question_value = "關於參考呼叫 (Call By Reference)下列敘述何者正確？", answer1_value = "引數傳遞方式預設為傳址呼叫", answer2_value = "呼叫程式實引數與被呼叫程式虛引數兩者佔用不同記憶體位址", answer3_value = "是一種正本概念", answer4_value = "會將資料回傳給原呼叫程式", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 8, question_value = "關於參考呼叫 (Call By Reference)下列敘述何者錯誤？", answer1_value = "以 ref 宣告", answer2_value = "兩者佔用不同位址記憶體", answer3_value = "是一種正本的概念", answer4_value = "將方法內處理結果傳回給呼叫程式時用", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 8, question_value = "關於參考呼叫 (Call By Reference)下列敘述何者正確？", answer1_value = "不以 ref 宣告", answer2_value = "兩者佔用相同位址記憶體", answer3_value = "是一種副本概念", answer4_value = "將方法內處理結果不會傳回給呼叫程式時用", keybutton = "answer2" });

        //第9章
        question_bank.Add(new quetion_and_answer { chapter = 9, question_value = "哪個滑鼠事件，可取得滑鼠游標所在位置？", answer1_value = "Click", answer2_value = "MouseDown", answer3_value = "MouseMove", answer4_value = "MouseUp", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 9, question_value = "滑鼠游標從外滑進去控制項，沒有停留立即再滑出來，則哪個事件並不會被觸動到？", answer1_value = "MouseEnter", answer2_value = "MouseLeave", answer3_value = "MouseMove", answer4_value = "MouseHover", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 9, question_value = "滑鼠游標從外滑進去控制項，停留後再滑出來，則哪個滑鼠事件被觸動不只一次？", answer1_value = "MouseEnter", answer2_value = "MouseLeave", answer3_value = "MouseMove", answer4_value = "MouseHover", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 9, question_value = "當使用者在Button控制項上按一下立即放開，則哪個滑鼠事件並不會被觸動到？", answer1_value = "MouseUp", answer2_value = "MouseDown", answer3_value = "MouseClick", answer4_value = "DoubleClick", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 9, question_value = "哪個滑鼠事件，可用e.Button 來偵測哪個滑鼠鍵被按下？", answer1_value = "MouseUp", answer2_value = "MouseEnter", answer3_value = "MouseClick", answer4_value = "Click", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 9, question_value = "檢查使用者所輸入的字元是否合乎條件，程式碼通常要寫在哪個事件？", answer1_value = "MouseDown", answer2_value = "KeyPress", answer3_value = "KeyUp", answer4_value = "Click", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 9, question_value = "下列哪種應用程式可以完全支援C# 觸控手勢？", answer1_value = "主控台", answer2_value = "ASP.NET Web", answer3_value = "Windows Form", answer4_value = "WPF", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 9, question_value = "支援觸控手勢伸展或捏合(Zoom)動作，程式碼要寫在哪個滑鼠事件？", answer1_value = "DoubleClick", answer2_value = "MouseClick", answer3_value = "MouseMove", answer4_value = "MouseWheel", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 9, question_value = "如果要確定使用者是否為長按觸控，要檢查MouseClick事件的哪個值？", answer1_value = "e.Button", answer2_value = "e.Clicks", answer3_value = "e.Delta", answer4_value = "e.Handled", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 9, question_value = "在KeyDown事件中可使用哪個屬性值取得輸入按鍵的ASCII值？", answer1_value = "e.Handled", answer2_value = "e.KeyCode", answer3_value = "e.KeyValue", answer4_value = "e.Shift", keybutton = "answer3" });

        //第10章
        question_bank.Add(new quetion_and_answer { chapter = 10, question_value = "控制項要與快顯功能表建立關聯必須使用哪個屬性？", answer1_value = "Text", answer2_value = "DataSouce", answer3_value = "Color", answer4_value = "ContextMenuStrip", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 10, question_value = "工具列必須使用哪個控制項來建立？", answer1_value = "ToolBar", answer2_value = "ToolStrip", answer3_value = "ToolMenu", answer4_value = "MenuStrip", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 10, question_value = "ToolStrip 控制項同時顯示文字和圖示，須將DisplayStyle屬性值設定為何？", answer1_value = "None", answer2_value = "Text", answer3_value = "Image", answer4_value = "ImageAndText", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 10, question_value = "功能表項目是什麼物件？", answer1_value = "MenuBox", answer2_value = "MenuItem", answer3_value = "MenuButton", answer4_value = "Button", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 10, question_value = "功能表項目中加入一個分隔線，可在功能表按下右鍵，並執行快顯功能表？", answer1_value = "[新增/分隔線]", answer2_value = "[插入/分隔線]", answer3_value = "[新增/Separator]", answer4_value = "[插入/Separator]", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 10, question_value = "ToolStrip 控制項的項目只要顯示文字，DisplayStyle屬性設定為何？", answer1_value = "None", answer2_value = "Text", answer3_value = "Image", answer4_value = "ImageAndText", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 10, question_value = "功能表項目menuItem1要變成核取記號，寫法為何？", answer1_value = "menuItem1.setChecked(true)", answer2_value = "menuItem1.setChecked = true", answer3_value = "menuItem1.Checked = true", answer4_value = "menuItem1.Click = true", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 10, question_value = "功能表項目menuItem1要設為失效不啟用，敘述寫法為何？", answer1_value = "menuItem1.setEnabled(false)", answer2_value = "menuItem1.setEnabled = false", answer3_value = "menuItem1.Enabled(false)", answer4_value = "menuItem1.Enabled = false", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 10, question_value = "設定功能表項目快速鍵，須設定哪個屬性？", answer1_value = "ToolTipText", answer2_value = "ShortcutKeys", answer3_value = "Image", answer4_value = "QuickKeys", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 10, question_value = "設定功能表項目的小圖示，須設定哪個屬性？", answer1_value = "Images", answer2_value = "Icon", answer3_value = "Image", answer4_value = "setImage", keybutton = "answer3" });

        //第11章 (少一題)
        question_bank.Add(new quetion_and_answer { chapter = 11, question_value = "欲開啟對話方塊，必須呼叫該對話方塊的哪個方法？", answer1_value = "OpenDialog", answer2_value = "ShowDialog", answer3_value = "CreateDialog", answer4_value = "NewDialog", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 11, question_value = "FontDialog 下列那個屬性不是決定是否要顯示？", answer1_value = "ShowApply", answer2_value = "ShowColor", answer3_value = "ShowHelp", answer4_value = "ShowHelpg", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 11, question_value = "RichTextBox控制項載入文字檔資料，須使用哪個方法？", answer1_value = "Load", answer2_value = "LoadData", answer3_value = "LoadFile", answer4_value = "GetFile", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 11, question_value = "RichTextBox控制項寫入資料到文字檔，須使用哪個方法？", answer1_value = "Save", answer2_value = "SaveData", answer3_value = "SaveFile", answer4_value = "SetFile", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 11, question_value = "欲使RichTextBox控制項內的資料能連結URL，須將DetectUrls屬性設為何？", answer1_value = "None", answer2_value = "false", answer3_value = "true", answer4_value = "Link", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 11, question_value = "連結到指定URL須使用何種方法？", answer1_value = "Process.Start", answer2_value = "GetURL", answer3_value = "Link", answer4_value = "SetLink", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 11, question_value = "RichTextBox控制項指定撰取文字的背景顏色，必須設定哪個屬性？", answer1_value = "BackColor", answer2_value = "ForeColor", answer3_value = "SelectionBackColor", answer4_value = "SelectionForColor", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 11, question_value = "RichTextBox控制項將撰取的範圍複製到剪貼簿，必須使用哪個方法？", answer1_value = "Cut", answer2_value = "Paste", answer3_value = "Copy", answer4_value = "CopyData", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 11, question_value = "使用檔案類別來讀寫資料檔，則必須在程式最開頭撰寫下列哪行敘述？", answer1_value = "using System.Data", answer2_value = "using System.Data.IO", answer3_value = "using System.IO", answer4_value = "using System.IO.Data", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 11, question_value = "資料寫入至指定的資料檔，可使用哪個類別物件？", answer1_value = "StreamWriter", answer2_value = "StreamReader", answer3_value = "FileInfo", answer4_value = "DataReader", keybutton = "answer1" });

        //第12章
        question_bank.Add(new quetion_and_answer { chapter = 12, question_value = "設定顏色透明度、紅色、綠色、藍色等四種不同屬性值，可以用何種方法調配出各種顏色效果？", answer1_value = "Color", answer2_value = "Color.FromArgb", answer3_value = "RGB", answer4_value = "GetRGB", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 12, question_value = "下列何者無法設定顏色？", answer1_value = "Color.FormArgb方法", answer2_value = "ColorTranslator物件類別", answer3_value = "Color結構", answer4_value = "String物件", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 12, question_value = "有一Button物件btn，取得該物件紅色值，可使用下列哪種方式？", answer1_value = "btn.BackColor.A", answer2_value = "btn.BackColor.R", answer3_value = "btn.BackColor.G", answer4_value = "btn.BackColor.B", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 12, question_value = "Graphics物件顯示文字須使用何種方法？", answer1_value = "DragText", answer2_value = "DragTextShow", answer3_value = "DragString", answer4_value = "Drag", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 12, question_value = "Graphics物件線製線段須使用何種方法？", answer1_value = "SetLine", answer2_value = "GetLine", answer3_value = "ShowLine", answer4_value = "DrawLine", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 12, question_value = "有一PictureBox控制項，其物件名稱為pic，程式執行時載入C:\apple.jpg，應使用下列哪行敘述？", answer1_value = "pic.Image = new Bitmap(\"c:\\apple.jpg\")", answer2_value = "pic.Image(\"c:\\apple.jpg\")", answer3_value = "pic.Load = new Image(\"c:\\apple.jpg\")", answer4_value = "pic.Load(\"c:\\apple.jpg\")", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 12, question_value = "Bitmap圖形物件內的圖形儲存成圖像檔案必須使用哪個方法？", answer1_value = "Save", answer2_value = "SaveImage", answer3_value = "SaveFile", answer4_value = "Write", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 12, question_value = "填滿區塊內部顏色，須使用哪種物件？", answer1_value = "Pen", answer2_value = "Brushes ", answer3_value = "Bitmap", answer4_value = "Audio", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 12, question_value = "在Form內建立一個物件名稱為g的Graphics物件，應使用下列哪行敘述？", answer1_value = "Graphics g = this.CreateGraphics()", answer2_value = "Dim g As Graphics = new CreateGraphics()", answer3_value = "Graphics g = Form1.CreateGraphics()", answer4_value = "Graphics g = Me.CreateGraphics()", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 12, question_value = "Graphics物件從主記憶體中移除，可使用哪個方法？", answer1_value = "Close", answer2_value = "Dispose", answer3_value = "Cls", answer4_value = "Clear", keybutton = "answer2" });

        //第13章
        question_bank.Add(new quetion_and_answer { chapter = 13, question_value = "類別成員要設為公開成員須使用哪個保留字？", answer1_value = "protected", answer2_value = "static", answer3_value = "private", answer4_value = "public", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 13, question_value = "類別成員要設為私有成員須使用哪個保留字？", answer1_value = "protected", answer2_value = "static", answer3_value = "private", answer4_value = "public", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 13, question_value = "類別成員要設為保護成員須使用哪個保留字？", answer1_value = "protected", answer2_value = "static", answer3_value = "private", answer4_value = "public", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 13, question_value = "關於建構式(Constructor)下列敘述何者錯誤？", answer1_value = "建構式與類別同名", answer2_value = "建構式可以多載", answer3_value = "建構式沒有傳回值", answer4_value = "建構式的名稱為new", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 13, question_value = "一個*.cs檔可以定義幾個類別？", answer1_value = "1個", answer2_value = "2個", answer3_value = "3個", answer4_value = "無限多個", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 13, question_value = "C# 的存取子的功能為何？", answer1_value = "定義屬性", answer2_value = "定義方法", answer3_value = "定義欄位", answer4_value = "定義類別", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 13, question_value = "下列敘述何者正確？", answer1_value = "一個*.cs程式檔只能有一個類別", answer2_value = "將類別中的成員宣告成public，即表示該成員不能被外部所存取", answer3_value = "建構式必須有傳回值", answer4_value = "定義靜態成員可使用static保留字", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 13, question_value = "C# 會依照輸入引數不同而區別所呼叫方法，稱之為？", answer1_value = "多載方法", answer2_value = "覆寫方法", answer3_value = "靜態方法", answer4_value = "抽象方法", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 13, question_value = "下列說明何者正確？", answer1_value = "類別中必須撰寫建構式", answer2_value = "類別中建立一個共用變數，可將該變數定義成static資料成員", answer3_value = "建構式的名稱為new", answer4_value = "方法宣告為private，表示該方法是公開型態", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 13, question_value = "Form類別是繼承自哪個類別？", answer1_value = "System.Page.Form", answer2_value = "System.Windows.Forms", answer3_value = "System.Data.Form", answer4_value = "System.Windows.Forms.Form", keybutton = "answer4" });

        //第14章
        question_bank.Add(new quetion_and_answer { chapter = 14, question_value = "Access當資料庫則必須在程式最開頭撰寫？", answer1_value = "using System", answer2_value = "using System.Data.SqlClient", answer3_value = "using System.Data", answer4_value = "using System.Data.OleDb", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 14, question_value = "SQL Server當資料庫則必須在程式最開頭撰寫？", answer1_value = "using System", answer2_value = "using System.Data.SqlClient", answer3_value = "using System.Data", answer4_value = "using System.Data.OleDb", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 14, question_value = "下列哪一個物件可以執行SQL語法？", answer1_value = "Connection", answer2_value = "Command", answer3_value = "DataSet", answer4_value = "Button", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 14, question_value = "下列敘述何者錯誤？", answer1_value = "ADO .NET目前最新版為2.0", answer2_value = "ADO .NET採離線式存取", answer3_value = "DataSet是記憶體的資料庫", answer4_value = "使用DataReader物件可將資料庫的資料一次填寫入DataSet", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 14, question_value = "下列哪一個物件可以開啟和關閉連接資料庫？", answer1_value = "Connection", answer2_value = "Command", answer3_value = "DataSet", answer4_value = "Button", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 14, question_value = "查詢資料表記錄可使用SQL語法哪個陳述式？", answer1_value = "INSERT", answer2_value = "UPDATE", answer3_value = "DELETE", answer4_value = "SELECT", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 14, question_value = "新增資料表記錄可使用SQL語法哪個陳述式？", answer1_value = "INSERT", answer2_value = "UPDATE", answer3_value = "DELETE", answer4_value = "SELECT", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 14, question_value = "刪除資料表記錄可使用SQL語法哪個陳述式？", answer1_value = "INSERT", answer2_value = "UPDATE", answer3_value = "DELETE", answer4_value = "SELECT", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 14, question_value = "建立二維資料控制項，顯示和編修各種不同資料來源的表格式資料，可使用哪個控制項？", answer1_value = "DataSet", answer2_value = "DataGridView", answer3_value = "BindingSource", answer4_value = "Connection", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 14, question_value = "使用DataAdapter物件哪個方法可以將資料表資料一次填入記憶體的DataSet？", answer1_value = "GetData", answer2_value = "GetTable", answer3_value = "Fill", answer4_value = "Update", keybutton = "answer3" });

        //第15章
        question_bank.Add(new quetion_and_answer { chapter = 15, question_value = "ASP.NET網頁程式在網路上供使用者瀏覽，伺服器網站須架設何種軟體？", answer1_value = "IBM", answer2_value = "FaceBook", answer3_value = "IIS", answer4_value = "Line", keybutton = "answer3" });
        question_bank.Add(new quetion_and_answer { chapter = 15, question_value = "在ASP.NET專案中，存放資料庫檔案的資料夾名稱為何？", answer1_value = "App_Data", answer2_value = "App", answer3_value = "Data", answer4_value = "mdf", keybutton = "answer1" });
        question_bank.Add(new quetion_and_answer { chapter = 15, question_value = "SqlDataSource控制項用什麼屬性來設定資料庫連接字串？", answer1_value = "Connection", answer2_value = "ConnectionString", answer3_value = "ConString", answer4_value = "String", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 15, question_value = "ASP.NET的網頁程式文件中，不包含下列何種標記語法？", answer1_value = "HTML", answer2_value = "CSS", answer3_value = "JavaScript", answer4_value = "PHP", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 15, question_value = "下列哪種資料繫結控制項，一頁只能顯示一筆記錄資料？", answer1_value = "FormView", answer2_value = "ListView", answer3_value = "GridView", answer4_value = "DetailsView", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 15, question_value = "GridView資料繫結控制項，沒有下列何種功能？", answer1_value = "分頁", answer2_value = "新增", answer3_value = "編輯", answer4_value = "排序", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 15, question_value = "DetailsView資料繫結控制項，沒有下列何種功能？", answer1_value = "分頁", answer2_value = "新增", answer3_value = "編輯", answer4_value = "排序", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 15, question_value = "GridView資料繫結控制項，預設一頁可顯示多少筆記錄？", answer1_value = "12", answer2_value = "10", answer3_value = "6", answer4_value = "5", keybutton = "answer2" });
        question_bank.Add(new quetion_and_answer { chapter = 15, question_value = "有關jQuery Mobile的敍述，下列何者錯誤？", answer1_value = "使用標準的HTML5標記語法", answer2_value = "為各種不同的行動裝置提供一致的UI介面", answer3_value = "支援不同的作業系統", answer4_value = "無法搭配ASP.NET整合設計", keybutton = "answer4" });
        question_bank.Add(new quetion_and_answer { chapter = 15, question_value = "jQuery Mobile用什麼敍述來指定網頁的頁首？", answer1_value = "data-role=\"header\"", answer2_value = "data-role=\"footer\"", answer3_value = "data-role=\"content\"", answer4_value = "data-role=\"page\"", keybutton = "answer1" });

    }
    void setquestion1(JsonData json)
    {
        for(int i=0;i<json.Count;i++)
        {
            question_bank.Add(new quetion_and_answer {question_value=json[i][2].ToString(),answer1_value= json[i][3].ToString(), answer2_value=json[i][4].ToString(),answer3_value=json[i][5].ToString(),answer4_value= json[i][6].ToString(),keybutton= json[i][7].ToString() });
        }
    }
    IEnumerator connect_question()
    {
        WWWForm form = new WWWForm();
        form.AddField("ch",playscript.chooseindex);
        WWW www = new WWW(quesyion_url,form);
        yield return www;
        print(www.text);
        JsonData json = JsonMapper.ToObject<JsonData>(www.text);
        setquestion1(json);
        rand();
    }
}
public class quetion_and_answer
{
    public int chapter;
    public string question_value;
    public string answer1_value;
    public string answer2_value;
    public string answer3_value;
    public string answer4_value;
    public string keybutton;
}
