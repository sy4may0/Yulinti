using Yulinti.Dux.ContractusDucis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResolutorCivisRamorumNavmesh {
        private readonly IRamusCivisNavmesh[] _rami;
        private readonly Dictionary<IDCivisStatusNavmesh, IRamusCivisNavmesh[][]> _tabula;
        private readonly Random _random;

        public ResolutorCivisRamorumNavmesh() {
            _random = new Random();

            _rami = new IRamusCivisNavmesh[] {
                new RamusCivisNativitasAdAditorium(),
                new RamusCivisAditoriumAdAditorium(),
                new RamusCivisAditoriumAdCrematorium(),
                new RamusCivisCrematoriumAdSuicidum(),
            };

            _tabula = new Dictionary<IDCivisStatusNavmesh, IRamusCivisNavmesh[][]>();

            foreach (IDCivisStatusNavmesh status in Enum.GetValues(typeof(IDCivisStatusNavmesh))) {
                if (status == IDCivisStatusNavmesh.None) continue;

                var ramiPG = _rami
                    .Where(r => r.IdStatusActualis == status)
                    .GroupBy(r => r.Prioritas)
                    .OrderBy(g => g.Key)
                    .Select(g => g.ToArray())
                    .ToArray();
                    
                if (ramiPG.Length > 0) {
                    _tabula[status] = ramiPG;
                }
            }
        }
        public IDCivisStatusNavmesh Resolvere(
            IDCivisStatusNavmesh idStatusActualis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            ContextusCivisResFluidaLegibile contextusResFluida
        ) {
            if (!_tabula.ContainsKey(idStatusActualis)) {
                return IDCivisStatusNavmesh.None;
            }

            foreach (var ramiPG in _tabula[idStatusActualis]) {
                IDCivisStatusNavmesh idStatusProximus = selegereCaecus(ramiPG, contextusOstiorum, contextusResFluida);
                if (idStatusProximus != IDCivisStatusNavmesh.None) {
                    return idStatusProximus;
                }
            }

            return IDCivisStatusNavmesh.None;
        }

        private IDCivisStatusNavmesh selegereCaecus(
            IRamusCivisNavmesh[] rami,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            ContextusCivisResFluidaLegibile contextusResFluida
        ) {
            IRamusCivisNavmesh selecta = null;
            int summa = 0;

            foreach (var ramus in rami) {
                if (!ramus.Condicio(contextusOstiorum, contextusResFluida)) {
                    continue;
                }

                summa++;

                if (_random.Next(0, summa) == 0) {
                    selecta = ramus;
                }
            }
            if (selecta == null) {
                return IDCivisStatusNavmesh.None;
            }
            return selecta.IdStatusProximus;
        }
    }
}