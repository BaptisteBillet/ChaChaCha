using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public enum TypeOfKeyBoard
{
    AZERTY,
    QWERTY
}

public enum GameStates
{
    TUTO,
    KEYBOARD,
    GAME,
    END
}

public partial class GameManager : MonoBehaviour {

    private TypeOfKeyBoard KeyBoardType=TypeOfKeyBoard.AZERTY;
    private GameStates GameState = GameStates.TUTO;

    public GameObject TUTO;
    public GameObject PanelTuto;
    public GameObject PanelChoiceOfKeyboard;

    public List<Button> KeyBoardChoice = new List<Button>();

    public int m_LeftFinger = -1;
    public int m_RightFinger = -1;

    public int m_LeftFingerLast = -2;
    public int m_RightFingerLast = -2;

    private int m_LeftFingerMemory = -2;
    private int m_RightFingerMemory = -2;

    private bool m_LeftHasChanged = false;
    private bool m_RightHasChanged = false;

    //Tuto
    private bool m_Choice = false;
    private int m_KeyboardChoiceIndex = 0;
    private int m_KeyboardChoiceMax = 1;
    private int m_KeyboardChoiceMin = 0;

    //
    private Dictionary<KeyCode, int> KeyNumeric = new Dictionary<KeyCode, int>();

    public Animator m_Tuto;

    public Animator m_Bouche;

    public GameObject m_Coeur;

    void Awake()
    {
        KeyNumeric.Add(KeyCode.A, 0);
        KeyNumeric.Add(KeyCode.Z, 1);
        KeyNumeric.Add(KeyCode.E, 2);
        KeyNumeric.Add(KeyCode.R, 3);
        KeyNumeric.Add(KeyCode.T, 4);
        KeyNumeric.Add(KeyCode.Y, 5);
        KeyNumeric.Add(KeyCode.U, 6);
        KeyNumeric.Add(KeyCode.I, 7);
        KeyNumeric.Add(KeyCode.O, 8);
        KeyNumeric.Add(KeyCode.P, 9);
        KeyNumeric.Add(KeyCode.Q, 10);
        KeyNumeric.Add(KeyCode.S, 11);
        KeyNumeric.Add(KeyCode.D, 12);
        KeyNumeric.Add(KeyCode.F, 13);
        KeyNumeric.Add(KeyCode.G, 14);
        KeyNumeric.Add(KeyCode.H, 15);
        KeyNumeric.Add(KeyCode.J, 16);
        KeyNumeric.Add(KeyCode.K, 17);
        KeyNumeric.Add(KeyCode.L, 18);
        KeyNumeric.Add(KeyCode.M, 19);
        KeyNumeric.Add(KeyCode.W, 20);
        KeyNumeric.Add(KeyCode.X, 21);
        KeyNumeric.Add(KeyCode.C, 22);
        KeyNumeric.Add(KeyCode.V, 23);
        KeyNumeric.Add(KeyCode.B, 24);
        KeyNumeric.Add(KeyCode.N, 25);
        KeyNumeric.Add(KeyCode.Comma, 26);
        KeyNumeric.Add(KeyCode.Period, 27);
        KeyNumeric.Add(KeyCode.Slash, 28);

    }

    // Use this for initialization
    void Start () {
        m_ScoreText.text = "0";
        TUTO.SetActive(true);
        PanelTuto.SetActive(true);

        ///////////
        #region Choree1
        m_Choree1.m_Choree = new List<Enchainement>();

        Enchainement m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 2;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        //25
        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        //41
        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);
        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);
        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);
        //48
        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);
        //65
        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.StepLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);
        //69

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);
        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapFront;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapFront;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement.m_Mouvement = MouvementName.TapFront;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);
        //89

        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        //97
        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);
        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);
        //105
        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);
        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapLeft;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.TapRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);
        //113
        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.StepRight;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.Idle;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);

        m_Enchainement = new Enchainement();
        m_Enchainement.m_Mouvement = MouvementName.End;
        m_Enchainement.m_Repetition = 0;
        m_Choree1.m_Choree.Add(m_Enchainement);





        #endregion
    }


    public void SetKeyBoardMode(string _type)
    {
        switch (_type)
        {
            case "AZERTY":
                KeyBoardType = TypeOfKeyBoard.AZERTY;
                break;

            case "QWERTY":
                KeyBoardType = TypeOfKeyBoard.QWERTY;
                break;
        }
        
    }


	// Update is called once per frame
	void Update ()
    {
        if (GameState == GameStates.GAME)
        {
            #region Inputs
            if (Input.GetKeyDown(KeyCode.A))
            {
                TraductFromForeignKeyboard(KeyCode.A, true);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                TraductFromForeignKeyboard(KeyCode.A, false);
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                TraductFromForeignKeyboard(KeyCode.Z, true);
            }
            if (Input.GetKeyUp(KeyCode.Z))
            {
                TraductFromForeignKeyboard(KeyCode.Z, false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                TraductFromForeignKeyboard(KeyCode.E, true);
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                TraductFromForeignKeyboard(KeyCode.E, false);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                TraductFromForeignKeyboard(KeyCode.R, true);
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                TraductFromForeignKeyboard(KeyCode.R, false);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                TraductFromForeignKeyboard(KeyCode.T, true);
            }
            if (Input.GetKeyUp(KeyCode.T))
            {
                TraductFromForeignKeyboard(KeyCode.T, false);
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                TraductFromForeignKeyboard(KeyCode.Y, true);
            }
            if (Input.GetKeyUp(KeyCode.Y))
            {
                TraductFromForeignKeyboard(KeyCode.Y, false);
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                TraductFromForeignKeyboard(KeyCode.U, true);
            }
            if (Input.GetKeyUp(KeyCode.U))
            {
                TraductFromForeignKeyboard(KeyCode.U, false);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                TraductFromForeignKeyboard(KeyCode.I, true);
            }
            if (Input.GetKeyUp(KeyCode.I))
            {
                TraductFromForeignKeyboard(KeyCode.I, false);
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                TraductFromForeignKeyboard(KeyCode.O, true);
            }
            if (Input.GetKeyUp(KeyCode.O))
            {
                TraductFromForeignKeyboard(KeyCode.O, false);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                TraductFromForeignKeyboard(KeyCode.P, true);
            }
            if (Input.GetKeyUp(KeyCode.P))
            {
                TraductFromForeignKeyboard(KeyCode.P, false);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                TraductFromForeignKeyboard(KeyCode.Q, true);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                TraductFromForeignKeyboard(KeyCode.Q, false);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                TraductFromForeignKeyboard(KeyCode.S, true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                TraductFromForeignKeyboard(KeyCode.S, false);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                TraductFromForeignKeyboard(KeyCode.D, true);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                TraductFromForeignKeyboard(KeyCode.D, false);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                TraductFromForeignKeyboard(KeyCode.F, true);
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                TraductFromForeignKeyboard(KeyCode.F, false);
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                TraductFromForeignKeyboard(KeyCode.G, true);
            }
            if (Input.GetKeyUp(KeyCode.G))
            {
                TraductFromForeignKeyboard(KeyCode.G, false);
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                TraductFromForeignKeyboard(KeyCode.H, true);
            }
            if (Input.GetKeyUp(KeyCode.H))
            {
                TraductFromForeignKeyboard(KeyCode.H, false);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                TraductFromForeignKeyboard(KeyCode.J, true);
            }
            if (Input.GetKeyUp(KeyCode.J))
            {
                TraductFromForeignKeyboard(KeyCode.J, false);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                TraductFromForeignKeyboard(KeyCode.K, true);
            }
            if (Input.GetKeyUp(KeyCode.K))
            {
                TraductFromForeignKeyboard(KeyCode.K, false);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                TraductFromForeignKeyboard(KeyCode.L, true);
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                TraductFromForeignKeyboard(KeyCode.L, false);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                TraductFromForeignKeyboard(KeyCode.M, true);
            }
            if (Input.GetKeyUp(KeyCode.M))
            {
                TraductFromForeignKeyboard(KeyCode.M, false);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                TraductFromForeignKeyboard(KeyCode.W, true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                TraductFromForeignKeyboard(KeyCode.W, false);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                TraductFromForeignKeyboard(KeyCode.X, true);
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                TraductFromForeignKeyboard(KeyCode.X, false);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                TraductFromForeignKeyboard(KeyCode.C, true);
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                TraductFromForeignKeyboard(KeyCode.C, false);
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                TraductFromForeignKeyboard(KeyCode.V, true);
            }
            if (Input.GetKeyUp(KeyCode.V))
            {
                TraductFromForeignKeyboard(KeyCode.V, false);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                TraductFromForeignKeyboard(KeyCode.B, true);
            }
            if (Input.GetKeyUp(KeyCode.B))
            {
                TraductFromForeignKeyboard(KeyCode.B, false);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                TraductFromForeignKeyboard(KeyCode.N, true);
            }
            if (Input.GetKeyUp(KeyCode.N))
            {
                TraductFromForeignKeyboard(KeyCode.N, false);
            }

            if (Input.GetKeyDown(KeyCode.Comma))
            {
                TraductFromForeignKeyboard(KeyCode.Comma, true);
            }
            if (Input.GetKeyUp(KeyCode.Comma))
            {
                TraductFromForeignKeyboard(KeyCode.Comma, false);
            }

            if (Input.GetKeyDown(KeyCode.Semicolon))
            {
                TraductFromForeignKeyboard(KeyCode.Semicolon, true);
            }
            if (Input.GetKeyUp(KeyCode.Semicolon))
            {
                TraductFromForeignKeyboard(KeyCode.Semicolon, false);
            }

            if (Input.GetKeyDown(KeyCode.Colon))
            {
                TraductFromForeignKeyboard(KeyCode.Colon, true);
            }
            if (Input.GetKeyUp(KeyCode.Colon))
            {
                TraductFromForeignKeyboard(KeyCode.Colon, false);
            }

            if (Input.GetKeyDown(KeyCode.Exclaim))
            {
                TraductFromForeignKeyboard(KeyCode.Exclaim, true);
            }
            if (Input.GetKeyUp(KeyCode.Exclaim))
            {
                TraductFromForeignKeyboard(KeyCode.Exclaim, false);
            }

            if (Input.GetKeyDown(KeyCode.Period))
            {
                TraductFromForeignKeyboard(KeyCode.Period, true);
            }
            if (Input.GetKeyUp(KeyCode.Period))
            {
                TraductFromForeignKeyboard(KeyCode.Period, false);
            }

            if (Input.GetKeyDown(KeyCode.Slash))
            {
                TraductFromForeignKeyboard(KeyCode.Slash, true);
            }
            if (Input.GetKeyUp(KeyCode.Slash))
            {
                TraductFromForeignKeyboard(KeyCode.Slash, false);
            }

            if(m_LeftFinger==-1 && m_RightFinger==-1)
            {

            }

            #endregion

           
     
        }

        #region TUTO
        if (GameState==GameStates.TUTO)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                TraductFromForeignKeyboard(KeyCode.G, true);
            }
            if (Input.GetKeyUp(KeyCode.G))
            {
                TraductFromForeignKeyboard(KeyCode.G, false);
            }



            if (m_LeftFinger == 14)
            {
                if (Input.GetKeyDown(KeyCode.H))
                {
                    TraductFromForeignKeyboard(KeyCode.H, true);
                }
                if (Input.GetKeyUp(KeyCode.H))
                {
                    TraductFromForeignKeyboard(KeyCode.H, false);
                }

                if (m_RightFinger == 15 && m_LeftFinger == 14)
                {
                    m_Tuto.SetTrigger("Close");
                    PanelTuto.SetActive(false);


                    GameState = GameStates.GAME;
                    TUTO.SetActive(false);
                    LaunchMusic();
                }

            }

        }
        #endregion
        /*
        #region SETKEYBOARD
        if(GameState==GameStates.KEYBOARD)
        {

            //
            if (Input.GetKeyDown(KeyCode.G))
            {
                TraductFromForeignKeyboard(KeyCode.G, true);
            }
            if (Input.GetKeyUp(KeyCode.G))
            {
                TraductFromForeignKeyboard(KeyCode.G, false);
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                TraductFromForeignKeyboard(KeyCode.H, true);
            }
            if (Input.GetKeyUp(KeyCode.H))
            {
                TraductFromForeignKeyboard(KeyCode.H, false);
            }
            //

            KeyBoardChoice[m_KeyboardChoiceIndex].Select();

            //Selection
            if(m_RightFinger==-1 && m_Choice==false)
            {
                m_Choice = true;



                m_KeyboardChoiceIndex++;
                if(m_KeyboardChoiceIndex>m_KeyboardChoiceMax)
                {
                    m_KeyboardChoiceIndex = m_KeyboardChoiceMin;
                }

                KeyBoardChoice[m_KeyboardChoiceIndex].Select();

            }

            if (m_RightFinger != -1)
            {
                m_Choice = false;
            }
            //Selection

            if(m_LeftFinger==-1)
            {
                switch(m_KeyboardChoiceIndex)
                {
                    case 0:
                        SetKeyBoardMode("AZERTY");
                        break;

                    case 1:
                        SetKeyBoardMode("QWERTY");
                        break;
                }

                PanelChoiceOfKeyboard.SetActive(false);
                GameState = GameStates.GAME;
                TUTO.SetActive(false);
                LaunchMusic();

            }

        }
        #endregion
    */


    }

    void TraductFromForeignKeyboard(KeyCode _key, bool _isPush)
    {

        if (KeyBoardType == TypeOfKeyBoard.AZERTY)
        {
            ChangeFingersNumberFromAZERTY(_key, _isPush);
        }

        if (KeyBoardType == TypeOfKeyBoard.QWERTY)
        {
            #region QWERTY
            switch(_key)
            {
                case KeyCode.Q:
                    ChangeFingersNumberFromAZERTY(KeyCode.A, _isPush);
                    break;

                case KeyCode.W:
                    ChangeFingersNumberFromAZERTY(KeyCode.Z, _isPush);
                    break;

                case KeyCode.E:
                    ChangeFingersNumberFromAZERTY(KeyCode.E, _isPush);
                    break;

                case KeyCode.R:
                    ChangeFingersNumberFromAZERTY(KeyCode.R, _isPush);
                    break;

                case KeyCode.T:
                    ChangeFingersNumberFromAZERTY(KeyCode.T, _isPush);
                    break;

                case KeyCode.Y:
                    ChangeFingersNumberFromAZERTY(KeyCode.Y, _isPush);
                    break;

                case KeyCode.U:
                    ChangeFingersNumberFromAZERTY(KeyCode.U, _isPush);
                    break;

                case KeyCode.I:
                    ChangeFingersNumberFromAZERTY(KeyCode.I, _isPush);
                    break;

                case KeyCode.O:
                    ChangeFingersNumberFromAZERTY(KeyCode.O, _isPush);
                    break;

                case KeyCode.P:
                    ChangeFingersNumberFromAZERTY(KeyCode.P, _isPush);
                    break;

                case KeyCode.A:
                    ChangeFingersNumberFromAZERTY(KeyCode.Q, _isPush);
                    break;

                case KeyCode.S:
                    ChangeFingersNumberFromAZERTY(KeyCode.S, _isPush);
                    break;

                case KeyCode.D:
                    ChangeFingersNumberFromAZERTY(KeyCode.D, _isPush);
                    break;

                case KeyCode.F:
                    ChangeFingersNumberFromAZERTY(KeyCode.F, _isPush);
                    break;

                case KeyCode.G:
                    ChangeFingersNumberFromAZERTY(KeyCode.G, _isPush);
                    break;

                case KeyCode.H:
                    ChangeFingersNumberFromAZERTY(KeyCode.H, _isPush);
                    break;

                case KeyCode.J:
                    ChangeFingersNumberFromAZERTY(KeyCode.J, _isPush);
                    break;

                case KeyCode.K:
                    ChangeFingersNumberFromAZERTY(KeyCode.K, _isPush);
                    break;

                case KeyCode.L:
                    ChangeFingersNumberFromAZERTY(KeyCode.L, _isPush);
                    break;

                case KeyCode.Semicolon:
                    ChangeFingersNumberFromAZERTY(KeyCode.M, _isPush);
                    break;

                case KeyCode.Z:
                    ChangeFingersNumberFromAZERTY(KeyCode.W, _isPush);
                    break;

                case KeyCode.X:
                    ChangeFingersNumberFromAZERTY(KeyCode.X, _isPush);
                    break;

                case KeyCode.C:
                    ChangeFingersNumberFromAZERTY(KeyCode.C, _isPush);
                    break;

                case KeyCode.V:
                    ChangeFingersNumberFromAZERTY(KeyCode.V, _isPush);
                    break;

                case KeyCode.B:
                    ChangeFingersNumberFromAZERTY(KeyCode.B, _isPush);
                    break;

                case KeyCode.N:
                    ChangeFingersNumberFromAZERTY(KeyCode.N, _isPush);
                    break;

                case KeyCode.M:
                    ChangeFingersNumberFromAZERTY(KeyCode.Comma, _isPush);
                    break;

                case KeyCode.Quote:
                    ChangeFingersNumberFromAZERTY(KeyCode.Period, _isPush);
                    break;

                case KeyCode.Period:
                    ChangeFingersNumberFromAZERTY(KeyCode.Slash, _isPush);
                    break;


            }
            #endregion
        }
    }

    void ChangeFingersNumberFromAZERTY(KeyCode _key, bool _isPush)
    {
      
        int _value = KeyNumeric[_key];

        m_LeftFingerMemory = m_LeftFinger;
        m_RightFingerMemory = m_RightFinger;

       

        if (_isPush)
        {
            if (m_LeftFinger == -1)
            {
                m_LeftFinger = _value;
            }
            else if (m_RightFinger == -1)
            {
                m_RightFinger = _value;
            }
        }
        else
        {
            if (m_LeftFinger == _value)
            {
                m_LeftFinger = -1;
            }
            else if (m_RightFinger == _value)
            {
                m_RightFinger = -1;
            }
        }

        
        if(m_LeftFinger!=m_LeftFingerMemory && m_LeftFinger!=-1)
        {
            m_LeftHasChanged = true;
        }
        else
        {
            m_LeftHasChanged = false;
        }

        if (m_RightFinger != m_RightFingerMemory && m_RightFinger != -1)
        {
            m_RightHasChanged = true;
        }
        else
        {
            m_RightHasChanged = false;
        }

        


    }

    void ActivateCoeur(bool _isActivate)
    {
        m_Coeur.SetActive(_isActivate);
    }

}
