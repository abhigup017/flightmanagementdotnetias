﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IASFlightManagement
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[] {
            new ApiResource("AirlineService", "Airline Service"),
            new ApiResource("DiscountService", "Discount Service")
            //new ApiResource("admin", "Resource 1")
            //{
            // Scopes = { new Scope("airlineScope")}
            //}

            
            };

        }

        public static IEnumerable<Client> GetClients()
        {
            return new Client[]
            {
                new Client
                {
                    ClientId = "Admin",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("AdminSecret".Sha256())
                    },
                    AllowedScopes = { "AirlineService", "DiscountService" }

                },
                new Client
                {
                    ClientId = "User",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("UserSecret".Sha256())
                    },
                    AllowedScopes = { "DiscountService" }

                }

            };
        }
    }
}
    

