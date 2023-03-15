# outputs.tf - defines output values for the project

# Define any output values for the project
output "app_service_url" {
  value = azurerm_app_service.example.default_site_hostname
}
