using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem confetti;

    public void PlayConfetti()
    {
        confetti.Play();
    }
}
