using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{

    // class variable for pausing game
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    [SerializeField] GameObject pInHandler;  // reference to the player input handler
    void Start(){
        //if (pInHandler == null)
        //{
        //    pInHandler = GameObject.FindGameObjectWithTag("GameController");

        //}
    }


    /**
      *  Description: Update() checks for the Escape key press to toggle the pause state of the game
      *  Precon: none
      *  Postcon: Game is paused or resumed based on the Escape key press.
      */
    void Update(){
        if(Keyboard.current.escapeKey.wasPressedThisFrame){
            if(gameIsPaused){
                Resume();   //call the resume function
            } else {
                Pause();  //call the pause function
            }
        }
    }


    /** Resume()
     *  Description: Resumes the game by setting the time scale to 1 and updating the gameIsPaused variable.
     *  Precon: none
     *  Postcon: Game is resumed and the time scale is set to 1.
     */
     public void Resume(){
        pauseMenuUI.SetActive(false); //deactivate the pause menu UI
        Time.timeScale = 1f; //set the time scale to 1 to resume the game
        gameIsPaused = false; //update the gameIsPaused variable
        Cursor.lockState = CursorLockMode.Locked;  // lock cursor back
        Cursor.visible = false;  // hide cursor
        pInHandler.SetActive(true); // enable player input while paused
     }


    /** Pause()
     *  Description: Pauses the game by setting the time scale to 0 and updating the gameIsPaused variable.
     *  Precon: none
     *  Postcon: Game is paused and the time scale is set to 0.
     */
    void Pause(){
        pauseMenuUI.SetActive(true);  //activate the pause menu UI
        pInHandler.SetActive(false); // disable player input while paused
        Time.timeScale = 0f; //set the time scale to 0 to pause the game
        gameIsPaused = true; //update the gameIsPaused variable
        Cursor.lockState = CursorLockMode.None;  // free cursor
        Cursor.visible = true;  // show cursor
        
    }


    /** loadMenu()
      * Description: Loads the main menu scene. This function can be called from a button in the pause menu UI.
      * Precon: none
      * Postcon: Main menu scene is loaded.
      */
    public void loadMenu(){
        pauseMenuUI.SetActive(false); //deactivate the pause menu UI
        Time.timeScale = 1f; //set the time scale to 1 to resume the game
        gameIsPaused = false; //update the gameIsPaused variable
        pInHandler.SetActive(true); // enable player input while paused
        SceneManager.LoadScene("MainMenu");  // load the main menu scene
        

    }

    /** quitGame()
      * Description: Quits the game application. This function can be called from a button in the pause menu UI.
      * Precon: none
      * Postcon: Game application is quit.
      */
    public void quitGame(){
        Debug.Log("Quitting game...");
        Application.Quit();  // quit the application
    }



}   // eo pause menu class
