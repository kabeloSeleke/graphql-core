# main.tf - main configuration file for the project

# Define the provider(s) to use
provider "azurerm" {
  features {}
}

# Include any reusable modules
module "example" {
  source = "./modules/example"

  # Pass in any required variables for the module
  example_variable = var.example_variable
}

# Define any additional resources for the project
resource "azurerm_resource_group" "example" {
  name     = var.resource_group_name
  location = var.location
}

resource "azurerm_app_service_plan" "example" {
  name                = var.app_service_plan_name
  location            = var.location
  resource_group_name = azurerm_resource_group.example.name
  sku {
    tier = "Basic"
    size = "B1"
  }
}

resource "azurerm_app_service" "example" {
  name                = var.app_name
  location            = var.location
  resource_group_name = azurerm_resource_group.example.name
  app_service_plan_id = azurerm_app_service_plan.example.id

  site_config {
    dotnet_framework_version = "v7.0"
    scm_type                  = "LocalGit"
  }

  app_settings = var.app_settings
}

