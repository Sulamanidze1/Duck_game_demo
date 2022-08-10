using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public SpriteRenderer[] points;
    public SpriteRenderer yellowPoint;
   public Canvas reloadGameCanvas;


private void Start() 
{
     for(int i =0; i < Controller.WinRoundNumber; i++)
        {
            points[i].sprite = yellowPoint.sprite;
        }
}


 public void ReloadGame()
    {
        SceneManager.LoadScene("DuckGame");
    }
}
