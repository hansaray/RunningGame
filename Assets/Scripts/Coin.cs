using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] float turnSpeed = 90f;
    [SerializeField] AudioClip coindSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        //Check that the object we collided with the player
        if (other.gameObject.name != "Player")
        {
            return;
        }
        //Add to the player's Score
        GameManager.inst.IncrementScore();
        //Play sound
        AudioSource.PlayClipAtPoint(coindSound, transform.position,1f);
        //Destroy the coin
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
