using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppDirector : MonoBehaviour 
{

    // **************************
    // Member Variables
    // **************************

    public enum AppState
    {
        kMainMenu,      // Start screen
        kPlaying,       // User is swiping through options
        kMatchSelected, // Match shown
    }
        
    [SerializeField] private GameObject m_mainMenu;
    [SerializeField] private GameObject m_q1;
    [SerializeField] private GameObject m_q2;
    [SerializeField] private GameObject m_q3;
    [SerializeField] private GameObject m_matchScreen;

    private const int kNumQuestions = 3;

    private AppState m_appState;   
    private int m_currQuestion;
    private bool[] m_questionAnswers;

    // **************************
    // Public functions
    // **************************

	public void Start () 
    {
        m_appState = AppState.kMainMenu;

        m_currQuestion = -1;
        m_questionAnswers = new bool[kNumQuestions];
        DisplayMainMenu();
	}
	
	public void Update () 
    {
        // empty
	} 

    public void SelectedPlayGame()
    {        
        m_currQuestion = 0;
        DisplayNextQuestion();

        m_appState = AppState.kPlaying;
    }

    public void SelectedYes()
    {
        m_questionAnswers[m_currQuestion] = true;
        m_currQuestion++;

        DisplayNextQuestion();
        if (m_currQuestion == kNumQuestions)
        {
            CalculateMatch();
            DisplayMatchScreen();
        }
    }

    public void SelectedNo()
    {
        m_questionAnswers[m_currQuestion] = false;
        m_currQuestion++;

        DisplayNextQuestion();
        if (m_currQuestion == kNumQuestions)
        {
            CalculateMatch();
            DisplayMatchScreen();
        }
    }

    public void SelectedMatch()
    {
        m_currQuestion = -1;
        DisplayMainMenu();

        m_appState = AppState.kMainMenu;
    }

    // **************************
    // Private/Helper functions
    // **************************
        
    private void DisplayMainMenu()
    {
        m_mainMenu.SetActive(true);
        m_q1.SetActive(false);
        m_q2.SetActive(false);
        m_q3.SetActive(false);
        m_matchScreen.SetActive(false);
    }

    private void DisplayNextQuestion()
    {
        m_mainMenu.SetActive(false);
        m_q1.SetActive(m_currQuestion == 0);
        m_q2.SetActive(m_currQuestion == 1);
        m_q3.SetActive(m_currQuestion == 2);
        m_matchScreen.SetActive(false);
    }

    private void DisplayMatchScreen()
    {
        m_mainMenu.SetActive(false);
        m_q1.SetActive(false);
        m_q2.SetActive(false);
        m_q3.SetActive(false);
        m_matchScreen.SetActive(true);
    }

    private void CalculateMatch()
    {
        // TODO: Use m_questionAnswers[] to select match!
        m_appState = AppState.kMatchSelected;
    }
}