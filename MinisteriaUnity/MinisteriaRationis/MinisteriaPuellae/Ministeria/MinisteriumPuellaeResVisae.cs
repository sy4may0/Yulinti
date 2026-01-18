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

        private readonly Transform[] _resNudusAnterior;
        private readonly Transform[] _resNudusPosterior;
        private bool _estActivumNudusAnterior;
        private bool _estActivumNudusPosterior;


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

            int longitudoNudusAnterior = Enum.GetValues(typeof(IDPuellaeResNudusAnterior)).Length;
            int longitudoNudusPosterior = Enum.GetValues(typeof(IDPuellaeResNudusPosterior)).Length;
            _resNudusAnterior = new Transform[longitudoNudusAnterior];
            _resNudusPosterior = new Transform[longitudoNudusPosterior];

            _resNudusAnterior[(int)IDPuellaeResNudusAnterior.Pectoris] = anchoraPuellae.ResNudusPectoris;
            _resNudusAnterior[(int)IDPuellaeResNudusAnterior.Catellus] = anchoraPuellae.ResNudusCatellus;
            _resNudusPosterior[(int)IDPuellaeResNudusPosterior.Natium] = anchoraPuellae.ResNudusNatium;

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

            for (int i = 0; i < longitudoNudusAnterior; i++) {
                if (_resNudusAnterior[i] == null) {
                    Errorum.Fatal(IDErrorum.MINISTERIUMPUELLAE_UNINITIALIZED_RESNUDUS_ANTERIOR);
                    return;
                }
            }
            for (int i = 0; i < longitudoNudusPosterior; i++) {
                if (_resNudusPosterior[i] == null) {
                    Errorum.Fatal(IDErrorum.MINISTERIUMPUELLAE_UNINITIALIZED_RESNUDUS_POSTERIOR);
                    return;
                }
            }

            _estActivumCapitis = true;
            _estActivumPectoris = true;
            _estActivumNatium = true;
            _estActivumNudusAnterior = true;
            _estActivumNudusPosterior = true;
        }

        public bool EstActivumCapitis() => _estActivumCapitis;
        public bool EstActivumPectoris() => _estActivumPectoris;
        public bool EstActivumNatium() => _estActivumNatium;

        public bool EstActivumNudusAnterior() => _estActivumNudusAnterior;
        public bool EstActivumNudusPosterior() => _estActivumNudusPosterior;

        public void ActivareCapitis() {
            _estActivumCapitis = true;
        }
        public void ActivarePectoris() {
            _estActivumPectoris = true;
        }
        public void ActivareNatium() {
            _estActivumNatium = true;
        }
        public void ActivareNudusAnterior() {
            _estActivumNudusAnterior = true;
        }
        public void ActivareNudusPosterior() {
            _estActivumNudusPosterior = true;
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

        public void DeactivateNudusAnterior() {
            _estActivumNudusAnterior = false;
        }
        public void DeactivateNudusPosterior() {
            _estActivumNudusPosterior = false;
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

        public Vector3 LegoNudusAnterior(IDPuellaeResNudusAnterior idNudusAnterior) {
            return _resNudusAnterior[(int)idNudusAnterior].position;
        }

        public Vector3 LegoNudusPosterior(IDPuellaeResNudusPosterior idNudusPosterior) {
            return _resNudusPosterior[(int)idNudusPosterior].position;
        }

        public Vector3 LegoNudusAnteriorDirectio(IDPuellaeResNudusAnterior idNudusAnterior) {
            return _resNudusAnterior[(int)idNudusAnterior].forward;
        }

        public Vector3 LegoNudusPosteriorDirectio(IDPuellaeResNudusPosterior idNudusPosterior) {
            return _resNudusPosterior[(int)idNudusPosterior].forward;
        }

        public Vector3 LegoPositionemRadix() {
            return anchoraPuellae.Positio;
        }
    }
}