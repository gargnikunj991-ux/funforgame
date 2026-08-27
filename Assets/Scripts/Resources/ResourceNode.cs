using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    [Header("Resource Settings")]
    [SerializeField] private ItemData itemData;
    [SerializeField] private int resourceAmount = 5;

    [Header("Interaction")]
    [SerializeField] private float interactionRange = 2f;

    private Transform player;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(
            transform.position,
            player.position
        );

        if (distance <= interactionRange &&
            Input.GetKeyDown(KeyCode.E))
        {
            Gather();
        }
    }

    private void Gather()
    {
        if (resourceAmount <= 0 || itemData == null)
            return;

        resourceAmount--;

        Inventory inventory = player.GetComponent<Inventory>();

        if (inventory != null)
        {
            inventory.AddItem(itemData, 1);
        }

        if (resourceAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
}