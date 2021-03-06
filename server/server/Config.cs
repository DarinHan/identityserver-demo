﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace server
{
    public sealed class Config
    {
        public static IEnumerable<ApiResource> Apis =>
           new List<ApiResource>
           {
                new ApiResource("api1", "My API")
           };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "admin",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("admin".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                }
            };
    }
}
