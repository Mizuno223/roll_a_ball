using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBotton : MonoBehaviour
{
    public void OnClickStartBotton ()
    {
        SceneManager.LoadScene("MiniGame");
    }
}
