using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private Button shootButton;

    [SerializeField]
    private GameObject needle;

    private GameObject[] gameNeedles;

    [SerializeField]
    private int startingNeedles;

    private float needleDistance = 1.5f;
    private int needleIndex;


	// Use this for initialization
	void Awake () {
		if (instance == null)
        {
            instance = this;
        }

        GetButton();
	}
	
	// Update is called once per frame
	void Start () {
        CreateNeedles();
	}

    void GetButton ()
    {
        shootButton = GameObject.Find("Shoot Button").GetComponent<Button>();
        shootButton.onClick.AddListener(() => ShootNeedleNow());
    }

    public void ShootNeedleNow()
    {
        gameNeedles[needleIndex].GetComponent<NeedleMovementScript>().FireNeedle();
        needleIndex++;

        if (needleIndex == gameNeedles.Length)
        {
            Debug.Log("The game is finished");
            shootButton.onClick.RemoveAllListeners();
        }
    }

    void CreateNeedles()
    {
        gameNeedles = new GameObject[startingNeedles];
        Vector3 temp = transform.position;

        for (int i = 0; i < gameNeedles.Length; i++)
        {
            gameNeedles[i] = Instantiate(needle, temp, Quaternion.identity) as GameObject;
            temp.y -= needleDistance;
        }
    }

    public void InstantiateNeedle()
    {
        Instantiate(needle, transform.position, Quaternion.identity);
    }
}
