using Yulinti.Nucleus.Contractus;
using System;
using UnityEngine.UIElements;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Rex {
    public enum IDCarnifexVelum {
        NOTATI,
        ERRORIS,
        INTERMISSIONIS
    }

    public class CarnifexVelum : ICarnifex {
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
        private Button _buttonExitIntermissionis;

        // UIを表示中は追加エラーを処理できない。
        // 表示中はUIが閉じるまで、追加分をCarnifexBasisで処理する。
        private readonly CarnifexBasis _carnifexBasis;

        private bool _EstDemittereNotati;
        private bool _EstDemittereErroris; 
        private bool _EstDemittereIntermissionis;

        public CarnifexVelum(IAnchoraVelumRadicis anchoraVelumRadicis, CarnifexBasis carnifexBasis) {
            _anchoraVelumRadicis = anchoraVelumRadicis;
            _carnifexBasis = carnifexBasis;
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
            _buttonExitIntermissionis = _uiIntermissionis.rootVisualElement.Q<Button>("intermissionis-button-exit");

            // すべて非表示
            _uiNotati.rootVisualElement.style.display = DisplayStyle.None;
            _uiErroris.rootVisualElement.style.display = DisplayStyle.None;
            _uiIntermissionis.rootVisualElement.style.display = DisplayStyle.None;

            _EstDemittereNotati = false;
            _EstDemittereErroris = false;
            _EstDemittereIntermissionis = false;
        }

        // まず最初にDemittere()を呼ぶこと。
        public void Notare(string textus) {
            throw new NotImplementedException();
        }

        // まず最初にDemittere()を呼ぶこと。
        public void Error(string textus) {
            throw new NotImplementedException();
        }

        // まず最初にDemittere()を呼ぶこと。
        public void Error(Exception exception) {
            throw new NotImplementedException();
        }

        // まず最初にDemittere()を呼ぶこと。
        public void Intermissio(string textus) {
            throw new NotImplementedException();
        }

        // まず最初にDemittere()を呼ぶこと。
        public void Intermissio(Exception exception) {
            throw new NotImplementedException();
        }
    }
}