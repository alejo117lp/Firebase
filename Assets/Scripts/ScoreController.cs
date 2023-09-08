using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    DatabaseReference mDatabase;
    string userId;
    int score;

    private void Start() {
        mDatabase = FirebaseDatabase.DefaultInstance.RootReference;
        userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
    }

    public void WriteNewScore(int score) {
        mDatabase.Child("users").Child(userId).Child("score").SetValueAsync(score);
    }

    public void GetUsersScore() {
        FirebaseDatabase.DefaultInstance.GetReference("/users" + userId + "/username")
            .GetValueAsync().ContinueWithOnMainThread(task => {
                if (task.IsFaulted) {
                    Debug.Log(task.Exception);
                }
                else if (task.IsCompleted) {
                    DataSnapshot snapshot = task.Result;
                    Debug.Log("Score: " + snapshot.Value);
                    
                }
            });
    }

    public void GetUsersHighestScores() {
        FirebaseDatabase.DefaultInstance.GetReference("users").
            OrderByChild("score").LimitToLast(5).GetValueAsync().ContinueWithOnMainThread(task =>{
                if (task.IsFaulted) {
                    Debug.Log(task.Exception);
                }
                else if (task.IsCompleted) {
                    DataSnapshot snapshot = task.Result;
                    Debug.Log("Leaders: " + snapshot.Value);
                }
            });
    }

    public void IncrementScore() {
        score += 100;
        WriteNewScore(score);
    }
}

public class UserData {
    public int score;
    public string username;
}
