using Yulinti.Nucleus.Contractus;
using System;
using UnityEngine.UIElements;
using Yulinti.Unity.Contractus;
using UnityEngine;

namespace Yulinti.Regnum.Rex {
    public class CarnifexVelum {
        private readonly IAnchoraVelumRadicis _anchoraVelumRadicis;

        private UIDocument _uiNotati;
        private UIDocument _uiErroris;
        private UIDocument _uiIntermissionis;

        private Label _labelNotati; 

        private Label _labelErroris;
        private TextField _textareaErroris;
        private Label _labelContentErroris;
        private Button _buttonCopyErroris;
        private Button _buttonOKErroris;

        private Label _labelIntermissionis;
        private TextField _textareaIntermissionis;
        private Label _labelContentIntermissionis;
        private Button _buttonCopyIntermissionis;
        private Button _buttonExiIntermissionis;

        private bool _EstDemittereNotati;
        private bool _EstDemittereErroris; 
        private bool _EstDemittereIntermissionis;

        // Start済みか
        private bool _EstActivum;

        public bool EstActivum => _EstActivum;

        public CarnifexVelum(IAnchoraVelumRadicis anchoraVelumRadicis) {
            _anchoraVelumRadicis = anchoraVelumRadicis;
            _EstActivum = false;
        }

        // RexRadicisのStart()で呼び出す
        public void Initare() {
            _uiNotati = _anchoraVelumRadicis.UINotati;
            _uiErroris = _anchoraVelumRadicis.UIErroris;
            _uiIntermissionis = _anchoraVelumRadicis.UIIntermissionis;

            _labelNotati = _uiNotati.rootVisualElement.Q<Label>("notati-label");
            _labelErroris = _uiErroris.rootVisualElement.Q<Label>("erroris-label");
            _textareaErroris = _uiErroris.rootVisualElement.Q<TextField>("erroris-textarea");
            _labelContentErroris = _uiErroris.rootVisualElement.Q<Label>("erroris-content-label");
            _buttonCopyErroris = _uiErroris.rootVisualElement.Q<Button>("erroris-button-copy");
            _buttonOKErroris = _uiErroris.rootVisualElement.Q<Button>("erroris-button-ok");

            _labelIntermissionis = _uiIntermissionis.rootVisualElement.Q<Label>("intermissionis-label");
            _textareaIntermissionis = _uiIntermissionis.rootVisualElement.Q<TextField>("intermissionis-textarea");
            _labelContentIntermissionis = _uiIntermissionis.rootVisualElement.Q<Label>("intermissionis-content-label");
            _buttonCopyIntermissionis = _uiIntermissionis.rootVisualElement.Q<Button>("intermissionis-button-copy");
            _buttonExiIntermissionis = _uiIntermissionis.rootVisualElement.Q<Button>("intermissionis-button-exi");

            //[TODO]UIの固定文字列とかをここで設定するように。
            _textareaErroris.multiline = true;
            _textareaErroris.isReadOnly = true;
            _textareaErroris.style.whiteSpace = WhiteSpace.PreWrap;
            _textareaErroris.verticalScrollerVisibility = ScrollerVisibility.Auto;
            
            _textareaIntermissionis.multiline = true;
            _textareaIntermissionis.isReadOnly = true;
            _textareaIntermissionis.style.whiteSpace = WhiteSpace.PreWrap;
            _textareaIntermissionis.verticalScrollerVisibility = ScrollerVisibility.Auto;

            // すべて非表示
            _uiNotati.rootVisualElement.style.display = DisplayStyle.None;
            _uiErroris.rootVisualElement.style.display = DisplayStyle.None;
            _uiIntermissionis.rootVisualElement.style.display = DisplayStyle.None;

            _EstDemittereNotati = false;
            _EstDemittereErroris = false;
            _EstDemittereIntermissionis = false;

            // Erroris/Intermissionisはセルフで閉じる。
            _buttonOKErroris.clicked += TollereErroris;
            _buttonExiIntermissionis.clicked += TollereIntermissionis;

            // コピーも内部で処理する。
            _buttonCopyErroris.clicked += () => {
                GUIUtility.systemCopyBuffer = _textareaErroris.value ?? string.Empty;
            };
            _buttonCopyIntermissionis.clicked += () => {
                GUIUtility.systemCopyBuffer = _textareaIntermissionis.value ?? string.Empty;
            };

            _EstActivum = true;
        }

        public bool EstDemittereNotati() {
            return _EstDemittereNotati;
        }

        public bool EstDemittereErroris() {
            return _EstDemittereErroris;
        }

        public bool EstDemittereIntermissionis() {
            return _EstDemittereIntermissionis;
        }

        public void DemittereNotati(string textus) {
            _EstDemittereNotati = true;
            _uiNotati.rootVisualElement.style.display = DisplayStyle.Flex;
            _labelNotati.text = textus;
        }

        public void TollereNotati() {
            _uiNotati.rootVisualElement.style.display = DisplayStyle.None;
            _EstDemittereNotati = false;
        }

        public void DemittereErroris(string textus) {
            _EstDemittereErroris = true;
            _uiErroris.rootVisualElement.style.display = DisplayStyle.Flex;
            _textareaErroris.value = textus;
        }

        public void DemittereErroris(Exception exception) {
            _EstDemittereErroris = true;
            _uiErroris.rootVisualElement.style.display = DisplayStyle.Flex;
            _textareaErroris.value = exception.ToString();
        }

        public void TollereErroris() {
            _uiErroris.rootVisualElement.style.display = DisplayStyle.None;
            _EstDemittereErroris = false;
        }

        public void DemittereIntermissionis(string textus) {
            _EstDemittereIntermissionis = true;
            _uiIntermissionis.rootVisualElement.style.display = DisplayStyle.Flex;
            _textareaIntermissionis.value = textus;
        }

        public void DemittereIntermissionis(Exception exception) {
            _EstDemittereIntermissionis = true;
            _uiIntermissionis.rootVisualElement.style.display = DisplayStyle.Flex;
            _textareaIntermissionis.value = exception.ToString();
        }

        public void TollereIntermissionis() {
            _uiIntermissionis.rootVisualElement.style.display = DisplayStyle.None;
            _EstDemittereIntermissionis = false;
        }
    }
}