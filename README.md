# Banana Store App

## Overview

The Banana Store App is a simple console application that simulates a banana store's operations, including processing customer orders, checking inventory, and handling restocking from a supplier. The application utilizes a mediator pattern to manage the interactions between the store, supplier, and customer.

## Features

- **Customer Interaction**: The app prompts the user to enter the number of bananas they would like to purchase.
- **Inventory Management**: It checks the available bananas and processes the order accordingly.
- **Supplier Communication**: If the store has insufficient stock, the app automatically orders a full package of bananas from the supplier.

## Components

1. **Program**: The entry point of the application.
2. **StoreMediator**: Manages the flow between the customer, store, and supplier. It processes orders and coordinates inventory checks and supplier orders.
3. **Store**: Represents the banana store, holding the inventory and methods for selling and receiving bananas.
4. **Supplier**: Simulates a supplier that provides a fixed quantity of bananas to the store when requested.

## Getting Started

### Prerequisites

- .NET SDK installed on your machine. You can download it from [here](https://dotnet.microsoft.com/download).

### Running the Application

1. Clone this repository:
   ```bash
   git clone https://github.com/yourusername/BananaStoreApp.git
   cd BananaStoreApp
   ```
2. Open a terminal and navigate to the project directory using cd..
3. Run the application
   ```bash
   dotnet run
   ```
4. Follow the banana buying process
```bash
Hello dear customer, welcome to the Banana Store!
Enter how many bananas you would like: [enter your value]
Customer requested [entered value] bananas.

// from here the magic will begin, depending on the input

Store inventory updated: 9-[entered bananas] bananas left.
Order complete! [entered bananas] bananas have been provided to the customer.
```

## Code Structure

- **Program.cs**: Contains the main entry point and handles user input.
- **StoreMediator.cs**: Contains the logic to process customer orders and interact with the store and supplier.
- **Store.cs**: Manages the inventory of bananas and facilitates sales and restocking.
- **Supplier.cs**: Responsible for supplying bananas to the store.
- **Costumer.cs**: Responsible for requesting the correct banana amount.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue for any bugs or feature requests.
This project hopefully will bring more clarity about mediator design pattern, add to it take from it, but be careful to adding too much thus creating a *GOD OBJECT*

### Author
yours truly Janchuks

![Dancing Banana](https://media.tenor.com/RQKAyM7ZHA0AAAAM/banana-dance.gif)
