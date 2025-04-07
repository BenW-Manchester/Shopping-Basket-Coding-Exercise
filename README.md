# Running app
To run the app use `dotnet run`

# Running tests
To run the tests use `dotnet tests` in the `/Tests` dir

# Overview
This is a basic shopping basket console application.

It has 5 core features:

- see stock
- viewing basket
- add to basket
- remove from basket
- confirm order

Along with this when an order is being confirmed a discount code can be applied. 
Currently the only supported code is "TENOFF" which applies a 10% discount to the most expensive item in the basket (only for one of this item)
