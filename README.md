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

- User Registration and Authentication
- Browsing Products
- Adding Products to Cart
- Checkout
- Viewing Order History
- User Profile Management (Update Password)
- Admin and Worker Roles
- Admin CRUD Operations on Products, Orders, and Users
- Worker Ability to Edit Orders and Add Products
- Photo Upload for Products and User Profiles (Requires API Key)

## Getting Started

### Prerequisites

To run this project, you will need the following:

- .NET Core SDK (3.1 or higher)
- Node.js and npm (Node Package Manager)
- Visual Studio or Visual Studio Code (optional but recommended)
- Bytescale API Key for Photo Upload (optional)

### Installation

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/your-username/electronic-store.git
   ```

2. Navigate to the project directory:

    ```bash
    cd electronic-store
    ```

3. Install backend dependencies using .NET CLI:

    ```bash
    dotnet restore
    ```

4. Navigate to the ClientApp directory and install frontend dependencies using npm:

    ```bash
    cd ClientApp
    npm install
    ```

### Configuration

Before running the application, you need to configure the API key for photo upload. Follow these steps:

    1. Visit Bytescale to obtain an API key for photo upload.

    2. Create a configuration file for the API key. In the root directory of the project, create a file named appsettings.json and add the following content:

        
## Usage

### User

- **Register:** Sign up for an account using the registration page.
- **Sign In:** Log in with your credentials.
- **Browse Products:** Explore the electronic store's product catalog.
- **Add to Cart:** Select products and add them to your shopping cart.
- **Checkout:** Proceed to the checkout page to complete your purchase.
- **View Orders:** Access your order history and view order details in the "My Orders" section.
- **Update Profile:** Modify your user profile and change your password in the "My Profile" section.

### Admin

- **Log In:** Admins can log in using their credentials.
- **Manage Store:** Access the "Manage Store" menu to perform CRUD operations on Products, Orders, and Users.
  - **Products:** Add, edit, and delete products.
  - **Orders:** View and manage all orders.
  - **Users:** Manage user accounts, including role assignment.

### API Key for Photo Upload

This project supports uploading photos for products and user profiles, but it requires an API key from Bytescale for photo uploads. You can obtain a free trial API key from Bytescale for a two-week period. Afterward, this service may become paid.

Without the API key, you can still add products and users to the store, but you won't be able to upload photos for them.