using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _speakerName;
    [SerializeField]
    private TextMeshProUGUI _dialogue;

    [SerializeField]
    private GameObject _speakerOneUI;
    [SerializeField]
    private GameObject _speakerTwoUI;

    [SerializeField]
    private GameObject _canvas;

    [SerializeField]
    private float _transitionTime;

    private Animator _speakerOneAnimator;
    private Animator _speakerTwoAnimator;

    private Animator _dialogueBoxAnimator;

    private Image _speakerOneImage;
    private Image _speakerTwoImage;

    private DialogueLine _currentDialogueLine;

    private int _dialogueLineIndex;
    private bool? _previousSpeakerWasSpeakerOne;

    private Conversation _currentConversation;
    private Coroutine _typing;

    private static DialogueManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_canvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ReadNext();
            }
        }
    }

    public static void StartConversation(Conversation conversation)
    {
        instance._dialogueLineIndex = 0;
        instance._currentConversation = conversation;
        instance._currentDialogueLine = conversation.GetLineByIndex(0);
        instance.SetupDialogueBoxAnimator();
        instance.SetupSpeakers();
        instance.WaitForInitialAnimationsAndPlayFirstLine();
    }

    private void SetupDialogueBoxAnimator()
    {
        _dialogueBoxAnimator = GetComponent<Animator>();
    }

    private void SetupSpeakers()
    {
        SetupImages();
        StartCoroutine(SetupSpeakerAnimatorAndPlayInitialAnimationsNew());
        SetSpeakerName("");
        SetDialogueText("");
    }

    private void SetupImages()
    {
        _speakerOneImage = _speakerOneUI.GetComponent<Image>();
        _speakerTwoImage = _speakerTwoUI.GetComponent<Image>();
    }

    private IEnumerator SetupSpeakerAnimatorAndPlayInitialAnimationsNew()
    {
        _speakerOneAnimator = _speakerOneUI.GetComponent<Animator>();
        _speakerOneAnimator.runtimeAnimatorController = _currentConversation._speakerOne.getSpeakerObject().GetComponent<Animator>().runtimeAnimatorController;

        _speakerTwoAnimator = _speakerTwoUI.GetComponent<Animator>();
        _speakerTwoAnimator.runtimeAnimatorController = _currentConversation._speakerTwo.getSpeakerObject().GetComponent<Animator>().runtimeAnimatorController;

        _speakerOneAnimator.Play("ScaleUp");
        _speakerTwoAnimator.Play("ScaleUp");

        yield return new WaitForSecondsRealtime(_transitionTime);
        GetSpeakerAnimator(false).Play("Darken");
    }

    private void WaitForInitialAnimationsAndPlayFirstLine()
    {
        StartCoroutine(WaitForInitialAnimationsAndPlayFirstLineCoroutine());
    }

    private IEnumerator WaitForInitialAnimationsAndPlayFirstLineCoroutine()
    {
        yield return new WaitForSecondsRealtime(_transitionTime);
        ReadNext();
    }

    public void ReadNext()
    {
        if (_dialogueLineIndex >= _currentConversation.GetLength())
        {
            StartCoroutine(CloseDialogueBoxCoroutine());
            return;
        }

        _currentDialogueLine = _currentConversation.GetLineByIndex(_dialogueLineIndex);

        var currentSpeaker = GetSpeaker(true);

        SetSpeakerName(currentSpeaker.getSpeakerName());

        SetDialogueTextAndIncrementIndex(_currentDialogueLine.dialogue);

        PlayAnimations(_currentDialogueLine);

        _previousSpeakerWasSpeakerOne = _currentDialogueLine.isSpeakerOne;
    }

    private IEnumerator CloseDialogueBoxCoroutine()
    {
        PlayClosingAnimations();
        yield return new WaitForSecondsRealtime(_transitionTime);
        ResetImages();
        _canvas.SetActive(false);
        Time.timeScale = 1;
        _previousSpeakerWasSpeakerOne = null;
    }

    private void ResetImages()
    {
        _speakerOneImage.color = new Color(1, 1, 1, 1);
        _speakerTwoImage.color = new Color(1, 1, 1, 1);
        _speakerOneUI.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        _speakerTwoUI.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    private void PlayClosingAnimations()
    {
        _dialogueBoxAnimator.Play("MoveOut");
        _speakerOneAnimator.Play("ScaleDown");
        _speakerTwoAnimator.Play("ScaleDown");
    }

    private void SetDialogueTextAndIncrementIndex(string text)
    {
        if (_typing == null)
        {
            _typing = StartCoroutine(TypeTextAndIncrementIndex(text));
        }
        else
        {
            FinishLineAndIncrementIndex(text);
        }
    }

    private IEnumerator TypeTextAndIncrementIndex(string text)
    {
        SetDialogueText("");
        var complete = false;
        var textIndex = 0;

        while (!complete)
        {
            _dialogue.text += text[textIndex];
            textIndex++;

            if (textIndex == text.Length)
            {
                complete = true;
            }

            yield return new WaitForSecondsRealtime(0.02f);
        }

        _typing = null;
        _dialogueLineIndex++;
    }

    private void FinishLineAndIncrementIndex(string text)
    {
        StopCoroutine(_typing);
        _typing = null;
        SetDialogueText(text);
        _dialogueLineIndex++;
    }

    private void PlayAnimations(DialogueLine dialogueLine)
    {
        StartCoroutine(PlayAnimationsCoroutine(dialogueLine));
    }

    private IEnumerator PlayAnimationsCoroutine(DialogueLine dialogueLine)
    {
        if (!_previousSpeakerWasSpeakerOne == dialogueLine.isSpeakerOne)
        {
            GetSpeakerAnimator(true).Play("Brighten");
            GetSpeakerAnimator(false).Play("Darken");
            yield return new WaitForSecondsRealtime(_transitionTime);
        }

        if (dialogueLine.animation != null)
        {
            var animationClipName = dialogueLine.animation.ToString().Split()[0];
            GetSpeakerAnimator(true).Play(animationClipName);
        }
    }

    private Speaker GetSpeaker(bool isCurrent)
    {
        if (isCurrent)
        {
            return _currentDialogueLine.isSpeakerOne ? _currentConversation._speakerOne : _currentConversation._speakerTwo;
        }
        else
        {
            return _currentDialogueLine.isSpeakerOne ? _currentConversation._speakerTwo : _currentConversation._speakerOne;
        }
    }

    private Animator GetSpeakerAnimator(bool isCurrent)
    {
        if (isCurrent)
        {
            return _currentDialogueLine.isSpeakerOne ? _speakerOneAnimator : _speakerTwoAnimator;
        }
        else
        {
            return _currentDialogueLine.isSpeakerOne ? _speakerTwoAnimator : _speakerOneAnimator;
        }
    }

    private void SetSpeakerName(string text)
    {
        _speakerName.text = text;
    }

    private void SetDialogueText(string text)
    {
        _dialogue.text = text;
    }
}
