using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Inventory inv;
    public Text scoreText;
    public Text weightText;
    public GameObject item;

    private int _totalScore;
    private int totalScore
    {
        set { _totalScore = value;
            scoreText.text = "Score: " + _totalScore;
        }
    }

    private int _totalWeight;
    private int totalWeight
    {
        set
        { _totalWeight = value;
            weightText.text = "Weight: " + _totalWeight;
        }
    }

    private System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inv = new Inventory();
        SpawnItem(4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        if (Input.GetKey("w"))
        {
            transform.Translate(0, 0, 10 * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0, 0, -10 * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(-10 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(10 * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            inv.StoreItemData(collision.gameObject.GetComponent<ItemBehaviour>().score, collision.gameObject.GetComponent<ItemBehaviour>().weight);

            totalScore = inv.inventory.Sum(i => i.score);
            totalWeight = inv.inventory.Sum(i => i.weight);

            Destroy(collision.gameObject);

            SpawnItem(1);
        }
    }

    private void SpawnItem(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(item, new Vector3(rnd.Next(90, 120), 3, rnd.Next(430, 470)), Quaternion.identity);
        }
    }
}
