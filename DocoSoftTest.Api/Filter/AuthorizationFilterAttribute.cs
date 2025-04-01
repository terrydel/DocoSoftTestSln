﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace DocoSoftTest.Api.Filter
{
    public class AuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string? _apiKey;
        private readonly string? _apiKeySecondary;
        private readonly bool _canUseSecondaryApiKey;

        public AuthorizationFilterAttribute(IConfiguration configuration)
        {
            _apiKey = configuration["SecretKeys:ApiKey"];
            _apiKeySecondary = configuration["SecretKeys:ApiKeySecondary"];
            _canUseSecondaryApiKey = configuration["SecretKeys:UseSecondaryKey"] == "True";
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var apiKeyHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            var authController = new Controllers.AuthController();

            if (apiKeyHeader.Any())
            {
                var keys = new List<string>();

                if (!string.IsNullOrEmpty(_apiKey))
                {
                    keys.Add(_apiKey);
                }

                if (_canUseSecondaryApiKey && !string.IsNullOrEmpty(_apiKeySecondary))
                {
                    keys.AddRange(_apiKeySecondary.Split(','));
                }

                if (keys.FindIndex(x => x.Equals(apiKeyHeader, StringComparison.OrdinalIgnoreCase)) == -1)
                {
                    context.Result = authController.NotAuthorized();
                }
            }
            else
            {
                context.Result = authController.NotAuthorized();
            }
        }
    }
}
