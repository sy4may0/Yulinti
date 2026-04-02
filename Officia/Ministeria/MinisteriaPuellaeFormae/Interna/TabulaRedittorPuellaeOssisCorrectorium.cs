using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using System;

namespace Yulinti.Officia.Ministeria {
    internal sealed class TabulaRedittorPuellaeOssisCorrectorium {
        private readonly Transform[] _ossa;

        public TabulaRedittorPuellaeOssisCorrectorium(IAnchoraPuellae anchora) {
            int longitudo = Enum.GetNames(typeof(IDRedittorPuellaeOssisCorrectorium)).Length;
            _ossa = new Transform[longitudo];

            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Radix] = anchora.OsCorrectoriumRadicis;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Caput] = anchora.OsCorrectoriumCapitis;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Cervix] = anchora.OsCorrectoriumCervicis;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Spina2] = anchora.OsCorrectoriumSpinae2;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Spina1] = anchora.OsCorrectoriumSpinae1;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Spina0] = anchora.OsCorrectoriumSpinae0;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Pelvis] = anchora.OsCorrectoriumPelvis;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.UmerusDexter] = anchora.OsCorrectoriumUmeriDexter;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.BracchiumDextrum] = anchora.OsCorrectoriumBracchiiDexter;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.AntebracchiumDextrum] = anchora.OsCorrectoriumAntebracchiiDexter;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.ManusDextra] = anchora.OsCorrectoriumManusDexter;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.UmerusSinister] = anchora.OsCorrectoriumUmeriSinister;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.BracchiumSinistrum] = anchora.OsCorrectoriumBracchiiSinister;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.AntebracchiumSinistrum] = anchora.OsCorrectoriumAntebracchiiSinister;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.ManusSinistra] = anchora.OsCorrectoriumManusSinister;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.FemurDextrum] = anchora.OsCorrectoriumFemurisDexter;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.CrusDextrum] = anchora.OsCorrectoriumCrurisDexter;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.PesDexter] = anchora.OsCorrectoriumPedisDexter;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.DigitusPedisDexter] = anchora.OsCorrectoriumDigitiPedisDexter;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.FemurSinistrum] = anchora.OsCorrectoriumFemurisSinister;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.CrusSinistrum] = anchora.OsCorrectoriumCrurisSinister;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.PesSinister] = anchora.OsCorrectoriumPedisSinister;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.DigitusPedisSinister] = anchora.OsCorrectoriumDigitiPedisSinister;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.PectusDextrum] = anchora.OsCorrectoriumPectorissDexter;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.PectusSinistrum] = anchora.OsCorrectoriumPectorissSinister;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.NatisDextra] = anchora.OsCorrectoriumNatisDexter;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.NatisSinistra] = anchora.OsCorrectoriumNatisSinister;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Venter] = anchora.OsCorrectoriumVenter;

            for (int i = 0; i < longitudo; i++) {
                if (_ossa[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaRedittorPuellaeOssisCorrectorium_TABULAREDITTORPUELLAEOSSISCORRECTORIUM_BONE_NOT_FOUND);
                }
            }
        }

        public Transform Lego(IDRedittorPuellaeOssisCorrectorium idOssa) => _ossa[(int)idOssa];
    }
}