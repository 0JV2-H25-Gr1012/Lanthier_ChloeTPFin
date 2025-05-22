using UnityEngine;

public class CollecteurDechets : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private AudioSource playerAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monnaie")) 
        {
            Destroy(other.gameObject);

            if (pickupSound != null && playerAudioSource != null)
            {
                playerAudioSource.PlayOneShot(pickupSound);
            }
        }
    }
}
