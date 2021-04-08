using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ficha : MonoBehaviour
{
    GameManager mGameManager;

    public GameObject empty;
    public GameObject player1_X;
    public GameObject player2_0;
    [Space(10)]
    //0 = empty, 1 = X, 2 = 0;
    public int fichaEstado = 0;

    void Awake()
    {
                        // 1 Al inicio de la ejecucion (AWAKE) & 2 Solo exista una instancia en toda la escena de este componente
        mGameManager = FindObjectOfType<GameManager>(); //GameObject.Find("_GameManager").gameObject.GetComponent<GameManager>();
    }

    public void ChangePlayerShape()
    {
        if (mGameManager.player == false) // X
        {
            fichaEstado = 1; // X
            empty.SetActive(false);
            player1_X.SetActive(true);
        } else
        {
            fichaEstado = 2; // 0
            empty.SetActive(false);
            player2_0.SetActive(true);
        }
    }
}
