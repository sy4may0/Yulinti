using UnityEngine;
using System;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeResVisae {
        private readonly IAnchoraPuellae anchoraPuellae;

        private readonly Transform[] _resVisaeCapitis;
        private readonly Transform[] _resVisaePectoris;
        private readonly Transform[] _resVisaeNatium;
        private bool _estActivumCapitis;
        private bool _estActivumPectoris;
        private bool _estActivumNatium;

        public MinisteriumPuellaeResVisae(IAnchoraPuellae anchoraPuellae) {
            this.anchoraPuellae = anchoraPuellae;

            int longitudoCapitis = Enum.GetValues(typeof(IDPuellaeResVisaeCapitis)).Length;
            int longitudoPectoris = Enum.GetValues(typeof(IDPuellaeResVisaePectoris)).Length;
            int longitudoNatium = Enum.GetValues(typeof(IDPuellaeResVisaeNatium)).Length;
            _resVisaeCapitis = new Transform[longitudoCapitis];
            _resVisaePectoris = new Transform[longitudoPectoris];
            _resVisaeNatium = new Transform[longitudoNatium];

            _resVisaeCapitis[(int)IDPuellaeResVisaeCapitis.Dexter] = anchoraPuellae.ResVisaeCapitisDexter;
            _resVisaeCapitis[(int)IDPuellaeResVisaeCapitis.Sinister] = anchoraPuellae.ResVisaeCapitisSinister;
            _resVisaePectoris[(int)IDPuellaeResVisaePectoris.Dexter] = anchoraPuellae.ResVisaePectorisDexter;
            _resVisaePectoris[(int)IDPuellaeResVisaePectoris.Sinister] = anchoraPuellae.ResVisaePectorisSinister;
            _resVisaeNatium[(int)IDPuellaeResVisaeNatium.Dexter] = anchoraPuellae.ResVisaeNatiumDexter;
            _resVisaeNatium[(int)IDPuellaeResVisaeNatium.Sinister] = anchoraPuellae.ResVisaeNatiumSinister;

            // validate
            for (int i = 0; i < longitudoCapitis; i++) {
                if (_resVisaeCapitis[i] == null) {
                    Errorum.Fatal(IDErrorum.MINISTERIUMPUELLAE_UNINITIALIZED_RESVISAE_CAPITIS);
                    return;
                }
            }
            for (int i = 0; i < longitudoPectoris; i++) {
                if (_resVisaePectoris[i] == null) {
                    Errorum.Fatal(IDErrorum.MINISTERIUMPUELLAE_UNINITIALIZED_RESVISAE_PECTORIS);
                    return;
                }
            }
            for (int i = 0; i < longitudoNatium; i++) {
                if (_resVisaeNatium[i] == null) {
                    Errorum.Fatal(IDErrorum.MINISTERIUMPUELLAE_UNINITIALIZED_RESVISAE_NATIUM);
                    return;
                }
            }

            _estActivumCapitis = true;
            _estActivumPectoris = true;
            _estActivumNatium = true;
        }

        public bool EstActivumCapitis() => _estActivumCapitis;
        public bool EstActivumPectoris() => _estActivumPectoris;
        public bool EstActivumNatium() => _estActivumNatium;

        public void ActivareCapitis() {
            _estActivumCapitis = true;
        }
        public void ActivarePectoris() {
            _estActivumPectoris = true;
        }
        public void ActivareNatium() {
            _estActivumNatium = true;
        }

        public void DeactivateCapitis() {
            _estActivumCapitis = false;
        }
        public void DeactivatePectoris() {
            _estActivumPectoris = false;
        }
        public void DeactivateNatium() {
            _estActivumNatium = false;
        }

        public Vector3 LegoCapitis(IDPuellaeResVisaeCapitis idCapitis) {
            return _resVisaeCapitis[(int)idCapitis].position;
        }

        public Vector3 LegoPectoris(IDPuellaeResVisaePectoris idPectoris) {
            return _resVisaePectoris[(int)idPectoris].position;
        }

        public Vector3 LegoNatium(IDPuellaeResVisaeNatium idNatium) {
            return _resVisaeNatium[(int)idNatium].position;
        }

        public Vector3 LegoPositionemRadix() {
            return anchoraPuellae.Positio;
        }
    }
}