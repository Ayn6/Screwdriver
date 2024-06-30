using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialDialog : MonoBehaviour
{
    [Header("Диалог")]
    [SerializeField] private string _name;
    [SerializeField] private List<string> _words;
    [Header("Текстовые поля")]
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private TextMeshProUGUI _textField;
    [Header("Анимация")]
    [SerializeField] private Animator _animator;

    private int index;

    private void Start()
    {
        if (_name != null && _words.Count > 0)
        {
            _nameField.text = _name;
            _textField.text = _words[0];
            index = 0;
        }
    }

    public void Next()
    {
        if ( (index + 1) >= _words.Count)
            _animator.SetTrigger("Close");
        else
        {
            index++;
            _textField.text = _words[index];
        }
    }
}
