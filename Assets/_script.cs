using UnityEngine;

public class _script : MonoBehaviour
{
    public ParticleSystem kaka;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
           kaka.Play();
        }

    }
}
