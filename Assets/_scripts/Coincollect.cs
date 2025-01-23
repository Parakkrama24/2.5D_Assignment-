using TMPro;
using UnityEngine;


public class Coincollect : MonoBehaviour
{
    [SerializeField] private AudioClip coinCollectSound;
    private AudioSource audioSource;
    private TMP_Text GuidText;
    private GameObject coliedgameObject;

    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GuidText= GameObject.Find("GuidText").GetComponent<TMP_Text>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            GuidText.text= "Press 'E'";
            coliedgameObject = collision.gameObject;
            audioSource.PlayOneShot(coinCollectSound);
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            GuidText.text = "Collect all Coin";
            coliedgameObject = null;
        }

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && coliedgameObject!=null)
        {
            coliedgameObject.SetActive(false);
           // ScoreManager.instance.ChangeScore(1);
            GuidText.text = "Collect all Coin";
        }
        


    }



}
