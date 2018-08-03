using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CldMedAPI.Controler;
using CldMedAPI.Data;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class RecivingApi : MonoBehaviour {
    public GameObject inputField;
    public GameObject loginButton;
    private List<Perscription> perscriptions;
    private Regex r;

    void Start () {
        r = new Regex(@"\d*");
        if (PlayerPrefs.HasKey("Name") && PlayerPrefs.GetInt("Logged") == 1 && loginButton)
        {
            loginButton.GetComponentsInChildren<Text>()[0].text = "Welcome, Dr " + PlayerPrefs.GetString("Name").Split(' ')[0];
            // disable clicking on button
            loginButton.GetComponent<Button>().interactable = false;
        }
    }

    public void displayStuff(string healthId)
    {
        DbControl a = new DbControl("drvigor", "Drugbud123");
        string hId = inputField.transform.GetComponent<InputField>().text;
        if (hId == "")
        {
            hId = "007716130322";
        } else
        {
            inputField.transform.GetComponent<InputField>().image.color = Color.white;
        }
        perscriptions = a.getPerscriptions(hId);

        // login control if number doesnt exist
        if (perscriptions.Count < 1)
        {
            inputField.transform.GetComponent<InputField>().image.color = Color.red;
            inputField.transform.GetComponent<InputField>().GetComponentsInChildren<Text>()[1].text = "ID doesn't exist!";
            return;
        }

        SaveManager.Instance.ClearMedList();
        string name = null;
        for (int i = 0; i < perscriptions.Count; i++)
        {
            if (name == null)
            {
                name = perscriptions[i].Usr.Name;
            }
            Medicine m = new Medicine();
            m.medName = perscriptions[i].Med.Name;
            m.dosage = ParseInterval(perscriptions[i].Dose);
            m.timesPerDay = ParseInterval(perscriptions[i].Interval);
            m.notes = perscriptions[i].Interval;

            SaveManager.Instance.AddMedicine(m);
        }
        SaveManager.Instance.changeName(name);
        PlayerPrefs.SetString("Name", name);
        PlayerPrefs.SetInt("Logged", 1);
        SceneManager.LoadScene("neal");
    }

    private int ParseInterval (string interval)
    {
        Match m = r.Match(interval);
        if (m.Success)
        {
            return int.Parse(m.Groups[0].Value);
        }
        return -1;
    }

    public void deleteLogin()
    {
        Destroy(loginButton);
    }
}
