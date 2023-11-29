using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public AudioClip BackgroundThemeSong;
    public AudioClip JumpSound;
    public FoxBehaviour PlayerStatus;

    [SerializeField] private GameObject[] item;
    [SerializeField] private float ItemRandomBoxSize; 

    public int Score;

    [SerializeField] int RandomItemCD = 15;

    Transform Temp;

    
    private void Start()
    {

        if (PlayerStatus.HP > 0)
        {
            PlayBGMuisc();
        }
        InvokeRepeating("RandomItem", RandomItemCD, RandomItemCD);
        //RandomChunck();
    }

    private void Update()
    {
        
    }
       
    void PlayBGMuisc()
    {
        this.GetComponent<AudioSource>().PlayOneShot(BackgroundThemeSong);
    }

    public void AddScore()
    {
        Score = Score + 100;
    }

    //Game Jam part
    public void RandomItem ()
    {
        int targetItem = Random.Range(0, item.Length);

        if (item.Length != 0) 
        {
            Transform PlayerPos = PlayerStatus.transform;        
            Vector2 RandomPos = new Vector2(Random.Range(0, 18), Random.Range(PlayerPos.position.y, PlayerPos.position.y + 10));
            GameObject newItem = Instantiate(item[targetItem]) as GameObject;
            RandomInArea(newItem.transform);
            ItemScript script = newItem.AddComponent<ItemScript>();
            script.Setprefab();
        }

    }

    private void RandomInArea(Transform O)
    {
        float Xmin = PlayerStatus.transform.position.x - ItemRandomBoxSize;
        float Xmax = PlayerStatus.transform.position.x + ItemRandomBoxSize;
        float Ymin = PlayerStatus.transform.position.y - ItemRandomBoxSize;
        float Ymax = PlayerStatus.transform.position.y + ItemRandomBoxSize;
        
        O.position = new Vector2(Random.Range(Xmin, Xmax), Random.Range(Ymin, Ymax));
    }


}



