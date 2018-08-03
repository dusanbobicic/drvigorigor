using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {
    public static CanvasController Instance { set; get; }

    public GameObject panel;
    private GameObject container;
    private GameObject newPanel;
    public Image muteButton;

    private static Sprite mOn;
    private static Sprite mOff;

    // Use this for initialization
    void Start () {
        container = GameObject.Find("container");
        bool music = PlayerPrefs.GetInt("Music") == 1 ? true : false;
        mOn = Resources.Load<Sprite>("sprites/musicOn");
        mOff = Resources.Load<Sprite>("sprites/musicOff");
        if (music)
        {
            muteButton.sprite = mOn;
        }
        else
        {
            muteButton.sprite = mOff;
        }
        
    }

    public void ShowAddMedicinePanel() {
        newPanel = Instantiate(panel) as GameObject;
        newPanel.transform.SetParent(container.transform, false);
    }

    public void jumpToNextScene(string scena)
    {
        SceneManager.LoadScene(scena);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
    }

    public void MuteToggle()
    {
        bool music = !PlayerPrefs.HasKey("Music") || PlayerPrefs.GetInt("Music") == 1 ? true : false;
        if (music)
        {
            muteButton.sprite = mOff;
            MusicController.Instance.Stop();
        } else
        {
            muteButton.sprite = mOn;
            MusicController.Instance.Play();
        }
    }
}
