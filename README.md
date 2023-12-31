# Electronic Store API with React Frontend

Welcome to the Electronic Store API project with a React frontend. This application allows users to interact with an electronic store, perform various actions such as registering, signing in, browsing products, adding items to their cart, and checking out. Additionally, it provides administrative and worker functionalities for managing store resources. Please read this README.md thoroughly to understand the project's contents, functionality, and usage.

## Table of Contents

1. [Features](#features)
2. [Getting Started](#getting-started)
   - [Prerequisites](#prerequisites)
   - [Installation](#installation)
   - [Configuration](#configuration)
3. [Usage](#usage)
   - [User](#user)
   - [Admin](#admin)
4. [API Key for Photo Upload](#api-key-for-photo-upload)

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

## Documentation
For a detailed understanding of each component, refer to the documentation folder in the project repository.

## Support and Contribution
For support, contact [Support Email]. To contribute, please follow the contribution guidelines outlined in CONTRIBUTING.md.

## License
This project is licensed under the [License Name] - see the LICENSE.md file for details.

---

*Note: This README is subject to updates. For the latest information, always refer to the latest version in the repository.*
