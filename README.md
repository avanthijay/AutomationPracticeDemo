# AutomationPracticeDemo
This is a Test Automation demo project for AutomationPractice web site.
Languages used: 
	- C#, Seleinum. NUnit and SpecFlow

Pre-Requestees:
	1. .NET Framework 4.6
	2. Visual Studio 2017
	3. SpecFlow Plugin for Visual Studio
	4. Microsoft Excel installed

Test Summary: Three tests are written to validate page elements and one end to end functional test 
Test : ValidateContentsWidget
	1. Go to https://ultimateqa.com/automation/
	2. Hide contents
	3. Check the content list
	4. SHow Contents
	5. Check the content list

	Test : ValidateSearchBoxFunctionality -  positive 
	1. Go to https://ultimateqa.com/automation/
	2. Search for positive results
	3. Validate the results
	Test : ValidateSearchBoxFunctionality -  Negative 
	1. Go to https://ultimateqa.com/automation/
	2. Search for negative results
	3. Validate the results

	Test : Login In
	1. Go to https://ultimateqa.com/automation/
	2. Click on Login link
	3. Enter valid Email
	4. Enter valid Pwd
	5. Click on SignIn
	6.Verify Dashboard (This part is commented due to UltimateQA restrictions of Automated Login)


How to Run Tests:
	1. Open ‘AutomationPracticeDemo.sln’ solution.
	2. Build solution.
	3. Restore Nuget packages (This automatically happens when you build solution).
	4. Open Test Explorer or Unit Test Explorer with ReSharper on Visual Studio and run tests.
