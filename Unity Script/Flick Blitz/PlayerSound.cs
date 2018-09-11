using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

    [SerializeField]
    private AudioSource run, walk, jump, flick, attack, reload;

    private new Dictionary<string, AudioSource> audio;

    private void Awake() {
        audio = new Dictionary<string, AudioSource>();

        audio["run"] = run;
        audio["walk"] = walk;
        audio["jump"] = jump;
        audio["flick"] = flick;
        audio["attack"] = attack;
        audio["reload"] = reload;
    }

    public void PlaySound(string audioName, bool bAllowOverlap = true) {
        if (!bAllowOverlap && audio[audioName].isPlaying) return;

        try { audio[audioName].Play(); }
        catch(Exception e) { Debug.LogError(e.StackTrace); }
    }
}
