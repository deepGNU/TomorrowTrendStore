import api from "../e-store-api";
import { getOrdersStart, getOrdersSuccess, getOrdersFailure, deleteOrder, updateOrder, addOrder } from "../../features/orders/orders-slice";

export const getOrdersAPI = async (dispatch) => {
    try {
        dispatch(getOrdersStart());
        const result = await api.get("/Orders");
        dispatch(getOrdersSuccess(result.data));
    } catch (error) {
        dispatch(getOrdersFailure(error));
        console.error(error.message);
    }
}

export const getOrdersByUserIdAPI = async (userId) => {
    try {
        const response = await api.get(`/Orders/user/${userId}`);
        return response.data;
    } catch (error) {
        console.error(error.message);
    }
}

export const hasPurchasedAPI = async (productId) => {
    try {
        const response = await api.get(`/orders/haspurchased/${productId}`);
        return response.data;
    } catch (error) {
        console.error(error.message);
    }
}

export const getOrderByIdAPI = async (orderId) => {
    try {
        const response = await api.get(`/Orders/${orderId}`);
        return response.data;
    } catch (error) {
        console.error(error.message);
    }
}

export const deleteOrderAPI = async (dispatch, orderId) => {
    try {
        const response = await api.delete(`/Orders/${orderId}`);
        dispatch(deleteOrder(orderId));
        return response.data;
    } catch (error) {
        console.error(error.message);
    }
}

export const updateOrderAPI = async (dispatch, orderId, order) => {
    try {
        const response = await api.put(`/Orders/${orderId}`, order);
        dispatch(updateOrder(response.data));
    } catch (error) {
        console.error(error.message);
    }
}

export const createOrderAPI = async (dispatch, order) => {
    try {
        const response = await api.post("/Orders", order);
        dispatch(addOrder(response.data));
    } catch (error) {
        console.error(error.message);
    }
}