using Yulinti.Dux.ContractusDucis;
using System.Numerics;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MotorCivisActionis {
        private readonly IOstiumCivisLociMutabile _ostiumCivisLociMutabile;
        private readonly ContextusCivisOstiorumLegibile _contextusOstiorum;

        private readonly SpeciesOrdinationisCivis?[] _speciesActualis;

        // TransportoおよびActivareNavmeshの結果を保存する。
        // falseがあればNavmesh上にいない。
        private bool[] _estInNavmesh;

        public MotorCivisActionis(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IOstiumCivisLociMutabile ostiumCivisLociMutabile
        ) {
            _ostiumCivisLociMutabile = ostiumCivisLociMutabile;
            _contextusOstiorum = contextusOstiorum;
            _speciesActualis = new SpeciesOrdinationisCivis?[contextusOstiorum.Civis.Longitudo];
            _estInNavmesh = new bool[contextusOstiorum.Civis.Longitudo];
            for (int i = 0; i < contextusOstiorum.Civis.Longitudo; i++) {
                _estInNavmesh[i] = true;
            }
        }

        public void ApplicareActionis(
            OrdinatioCivisActionis ordinatio
        ) {
            int idCivis = ordinatio.IdCivis;
            ordinatio.Match(
                motus => ApplicareMotus(idCivis, motus),
                navmesh => ApplicareNavmesh(idCivis, navmesh),
                initareNavmesh => ApplicareInitareNavmesh(idCivis, initareNavmesh)
            );
            _speciesActualis[idCivis] = ordinatio.Species;
        }

        private void ApplicareMotus(
            int idCivis,
            OrdinatioCivisMotus motus
        ) {
            if (_speciesActualis[idCivis] != SpeciesOrdinationisCivis.Motus) {
                IntrareMotus(idCivis);
            }
            _ostiumCivisLociMutabile.Moto(
                idCivis,
                motus.Horizontalis.Velocitas,
                motus.Horizontalis.TempusLevigatum,
                motus.RotationisY.RotatioY,
                motus.RotationisY.TempusLevigatum,
                _contextusOstiorum.Temporis.Intervallum
            );
        }

        private void ApplicareNavmesh(
            int idCivis,
            OrdinatioCivisNavmesh navmesh
        ) {
            if (_speciesActualis[idCivis] != SpeciesOrdinationisCivis.Navmesh) {
                IntrareNavmesh(idCivis);
            }
            _ostiumCivisLociMutabile.InitareMigrare(idCivis);
            _ostiumCivisLociMutabile.IncipereMigrare(idCivis, navmesh.Positio);
            _ostiumCivisLociMutabile.PonoVelocitatem(idCivis, navmesh.VelocitasDesiderata);
            _ostiumCivisLociMutabile.PonoAccelerationem(idCivis, navmesh.Acceleratio);
            _ostiumCivisLociMutabile.PonoVelocitatemRotationis(idCivis, navmesh.VelocitasRotationis);
            _ostiumCivisLociMutabile.PonoDistantiaDeaccelerationis(idCivis, navmesh.DistantiaDeaccelerationis);
        }

        private void ApplicareInitareNavmesh(
            int idCivis,
            OrdinatioCivisInitareNavmesh initareNavmesh
        ) {
            if (_speciesActualis[idCivis] != SpeciesOrdinationisCivis.InitareNavmesh) {
                IntrareNavmesh(idCivis);
            }
            _estInNavmesh[idCivis] = _ostiumCivisLociMutabile.Transporto(idCivis, initareNavmesh.Positio, _contextusOstiorum.Loci.Rotatio(idCivis));
        }

        private void IntrareMotus(int idCivis) {
            _ostiumCivisLociMutabile.ActivareMotus(idCivis);
        }

        private void IntrareNavmesh(int idCivis) {
            _estInNavmesh[idCivis] = _ostiumCivisLociMutabile.ActivareNavMesh(idCivis);
        }

        public float VelocitasHorizontalisActualis(int idCivis) {
            return _contextusOstiorum.Loci.VelocitasHorizontalisActualis(idCivis);
        }

        public float RotatioYActualis(int idCivis) {
            return _contextusOstiorum.Loci.RotatioYActualis(idCivis);
        }

        public OrdinatioCivis VerificareNavmesh(int idCivis) {
            // Navmesh上にいない場合、Civis消去Ordinatioを返す。
            if (!_estInNavmesh[idCivis]) {
                return new OrdinatioCivis(
                    idCivis, 
                    veletudinisMortis: new OrdinatioCivisVeletudinisMortis(idCivis, estSpirituare: true)
                );
            }
            return OrdinatioCivis.Nihil(idCivis);
        }
    }
}
