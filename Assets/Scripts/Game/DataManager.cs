using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{

    private Dictionary<string, User> allUsers = new Dictionary<string, User>();
    public Dictionary<string, User> AllUsers { get => allUsers; }
    public User user=null;
    public override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GetUsers();
    }

    private void GetUsers()
    {
        string filePath = Application.dataPath + "/users.json";

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Users users = JsonUtility.FromJson<Users>(json);

            if (users?.users != null)
            {
                foreach (User user in users.users)
                {
                    allUsers.Add(user.username, user);
                }
            }
        }

    }

    public void SaveUser(User user)
    {
        if (!allUsers.ContainsKey(user.username))
        {
            allUsers.Add(user.username, user);

        }
        SetUser(user);
        SaveUsersInFile();
    }

    public void SaveUsersInFile()
    {

        Users users = new Users();
        users.users = allUsers.Values.ToArray();
        string json = JsonUtility.ToJson(users);

        string filePath = Application.dataPath + "/users.json";
        File.WriteAllText(filePath, json);
        Debug.Log(filePath);
    }

    public void SetUser(User user)
    {
        this.user = user;
    }

    public string GetUsername()
    {
        if (this.user!=null)
        {
            return this.user.username;
        }
        return null;
    }
}


[System.Serializable]
public class User
{
    public User(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public string username;
    public string password;
    public PlayerInventory inventory;
}


[System.Serializable]
public class PlayerWearable
{
    public PlayerWearable(string id, int position, bool isWeared)
    {
        this.id = id;
        this.position = position;
        this.isWeared = isWeared;   
    }
    public string id;
    public int position;
    public bool isWeared;
}

[System.Serializable]
public class PlayerInventory
{
    public PlayerWearable[] wearables;
}

[System.Serializable]
public class Users
{
    public User[] users;
}

