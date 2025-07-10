# Getting Started with C# ExpressionNotationConverter

### `' Dotnet cli required'`
### ` Navigate to  folder  named 'ExpressionNotationConverter'`

## Available Scripts

In the project directory, you can run:

### `dotnet build`

to build the project, then

### `dotnet run`

# Design Decisions

Created the Converter as a class library making it easier to use in other projects.

Created a Parser class PostfixToInfixParser with base class with base Parser thus allowing for extension by  adding other parsers without having to modify existing parser classes.




# Testing

To test the component I would  first identify the core areas functionality.

I would then prepare a list of test cases for the individual areas.

I would test both path success and failure paths.

I would ensure input validation done and security tests are conducted as well.

I would also ensure to include tests that evaluate performance

I would conduct these tests with a test framework such as xunit.

