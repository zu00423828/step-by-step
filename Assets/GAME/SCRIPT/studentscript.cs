using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class studentscript : MonoBehaviour
{
    public Button playmodel;
    public Button recordmodel;
    public Button rankingmodel;
    public GameObject play_block;
    public GameObject record_block;
    public GameObject ranking_block;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playmodel.onClick.AddListener(playmodelOnclick);
        recordmodel.onClick.AddListener(recordmodelOnclick);
        rankingmodel.onClick.AddListener(rankingmodeOnclick);
    }
    void playmodelOnclick()
    {
        gameObject.SetActive(false);
        play_block.SetActive(true);
    }
    void recordmodelOnclick()
    {
        gameObject.SetActive(false);
        record_block.SetActive(true);
    }
    void rankingmodeOnclick()
    {
        gameObject.SetActive(false);
        ranking_block.SetActive(true);
    }
}
