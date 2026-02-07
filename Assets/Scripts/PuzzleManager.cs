using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] PuzzlePieceHolder1;
    public GameObject[] PuzzlePieceHolder2;
    public GameObject[] PuzzlePieceHolder3;
    public GameObject[] PuzzlePieceHolder4;
    public GameObject[] PuzzlePieceHolder5;
    
    private int greenCounter;
    private int cubeCounter;
    private int puzzle3Counter;


    public void GreenATM()
    {
        greenCounter++;

        switch (greenCounter)
        {
            case 0:
                PuzzlePieceHolder1[0].SetActive(true);
                PuzzlePieceHolder1[1].SetActive(false);
                PuzzlePieceHolder1[2].SetActive(false);
                break;
            case 1:
                PuzzlePieceHolder1[0].SetActive(false);
                PuzzlePieceHolder1[1].SetActive(false);
                PuzzlePieceHolder1[2].SetActive(true);
                greenCounter = 0;
                break;
        }
    }

    public void Cube()
    {
        cubeCounter++;

        switch (cubeCounter)
        {
            case 0:
                PuzzlePieceHolder2[0].SetActive(true);
                PuzzlePieceHolder2[1].SetActive(false);
                PuzzlePieceHolder2[2].SetActive(false);
                break;
            case 1:
                PuzzlePieceHolder2[0].SetActive(false);
                PuzzlePieceHolder2[1].SetActive(false);
                PuzzlePieceHolder2[2].SetActive(true);
                cubeCounter = 0;
                break;
        }
    }

    public void Puzzle3()
    {
        puzzle3Counter++;

        switch (puzzle3Counter)
        {
            case 0:
                PuzzlePieceHolder3[0].SetActive(true);
                PuzzlePieceHolder3[1].SetActive(false);
                PuzzlePieceHolder3[2].SetActive(false);
                break;
            case 1:
                PuzzlePieceHolder3[0].SetActive(false);
                PuzzlePieceHolder3[1].SetActive(false);
                PuzzlePieceHolder3[2].SetActive(true);
                puzzle3Counter = 0;
                break;
        }
    }
}
