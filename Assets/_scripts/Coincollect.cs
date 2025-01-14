using UnityEngine;


public class Coincollect : MonoBehaviour
{
    [SerializeField] private AudioClip coinCollectSound;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coinCollectSound);
            collision.gameObject.SetActive(false);
            ScoreManager.instance.ChangeScore(1);
        }
    }
}
