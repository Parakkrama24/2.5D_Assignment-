using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnDisable()
    {
        ScoreManager.instance.ChangeScore(1);
    }
}
