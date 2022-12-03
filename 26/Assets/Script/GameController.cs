
using UnityEngine.SceneManagement;
using UnityEngine;
[DefaultExecutionOrder(-100)]
public class GameController : MonoBehaviour
{
    public Color colorPink;
    public Color colorBlue;
    public bool startGame, GameOver;
    Player player;
    public GameObject StartCanvas, EndCanvas;
    // Start is called before the first frame update
    void Start()
    {
        StartCanvas.SetActive(true);
        EndCanvas.SetActive(false);
        player = FindObjectOfType<Player>();
    }

   public void StartTheGame()
    {
        startGame = true;
        player.ChangeTheRigidbody();
    }
    public void ShowEndCanvas()
    {
        EndCanvas.SetActive(true);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
