using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsPlayer : MonoBehaviour
{
   public int experience,
          level,
          honor,
          astracoins,
          astradum;
    float saveGameTimer, saveGameEvery = 5;
    // Start is called before the first frame update
    void Start()
    {
        LoadFromSave();
    }

    // Update is called once per frame
    void Update()
    {
        saveGameTimer += Time.deltaTime;
        if (saveGameTimer > saveGameEvery)
        {
            SaveGame();
            saveGameTimer = 0;
        }
    }

    public void NewGame()
    {
        experience = 0;
        level = 1;
        honor = 0;
        astracoins = 0;
        astradum = 0;
        PlayerPrefs.SetInt("PExperience", experience);
        PlayerPrefs.SetInt("PLevel", level);
        PlayerPrefs.SetInt("PHonor", honor);
        PlayerPrefs.SetInt("PAstracoins", astracoins);
        PlayerPrefs.SetInt("PAstradum", astradum);
        SceneManager.LoadScene("MapA-1");
        PlayerPrefs.SetFloat("PPosX", 0);
        PlayerPrefs.SetFloat("PPosY", 0);
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("PExperience", experience);
        PlayerPrefs.SetInt("PLevel", level);
        PlayerPrefs.SetInt("PHonor", honor);
        PlayerPrefs.SetInt("PAstracoins", astracoins);
        PlayerPrefs.SetInt("PAstradum", astradum);
        PlayerPrefs.SetFloat("PPosX", transform.position.x);
        PlayerPrefs.SetFloat("PPosY", transform.position.y);
        PlayerPrefs.SetString("CurrentMap",SceneManager.GetActiveScene().name);
    }

    private void LoadFromSave()
    {
        experience = PlayerPrefs.GetInt("PExperience");
        level = PlayerPrefs.GetInt("PLevel");
        honor = PlayerPrefs.GetInt("PHonor");
        astracoins = PlayerPrefs.GetInt("PAstracoins");
        astradum = PlayerPrefs.GetInt("PAstradum");
        if (SceneManager.GetActiveScene().name != PlayerPrefs.GetString("CurrentMap"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("CurrentMap"));
        }
        transform.position = new Vector3(PlayerPrefs.GetFloat("PPosX"), PlayerPrefs.GetFloat("PPosY"), 0);
    }
}
