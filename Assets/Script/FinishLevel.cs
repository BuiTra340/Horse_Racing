using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private GameObject finishCam;
    [SerializeField] private HorseController mainHorse;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private ShowIndexHorse showIndexHorse;
    [SerializeField] private Transform resultParentText;
    private bool finishGame;
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, showIndexHorse.wayLength);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HorseController>() == mainHorse && !finishGame)
        {
            finishGame = true;
            Time.timeScale = 0.3f;
            finishCam.gameObject.SetActive(true);
            StartCoroutine(WaitForEndGame());
        }
    }

    private IEnumerator WaitForEndGame()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
        resultPanel.SetActive(true);
        resultText.text = showIndexHorse.indexModifyText(showIndexHorse.indexOfMainHorse) + " Of 12";
        ShowAllIndexHorse(resultParentText);
    }

    public void ShowAllIndexHorse(Transform transformParent)
    {
        for (int i = 0; i < resultParentText.childCount; i++)
        {
            Transform indexHorse = showIndexHorse.listHorse[i];
            transformParent.GetChild(i).GetComponent<TextMeshProUGUI>().text =
                i+1 + "\t" +indexHorse.name;
        }
    }
}
