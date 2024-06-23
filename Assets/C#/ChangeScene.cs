using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Result()
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Smple()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Gameover()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
