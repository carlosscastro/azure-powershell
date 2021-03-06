﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Security;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Common
{
    public class FakeAccessTokenProvider : ITokenProvider
    {
        private readonly IAccessToken accessToken;

        public FakeAccessTokenProvider(string token)
            : this(token, "user@live.com")
        { }

        public FakeAccessTokenProvider(string token, string userId)
        {
            this.accessToken = new MockAccessToken()
            {
                AccessToken = token,
                UserId = userId
            };
        }

        public IAccessToken GetAccessToken(AdalConfiguration config, string promptBehavior, Action<string> promptAction, string userId, SecureString password,
            string credentialType)
        {
            return this.accessToken;
        }

        public IAccessToken GetAccessTokenWithCertificate(AdalConfiguration config, string principalId, string certificateThumbprint, string credentialType)
        {
            return this.accessToken;
        }
    }
}