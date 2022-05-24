using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private bool isDead = false;
    [SerializeField] private AudioSource deathSound;

    private void Update()
    {
        if(transform.position.y < -2f && isDead == false)
        {
            isDead = true;
            Death();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Death();
        }
    }

    private void Death()
    {
        deathSound.Play();
        Invoke("ReloadScene", 1.5f);
        isDead = true;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
