using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject target=null;
    [SerializeField]
    GameObject []player=null;
    Renderer rendererTarget;
    Renderer rendererPlayer;
    bool stageComplete = false;
    [SerializeField]
    Slider pointBar;
    [SerializeField]
    GameObject panel;
    void Start()
    {
        panel.SetActive(false);
        rendererTarget = target.GetComponent<Renderer>();
        rendererTarget.material.color = Color.red;
        for(int i=0; i < 3; i++)
        {
            rendererPlayer=player[i].GetComponent<Renderer>();
            rendererPlayer.material.color = Color.cyan;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (pointBar.value == 1)
            {
                panel.SetActive(true);
                if (panel.activeInHierarchy && Input.touchCount == 1)
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (pointBar.value == 1)
            {
                panel.SetActive(true);
                if (panel.activeInHierarchy && Input.touchCount > 1)
                {
                    Application.Quit();
                }
            }
        }

    }
}
