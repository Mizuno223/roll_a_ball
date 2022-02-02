using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void OnClickBackButton ()
    {
        SceneManager.LoadScene("StageSelect");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;   // UnityEditorの実行を停止する処理
    #else
            Application.Quit();                                // ゲームを終了する処理
    #endif
        }
    }
}
