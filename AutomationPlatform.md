# AutomationLab – Hybrid Automation Platform

AutomationLab is an enterprise-grade hybrid automation platform designed for UI, API, and Mobile automation using clean layered architecture.

This platform is built to provide:
- CI-stable execution
- Hybrid UI + API + Mobile extensibility
- Centralized stability control
- Clean business-driven automation

---

## Architecture Overview

```

Feature Files
↓
Step Definitions
↓
Domain Services (Business Brain)
↓
Page / API / Screen Abstractions
↓
Execution Engines (UiExecutor, ApiExecutor, MobileExecutor)
↓
Driver Manager (Hybrid Driver Hub)
↓
Technology Drivers (Selenium, HttpClient, Appium)

```

## Core Design Principles

| Rule | Description |
|-----|-------------|
| Steps never touch Selenium | Only Domain calls Executor |
| Pages never contain waits | Only locators |
| Only Executors interact with drivers | Stability is centralized |
| All drivers are managed via DriverManager | Hybrid safe |
| All waits are centralized in WaitEngine | CI stable |

## Execution Flow

```
Feature → Step → Domain → Page → UiExecutor → DriverManager → WebDriver
```


## Framework Pillars

| Component | Responsibility |
|----------|----------------|
| DriverManager | Central hybrid driver registry |
| UiDriverFactory | Browser creation |
| UiExecutor | Central UI execution engine |
| WaitEngine | Central wait engine |
| Domain | Business workflows |
| Pages | UI abstraction |
| Config | Environment & routes |

## Why This Architecture

- Enables UI / API / Mobile hybrid testing
- Prevents flaky pipelines
- Supports CI/CD and cloud execution
- Easy to extend and maintain


## Module Structure

```
Domains/
Pages/
Features/
StepDefinitions/
Helpers/
Drivers/
Config/
```

## How To Add New Module
1. Create Page abstraction
2. Create Domain workflow
3. Add Feature
4. Add StepDefinition
5. Run tests


This platform is designed to evolve with growing automation needs.
