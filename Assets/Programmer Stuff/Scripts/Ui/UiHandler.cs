using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHandler : MonoBehaviour
{
    GameObject canvas;
    [SerializeField] Font clockFont;
    [SerializeField] Font scoreFont;

    public static List<GameObject> uiTexts = new List<GameObject>();

    string minutes;
    string hours;


    // Start is called before the first frame update
    void Start()
    {
        //Initialize canvas variable
        canvas = GameObject.Find("Canvas");
        
        //Spawn wanted texts
        SpawnText(scoreFont, new Vector3(0, 475, 0), "ScoreText",75);
        SpawnText(clockFont, new Vector3(750, 475, 0), "Time",55);




    }

    // Update is called once per frame
    void Update()
    {
        

        if (GameData.hours < 10)
        {
            hours = "0" + (GameData.hours).ToString("F0");
        }
        else
        {
            hours = GameData.hours.ToString("F0");

        }


        if (GameData.minutes < 10)
        {
            minutes = "0" + (GameData.minutes).ToString("F0");
        }
        else
        {
            minutes = GameData.minutes.ToString("F0");

        }

        uiTexts[1].GetComponent<Text>().text = hours + ":" + minutes;
    }


    public void SpawnText(Font fontName, Vector3 pos, string objName, int size)
    {
        //Create nre GameObject and Add Text component
        GameObject text = new GameObject();
        Text tc = text.AddComponent(typeof(Text)) as Text;

        //Set Text Object caratteristics
        text.name = objName;
        text.transform.parent = canvas.transform;
        text.transform.localPosition = pos;
        text.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 250);

        //Set Text Component Caratteristic
        tc.font = fontName;
        tc.text = objName;
        tc.alignment = TextAnchor.MiddleCenter;
        tc.fontSize = size;

        //Add Text GameObject to List
        uiTexts.Add(text);
    }

}
