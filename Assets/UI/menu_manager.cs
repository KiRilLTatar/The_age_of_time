using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button buttonprolog;
    [SerializeField] private Button play;
    [SerializeField] private Button exitprolog;
    [SerializeField] private Button exitgame;
    [SerializeField] private GameObject prologpanel;
    [SerializeField] private Text textprolog;

    void Start()
    {
        buttonprolog.onClick.AddListener(ShowProlog);
        exitprolog.onClick.AddListener(HideProlog);
    }

    void ShowProlog()
    {
        play.gameObject.SetActive(false);
        exitgame.gameObject.SetActive(false);

        prologpanel.SetActive(true);
    }
    public void HideProlog()
    {
        prologpanel.SetActive(false);
        play.gameObject.SetActive(true);
        exitgame.gameObject.SetActive(true);
    }
}
