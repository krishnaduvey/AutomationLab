# AutomationLab – Module Template Guide
This guide explains how to add new automation modules.


## Step 1 – Page Layer
Create locator abstraction:

```
Pages/UI/Elements/NewPage.cs
```
Contains:
- Only locators
- No logic
- No waits

## Step 2 – Domain Layer
Create business service:

```
Domains/Elements/NewDomain.cs
```

Contains:
- Business workflows
- Uses UiExecutor
- Uses Page

## Step 3 – Feature Layer
Add feature file:

```
Features/UI/Elements/NewFeature.feature
```

## Step 4 – Step Definitions
Add glue: [means binding to the feature file]

```
StepDefinitions/NewSteps.cs
```

- Calls Domain only.


## Golden Rule

```
Steps → Domain → Page → Executor → DriverManager → Technology
```

| Layer         | What it means in simple words                                                                                                            |
| ------------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| Steps         | This is where we write test steps in English (Given, When, Then). Steps never touch browser or API directly.                             |
| Domain        | This is the brain of the framework. It knows how a real business action is done. For example: Login, Register, Submit Form, Place Order. |
| Page          | This layer only knows where elements are present on screen. It only keeps locators (Id, XPath etc). No logic, no wait, no click here.    |
| Executor      | This is the worker of the framework. It actually performs click, type, scroll, wait, retry and all stability logic.                      |
| DriverManager | This is the storage of drivers. It keeps browser, API client and mobile driver safely for each running test.                             |
| Technology    | This is the real tool which talks to application. Like Selenium browser, API HttpClient or Appium mobile driver.                         |

