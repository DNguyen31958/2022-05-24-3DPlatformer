using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private AudioSource coinSound;
    private int coinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinSound.Play();
            Destroy(other.gameObject);
            coinCount++;
            coinText.text = "Coin: " + coinCount;
        }
    }
}
