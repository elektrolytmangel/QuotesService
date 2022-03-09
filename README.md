# UnitTesting-HxGN
This project contains all information, code and examples to complete the unit-testing day @HxGN, 03/10/2022.

# Prerequisites
* [.Net 6 / .Net Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)
* Visual Studio 2022 Professional (Paid) or [Visual Studio Code](https://code.visualstudio.com/)
* Basic knowledge how to write C# code
* [optional] [Fine Code Coverage](https://marketplace.visualstudio.com/items?itemName=FortuneNgwenya.FineCodeCoverage)

# Getting started
* Clone this repo to your local storage
* Open the project of your choice (.Net 6 or .Net Framework) in your code editor (if you are using Visual Studio Code, it is recommended to use .Net 6 Examples)
* Restore nugets and build project
* You are ready to go.

# Coverage reports
To create coverage reports, open powershell in the "QuotesService" directory and execute the lines below.
``` ps
dotnet test --collect:"XPlat Code Coverage"

$dir = ".\QuotesService.UnitTests\TestResults"
$latest = Get-ChildItem -Path $dir | Sort-Object LastAccessTime -Descending | Select-Object -First 1
Copy-Item $dir\$latest\coverage.cobertura.xml -Destination .\

dotnet $env:USERPROFILE\.nuget\packages\reportgenerator\5.0.4\tools\net6.0\ReportGenerator.dll "-reports:coverage.cobertura.xml" "-targetdir:.\report"

Start-Process .\report\index.html
```