using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private enum TagType
    {
        Enemy,
        Building
    }
    private List<GameObject> tagList = new();
    [SerializeField] private TagType tagType;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tagType.ToString()))
        {
            tagList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tagType.ToString()))
        {
            tagList.Remove(other.gameObject);
        }
    }
    public List<GameObject> GetTagList()
    {
        return tagList;
    }
}
