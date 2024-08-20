using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public GameObject boss;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (boss != null)
        {
            if (transform.childCount == 0)
                boss.SetActive(true);
            else
                boss.SetActive(false);
        }
        else
        {
            StartCoroutine(WaitAndLoadWinScene());
        }

        if (player == null)
        {
            StartCoroutine(WaitAndLoadLoseScene());
        }
    }

    IEnumerator WaitAndLoadWinScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("WinScene");
    }

    IEnumerator WaitAndLoadLoseScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("LoseScene");
    }
}
