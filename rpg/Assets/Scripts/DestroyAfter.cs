using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float timeToDestroy;
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
            Destroy(gameObject);
    }
}