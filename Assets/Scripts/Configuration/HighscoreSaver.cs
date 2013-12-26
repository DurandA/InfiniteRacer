using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MiniJSON;


public static class HighscoreSaver {
    private const string SECRET_KEY         = "infinite2013"; 
    private const string ADD_SCORE_URL      = "http://randonnazbike.ch/savehighscores.php?"; 
	private const string GET_SCORE_URL      = "http://randonnazbike.ch/gethighscores.php?";
    private const string SQL_SCORE_TABLE    = "scores";

    public struct Highscore
    {
        public Highscore(string name, string score)
        {
            this.name = name; this.score = score;
        }
        public string name;
        public string score;
    }
   

    private static string GetMd5Hash(MD5 md5Hash, string input)
    {
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }

    public static void postScore(string name, string score, MonoBehaviour script)
    {
        script.StartCoroutine(serverPostRequest(name, score, script));
    }
    private static IEnumerator serverPostRequest(string name, string score, MonoBehaviour script)
    {
        string hash = GetMd5Hash(MD5.Create(), (name + score + SECRET_KEY));
        string highscore_url = ADD_SCORE_URL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash + "&table=" + SQL_SCORE_TABLE;
        WWW hs_post = new WWW(highscore_url);
        yield return hs_post; // Wait until the download is done
        if (hs_post.error != null)
        {
            Debug.Log("There was an error posting the high score: " + hs_post.error + " | ");
        }
        if (hs_post.isDone)
        {
            script.SendMessage("OnHighscorePosted");
        }

    }
    private static IEnumerator serverGetRequest(MonoBehaviour script)
    {
        List<Highscore> hslist = new List<Highscore>();
        Debug.Log("starting request");
        WWW hs_get = new WWW(GET_SCORE_URL + "table=" + SQL_SCORE_TABLE);
        float timeelapsed = 0;
        while (!hs_get.isDone)
        {
            timeelapsed += Time.deltaTime;
            if (timeelapsed > 10) break;
            else yield return hs_get;
        }
        if (hs_get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + hs_get.error);
        }
        if (hs_get.isDone)
        {
            IDictionary o = (IDictionary)Json.Deserialize(hs_get.text);
            Debug.Log(hs_get.text + " - wtext");
            Debug.Log("Size: " + o.Count);
            foreach (IDictionary user in o.Values)
            {
                Debug.Log("Adding data: " + (string)user["name"] + " " + (string)user["score"]);
                hslist.Add(new Highscore((string)user["name"], (string)user["score"]));
            }

            script.SendMessage("OnHighscoreLoaded", hslist);
        }
    }

    public static void loadScores(MonoBehaviour script)
    {
        script.StartCoroutine(serverGetRequest(script));
    }
}
