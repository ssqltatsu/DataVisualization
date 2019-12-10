﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;

public class SampleSpeechToText : MonoBehaviour {

    [SerializeField]
//    private AudioClip m_AudioClip = new AudioClip();
    private SpeechToText m_SpeechToText = new SpeechToText();

    // Use this for initialization
    IEnumerator Start()
    {
        // 音声をマイクから 3 秒間取得する
        Debug.Log ("Start record"); //集音開始
        var audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(null, true, 10, 44100);
        audioSource.loop = false;
        audioSource.spatialBlend = 0.0f;
        yield return new WaitForSeconds (10f);
        Microphone.End (null); //集音終了
        Debug.Log ("Finish record");

        // ためしに録音内容を再生してみる
        audioSource.Play ();

        // SpeechToText を日本語指定して、録音音声をテキストに変換
        m_SpeechToText.RecognizeModel = "ja-JP_BroadbandModel";
        m_SpeechToText.Recognize(audioSource.clip, HandleOnRecognize);
    }

    void HandleOnRecognize(SpeechRecognitionEvent result)
    {
        if (result != null && result.results.Length > 0)
        {
            Debug.Log("result is not empty");
            foreach (var res in result.results)
            {
                Debug.Log("result is not empty");
                foreach (var alt in res.alternatives)
                {
                    Debug.Log("??");
                    string text = alt.transcript;
                    Debug.Log(string.Format("{0} ({1}, {2:0.00})\n", text, res.final ? "Final" : "Interim", alt.confidence));
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {

    }
}