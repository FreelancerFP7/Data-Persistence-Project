using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text nameInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(GameManager.Instance.previousUserName);
        nameInput.text = GameManager.Instance.previousUserName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.LoadScore();
        GameManager.Instance.playerName = nameInput.text;
    }

    public void WipeScore()
    {
       
        GameManager.Instance.WipeScore();
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
