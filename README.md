Question 2: A new category was created called PEP (politically exposed person). Also, a new bool property 
IsPoliticallyExposed was created in the ITrade interface. A trade shall be categorized as PEP if 
IsPoliticallyExposed is true. Describe in at most 1 paragraph what you must do in your design to account for this 
new category.

Answer:

We created a new class called PEP that inherits from ITrade, a new constructor in the AbstractTrade class to receive the value of 
IsPoliticallyExposed and finally a new overload for the CreateTrade method in the TradeFactory class that will be responsible for creating the PEP type
