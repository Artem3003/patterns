# Adapter

Adapter is a structural design pattern that allows objects with incompatible interfaces to collaborate.

## Usage examples

The Adapter pattern is pretty common in C# code. It’s very often used in systems based on some legacy code. In such cases, Adapters make legacy code work with modern classes.

## Identification

Adapter is recognizable by a constructor which takes an instance of a different abstract/interface type. When the adapter receives a call to any of its methods, it translates parameters to the appropriate format and then directs the call to one or several methods of the wrapped object.

> *** Note ***
>
> Use the Adapter class when you want to use some existing class, but its interface isn’t compatible with the rest of your code.

> *** Note ***
>
> Use the pattern when you want to reuse several existing subclasses that lack some common functionality that can’t be added to the superclass.