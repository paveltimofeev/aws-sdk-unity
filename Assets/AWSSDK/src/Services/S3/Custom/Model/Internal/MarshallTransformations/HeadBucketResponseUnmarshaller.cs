//
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
using System.Net;
using System.Collections.Generic;
using Amazon.S3.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
    /// <summary>
    ///    Response Unmarshaller for HeadBucket operation
    /// </summary>
    internal class HeadBucketResponseUnmarshaller : S3ReponseUnmarshaller
    {

        public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context) 
        {
            HeadBucketResponse response = new HeadBucketResponse();
            

            return response;
        }

        private static HeadBucketResponseUnmarshaller _instance;

        public static HeadBucketResponseUnmarshaller Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HeadBucketResponseUnmarshaller();
                }
                return _instance;
            }
        }
    }
}
    