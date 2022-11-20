using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    public float bgspeed;
    public float spawningTime;
    private float spawnCooldown = 0;
    [SerializeField] private TextMeshProUGUI textVies;
    [SerializeField] private RunPlayerMovements player;
    [SerializeField] private GameObject box;
    private bool playing = true;
    [SerializeField] private int playTime;
    [SerializeField] private TextMeshProUGUI textTime;

    // Start is called before the first frame update
    void Start()
    {
        textVies.text = player.vies.ToString() + " vies";
        textTime.text = playTime.ToString();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if(playing)
        {
            Cooldowns();
        }
    }

    public void Cooldowns()
    {
        spawnCooldown += Time.deltaTime;
        if (spawnCooldown > 0)
        {
            spawnCooldown = -spawningTime;
            SpawnBox();
        }
    }

    public void SpawnBox()
    {
        GameObject.Instantiate(box, new Vector3(Random.Range(-7.5f, 7.5f), 7.2f, 0), Quaternion.identity);
    }

    public void OnHit()
    {
        textVies.text = player.vies.ToString() + " vies";
    }

    IEnumerator Timer()
    {
        while (playTime > 0)
        {
            yield return new WaitForSeconds(1f);
            playTime--;
            textTime.text = playTime.ToString();
        }
    }
}
