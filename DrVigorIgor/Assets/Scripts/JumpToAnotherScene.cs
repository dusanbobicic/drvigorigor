using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToAnotherScene : MonoBehaviour
{

    

    public void jumpToNextScene(string scena)
    {
        SceneManager.LoadScene(scena);

    }
}