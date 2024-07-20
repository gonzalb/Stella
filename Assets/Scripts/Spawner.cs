using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Animator animator;
    public GameObject[] prefab;
    public float minTime = 2f;
    public float maxTime = 4f;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        animator.SetTrigger("throw");
        int i = (int)Random.Range(0,100) % prefab.Length;   
        Instantiate(prefab[i], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(minTime, maxTime));
        SoundManager.PlaySound("barrel");
    }
}
