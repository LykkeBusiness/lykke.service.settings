// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.SettingsServiceV2.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class OverrideValue
    {
        /// <summary>
        /// Initializes a new instance of the OverrideValue class.
        /// </summary>
        public OverrideValue()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the OverrideValue class.
        /// </summary>
        public OverrideValue(string networkId = default(string), string value = default(string))
        {
            NetworkId = networkId;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "networkId")]
        public string NetworkId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}