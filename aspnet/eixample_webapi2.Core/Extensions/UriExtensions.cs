﻿using eixample_webapi2.Consts;
using System;
using System.Linq;

namespace eixample_webapi2.Extensions
{
    public static class UriExtensions
    {
        public static string GetSubDomain(this Uri url)
        {
            var parts = url.Host.Split('.').ToList();

            if (parts.Any())
            {
                if (!parts.First().Equals(AppConsts.Host))
                {
                    return parts.First();
                }
            }

            return null;
        }
    }
}
