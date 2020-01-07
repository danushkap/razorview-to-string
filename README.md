# Render Razor view to string

[![Azure DevOps builds](https://img.shields.io/azure-devops/build/danushkap/razorview-to-string/3?logo=azure-pipelines)](https://dev.azure.com/danushkap/razorview-to-string/_build/latest?definitionId=3) [![CodeFactor](https://img.shields.io/codefactor/grade/github/danushkap/razorview-to-string?style=flat&logo=codefactor&logoColor=whitesmoke)](https://www.codefactor.io/repository/github/danushkap/razorview-to-string)

[![GitHub license](https://img.shields.io/github/license/danushkap/razorview-to-string?style=flat&logo=github)](https://github.com/danushkap/razorview-to-string/blob/master/LICENSE) [![GitHub issues](https://img.shields.io/github/issues/danushkap/razorview-to-string?style=flat&logo=github)](https://github.com/danushkap/razorview-to-string/issues)

This POC demonstrates how to render (convert) a Razor view to a string in/using ASP.NET Core.

The actual render operation is done in the `RazorViewToString` **Class-library** project.

And how its used in a:

* Non-web scenario - is illustrated in `RazorViewToString.InNonWeb` **Console** project
* Web scenario - is illustrated in `RazorViewToString.InWeb` **ASP.NET MVC** project
