import { configureStore } from '@reduxjs/toolkit';
import usersReducer from '../features/users/users-slice';
import productsReducer from '../features/products/products-slice';
import ordersReducer from '../features/orders/orders-slice';
import cartsReducer from '../features/carts/carts-slice';
import currentUserReducer from '../features/current-user/current-user-slice';
import imageUploadReducer from '../features/image-upload/image-upload';

const store = configureStore({
    reducer: {
        users: usersReducer,
        products: productsReducer,
        orders: ordersReducer,
        carts: cartsReducer,
        currentUser: currentUserReducer,
        imageUpload: imageUploadReducer,
    },
});

export default store;