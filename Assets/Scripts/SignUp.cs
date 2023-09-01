using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SignUp : MonoBehaviour
{
    [SerializeField] private Button registrationButton;

    private void Reset() {
        registrationButton = GetComponent<Button>();
    }
    void Start() {
        registrationButton.onClick.AddListener(HandleRegisterButtonClicked);
    }

    private void HandleRegisterButtonClicked() { 
        string email = GameObject.Find("InputEmail").GetComponent<TMP_InputField>().text;
    }
}
