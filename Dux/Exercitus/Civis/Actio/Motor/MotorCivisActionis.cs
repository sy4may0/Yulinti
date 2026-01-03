using Yulinti.Dux.ContractusDucis;
using System.Numerics;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MotorCivisActionis {
        private readonly IOstiumCivisLociMutabile _ostiumCivisLociMutabile;
        private readonly IOstiumCivisLociNavmeshMutabile _ostiumCivisLociNavmeshMutabile;
        private readonly ContextusCivisOstiorumLegibile _contextusOstiorum;

        private readonly SpeciesOrdinationisCivis?[] _speciesActualis;

        public MotorCivisActionis(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IOstiumCivisLociMutabile ostiumCivisLociMutabile,
            IOstiumCivisLociNavmeshMutabile ostiumCivisLociNavmeshMutabile
        ) {
            _ostiumCivisLociMutabile = ostiumCivisLociMutabile;
            _ostiumCivisLociNavmeshMutabile = ostiumCivisLociNavmeshMutabile;
            _contextusOstiorum = contextusOstiorum;
            _speciesActualis = new SpeciesOrdinationisCivis?[contextusOstiorum.Civis.Longitudo];
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
                motus.Verticalis.Velocitas,
                motus.Verticalis.TempusLevigatum,
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
            _ostiumCivisLociNavmeshMutabile.InitareMigrare(idCivis);
            _ostiumCivisLociNavmeshMutabile.IncipereMigrare(idCivis, navmesh.Positio);
            _ostiumCivisLociNavmeshMutabile.PonoVelocitatem(idCivis, navmesh.VelocitasDesiderata);
            _ostiumCivisLociNavmeshMutabile.PonoAccelerationem(idCivis, navmesh.Acceleratio);
            _ostiumCivisLociNavmeshMutabile.PonoVelocitatemRotationis(idCivis, navmesh.VelocitasRotationis);
            _ostiumCivisLociNavmeshMutabile.PonoDistantiaDeaccelerationis(idCivis, navmesh.DistantiaDeaccelerationis);
        }

        private void ApplicareInitareNavmesh(
            int idCivis,
            OrdinatioCivisInitareNavmesh initareNavmesh
        ) {
            if (_speciesActualis[idCivis] != SpeciesOrdinationisCivis.InitareNavmesh) {
                IntrareNavmesh(idCivis);
            }
            _ostiumCivisLociNavmeshMutabile.Transporto(idCivis, initareNavmesh.Positio, _contextusOstiorum.LociNavmesh.Rotatio(idCivis));
        }

        private void IntrareMotus(int idCivis) {
            Vector3 positio = _contextusOstiorum.LociNavmesh.Positio(idCivis);
            Quaternion rotatio = _contextusOstiorum.LociNavmesh.Rotatio(idCivis);

            _ostiumCivisLociNavmeshMutabile.Deactivare(idCivis);
            _ostiumCivisLociMutabile.Activare(idCivis);

            _ostiumCivisLociMutabile.PonoPositionemCoacte(idCivis, positio);
            _ostiumCivisLociMutabile.PonoRotationemCoacte(idCivis, rotatio);
        }

        private void IntrareNavmesh(int idCivis) {
            Vector3 positio = _contextusOstiorum.Loci.Positio(idCivis);
            Quaternion rotatio = _contextusOstiorum.Loci.Rotatio(idCivis);
            _ostiumCivisLociMutabile.Deactivare(idCivis);
            _ostiumCivisLociNavmeshMutabile.Activare(idCivis);
            _ostiumCivisLociNavmeshMutabile.Transporto(idCivis, positio, rotatio);
        }

        public float VelocitasHorizontalisActualis(int idCivis) {
            if (_speciesActualis[idCivis] == SpeciesOrdinationisCivis.Motus) {
                return _contextusOstiorum.Loci.VelHorizontalisActualis(idCivis);
            }
            if (_speciesActualis[idCivis] == SpeciesOrdinationisCivis.Navmesh) {
                return _contextusOstiorum.LociNavmesh.VelocitasHorizontalisActualis(idCivis);
            }
            return 0f;
        }

        public float VelocitasVerticalisActualis(int idCivis) {
            if (_speciesActualis[idCivis] == SpeciesOrdinationisCivis.Motus) {
                return _contextusOstiorum.Loci.VelVerticalisActualis(idCivis);
            }
            if (_speciesActualis[idCivis] == SpeciesOrdinationisCivis.Navmesh) {
                return _contextusOstiorum.LociNavmesh.VelocitasVerticalisActualis(idCivis);
            }
            return 0f;
        }

        public float RotatioYActualis(int idCivis) {
            if (_speciesActualis[idCivis] == SpeciesOrdinationisCivis.Motus) {
                return _contextusOstiorum.Loci.RotatioYActualis(idCivis);
            }
            if (_speciesActualis[idCivis] == SpeciesOrdinationisCivis.Navmesh) {
                return _contextusOstiorum.LociNavmesh.RotatioYActualis(idCivis);
            }
            return 0f;
        }
    }
}
