using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Controller : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset;
    private bool rightPosition=false;
    [SerializeField] GameObject pairGameobject;
   private  Vector2 duckStartPosition;
   private Animator animator; 
   public ParticleSystem duckJumpParticle;
   private bool duckCanMove;
   public static int CorrectAnswer;
   public static int WinRoundNumber= 0;
   private bool duckInBusket=false;

   private WinManager winmanager;
   private AudioManager audioManager;
   
   
    public void Awake()
    {
        mainCamera = Camera.main;
        animator=GetComponent<Animator>();
        CorrectAnswer = 0;
    }

  private void Start()
   {
      duckStartPosition=gameObject.transform.position;
      duckCanMove=true;
      //WinRoundNumber=PlayerPrefs.GetInt("win round totoal number");
       winmanager=FindObjectOfType<WinManager>();
       audioManager=FindObjectOfType<AudioManager>();
  }  


    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

  private void OnMouseDrag()
  {   if (duckCanMove)
      {
        transform.position=GetMousePosition()+offset;
      animator.enabled=false;
      transform.localScale=new Vector3(1.1f,1.1f,1.1f);
      }

  }

  private void OnMouseDown()
  { 
    offset=transform.position-GetMousePosition();
  }



 private void OnTriggerEnter2D (Collider2D other)
   {
    if(other.gameObject.tag==gameObject.tag)
    {  
        rightPosition=true;
        pairGameobject.transform.position=other.gameObject.transform.position;


    }
   }

 
 private void OnTriggerExit2D (Collider2D other)
   {
    if(other.gameObject.tag==gameObject.tag)
    {  
        rightPosition=false;
    }
   }



private void OnMouseUp()
{ 
  if (rightPosition&&!duckInBusket)
{
  gameObject.transform.position=pairGameobject.transform.position+new Vector3(0,1.6f,0);
  duckInBusket=true;
   transform.localScale=new Vector3(1,1,1);
   duckJumpParticle.Play();
   duckCanMove=false;
   CorrectAnswer++;
   WinCheck();
   audioManager.PlaySound(2);
  
}
if (!rightPosition)
{
    transform.position=duckStartPosition;
    animator.enabled=true;
}
}


public void WinCheck() 
{
if (CorrectAnswer>=3)
{
  WinRoundNumber++;
  audioManager.PlaySound(0);
 // PlayerPrefs.SetInt("win round totoal number",WinRoundNumber);
  if (WinRoundNumber >= 5)
     StartCoroutine(LoadNextRound(false));
      else
        StartCoroutine(LoadNextRound(true));


}
}


IEnumerator LoadNextRound(bool load)
    {
        if(load)
        {
            yield return new WaitForSeconds(0.7f);
            CorrectAnswer=0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        else
        {
            WinRoundNumber = 0;
            yield return new WaitForSeconds(0.7f);
            winmanager.points[4].sprite =winmanager.yellowPoint.sprite;
            winmanager.reloadGameCanvas.gameObject.SetActive(true);
     
      
        }


}

}








