Feature: Stock

A short summary of the feature

@tag1
Scenario: Calculate time for investment with 200 per month until 1000 return
	Given get stock price and last divident price for nVidia
	When calculate the time for return investment of 1000 for 100 per month
	Then the needed time is 2 years and 0 months
@Login
Scenario: Online Shop
	When online shop login with "staf5" username and "staf5" password
	Then validate user is logged in
@Products
Scenario Outline: Add Product
	When online shop login with "admin3" username and "admin123" password
	When Product with product_id:"<product_id>", name:"<name>", quantity:<quantity>, price:<price> and description:"<description>" is added
	Then the response message is "Product added successfully"
	Examples: 
	| product_id | name        | quantity | price | description                |
	| "2000"     | "Product 1" | 5        | 25.50 | "BP Description product 1" |
	| "2001"     | "Product 2" | 14       | 22.99 | "BP Description product 2" |
	| "2002"     | "Product 3" | 13       | 30.00 | "BP Description product 3" |
	| "2003"     | "Product 4" | 11       | 20.55 | "BP Description product 4" |
	| "2004"     | "Product 5" | 14       | 5.15  | "BP Description product 5" |