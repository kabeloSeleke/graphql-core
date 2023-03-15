variable "app_settings" {
  type        = map(string)
  description = "App settings to configure for the App Service"
  default = {
    "WEBSITE_RUN_FROM_PACKAGE"            = "1"
    "ASPNETCORE_ENVIRONMENT"              = "Production"
    "APPINSIGHTS_INSTRUMENTATIONKEY"      = "your-application-insights-instrumentation-key"
    "ApplicationInsightsAgent_EXTENSION_VERSION" = "~2"
    "WEBSITE_DOTNET_RUNTIME_VERSION"      = "7.0"
  }
}
