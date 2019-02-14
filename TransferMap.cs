using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName;

    private PlayerManager thePlayer;
    private FadeManager theFade;
    private IEnumerator MvCoroutine;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
        theFade = FindObjectOfType<FadeManager>();
        MvCoroutine = thePlayer.MoveCoroutine();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(TransferCoroutine());
        }
    }

    IEnumerator TransferCoroutine()
    {
            theFade.FadeOut();
        StopCoroutine(MvCoroutine);
            yield return new WaitForSeconds(1f); 
            thePlayer.currentMapName = transferMapName;
            SceneManager.LoadScene(transferMapName);
            theFade.FadeIn();
        yield return new WaitForSeconds(2f);
        StartCoroutine(MvCoroutine);
    }
}