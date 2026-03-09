using System;
using UnityEngine.UIElements;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Velum {
    internal class ApplicatorSoniVeli {
        public const string C_Submittere = "sonus-c-submittere";
        public const string C_SubmittereAdditum = "sonus-c-submittere-additum";
        public const string C_Exire = "sonus-c-exire";
        public const string C_Supervolare = "sonus-f-supervolare";
        public const string C_SiNon = "sonus-c-si-non";
        public const string C_Cursor = "sonus-t-cursor";

        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private Action _sonareSubmittere;
        private Action _sonareSubmittereAdditum;
        private Action _sonareExire;
        private EventCallback<FocusInEvent> _sonareSupervolare;
        private EventCallback<ChangeEvent<bool>> _sonareSiNon;
        private EventCallback<ChangeEvent<float>> _sonareCursor;

        public ApplicatorSoniVeli(ITurrisSoniVeli turrisSoniVeli) {
            _turrisSoniVeli = turrisSoniVeli;

            _sonareSubmittere = SonareSubmittere;
            _sonareSubmittereAdditum = SonareSubmittereAdditum;
            _sonareExire = SonareExire;
            _sonareSupervolare = SonareSupervolare;
            _sonareSiNon = SonareSiNon;
            _sonareCursor = SonareCursor;
        }

        private void SonareSubmittere() {
            _turrisSoniVeli.Sonare(IDSonusVeli.Submittere);
        }
        private void SonareSubmittereAdditum() {
            _turrisSoniVeli.Sonare(IDSonusVeli.SubmittereAdditum);
        }
        private void SonareExire() {
            _turrisSoniVeli.Sonare(IDSonusVeli.Exire);
        }
        private void SonareSupervolare(FocusInEvent e) {
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
                        ve.RegisterCallback<FocusInEvent>(_sonareSupervolare);
                }
        
                if (ve is Toggle toggle) {
                    if (toggle.ClassListContains(C_SiNon))
                        toggle.RegisterValueChangedCallback(_sonareSiNon);
                }
        
                if (ve is Slider slider) {
                    if (slider.ClassListContains(C_Cursor))
                        slider.RegisterValueChangedCallback(_sonareCursor);
                }
            }
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
                        ve.UnregisterCallback<FocusInEvent>(_sonareSupervolare);
                }
                if (ve is Toggle toggle) {
                    if (toggle.ClassListContains(C_SiNon))
                        toggle.UnregisterValueChangedCallback(_sonareSiNon);
                }
                if (ve is Slider slider) {
                    if (slider.ClassListContains(C_Cursor))
                        slider.UnregisterValueChangedCallback(_sonareCursor);
                }
            }
        }
    }
}