using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject PlayerPrefab;

    public List<GameObject> GibsPrefabs;

    public List<AudioClip> Music; 


    public MapSpriteMatrix MapSpriteMatrix;

    public EntityController EntityController;


    public MapScript CurrentMap;


    public GameObject Player;

    public UIScript UI;

    public AudioSource BackgroundMusic; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
            return; 
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        EntityController = GetComponent<EntityController>();
        BackgroundMusic = GetComponent<AudioSource>();

        if (Player == null)
        {
            StartCoroutine(SpawnPlayer());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnPlayer()
    {
        Player = Instantiate(PlayerPrefab);        
        DontDestroyOnLoad(Player); 
        yield return null;
        Player.transform.position = CurrentMap.PlayerSpawnLoc("Alpha");
    }


    public Camera GetCurrentCamera()
    {
        return Camera.main;
    }



    public void StartNewGame()
    {
        StartCoroutine (NewGame());
    }

    IEnumerator NewGame()
    {
        if (Player == null)
        {
            yield return SpawnPlayer(); 
        }
        yield return null;
        var attributes = Player.GetComponent<Attributes>();
        attributes.CurrentHp = attributes.MaxHP;
        attributes.Immune = false; //turn off immunity. 

        Player.GetComponent<ProjectileFire>().HasGun = false;
        Cursor.lockState = CursorLockMode.Locked;

        yield return LoadLevelCo("IntroScene", "Alpha"); 
    }



    public void LoadLevel(string levelname, string startpos)
    {
        StartCoroutine(LoadLevelCo(levelname, startpos)); 
    }


    IEnumerator LoadLevelCo(string levelname, string startpos)
    {
        SceneManager.LoadScene(levelname, LoadSceneMode.Single); 
        yield return null;
        CurrentMap = FindAnyObjectByType<MapScript>(FindObjectsInactive.Include);
        yield return null;
        Player.transform.position = CurrentMap.PlayerSpawnLoc(startpos);
        Player.GetComponent<PlayerController>().LockControls = false; //make sure the controls are not locked!
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);  //reset rotation in case it got weird. 

        //set player location here. 
        yield return null;
        UI.ShowSpeechPanel(false);
        UI.ShowBlackPanel(false);
        SetMusic(CurrentMap.Music);
        

    }


    public void GameOver()
    {       

        StartCoroutine(GameOverCo());
    }

    IEnumerator GameOverCo()
    {
        var playerattri = Player.GetComponent<Attributes>();
        playerattri.CurrentHp = 1; //make sure we're not going to be constantly triggering this. 
        playerattri.Immune = true;

        UI.ShowBlackPanel(true); 
        UI.ShowSpeech("YOU DIE!");
        yield return new WaitForSeconds(5f);
        yield return LoadLevelCo("MainMenu", "Alpha"); 
        

    }


    public void Victory()
    {
        StartCoroutine (VictoryCo());
    }

    IEnumerator VictoryCo()
    {
        UI.ShowBlackPanel(true);
        UI.ShowSpeech("You have escaped... for now.");
        yield return new WaitForSeconds(5f);
        yield return LoadLevelCo("MainMenu", "Alpha");
    }



    public void SetMusic(string song)
    {
        var clip = Music.FirstOrDefault(x => x.name == song);

        if (clip != null)
        {
            BackgroundMusic.clip = clip;
            BackgroundMusic.Play();
        }
    }

}
