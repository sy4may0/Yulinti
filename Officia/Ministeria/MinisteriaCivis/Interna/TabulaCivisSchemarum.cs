using System;
using UnityEngine.AddressableAssets;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.Officia.Ministeria {
    internal sealed class TabulaCivisSchemarum {
        private readonly AssetReferenceGameObject[][] _schemarum;

        public TabulaCivisSchemarum(
            IConfiguratioCivisSchemae[] schemarum
        ) {
            int longitudo = Enum.GetValues(typeof(IDCivisSchemae)).Length;
            _schemarum = new AssetReferenceGameObject[longitudo][];

            foreach (IConfiguratioCivisSchemae schema in schemarum) {
                if (schema == null) continue;
                if (schema.IDCivisSchemae == IDCivisSchemae.Nihil) continue;

                _schemarum[(int)schema.IDCivisSchemae] = schema.Schemarum;
            }

            for (int i = 0; i < longitudo; i++) {
                if ((IDCivisSchemae)i == IDCivisSchemae.Nihil) continue;
                if (_schemarum[i] == null || _schemarum[i].Length == 0) {
                    Carnifex.Intermissio(LogTextus.TabulaCivisSchemarum_TABULACIVISSCHEMARUM_SCHEMA_NOT_FOUND);
                }
            }
        }

        public AssetReferenceGameObject[] Legere(IDCivisSchemae idCivisSchemae) {
            if (idCivisSchemae == IDCivisSchemae.Nihil) return null;
            return _schemarum[(int)idCivisSchemae];
        }

        public AssetReferenceGameObject LegereTemere(IDCivisSchemae idCivisSchemae, Random random) {
            if (idCivisSchemae == IDCivisSchemae.Nihil) return null;
            return _schemarum[(int)idCivisSchemae][random.Next(_schemarum[(int)idCivisSchemae].Length)];
        }
    }
}