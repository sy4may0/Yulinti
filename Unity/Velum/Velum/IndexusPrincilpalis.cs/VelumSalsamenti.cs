using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using UnityEngine.UIElements;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor;

namespace Yulinti.Unity.Velum {
    internal sealed class VelumSalsamenti : IVelumSalsamenti, IVelum, IVelumLiberabilis {
        private readonly IAnchoraVelumSalsamenti _anchoraVelumSalsamenti;
        private readonly ITurrisInterpretationis _turrisInterpretationis;

        private VisualElement _containerSalsamenti;

        // ヘッダーラベル
        private Label _labelSalsamenti;

        // リストラベル
        private Label _labelManualis;
        private Label _labelAutomaticus;
        // Manualisスクロールビュー
        private ListView _listManualis;
        // Automaticusスクロールビュー
        private ListView _listAutomaticus;
        // ボタンロード
        private Button _buttonOneraLudum;
        // ボタン削除
        private Button _buttonDeletoLudum;
        // ボタンキャンセル
        private Button _buttonExi;

        private Action<Guid> _onOneraLudum;
        private Action<Guid> _onDeletoLudum;
        private Action _onExi;

        private Guid _focusGuid;

        // IReadOnlyListをListに変換するためのバッファ。
        // ListViewがIReadOnlyListをサポートしていないため。
        private List<IOstiumSalsamentiNotitiae> _bufNotitiaManualis;
        private List<IOstiumSalsamentiNotitiae> _bufNotitiaAutomaticus;

        public VelumSalsamenti(
            IAnchoraVelumSalsamenti anchoraVelumSalsamenti,
            ITurrisInterpretationis turrisInterpretationis
        ) {
            _anchoraVelumSalsamenti = anchoraVelumSalsamenti;
            _turrisInterpretationis = turrisInterpretationis;

            _bufNotitiaManualis = new List<IOstiumSalsamentiNotitiae>();
            _bufNotitiaAutomaticus = new List<IOstiumSalsamentiNotitiae>();

            _onOneraLudum = null;
            _onDeletoLudum = null;
            _onExi = null;

            _focusGuid = Guid.Empty;
        }

        public void Initare() {
            _containerSalsamenti = _anchoraVelumSalsamenti.UIDocument.rootVisualElement.Q<VisualElement>("salsamentum-root");
            _labelSalsamenti = _containerSalsamenti.Q<Label>("salsamentum-header-label");
            _labelManualis = _containerSalsamenti.Q<Label>("salsamentum-list-manualis-label");
            _labelAutomaticus = _containerSalsamenti.Q<Label>("salsamentum-list-automaticus-label");
            _listManualis = _containerSalsamenti.Q<ListView>("salsamentum-scroll-view-manualis");
            _listAutomaticus = _containerSalsamenti.Q<ListView>("salsamentum-scroll-view-automaticus");
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

            _listManualis.fixedItemHeight = 120;

            InitareListManualis();
            InitareListAutomaticus();
        }

        private void InitareListManualis() {
            _listManualis.selectionType = SelectionType.Single;

            _listManualis.makeItem = () => {
                VisualElement articulus = new VisualElement();
                _anchoraVelumSalsamenti.FormaArticulusSalsamenti.CloneTree(articulus);
                if (articulus == null) {
                    Carnifex.Intermissio(LogTextus.VelumSalsamenti_RENOVARETABEAMANUALIS_ARTICULUS_NULL);
                }
                articulus.style.display = DisplayStyle.Flex;
                articulus.focusable = true;
                articulus.tabIndex = 0;
                articulus.pickingMode = PickingMode.Position;
                return articulus;
            };

            _listManualis.bindItem = (ve, index) => {
                IOstiumSalsamentiNotitiae notitia = (IOstiumSalsamentiNotitiae)_listManualis.itemsSource[index];
                AppricareArticulus(index, notitia, "manualis", ve);
            };

            _listManualis.selectionChanged += selected => {
                bool estSelectus = false;
                foreach (var obj in selected) {
                    if (obj is IOstiumSalsamentiNotitiae notitia && notitia.Id is Guid guid) {
                        estSelectus = true;
                        _focusGuid = guid;
                        if (_focusGuid != Guid.Empty) {
                            ActivareButton(ButtonSalsamenti.OneraLudum);
                            ActivareButton(ButtonSalsamenti.DeletoLudum);
                        } else {
                            DeactivareButton(ButtonSalsamenti.OneraLudum);
                            DeactivareButton(ButtonSalsamenti.DeletoLudum);
                        }
                        break;
                    }
                }
                if (!estSelectus) {
                    _focusGuid = Guid.Empty;
                    DeactivareButton(ButtonSalsamenti.OneraLudum);
                    DeactivareButton(ButtonSalsamenti.DeletoLudum);
                }
            };
        }

        private void InitareListAutomaticus() {
            _listAutomaticus.selectionType = SelectionType.Single;

            _listAutomaticus.makeItem = () => {
                VisualElement articulus = _anchoraVelumSalsamenti.FormaArticulusSalsamenti.Instantiate();
                if (articulus == null) {
                    Carnifex.Intermissio(LogTextus.VelumSalsamenti_RENOVARETABEAAUTOMATICUS_ARTICULUS_NULL);
                }
                articulus.style.display = DisplayStyle.Flex;
                articulus.focusable = true;
                articulus.tabIndex = 0;
                articulus.pickingMode = PickingMode.Position;
                return articulus;
            };

            _listAutomaticus.bindItem = (ve, index) => {
                IOstiumSalsamentiNotitiae notitia = (IOstiumSalsamentiNotitiae)_listAutomaticus.itemsSource[index];
                AppricareArticulus(index, notitia, "automaticus", ve);
            };

            _listAutomaticus.selectionChanged += selected => {
                bool estSelectus = false;
                foreach (var obj in selected) {
                    if (obj is IOstiumSalsamentiNotitiae notitia && notitia.Id is Guid guid) {
                        estSelectus = true;
                        _focusGuid = guid;
                        if (_focusGuid != Guid.Empty) {
                            ActivareButton(ButtonSalsamenti.OneraLudum);
                            ActivareButton(ButtonSalsamenti.DeletoLudum);
                        } else {
                            DeactivareButton(ButtonSalsamenti.OneraLudum);
                            DeactivareButton(ButtonSalsamenti.DeletoLudum);
                        }
                        break;
                    }
                }
                if (!estSelectus) {
                    _focusGuid = Guid.Empty;
                    DeactivareButton(ButtonSalsamenti.OneraLudum);
                    DeactivareButton(ButtonSalsamenti.DeletoLudum);
                }
            };
        }

        public void Activare() {
            _containerSalsamenti.style.display = DisplayStyle.Flex;
        }

        public void Deactivare() {
            _containerSalsamenti.style.display = DisplayStyle.None;
        }

        public void TollereSalsamenti() {
            DeactivareButton(ButtonSalsamenti.OneraLudum);
            DeactivareButton(ButtonSalsamenti.DeletoLudum);
            DeactivareButton(ButtonSalsamenti.Exi);

            _onOneraLudum = null;
            _onDeletoLudum = null;
            _onExi = null;

            _focusGuid = Guid.Empty;
            _listManualis.ClearSelection();
            _listAutomaticus.ClearSelection();

            _listManualis.itemsSource = null;
            _listAutomaticus.itemsSource = null;

            _buttonExi.Blur();
            Deactivare();
        }

        public void DemittereSalsamenti() {
            _onOneraLudum = null;
            _onDeletoLudum = null;
            _onExi = null;

            _focusGuid = Guid.Empty;
            _listManualis.ClearSelection();
            _listAutomaticus.ClearSelection();

            _bufNotitiaManualis.Clear();
            _bufNotitiaAutomaticus.Clear();
            _listManualis.itemsSource = _bufNotitiaManualis;
            _listAutomaticus.itemsSource = _bufNotitiaAutomaticus;
            _listManualis.Rebuild();
            _listAutomaticus.Rebuild();

            DeactivareButton(ButtonSalsamenti.OneraLudum);
            DeactivareButton(ButtonSalsamenti.DeletoLudum);
            ActivareButton(ButtonSalsamenti.Exi);

            Activare();
            _buttonExi.Focus();
        }

        public void RenovareTablaeManualis(IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaManualis) {
            // IReadOnlyにした意味無くね？そうでもないか。
            _bufNotitiaManualis.Clear();
            _bufNotitiaManualis.AddRange(notitiaManualis);

            _listManualis.itemsSource = _bufNotitiaManualis;
            _listManualis.Rebuild();
        }

        public void RenovareTablaeAutomaticus(IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaAutomaticus) {
            _bufNotitiaAutomaticus.Clear();
            _bufNotitiaAutomaticus.AddRange(notitiaAutomaticus);

            _listAutomaticus.itemsSource = _bufNotitiaAutomaticus;
            _listAutomaticus.Rebuild();
        }

        // テンプレートから生成したアイテムのクラスやnameを設定する。
        private void AppricareArticulus(
            int index,
            IOstiumSalsamentiNotitiae notitia,
            string className,
            VisualElement articulus
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

            // ヘッダーに表示するテキストを設定
            label.text = _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_LIST_MANUALIS_ITEM_LABEL) + " " + index;
            timestamp.text = notitia.Timestamp.ToString("yyyy-MM-dd HH:mm:ss");

            StringBuilder infoTextus = new StringBuilder();
            infoTextus.Append(_turrisInterpretationis.LegoTextus(IDTextus.PUELLAEPERSONAE_GRADUS_LUXURIOSUS));
            infoTextus.Append(" ");
            infoTextus.Append(_turrisInterpretationis.LegoTextus(IDTextus.PUELLAEPERSONAE_GRADUS_PREFIX));
            infoTextus.Append(notitia.PuellaeNotitiae.GradusLuxuriosus.ToString());
            infoTextus.Append(" / ");
            infoTextus.Append(_turrisInterpretationis.LegoTextus(IDTextus.PUELLAEPERSONAE_GRADUS_EXHIBITUS));
            infoTextus.Append(" ");
            infoTextus.Append(_turrisInterpretationis.LegoTextus(IDTextus.PUELLAEPERSONAE_GRADUS_PREFIX));
            infoTextus.Append(notitia.PuellaeNotitiae.GradusExhibitus.ToString());
            infoTextus.Append(" / ");
            infoTextus.Append(_turrisInterpretationis.LegoTextus(IDTextus.PUELLAEPERSONAE_GRADUS_PERVERSUS));
            infoTextus.Append(" ");
            infoTextus.Append(_turrisInterpretationis.LegoTextus(IDTextus.PUELLAEPERSONAE_GRADUS_PREFIX));
            infoTextus.Append(notitia.PuellaeNotitiae.GradusPerversus.ToString());
            infoTextus.Append(" / ");
            infoTextus.Append(_turrisInterpretationis.LegoTextus(IDTextus.PUELLAEPERSONAE_GRADUS_QUAERIT_DOLOR));
            infoTextus.Append(" ");
            infoTextus.Append(_turrisInterpretationis.LegoTextus(IDTextus.PUELLAEPERSONAE_GRADUS_PREFIX));
            infoTextus.Append(notitia.PuellaeNotitiae.GradusQuaeritDolore.ToString());
            info.text = infoTextus.ToString();

            // GUIDをカードに設定
            articulus.userData = notitia.Id;
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

        public void DeactivareButton(ButtonSalsamenti buttonSalsamenti) {
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
            if (_focusGuid == Guid.Empty) {
                // [TODO] エラーメッセージを画面に表示する。
                return;
            }
            _onOneraLudum?.Invoke(_focusGuid);
        }

        public void AdPremereDeletoLudum(Action<Guid> ae) {
            _onDeletoLudum = ae;
        }

        private void premereDeletoLudum() {
            // ここでフォーカスGuidを取得して、_onDeletoLudumを呼び出す。
            if (_focusGuid == Guid.Empty) {
                // [TODO] エラーメッセージを画面に表示する。
                return;
            }
            _onDeletoLudum?.Invoke(_focusGuid);
        }

        public void AdPremereExi(Action ae) {
            _onExi = ae;
        }

        private void premereExi() {
            _onExi?.Invoke();
        }

        public void Liberare() {
            TollereSalsamenti();
        }
    }
}
