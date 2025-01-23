using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHelth : MonoBehaviour
{
    private float health = 100;
    private Image healthBar;
    [SerializeField] private AudioClip GameOver;
    private AudioSource audioSource;    
    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        healthBar.fillAmount = health / 100;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        healthBar.fillAmount = health / 100;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacals")
        {
            health -= 50;
            Debug.Log("Health: " + health);
           
        }
        else if (collision.gameObject.tag == "groundEnd")
        {
            health =0;
            audioSource.clip = GameOver;
            audioSource.PlayOneShot(GameOver);
            Debug.Log("You Loos");
        }
        else if(collision.gameObject.tag == "WinPoint" && ScoreManager.instance.score==10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
