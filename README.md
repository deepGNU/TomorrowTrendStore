# .NET API with React Frontend - Electronic Store Project

## Introduction

Welcome to our .NET API project featuring a React frontend, designed for an electronic store platform. This application offers a comprehensive e-commerce experience, allowing users to register, browse products, manage their carts, and complete purchases. It also includes specialized functionalities for admin and worker roles, enhancing the management of store resources.

## Features

### User Capabilities
- **Account Registration and Authentication**: Users can sign up for an account and log in to access the store.
- **Product Interaction**: View various electronic products and add them to the shopping cart.
- **Cart Management**: The shopping cart icon flickers in the navigation bar when items are added. Users can modify their cart contents.
- **Order Management**: View personal order history under 'My Orders' in the navigation menu.
- **Profile Management**: Users can update their profiles and passwords through 'My Profile'.

### Admin and Worker Functionalities
- **CRUD Operations**: Perform create, read, update, and delete operations on store resources.
- **Role-Specific Access**:
  - *Regular Workers*: Can edit orders and add new products.
  - *Admins*: Have full control over products, orders, and user accounts.
- **Management Access**: Accessible via the 'Manage Store' menu for logged-in workers and admins.

### Photo Integration
- **Photo Uploads**: Both products and user accounts support photo inclusion.
- **API Integration**: To enable photo uploads, obtain an API key from [Bytescale](https://www.bytescale.com). A 2-week free trial is available, followed by a paid subscription.
- **Functionality Without API Key**: Adding products and users without photos is possible without the API key.

## Getting Started

### Prerequisites
- .NET SDK
- Node.js and npm (for React)
- Visual Studio or a preferred .NET IDE
- A modern web browser

### Installation
1. Clone the repository to your local machine.
2. Navigate to the project directory and install the necessary packages:
   - For .NET backend: `dotnet restore`
   - For React frontend: `npm install`
3. Obtain the Bytescale API key for photo upload functionality.
4. Configure the environment variables with your database and API credentials.

### Running the Application
1. Start the .NET backend server: `dotnet run` inside the backend directory.
2. Launch the React frontend: `npm start` in the frontend directory.
3. Access the application via the browser at `http://localhost:3000`.

---

*Note: This README is subject to updates. For the latest information, always refer to the latest version in the repository.*
