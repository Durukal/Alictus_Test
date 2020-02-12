using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    Texture2D map;
    public ColorToPrefab[] colorMappings;
    
    void Start()
    {
        GenerateLevel();
    }
    void GenerateLevel()
    {
        for(int x=0; x<map.width; x++)
        {
            for(int z=0; z<map.height; z++)
            {
                GenerateTile(x, z);
            }
        }
    }
    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);
        if(pixelColor.a == 0)
        {
            //The pixel is transparent! Just ignore it...
            return;
        }
        else
        {
            
            
                    print("here");
                    Vector3 position = this.transform.position + new Vector3((-x * 1.0f)+0.1f, 0f, (-z * 1.0f)+0.1f);
                    GameObject collectible = ObjectPooler.SharedInstance.GetPooledObject();
                    if (collectible != null)
                    {
                        collectible.transform.position = position;
                        collectible.SetActive(true);
                        collectible.GetComponent<Renderer>().material.color = pixelColor;
                    }            
        }

    }
}
