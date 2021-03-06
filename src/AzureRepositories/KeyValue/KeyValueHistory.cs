﻿using Core.Entities;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureRepositories.KeyValue
{
    public class KeyValueHistory : TableEntity, IKeyValueHistory
    {
        private string _dateTime;

        public string GeneratePartitionKey() => KeyValueId;

        public string DateTime
        {
            get => _dateTime ?? RowKey;
            set => _dateTime = value;
        }

        public string KeyValueId { get; set; }
        public string NewValue { get; set; }
        public string NewOverride { get; set; }
        public string KeyValuesSnapshot { get; set; }
        public string UserName { get; set; }
        public string UserIpAddress { get; set; }
    }
}
