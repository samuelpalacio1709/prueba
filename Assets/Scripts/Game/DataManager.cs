using System;
using System.Collections;
using System.Collections.Generic;
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
        TextAsset usersJson = Resources.Load<TextAsset>("users");
        if (!usersJson) return;
        Users users = JsonUtility.FromJson<Users>(usersJson.text);
        Debug.Log(users);
        if (users.users != null)
        {
            foreach (User user in users.users)
            {
                allUsers.Add(user.username, user);
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
        users.users= allUsers.Values.ToArray();
        string json = JsonUtility.ToJson(users);
        Debug.Log(json);
        System.IO.File.WriteAllText("Assets/Resources/users.json", json);
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
        return "Guest";
    }
}
