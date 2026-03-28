using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class SalsamentumPuellaeFormarumDto {
        [JsonProperty("formarum")]
        public Dictionary<IDPuellaeFormae, SalsamentumPuellaeFormaeDto> Formarum { get; set; }

        public SalsamentumPuellaeFormarumDto() {
            UnityEngine.Debug.Log("SalsamentumPuellaeFormarumDto Constructor");
            Formarum = new Dictionary<IDPuellaeFormae, SalsamentumPuellaeFormaeDto>();
            InitiareFormarum();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context) {
            Formarum ??= new Dictionary<IDPuellaeFormae, SalsamentumPuellaeFormaeDto>();

            // 必要なキーが存在しない場合は追加する。
            InitiareFormarum();

        }

        private void InitiareFormarum() {
            foreach (IDPuellaeFormae idFormae in Enum.GetValues(typeof(IDPuellaeFormae))) {
                if (!Formarum.ContainsKey(idFormae)) {
                    Formarum[idFormae] = new SalsamentumPuellaeFormaeDto();
                }
            }
        }
    }
}