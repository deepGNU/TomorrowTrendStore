import { createSlice } from "@reduxjs/toolkit";
import { resetState } from "../shared-actions";

const initialState = {
    orders: [],
    loading: false,
    error: null,
    orderToEdit: null,
};

const ordersSlice = createSlice({
    name: "orders",
    initialState,
    reducers: {
        getOrdersStart(state) {
            state.loading = true;
        },
        getOrdersSuccess(state, action) {
            state.orders = action.payload;
            state.loading = false;
            state.error = null;
        },
        getOrdersFailure(state, action) {
            state.loading = false;
            state.error = action.payload;
        },
        setOrderToEdit(state, action) {
            state.orderToEdit = action.payload;
        },
        updateOrder(state, action) {
            const updatedOrder = action.payload;
            state.orders = state.orders.map((order) =>
                order.id === updatedOrder.id ? updatedOrder : order
            );
            state.orderToEdit = null;
        },
        deleteOrder(state, action) {
            const orderId = action.payload;
            state.orders = state.orders.filter((order) => order.id !== orderId);
        },
        addOrder(state, action) {
            const newOrder = action.payload;
            state.orders.push(newOrder);
        },
    },
    extraReducers: (builder) => {
        builder.addCase(resetState, () => initialState);
    }
});

export const { resetOrdersState, getOrdersStart, getOrdersSuccess, getOrdersFailure, setOrderToEdit, updateOrder, deleteOrder, addOrder } = ordersSlice.actions;

export default ordersSlice.reducer;