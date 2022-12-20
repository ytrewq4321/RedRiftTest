using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetArt : MonoBehaviour
{
    private CardGUI cardGUI;

    private void Start()
    {
        cardGUI = GetComponent<CardGUI>();
        StartCoroutine(GetArtCoroutine());
    }

    private IEnumerator GetArtCoroutine()
    {
        string uri = "https://picsum.photos/512/512";
        using(UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return request.SendWebRequest();
            DownloadHandlerTexture downloadHandlerTexture = request.downloadHandler as DownloadHandlerTexture;
            var texture2D = downloadHandlerTexture.texture;
            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
            cardGUI.art.sprite = sprite;
        }
    }
}
