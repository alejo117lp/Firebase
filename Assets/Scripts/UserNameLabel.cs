using Firebase.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserNameLabel : MonoBehaviour {
    [SerializeField] TMP_Text label;

    private void Reset() {
        label = GetComponent<TMP_Text>();
    }

    private void Start() {
        FirebaseAuth.DefaultInstance.StateChanged += HandleAuthChange;
    }

    private void HandleAuthChange(object sender, EventArgs e) {
        var currentUser = FirebaseAuth.DefaultInstance.CurrentUser;

        if(currentUser != null) {
            label.text = currentUser.Email;
        }
    }
}
