using System;
using UnityEngine.UIElements;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;
using System.Collections.Generic;

namespace Yulinti.Unity.Velum {
    internal class ApplicatorSoniVeli {
        public const string C_Submittere = "sonus-c-submittere";
        public const string C_SubmittereAdditum = "sonus-c-submittere-additum";
        public const string C_Exire = "sonus-c-exire";
        public const string C_Supervolare = "sonus-f-supervolare";
        public const string C_SiNon = "sonus-c-si-non";
        public const string C_Cursor = "sonus-t-cursor";
        public const string C_SupervolareList = "sonus-f-supervolare-list";

        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private Action _sonareSubmittere;
        private Action _sonareSubmittereAdditum;
        private Action _sonareExire;
        private EventCallback<FocusEvent> _sonareSupervolare;
        private EventCallback<ChangeEvent<bool>> _sonareSiNon;
        private EventCallback<ChangeEvent<float>> _sonareCursor;
        private Action<IEnumerable<object>> _sonareSupervolareList;
        private EventCallback<NavigationMoveEvent> _sonareSupervolareNav;

        public ApplicatorSoniVeli(ITurrisSoniVeli turrisSoniVeli) {
            _turrisSoniVeli = turrisSoniVeli;

            _sonareSubmittere = SonareSubmittere;
            _sonareSubmittereAdditum = SonareSubmittereAdditum;
            _sonareExire = SonareExire;
            _sonareSupervolare = SonareSupervolare;
            _sonareSiNon = SonareSiNon;
            _sonareCursor = SonareCursor;
            _sonareSupervolareList = SonareSupervolareList;
            _sonareSupervolareNav = SonareSupervolareNav;
        }

        private void SonareSubmittere() {
            int framecount = UnityEngine.Time.frameCount;
            UnityEngine.Debug.Log($"SonareSubmittere: {framecount}");
            _turrisSoniVeli.Sonare(IDSonusVeli.Submittere);
        }
        private void SonareSubmittereAdditum() {
            _turrisSoniVeli.Sonare(IDSonusVeli.SubmittereAdditum);
        }
        private void SonareExire() {
            _turrisSoniVeli.Sonare(IDSonusVeli.Exire);
        }
        private void SonareSupervolare(FocusEvent e) {
            int framecount = UnityEngine.Time.frameCount;
            UnityEngine.Debug.Log($"SonareSupervolare: {framecount}");
            _turrisSoniVeli.Sonare(IDSonusVeli.Supervolare);
        }
        private void SonareSiNon(ChangeEvent<bool> e) {
            bool EstSi = e.newValue;
            if (EstSi) {
                _turrisSoniVeli.Sonare(IDSonusVeli.Activare);
            } else {
                _turrisSoniVeli.Sonare(IDSonusVeli.Deactivare);
            }
        }
        private void SonareCursor(ChangeEvent<float> e) {
            _turrisSoniVeli.Sonare(IDSonusVeli.Cursor);
        }
        private void SonareSupervolareList(IEnumerable<object> _) {
            _turrisSoniVeli.Sonare(IDSonusVeli.Supervolare);
        }

        private void SonareSupervolareNav(NavigationMoveEvent e) {
            _turrisSoniVeli.Sonare(IDSonusVeli.Supervolare);
        }

        public void ApplicareRadix(UIDocument uiDocument) {
            uiDocument.rootVisualElement.RegisterCallback<NavigationMoveEvent>(_sonareSupervolareNav);
        }

        // UI要素で、特定のクラスを持っている要素に、SEを適用する。
        // 重いからVelum初期化以外で使うな。
        public void Applicare(VisualElement root) {
            foreach (var ve in root.Query<VisualElement>().ToList()) {
                if (ve is Button button) {
                    if (button.ClassListContains(C_Submittere))
                        button.clicked += _sonareSubmittere;
        
                    if (button.ClassListContains(C_SubmittereAdditum))
                        button.clicked += _sonareSubmittereAdditum;
        
                    if (button.ClassListContains(C_Exire))
                        button.clicked += _sonareExire;
                }
                if (ve.focusable) {
                    if (ve.ClassListContains(C_Supervolare))
                        ve.RegisterCallback<FocusEvent>(_sonareSupervolare);
                }
        
                if (ve is Toggle toggle) {
                    if (toggle.ClassListContains(C_SiNon))
                        toggle.RegisterValueChangedCallback(_sonareSiNon);
                }
        
                if (ve is Slider slider) {
                    if (slider.ClassListContains(C_Cursor))
                        slider.RegisterValueChangedCallback(_sonareCursor);
                }

                if (ve is ListView listView) {
                    if (listView.ClassListContains(C_SupervolareList))
                        listView.selectionChanged += _sonareSupervolareList;
                }
            }
        }

        public void PurgereRadix(UIDocument uiDocument) {
            uiDocument.rootVisualElement.UnregisterCallback<NavigationMoveEvent>(_sonareSupervolareNav);
        }

        public void Purgere(VisualElement root) {
            foreach (var ve in root.Query<VisualElement>().ToList()) {
                if (ve is Button button) {
                    if (button.ClassListContains(C_Submittere))
                        button.clicked -= _sonareSubmittere;
                    if (button.ClassListContains(C_SubmittereAdditum))
                        button.clicked -= _sonareSubmittereAdditum;
                    if (button.ClassListContains(C_Exire))
                        button.clicked -= _sonareExire;
                }
                if (ve.focusable) {
                    if (ve.ClassListContains(C_Supervolare))
                        ve.UnregisterCallback<FocusEvent>(_sonareSupervolare);
                }
                if (ve is Toggle toggle) {
                    if (toggle.ClassListContains(C_SiNon))
                        toggle.UnregisterValueChangedCallback(_sonareSiNon);
                }
                if (ve is Slider slider) {
                    if (slider.ClassListContains(C_Cursor))
                        slider.UnregisterValueChangedCallback(_sonareCursor);
                }
                if (ve is ListView listView) {
                    if (listView.ClassListContains(C_SupervolareList))
                        listView.selectionChanged -= _sonareSupervolareList;
                }
            }
        }
    }
}