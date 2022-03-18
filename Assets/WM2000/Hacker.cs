using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    const string menuHint = "You may type menu at any time. ";
    string[] level1Passwords = { "books", "librarian", "shelf", "whisper" };
    string[] level2Passwords = { "cell", "sheriff", "soap", "warrant" };
    //Game State

    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?\n \n Press 1 for the local library\n Press 2 for the prison\n \n Enter your selection: ");

    }


    void OnUserInput(string input)
    {
        if (input == "menu") 
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please Select A Valid Level");
        }    
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter The Password");
        Terminal.WriteLine(menuHint);
    }
 
    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;

        }
    } 

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            StartGame();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book... ");
                Terminal.WriteLine(@"
    ______
   /     //
  /     //
 /____ //
(_____(/


                ");
                Terminal.WriteLine(menuHint);
                break;
            case 2:
                Terminal.WriteLine("Have a gun...");
                Terminal.WriteLine(@"
      __________________
     /                 /  
    /                 /    
   /     ____________/
  / (   /
 /     /
/_____/
                ");
                Terminal.WriteLine(menuHint);
                break;
            default:
                Debug.LogError("Invalid Level Reacher");
                break;
        }
    }

    void Update()
    {

    }
}
