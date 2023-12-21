using System.Collections;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Section[] _sections;
    [SerializeField] private int _section;

    private float _zPosition = 120;
    private float _nextPositionOffset = 40;
    private float _delay;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);

        StartCoroutine(GenerateSection());
    }

    private IEnumerator GenerateSection()
    {
        while (true)
        {
            _section = Random.Range(0, _sections.Length);
            Instantiate(_sections[_section], new Vector3(0, 0, _zPosition), Quaternion.identity);
            _zPosition += _nextPositionOffset;
            yield return _waitForSeconds;
        }
    }
}
