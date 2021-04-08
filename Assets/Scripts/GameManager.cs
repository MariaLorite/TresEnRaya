using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

//https://www.youtube.com/watch?v=qTbXxSns-zE

public class GameManager : MonoBehaviour
{
    public bool player = false; //false = Player_1_X, true = player_2_0
    int playerNumber = 1;
    [Space(10)]
    public GameObject playerX_text;
    public GameObject player0_text;

    public List<GameObject> fichasTablero = new List<GameObject>();

    int casillasVacias = 0;

    public event Action<List<GameObject>,int> CheckWinnerEvent;

    private void Start()
    {
        player = false; //Empezamos con player X.
        playerX_text.SetActive(true);
        player0_text.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            //El rayo sale de la posicion de la cámara
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Si el rayo golpea con un objeto con fisicas, devuelveme el objeto en hit
            if(Physics.Raycast(ray, out hit))
            {
                Ficha fichaClick = hit.transform.gameObject.GetComponent<Ficha>();

                //Si la ficha está vacia cambia la forma de la ficha y el jugador
                if (fichaClick.fichaEstado == 0)
                {
                    hit.transform.gameObject.GetComponent<Ficha>().ChangePlayerShape();
                    //Cuando el rayo incida en un objecto que se cambie el jugador
                    
                    CheckForWinner();
                }
                else if (fichaClick.fichaEstado == 1)
                {
                    Debug.Log("is X");
                }
                else if (fichaClick.fichaEstado == 2)
                {
                    Debug.Log("is 0");
                }
                CheckBoard();
            }
        }
    }

    void OnCheckWinnerEvent(List<GameObject> fichasTablero, int playerNumber)
    {
        CheckWinnerEvent?.Invoke(fichasTablero, playerNumber);
    }

    void CheckForWinner()
    {
        Debug.Log("Check for Winner");
        OnCheckWinnerEvent(fichasTablero, playerNumber);
        ChangePlayerPlaying();
    }


    void CheckBoard()
    {
        for (int i = 0; i < fichasTablero.Count; i++)
        {
           if (fichasTablero[i].GetComponent<Ficha>().fichaEstado == 0)
            {
                casillasVacias++;
            }
        }
        if (casillasVacias == 0)
        {
            Debug.LogError("Tablas");
            ResetGame();
        }
        casillasVacias = 0;
    }


    void ChangePlayerPlaying()
    {
        player = !player;
        ChangePlayerText();
    }


    void ResetGame()
    {
        //Carga la escena desde el inicio
        SceneManager.LoadScene(0);
    }


    public void Winner()
    {
        Debug.LogError("Tenemos un ganador: el jugador " + playerNumber );
        ResetGame();
    }


    void ChangePlayerText()
    {
        if (player == false)
        {
            playerX_text.SetActive(true);
            player0_text.SetActive(false);
            playerNumber = 1;
        } else
        {
            playerX_text.SetActive(false);
            player0_text.SetActive(true);
            playerNumber = 2;
        }
    }
}
