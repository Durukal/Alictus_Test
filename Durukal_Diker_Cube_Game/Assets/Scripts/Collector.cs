using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public GameObject[] collectibles;
    public float countPoint=0f;
    float collectDistance = 40f;
    public Slider pointBar;
    
    // Start is called before the first frame update
    void Start()
    {
        collectibles = GameObject.FindGameObjectsWithTag("Collect");
        pointBar.value = calculatePoints(countPoint);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collectibles.Length.Equals(0))
        {
            collectibles = GameObject.FindGameObjectsWithTag("Collect");
        }
        GetClosestCollectible();
        
    }
     GameObject GetClosestCollectible()
    {
        GameObject closest = null;
        
        Vector3 position = transform.position;

        foreach (GameObject collectible in collectibles)
        {
            Vector3 diff = collectible.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < collectDistance)
            {
                print("worked");
                closest = collectible;
                collectDistance = curDistance;
                Collect(closest);
            }
        }
        return closest;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            Collect(other.gameObject);
        }
    }
    void Collect(GameObject collectable)
    {
        collectable.SetActive(false);
        countPoint++;
        pointBar.value = calculatePoints(countPoint);
    }
    float calculatePoints(float count)
    {
        if (count == 0f)
        {
            return 0f;
        }
        return count / collectibles.Length;
    }
}
