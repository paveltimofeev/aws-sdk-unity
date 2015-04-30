﻿//
// Copyright 2014-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
//
//
// Licensed under the AWS Mobile SDK for Unity Developer Preview License Agreement (the "License").
// You may not use this file except in compliance with the License.
// A copy of the License is located in the "license" file accompanying this file.
// See the License for the specific language governing permissions and limitations under the License.
//
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.SharedInterfaces;

namespace Amazon.DynamoDBv2.DataModel
{
    internal class S3ClientCache
    {
        private AmazonDynamoDBClient ddbClient;

        private Dictionary<string, ICoreAmazonS3> clientsByRegion;

        internal S3ClientCache(AmazonDynamoDBClient ddbClient)
        {
            this.ddbClient = ddbClient;

            this.clientsByRegion = new Dictionary<string, ICoreAmazonS3>(StringComparer.OrdinalIgnoreCase);
        }

        internal void UseClient(ICoreAmazonS3 client, RegionEndpoint region)
        {
            if (this.clientsByRegion.ContainsKey(region.SystemName))
            {
                this.clientsByRegion.Remove(region.SystemName);
            }
            this.clientsByRegion.Add(region.SystemName, client);
        }

        internal ICoreAmazonS3 GetClient(RegionEndpoint region)
        {
            ICoreAmazonS3 output;
            if (!this.clientsByRegion.TryGetValue(region.SystemName, out output))
            {
                output = ServiceClientHelpers.CreateServiceFromAssembly<ICoreAmazonS3>(ServiceClientHelpers.S3_ASSEMBLY_NAME, ServiceClientHelpers.S3_SERVICE_CLASS_NAME, this.ddbClient);
                this.clientsByRegion.Add(region.SystemName, output);
            }
            return output;
        }
    }
}