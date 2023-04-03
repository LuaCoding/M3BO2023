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
    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        Debug.Log("Added listener!");
    }

    // Update is called once per frame
    void OnClick()
    {
        Debug.Log("Clicked!");
        player.SetActive(true);
        main.SetActive(true);
        spawnzone.SetActive(true);
        intro.SetActive(false);
    }
}
