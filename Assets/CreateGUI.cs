using System.Collections.Generic;
using System.Collections;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class CreateGUI : UnityEngine.MonoBehaviour
{
    public GameObject buttontext;
    
    void Start()
    {

    }

    public static void CreateSceneBackButton(string str)
    {
        GameObject back_canvas = GameObject.Find("Canvas");
        GameObject back_button = Instantiate(Resources.Load("Button") as GameObject);
        back_button.name = "Back_Button";
        back_button.GetComponent<RectTransform>().SetParent(back_canvas.transform);
        back_button.GetComponentInChildren<Text>().text = str;
        back_button.transform.localPosition = new Vector3(-500, 280);
        Button addlis = back_button.GetComponent<Button>();
        addlis.onClick.AddListener(() => ClickObject.BackSceneOnClick());
        
//        CreateGUI.AddEvent(back_button, EventTriggerType.PointerDown, e => {ClickObject.BackSceneOnClick();});
    }
    
    public static void CreateASceneBackButton(string str)
    {
        GameObject back_canvas = GameObject.Find("Canvas");
        GameObject back_button = Instantiate(Resources.Load("Button") as GameObject);
        back_button.name = "Back_Button";
        back_button.GetComponent<RectTransform>().SetParent(back_canvas.transform);
        back_button.GetComponentInChildren<Text>().text = str;
        back_button.transform.localPosition = new Vector3(-500, 280);
        Button addlis = back_button.GetComponent<Button>();
        addlis.onClick.AddListener(() => ClickObject.BackASceneOnClick());
//        CreateGUI.AddEvent(back_button, EventTriggerType.PointerDown, e => {ClickObject.BackSceneOnClick();});
    }

    public static Button GenerateButton(Canvas canvas)
    {
        Button button = new GameObject().AddComponent<Button>();
        button.name = "Back_Button";
        button.transform.gameObject.AddComponent<RectTransform>();
        button.GetComponent<RectTransform>().SetParent(canvas.transform);
        return button;
    }

    public static Canvas GenerateCanvas()
    {
        Canvas canvas = new GameObject().AddComponent<Canvas>();
        canvas.name = "Back_Panel";
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.gameObject.AddComponent<GraphicRaycaster>();
        EventSystem eventSystem = new GameObject().AddComponent<EventSystem>();
        eventSystem.gameObject.AddComponent<StandaloneInputModule>();
        eventSystem.name = "Back_EventSystem";
        return canvas;
    }

    public static void AddEvent(Button button, EventTriggerType type, UnityEngine.Events.UnityAction<BaseEventData> call)
    {
        UnityEngine.EventSystems.EventTrigger.Entry entry = new UnityEngine.EventSystems.EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener(call);
        button.gameObject.AddComponent<EventTrigger>().triggers.Add(entry);
    }
}