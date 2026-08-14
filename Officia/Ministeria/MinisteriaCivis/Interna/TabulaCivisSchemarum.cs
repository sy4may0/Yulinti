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
            int longitudo = Enum.GetValues(typeof(IDCivisPersonae)).Length;
            _schemarum = new AssetReferenceGameObject[longitudo][];

            foreach (IConfiguratioCivisSchemae schema in schemarum) {
                if (schema == null) continue;
                if (schema.IDCivisPersonae == IDCivisPersonae.Nihil) continue;

                _schemarum[(int)schema.IDCivisPersonae] = schema.Schemarum;
            }

            for (int i = 0; i < longitudo; i++) {
                if ((IDCivisPersonae)i == IDCivisPersonae.Nihil) continue;
                if (_schemarum[i] == null || _schemarum[i].Length == 0) {
                    Carnifex.Intermissio(LogTextus.TabulaCivisSchemarum_TABULACIVISSCHEMARUM_SCHEMA_NOT_FOUND);
                }
            }
        }

        public AssetReferenceGameObject[] Legere(IDCivisPersonae idCivisPersonae) {
            if (idCivisPersonae == IDCivisPersonae.Nihil) return null;
            return _schemarum[(int)idCivisPersonae];
        }

        public AssetReferenceGameObject LegereTemere(IDCivisPersonae idCivisPersonae, Random random) {
            if (idCivisPersonae == IDCivisPersonae.Nihil) return null;
            return _schemarum[(int)idCivisPersonae][random.Next(_schemarum[(int)idCivisPersonae].Length)];
        }
    }
}