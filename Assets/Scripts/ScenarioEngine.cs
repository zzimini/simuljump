using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Cinemachine;
using System;
using TMPro;

public class ScenarioEngine : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas canvas;
    public GameObject[] cameras;

    public string[] objectsName;



    //private Image back;
    private Image front;
    private RawImage video;
    private TMP_Text text;
    private Canvas dialog;
    private VideoPlayer player;

    private Dictionary<string, GameObject> map = new Dictionary<string, GameObject>();


    void Start()
    {
        //front = canvas.transform.Find("Front").GetComponent<Image>();
        //video = canvas.transform.Find("Video").GetComponent<RawImage>();
        text = canvas.transform.Find("text").GetComponent<TMP_Text>();
        //player = transform.GetComponent<VideoPlayer>();
        //dialog = canvas.transform.Find("Dialog").GetComponent<Canvas>();
        foreach (string name in objectsName) map.Add(name, GameObject.Find(name));

        //string script = Resources.Load<TextAsset>("gamescript0").ToString();
        //StartCoroutine(PlayScript(script));        

    }

    public IEnumerator PlayScript(string script)
    {
        canvas.enabled = true;
        foreach (string token in script.Split('\n'))
        {
            string[] tokens = Parsing(token);
            string fun = tokens[0];
            if (fun == "video")
            {
                string clip = tokens[1];
                front.enabled = false;
                dialog.enabled = false;
                video.enabled = true;
                player.clip = Resources.Load<VideoClip>(clip);
                float len = (float)player.clip.length;
                player.Play();
                yield return new WaitForSeconds(len);
            }
            else if (fun == "text")
            {
                text.enabled = true;
                text.text = tokens[1];
                yield return new WaitForSeconds(float.Parse(tokens[2] == "" ? "0" : tokens[2]));
            }
            else if (fun == "image")
            {
                front.enabled = true;
                video.enabled = false;
                dialog.enabled = false;
                front.sprite = Resources.Load<Sprite>(tokens[1]);
                yield return new WaitForSeconds(float.Parse(tokens[2] == "" ? "0" : tokens[2]));
            }
            else if (fun == "wait")
            {
                yield return new WaitForSeconds(float.Parse(tokens[1] == "" ? "2" : tokens[1]));
            }
            else if (fun == "dialog")
            {
                dialog.enabled = true;
                front.enabled = false;
                video.enabled = false;
                string ch = tokens[1];
                string text = tokens[2];
                //dialog.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(ch);
                dialog.transform.Find("Text").GetComponent<Text>().text = text;
                yield return new WaitForSeconds(float.Parse(tokens[3] == "" ? "0" : tokens[3]));
            }
            else if (fun == "camera")
            {
                for (int i = 0; i < cameras.Length; i++) cameras[i].SetActive(false);
                cameras[int.Parse(tokens[1])].SetActive(true);
            }
            else if (fun == "show")
            {
                canvas.enabled = tokens[1] == "false" ? false : true;
            }
            else if (fun == "moveto")
            {
                GameObject obj = map[tokens[1]];
                Vector3 target = map[tokens[2]].transform.position;
                float duration = float.Parse(tokens[3] == "" ? "3" : tokens[3]);

                float elapsedTime = 0f;
                Vector3 startingPos = obj.transform.position;
                while (elapsedTime < duration)
                {
                    obj.transform.position = Vector3.Lerp(startingPos, target, elapsedTime / duration);
                    obj.transform.forward = (target - obj.transform.position).normalized;
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                obj.transform.position = target;
            }
        }
        canvas.enabled = false;
    }

    string[] Parsing(string cmd)
    {
        cmd = cmd.Replace("(", ",").Replace(")", "");
        string[] tokens = cmd.Split(',');
        for (int i = 0; i < tokens.Length; i++)
        {
            tokens[i] = tokens[i].Trim();
        }
        return tokens;
    }
}

