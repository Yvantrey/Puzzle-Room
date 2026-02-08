using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] PuzzlePieceHolder1;
    public GameObject[] PuzzlePieceHolder2;
    public GameObject[] PuzzlePieceHolder3;
    public GameObject[] PuzzlePieceHolder4;
    public GameObject[] PuzzlePieceHolder5;
    public GameObject wonPanel;
    
    private int greenCounter;
    private int cubeCounter;
    private int puzzle3Counter;
    private int puzzle4Counter;
    private int pressureplateCounter;
    private bool allPuzzlesCompleted = false;
    private PressurePlate pressurePlate;

    private bool puzzle1Completed = false;
    private bool puzzle3Completed = false;
    private bool puzzle4Completed = false;

    private void Start()
    {
        pressurePlate = FindObjectOfType<PressurePlate>();
    }

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
        CheckCompletion();
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
        CheckCompletion();
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
        CheckCompletion();
    }

    public void CompletePuzzle3()
    {
        if (!puzzle3Completed)
        {
            puzzle3Completed = true;
            PuzzlePieceHolder3[0].SetActive(false);
            PuzzlePieceHolder3[1].SetActive(false);
            PuzzlePieceHolder3[2].SetActive(true);
            CheckCompletion();
        }
    }

    public void UndoPuzzle3()
    {
        if (puzzle3Completed)
        {
            puzzle3Completed = false;
            PuzzlePieceHolder3[0].SetActive(true);
            PuzzlePieceHolder3[1].SetActive(false);
            PuzzlePieceHolder3[2].SetActive(false);
        }
    }

    public void Puzzle4()
    {
        puzzle4Counter++;

        switch (puzzle4Counter)
        {
            case 0:
                PuzzlePieceHolder4[0].SetActive(true);
                PuzzlePieceHolder4[1].SetActive(false);
                PuzzlePieceHolder4[2].SetActive(false);
                break;
            case 1:
                PuzzlePieceHolder4[0].SetActive(false);
                PuzzlePieceHolder4[1].SetActive(false);
                PuzzlePieceHolder4[2].SetActive(true);
                puzzle4Counter = 0;
                break;
        }
        CheckCompletion();
    }
        public void PressurePlate()
    {
        pressureplateCounter++;

        switch (pressureplateCounter)
        {
            case 0:
                PuzzlePieceHolder5[0].SetActive(true);
                PuzzlePieceHolder5[1].SetActive(false);
                PuzzlePieceHolder5[2].SetActive(false);
                break;
            case 1:
                PuzzlePieceHolder5[0].SetActive(false);
                PuzzlePieceHolder5[1].SetActive(false);
                PuzzlePieceHolder5[2].SetActive(true);
                pressureplateCounter = 0;
                break;
        }
        CheckCompletion();
    }

    private void CheckCompletion()
    {
        if (allPuzzlesCompleted)
            return;

        // Check if all final puzzle pieces are active
        if (PuzzlePieceHolder1[2].activeSelf &&
            PuzzlePieceHolder2[2].activeSelf &&
            PuzzlePieceHolder3[2].activeSelf &&
            PuzzlePieceHolder4[2].activeSelf &&
            PuzzlePieceHolder5[2].activeSelf)
        {
            allPuzzlesCompleted = true;
            FindObjectOfType<TimerCountdown>().StopTimer();
            if (wonPanel != null)
                wonPanel.SetActive(true);
            if (pressurePlate != null)
            {
                pressurePlate.HideDoor();
                Debug.Log("All puzzles completed! Exit door disappeared!");
            }
        }
    }
}
