using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    private PuzzleManager puzzleManager;
    private bool allPuzzlesCompleted = false;

    private void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (puzzleManager != null)
                puzzleManager.PressurePlate();
            door.SetActive(false); // door opens
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Only close the door if puzzles are not completed
            if (!allPuzzlesCompleted)
                door.SetActive(true);
        }
    }

    public void HideDoor()
    {
        allPuzzlesCompleted = true;
        if (door != null)
            door.SetActive(false);
    }
}
