import { createSlice } from '@reduxjs/toolkit';
import { resetState } from '../shared-actions';

const initialState = {
    allCarts: [],
    loadingAll: false,
    errorAll: null,
    cartToEdit: null,
    loggedInUserCart: localStorage.getItem('cart') ? JSON.parse(localStorage.getItem('cart')) : null,
    loadingLoggedInUserCart: false,
    errorLoggedInUserCart: null,
};

const nullState = {
    allCarts: [],
    loadingAll: false,
    errorAll: null,
    cartToEdit: null,
    loggedInUserCart: null,
    loadingLoggedInUserCart: false,
    errorLoggedInUserCart: null,
};

const cartsSlice = createSlice({
    name: 'carts',
    initialState,
    reducers: {
        getCartsStart(state) {
            state.loadingAll = true;
        },
        getCartsSuccess(state, action) {
            state.allCarts = action.payload;
            state.loadingAll = false;
            state.errorAll = null;
        },
        getCartsFailure(state, action) {
            state.loadingAll = false;
            state.errorAll = action.payload;
        },
        setCartToEdit(state, action) {
            state.cartToEdit = action.payload;
        },
        updateCart(state, action) {
            const updatedCart = action.payload;
            state.allCarts = state.allCarts.map((cart) =>
                cart.id === updatedCart.id ? updatedCart : cart
            );
            state.cartToEdit = null;
        },
        getCartStart(state) {
            state.loadingLoggedInUserCart = true;
        },
        getCartSuccess(state, action) {
            state.loggedInUserCart = action.payload;
            localStorage.setItem('cart', JSON.stringify(action.payload));
            state.loadingLoggedInUserCart = false;
            state.errorLoggedInUserCart = null;
        },
        getCartFailure(state, action) {
            state.loadingLoggedInUserCart = false;
            state.errorLoggedInUserCart = action.payload;
        },
        updateLoggedInUserCart(state, action) {
            const updatedCart = action.payload;
            state.loggedInUserCart = updatedCart;
            localStorage.setItem('cart', JSON.stringify(updatedCart));
        },
        updateOrderLine(state, action) {
            const updatedOrderLine = action.payload;
            const updatedCart = {
                ...state.loggedInUserCart,
                orderLines: state.loggedInUserCart.orderLines.map((orderLine) =>
                    orderLine.id === updatedOrderLine.id ? updatedOrderLine : orderLine
                )
            };
            state.loggedInUserCart = {
                ...updatedCart,
                totalPrice: updatedCart.orderLines.reduce((total, orderLine) => total + orderLine.price, 0)
            };
            localStorage.setItem('cart', JSON.stringify(state.loggedInUserCart));
        },
        deleteOrderLine(state, action) {
            const orderLineId = action.payload;
            const updatedCart = state.loggedInUserCart.orderLines.filter((orderLine) =>
                orderLine.id !== orderLineId
            );
            state.loggedInUserCart = {
                ...state.loggedInUserCart,
                orderLines: updatedCart,
                totalPrice: updatedCart.reduce((total, orderLine) => total + orderLine.price, 0)
            };
            localStorage.setItem('cart', JSON.stringify(state.loggedInUserCart));
        },
        clearCart(state) {
            state.loggedInUserCart = null;
            localStorage.removeItem('cart');
        }
    },
    extraReducers: (builder) => {
        builder.addCase(resetState, () => nullState);
    }
});

export const { resetCartsState, getCartsStart, getCartsSuccess, getCartsFailure, setCartToEdit, updateCart, getCartStart, getCartSuccess, getCartFailure, updateLoggedInUserCart, deleteOrderLine, updateOrderLine, clearCart } =
    cartsSlice.actions;

export default cartsSlice.reducer;
