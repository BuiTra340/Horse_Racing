using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowIndexHorse : MonoBehaviour
{
    [SerializeField] private Transform horseParent;
    [SerializeField] private Transform mainHorse;
    [SerializeField] private TextMeshProUGUI indexHorseText;
    [SerializeField] private TextMeshProUGUI remainingDistanceText;
    public int wayLength = 2000;
    public List<Transform> listHorse = new List<Transform>();
    public int indexOfMainHorse { get; private set; }
    private int remainingDistance;

    private void Start()
    {
        listHorse.Clear();
        for(int i = 0; i < horseParent.childCount; i++)
        {
            listHorse.Add(horseParent.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        getCurrentIndexOfHourse();
        showIndexOfMainHorse();
        showRemainingDistance();
    }

    private void showIndexOfMainHorse()
    {
        indexOfMainHorse = listHorse.IndexOf(mainHorse) + 1;
        indexHorseText.text = indexModifyText(indexOfMainHorse);
    }

    private void getCurrentIndexOfHourse()
    {
        for(int i = 0;i< listHorse.Count - 1;i++)
        {
            for(int j = i+1; j < listHorse.Count;j++)
            {
                if(listHorse[i].position.z < listHorse[j].position.z)
                {
                    Transform temp = listHorse[i];
                    listHorse[i] = listHorse[j];
                    listHorse[j] = temp;
                }
            }
        }
    }

    public string indexModifyText(int indexToModify)
    {
        switch(indexToModify)
        {
            case 1:
                return "1st";
            case 2:
                return "2nd";
            case 3:
                return "3rd";
            default : return indexToModify.ToString() + "th";
        }
    }

    private void showRemainingDistance()
    {
        remainingDistance = Mathf.Clamp(wayLength - (int)mainHorse.position.z, 0, wayLength);
        remainingDistanceText.text = remainingDistance.ToString() +"m";
    }
}
