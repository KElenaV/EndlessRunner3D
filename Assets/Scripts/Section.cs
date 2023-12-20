using UnityEngine;

public class Section : MonoBehaviour
{
    [SerializeField] private Cake[] _cakes;

    private void OnEnable()
    {
        foreach (var cake in _cakes)
        {
            cake.gameObject.SetActive(true);
        }
    }
}
