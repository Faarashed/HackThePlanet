using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game state
    int level;
    //MainMenu, Password, Win
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    //string password = "test";

    string[] level1Passwords = { "heart muscle", "inner body", "electronic device" };
    string[] level2Passwords = { "screen", "remote", "camera" };
    string password;

    // Pacemaker: Heart muscle, inner body, electronic device
    // baby monitor: screen, remote, camera


    // Start is called before the first frame update
    void Start()
    {

        ShowMainMenu("Filet Minyon");

    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu(" Filet Minyon");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            SelectLevel(input);

        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }
    


    private void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine(@"
 ____ ____ ____ ____ ____ ____ ____ _________ ____ ____ 
||S |||M |||A |||S |||H |||E |||D |||       |||I |||T ||
||__|||__|||__|||__|||__|||__|||__|||_______|||__|||__||
|/__\|/__\|/__\|/__\|/__\|/__\|/__\|/_______\|/__\|/__\|

");
        }
        else
        {
            Terminal.WriteLine(@"
  _   _   _     _   _   _   _  
 / \ / \ / \   / \ / \ / \ / \ 
( Y | o | u ) ( L | o | s | e )
 \_/ \_/ \_/   \_/ \_/ \_/ \_/ 

Try again or go to the main menu");
        }
    }


    void SelectLevel(string inputlevel)
    {
        if (inputlevel == "1")
        {
            level = 1;
            StartGame();

        }
        else if (inputlevel == "2")
        {
            level = 2;
            StartGame();
        }
        else if (inputlevel == "3")
        {
            level = 3;
            StartGame();
        }
        else
        {
            StartGame();
        }


        void StartGame()
        {
            currentScreen = Screen.Password;
            Terminal.WriteLine("you have chosen level:" + level);
            switch (level)
            {
                case 1:
                    password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                    break;
                case 2:
                    password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                    break;
                default:
                    Terminal.WriteLine("You Dumb ?");
                    break;

            }
            Terminal.WriteLine("enter the password to hack into the system " + password.Anagram());
        }



    }

    void ShowMainMenu(string name)
    {

        //Terminal.WriteLine("Welcome Agent"+ name);
        currentScreen=Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine($"welcome agent {name}");
        Terminal.WriteLine("What would you like to hack into");
        Terminal.WriteLine("press 1 for pacemaker ");
        Terminal.WriteLine("Press 2 for baby monitor ");
        Terminal.WriteLine("Enter your selection");
    }
    // Update is called once per frame
    void Update()
    {
    }
}
