using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiController : MonoBehaviour
{
    [SerializeField] private string searchText;
    [SerializeField] private List<GameObject> listaDeCubos;
    private List<Texture2D> listaDeImagenes = new List<Texture2D>(); 
    private int postersNum = 10;
    private int page = 1;

    void Start()
    {
        StartCoroutine(GetImages());
    }

    private IEnumerator GetImages()
    {
        listaDeImagenes.Clear();
        UnityWebRequest data = UnityWebRequest.Get($"https://www.omdbapi.com/?s={searchText}&page={page}&apikey=bec0dc5f");
        yield return data.SendWebRequest();

        if (data.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error de conexión con la API");
        }
        else
        {
            SearchData mySearch = JsonUtility.FromJson<SearchData>(data.downloadHandler.text);
            if (mySearch.Search != null)
            {
                for (int i = 0; i < Mathf.Min(postersNum, mySearch.Search.Count); i++)
                {
                    MovieData movie = mySearch.Search[i];

                    if (movie.Poster.StartsWith("http"))
                    {
                        UnityWebRequest www = UnityWebRequestTexture.GetTexture(movie.Poster);
                        yield return www.SendWebRequest();

                        if (www.result == UnityWebRequest.Result.ConnectionError)
                        {
                            Debug.LogError(www.error);
                        }
                        else
                        {
                            Texture2D loadedTexture = DownloadHandlerTexture.GetContent(www);
                            loadedTexture.wrapMode = TextureWrapMode.Clamp;
                            listaDeImagenes.Add(loadedTexture);
                        }
                    }
                }

                AssignImages();
            }
        }
    }

    private void AssignImages()
    {
        for (int i = 0; i < Mathf.Min(listaDeCubos.Count,listaDeImagenes.Count); i++)
        {
            Renderer rendererCubo = listaDeCubos[i].GetComponent<Renderer>();
            rendererCubo.material.mainTexture = listaDeImagenes[i];
        }
    }

    public void ChangePage()
    {
        page++;
        StartCoroutine(GetImages());
    }

    [Serializable]
    public class SearchData
    {
        public List<MovieData> Search;
        public string totalResults;
        public string Response;
    }

    [Serializable]
    public class MovieData
    {
        public string Title;
        public string Year;
        public string imdbID;
        public string Type;
        public string Poster;
    }
}
