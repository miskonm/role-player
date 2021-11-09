using RolePlayer.Data;
using RolePlayer.SaveLoad;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace RolePlayer.Example
{
  public class ExampleView : MonoBehaviour, ISaveLoadProgress
  {
    public TextMeshProUGUI NumberLabel;
    public Button AddButton;
    public Button SubButton;
    public Button SaveButton;

    private ISaveLoadService _saveLoadService;

    private int _number;

    [Inject]
    public void Construct(ISaveLoadService saveLoadService)
    {
      _saveLoadService = saveLoadService;
    }

    private void Awake()
    {
      AddButton.onClick.AddListener(Add);
      SubButton.onClick.AddListener(Sub);
      SaveButton.onClick.AddListener(SaveToService);
    }

    private void Update()
    {
      NumberLabel.text = _number.ToString();
    }

    public void Load(ProgressData data) =>
      _number = data.ExampleData.Number;

    public void Save(ProgressData data) =>
      data.ExampleData.Number = _number;

    private void Add() =>
      _number++;

    private void Sub() =>
      _number--;

    private void SaveToService() =>
      _saveLoadService.Save();
  }
}
