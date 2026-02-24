using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using UnityEngine.UIElements;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Unity.Velum {
    internal sealed class VelumSalsamenti : IVelumSalsamenti, IVelum, IVelumIncipabilis, IVelumLiberabilis {
        private readonly IAnchoraVelumSalsamenti _anchoraVelumSalsamenti;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ITurrisSalsamentiLegibile _turrisSalsamentiLegibile;
        private readonly CancellationTokenSource _cancellationTokenSource;

        private IReadOnlyList<IOstiumSalsamentiNotitiae> _notitiaManualis;
        private IReadOnlyList<IOstiumSalsamentiNotitiae> _notitiaAutomaticus;

        private VisualElement _containerSalsamenti;

        // ヘッダーラベル
        private Label _labelSalsamenti;

        // リストラベル
        private Label _labelManualis;
        private Label _labelAutomaticus;
        // Manualisスクロールビュー
        private ScrollView _scrollManualis;
        // Automaticusスクロールビュー
        private ScrollView _scrollAutomaticus;
        // ボタンロード
        private Button _buttonOneraLudum;
        // ボタン削除
        private Button _buttonDeletoLudum;
        // ボタンキャンセル
        private Button _buttonExi;

        private Action<Guid> _onOneraLudum;
        private Action<Guid> _onDeletoLudum;
        private Action _onExi;

        public VelumSalsamenti(
            IAnchoraVelumSalsamenti anchoraVelumSalsamenti,
            ITurrisInterpretationis turrisInterpretationis,
            ITurrisSalsamentiLegibile turrisSalsamentiLegibile
        ) {
            _anchoraVelumSalsamenti = anchoraVelumSalsamenti;
            _turrisInterpretationis = turrisInterpretationis;
            _turrisSalsamentiLegibile = turrisSalsamentiLegibile;

            _cancellationTokenSource = new CancellationTokenSource();

            _onOneraLudum = null;
            _onDeletoLudum = null;
            _onExi = null;
        }

        public void Initare() {
            _containerSalsamenti = _anchoraVelumSalsamenti.UIDocument.rootVisualElement.Q<VisualElement>("salsamentum-root");
            _labelSalsamenti = _containerSalsamenti.Q<Label>("salsamentum-header-label");
            _labelManualis = _containerSalsamenti.Q<Label>("salsamentum-list-manualis-label");
            _labelAutomaticus = _containerSalsamenti.Q<Label>("salsamentum-list-automaticus-label");
            _scrollManualis = _containerSalsamenti.Q<ScrollView>("salsamentum-scroll-view-manualis");
            _scrollAutomaticus = _containerSalsamenti.Q<ScrollView>("salsamentum-scroll-view-automaticus");
            _buttonOneraLudum = _containerSalsamenti.Q<Button>("salsamentum-button-onera-ludum");
            _buttonDeletoLudum = _containerSalsamenti.Q<Button>("salsamentum-button-deleto-ludum");
            _buttonExi = _containerSalsamenti.Q<Button>("salsamentum-button-exi");

            _labelSalsamenti.text = _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_HEADER_LABEL);
            _labelManualis.text = _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_LIST_MANUALIS_LABEL);
            _labelAutomaticus.text = _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_LIST_AUTOMATICUS_LABEL);
            _buttonOneraLudum.text = _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_BUTTON_ONERA_LUDUM);
            _buttonDeletoLudum.text = _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_BUTTON_DELETO_LUDUM);
            _buttonExi.text = _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_BUTTON_CANCEL);

            _buttonOneraLudum.clicked += premereOneraLudum;
            _buttonDeletoLudum.clicked += premereDeletoLudum;
            _buttonExi.clicked += premereExi;
        }

        public void Incipere() {
            Initare();
            Deactivare();
        }

        public void Activare() {
            _containerSalsamenti.style.display = DisplayStyle.Flex;
        }

        public void Deactivare() {
            _containerSalsamenti.style.display = DisplayStyle.None;
        }

        public void TollereSalsamenti() {
            Deactivare();
        }

        public void DemittereSalsamenti() {
            Activare();
        }

        public void RenovareTablaeManualis(IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaManualis) {
            VisualElement articulus = _anchoraVelumSalsamenti.FormaArticulusSalsamenti.CloneTree();
            if (articulus == null) {
                return;
            }

            for (int i = 0; i < notitiaManualis.Count; i++) {
                AppricareArticulus(notitiaManualis[i], "manualis", articulus);
                articulus.style.display = DisplayStyle.Flex;
                _scrollManualis.Add(articulus);
            }
        }

        public void RenovareTablaeAutomaticus(IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaAutomaticus) {
            VisualElement articulus = _anchoraVelumSalsamenti.FormaArticulusSalsamenti.CloneTree();
            if (articulus == null) {
                return;
            }

            for (int i = 0; i < notitiaAutomaticus.Count; i++) {
                AppricareArticulus(notitiaAutomaticus[i], "automaticus", articulus);
                articulus.style.display = DisplayStyle.Flex;
                _scrollAutomaticus.Add(articulus);
            }
        }

        // テンプレートから生成したアイテムのクラスやnameを設定する。
        private void AppricareArticulus(
            IOstiumSalsamentiNotitiae notitia,
            string className, VisualElement articulus
        ) {
            VisualElement header = articulus.Q<VisualElement>("forma-salsamentum-item-header");
            Label label = header.Q<Label>("forma-salsamentum-item-label");
            Label timestamp = header.Q<Label>("forma-salsamentum-item-timestamp");
            VisualElement divider = articulus.Q<VisualElement>("forma-salsamentum-item-divider");
            Label info = articulus.Q<Label>("forma-salsamentum-item-info");

            //　すべてにクラス名を付加
            articulus.AddToClassList(className);
            header.AddToClassList(className);
            label.AddToClassList(className);
            timestamp.AddToClassList(className);
            divider.AddToClassList(className);
            info.AddToClassList(className);

            // [TODO] 各種値を適用
        }

        public void ActivareButton(ButtonSalsamenti buttonSalsamenti) {
            switch (buttonSalsamenti) {
                case ButtonSalsamenti.OneraLudum:
                    _buttonOneraLudum.SetEnabled(true);
                    break;
                case ButtonSalsamenti.DeletoLudum:
                    _buttonDeletoLudum.SetEnabled(true);
                    break;
                case ButtonSalsamenti.Exi:
                    _buttonExi.SetEnabled(true);
                    break;
            }
        }

        public void DeactivateButton(ButtonSalsamenti buttonSalsamenti) {
            switch (buttonSalsamenti) {
                case ButtonSalsamenti.OneraLudum:
                    _buttonOneraLudum.SetEnabled(false);
                    break;
                case ButtonSalsamenti.DeletoLudum:
                    _buttonDeletoLudum.SetEnabled(false);
                    break;
                case ButtonSalsamenti.Exi:
                    _buttonExi.SetEnabled(false);
                    break;
            }
        }

        public void AdPremereOneraLudum(Action<Guid> ae) {
            _onOneraLudum = ae;
        }

        private void premereOneraLudum() {
            // ここでフォーカスGuidを取得して、_onOneraLudumを呼び出す。
            // 仮作成
            Guid guid = Guid.NewGuid();
            _onOneraLudum?.Invoke(guid);
        }

        public void AdPremereDeletoLudum(Action<Guid> ae) {
            _onDeletoLudum = ae;
        }

        private void premereDeletoLudum() {
            // ここでフォーカスGuidを取得して、_onDeletoLudumを呼び出す。
            // 仮作成
            Guid guid = Guid.NewGuid();
            _onDeletoLudum?.Invoke(guid);
        }

        public void AdPremereExi(Action ae) {
            _onExi = ae;
        }

        private void premereExi() {
            _onExi?.Invoke();
        }

        public void Liberare() {
            _cancellationTokenSource.Cancel();
            _onOneraLudum = null;
            _onDeletoLudum = null;
            _onExi = null;
            Deactivare();
        }
    }
}