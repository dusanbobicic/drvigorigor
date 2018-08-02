using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {
    public static CanvasController Instance { set; get; }

    public GameObject panel;
    private GameObject container;
    private GameObject newPanel;

    // Use this for initialization
    void Start () {
        container = GameObject.Find("container");
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
            MusicController.Instance.Stop();
        } else
        {
            MusicController.Instance.Play();
        }
    }

    public void playMusic() {
        MusicController.Instance.Play();
    }
    public void stopMusic() {
        MusicController.Instance.Stop();
    }
}
