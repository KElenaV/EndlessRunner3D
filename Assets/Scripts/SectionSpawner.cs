using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    [SerializeField] private Section[] _sections;
    [SerializeField] private Mover _playerMover;

    private float _spawnDistanse = 80;
    private Queue<Section> _gameSections = new Queue<Section>();
    private int _sectionsInScene = 2;
    private int _sectionNumber = 0;

    private void Awake()
    {
        foreach (var section in _sections)
        {
            section.gameObject.SetActive(false);
        }

        for (int i = 0; i < _sectionsInScene; i++)
        {
            CreateNewSection(_sections[i]);
        }
    }

    private void OnEnable()
    {
        _playerMover.CrossedSection += OnCrossedSection;
    }

    private void OnDisable()
    {
        _playerMover.CrossedSection -= OnCrossedSection;
    }

    private void OnCrossedSection()
    {
        DeleteSection();
        
        Section section = ChooseSection();

        CreateNewSection(section);
    }

    private void CreateNewSection(Section section)
    {
        _gameSections.Enqueue(section);
        var startSection = section.gameObject;
        startSection.SetActive(true);
        startSection.transform.position = new Vector3(0, 0, _spawnDistanse * _sectionNumber++);
    }

    private void DeleteSection()
    {
        var sectionToDelete = _gameSections.Dequeue();
        sectionToDelete.gameObject.SetActive(false);
    }

    private Section ChooseSection()
    {
        Section randomSection = null;
        while (!randomSection)
        {
            int randomIndex = Random.Range(0, _sections.Length);
            if (_sections[randomIndex].gameObject.activeSelf == false)
                randomSection = _sections[randomIndex];
        }

        return randomSection;
    }
}
