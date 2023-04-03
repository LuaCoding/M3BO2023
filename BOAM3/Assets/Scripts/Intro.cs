using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public GameObject player;
    public GameObject main;
    public GameObject spawnzone;
    public Button button;
    public GameObject intro;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        Debug.Log("Added listener!");
    }

    void OnClick()
    {
        Debug.Log("Clicked!");
        player.SetActive(true);
        main.SetActive(true);
        spawnzone.SetActive(true);
        intro.SetActive(false);
    }
}
